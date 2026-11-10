using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _7ZipSharp
{
    internal partial class SfxOptionsForm : Form
    {
        internal SelfExtractorOptions Options { get; private set; }

        internal SfxOptionsForm(SelfExtractorOptions options, IEnumerable<string> executableCandidates = null)
        {
            InitializeComponent();
            Options = options ?? SelfExtractorOptions.FromUserSettings();
            txtTitle.Text = Options.Title;
            txtInstallPath.Text = Options.InstallPath;
            txtBeginPrompt.Text = Options.BeginPrompt;
            foreach (string candidate in (executableCandidates ?? Enumerable.Empty<string>()).Distinct(StringComparer.OrdinalIgnoreCase))
                cmbRunProgram.Items.Add(candidate);
            cmbRunProgram.Text = Options.RunProgram;
            txtIconPath.Text = Options.IconPath ?? string.Empty;
            chkShowProgress.Checked = Options.ShowProgress;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            Localization.Apply(this);
            ProductUi.Apply(this);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                _7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText("Escribe un título para el autoextractor."),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInstallPath.Text))
            {
                _7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText("Indica una carpeta de destino o usa . para la carpeta actual."),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInstallPath.Focus();
                return;
            }

            if (Path.IsPathRooted(txtInstallPath.Text) && !Directory.Exists(txtInstallPath.Text))
            {
                _7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText("La carpeta de extracción seleccionada ya no existe."),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInstallPath.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtIconPath.Text))
            {
                if (!File.Exists(txtIconPath.Text))
                {
                    _7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText("No se encontró el icono SFX seleccionado."),
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIconPath.Focus();
                    return;
                }
                try { using (var icon = new System.Drawing.Icon(txtIconPath.Text)) { } }
                catch (Exception ex) when (ex is ArgumentException || ex is IOException)
                {
                    _7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText("Selecciona un archivo ICO válido."),
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIconPath.Focus();
                    return;
                }
            }

            if (HasUnsupportedConfigCharacters(txtTitle.Text) || HasUnsupportedConfigCharacters(txtInstallPath.Text) ||
                HasUnsupportedConfigCharacters(txtBeginPrompt.Text) || HasUnsupportedConfigCharacters(cmbRunProgram.Text))
            {
                _7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText("Los campos no pueden contener saltos de línea."),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Options = new SelfExtractorOptions
            {
                Title = txtTitle.Text.Trim(),
                InstallPath = txtInstallPath.Text.Trim(),
                BeginPrompt = txtBeginPrompt.Text.Trim(),
                RunProgram = cmbRunProgram.Text.Trim(),
                IconPath = txtIconPath.Text.Trim(),
                ShowProgress = chkShowProgress.Checked
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnBrowseInstallPath_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog
            {
                Description = Localization.TranslateText("Selecciona la carpeta donde se extraerá el contenido."),
                ShowNewFolderButton = true
            })
            {
                if (Directory.Exists(txtInstallPath.Text)) dialog.SelectedPath = txtInstallPath.Text;
                if (dialog.ShowDialog(this) == DialogResult.OK) txtInstallPath.Text = dialog.SelectedPath;
            }
        }

        private void btnBrowseIcon_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = "Iconos de Windows (*.ico)|*.ico",
                CheckFileExists = true,
                Multiselect = false,
                Title = Localization.TranslateText("Seleccionar icono para el autoextractor")
            })
            {
                if (File.Exists(txtIconPath.Text)) dialog.FileName = txtIconPath.Text;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        using (var icon = new System.Drawing.Icon(dialog.FileName)) { }
                        txtIconPath.Text = dialog.FileName;
                    }
                    catch (ArgumentException)
                    {
                        _7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText("Selecciona un archivo ICO válido."), Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnClearIcon_Click(object sender, EventArgs e) { txtIconPath.Clear(); }

        private static bool HasUnsupportedConfigCharacters(string value)
        {
            return value.IndexOf('\r') >= 0 || value.IndexOf('\n') >= 0;
        }
    }
}
