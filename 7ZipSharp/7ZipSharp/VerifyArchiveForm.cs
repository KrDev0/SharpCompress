using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SevenZip;

namespace _7ZipSharp
{
    public partial class VerifyArchiveForm : Form
    {
        private readonly string archivePath;
        private readonly Dictionary<string, ListViewItem> resultRows = new Dictionary<string, ListViewItem>(StringComparer.OrdinalIgnoreCase);
        private bool operationRunning;

        public VerifyArchiveForm(string path)
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            archivePath = path;
            Text = "Verificar archivo — SharpCompress";
            lblArchive.Text = Path.GetFileName(path);
            Localization.Apply(this);
            ProductUi.Apply(this);
            Shown += VerifyArchiveForm_Shown;
            FormClosing += VerifyArchiveForm_FormClosing;
        }

        private async void VerifyArchiveForm_Shown(object sender, EventArgs e)
        {
            operationRunning = true;
            btnClose.Enabled = false;
            lblStatus.Text = Localization.TranslateText("Preparando la verificación…");
            progressBar.Style = ProgressBarStyle.Marquee;
            SevenZipCompressor.SetLibraryPath(Path.Combine(Application.StartupPath,
                Environment.Is64BitProcess ? "7z64.dll" : "7z.dll"));

            string password = null;
            bool protectedArchive = await Task.Run(IsPasswordProtected);
            if (protectedArchive)
            {
                using (var passwordDialog = new formContraseña())
                {
                    if (passwordDialog.ShowDialog(this) != DialogResult.OK)
                    {
                        Finish(Localization.TranslateText("Verificación cancelada."), false);
                        return;
                    }
                    password = passwordDialog.ContraseñaIngresada;
                }
            }

            bool valid = false;
            string failure = null;
            try
            {
                lblStatus.Text = Localization.TranslateText("Leyendo y comprobando los datos del archivo…");
                progressBar.Style = ProgressBarStyle.Continuous;
                using (var extractor = new SevenZipExtractor(archivePath, password))
                {
                    extractor.Extracting += (s, args) => SetProgress(args.PercentDone);
                    extractor.FileExtractionFinished += (s, args) =>
                        SetResult(args.FileInfo.FileName, Localization.TranslateText("Correcto"), Localization.TranslateText("Datos descomprimidos y verificados."), Color.FromArgb(28, 125, 72));
                    extractor.FileExtractionFailed += (s, args) =>
                        SetResult(args.FileName, Localization.TranslateText("Error"), args.ErrorMessage, Color.FromArgb(190, 55, 48));
                    valid = await Task.Run(() => extractor.Check());
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex, "Archive integrity verification");
                failure = ex.Message;
            }

            if (!valid && listResults.Items.Count == 0)
                SetResult(Path.GetFileName(archivePath), Localization.TranslateText("Error"), failure ?? Localization.TranslateText("No se pudo completar la verificación. Comprueba el archivo y la contraseña."), Color.FromArgb(190, 55, 48));

            int failedCount = listResults.Items.Cast<ListViewItem>().Count(item => item.SubItems[1].Text == Localization.TranslateText("Error"));
            int passedCount = listResults.Items.Count - failedCount;
            string summary = Localization.IsEnglish
                ? (valid && failedCount == 0
                    ? string.Format("Verification complete: {0} item(s) passed.", passedCount)
                    : string.Format("Verification complete with errors: {0} passed, {1} failed.", passedCount, failedCount))
                : (valid && failedCount == 0
                    ? string.Format("Verificación completada: {0} elemento(s) correctos.", passedCount)
                    : string.Format("Verificación completada con errores: {0} correcto(s), {1} con error.", passedCount, failedCount));
            Finish(summary, true);
        }

        private bool IsPasswordProtected()
        {
            try
            {
                using (var extractor = new SevenZipExtractor(archivePath))
                    return extractor.ArchiveFileData.Any(entry => entry.Encrypted);
            }
            catch
            {
                return true;
            }
        }

        private void SetResult(string name, string state, string detail, Color stateColor)
        {
            if (IsDisposed || !IsHandleCreated) return;
            if (InvokeRequired)
            {
                try { Invoke(new Action(() => SetResult(name, state, detail, stateColor))); }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                return;
            }

            string key = name ?? Localization.TranslateText("Elemento desconocido");
            ListViewItem row;
            if (!resultRows.TryGetValue(key, out row))
            {
                row = new ListViewItem(key);
                row.SubItems.Add(string.Empty);
                row.SubItems.Add(string.Empty);
                resultRows.Add(key, row);
                listResults.Items.Add(row);
            }
            row.SubItems[1].Text = state;
            row.SubItems[1].ForeColor = stateColor;
            row.SubItems[2].Text = detail ?? string.Empty;
        }

        private void SetProgress(int value)
        {
            if (IsDisposed || !IsHandleCreated) return;
            if (InvokeRequired)
            {
                try { BeginInvoke(new Action(() => SetProgress(value))); }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                return;
            }
            progressBar.Value = Math.Max(progressBar.Minimum, Math.Min(progressBar.Maximum, value));
            lblStatus.Text = Localization.TranslateText("Verificando… ") + progressBar.Value + "%";
        }

        private void Finish(string message, bool completed)
        {
            operationRunning = false;
            progressBar.Style = ProgressBarStyle.Continuous;
            if (completed) progressBar.Value = 100;
            lblStatus.Text = message;
            btnClose.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!operationRunning) Close();
        }

        private void VerifyArchiveForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (operationRunning) e.Cancel = true;
        }
    }
}
