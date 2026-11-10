
﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SevenZip;

namespace _7ZipSharp
{
    public partial class extractF : Form
    {
        private Timer timer;
        private DateTime startTime;
        private string archivePath;
        private string password;
        private readonly string[] selectedArchiveEntries;
        private bool extractionStarted;
        private volatile bool extractionFinished;
        private bool startImmediately;
        private bool operationRunning;
        private volatile bool cancelRequested;
        private long totalOutputBytes;
        private long extractedOutputBytes;
        private int latestProgress;

        public extractF() : this(null, null, null) { }

        public extractF(string arch) : this(arch, null, null) { }

        public extractF(string arch, string outputDirectory) : this(arch, outputDirectory, null) { }

        public extractF(string arch, string outputDirectory, IEnumerable<string> entriesToExtract)
            : this(arch, outputDirectory, entriesToExtract, !string.IsNullOrWhiteSpace(outputDirectory))
        {
        }

        public extractF(string arch, string outputDirectory, IEnumerable<string> entriesToExtract, bool autoStart)
        {
            InitializeComponent();
            selectedArchiveEntries = (entriesToExtract ?? Enumerable.Empty<string>())
                .Select(NormalizeArchivePath)
                .Where(entry => !string.IsNullOrWhiteSpace(entry))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            FormClosed += extractF_FormClosed;
            Shown += extractF_Shown;
            FormClosing += extractF_FormClosing;
            Text = "Extractor | SharpCompress " + Application.ProductVersion.ToString();
            int rememberedConflict = _7ZipSharp.Properties.Settings.Default.ConflictPolicy;
            cmbConflict.SelectedIndex = rememberedConflict >= 0 && rememberedConflict < cmbConflict.Items.Count
                ? rememberedConflict : 0;
            Localization.Apply(this);
            ProductUi.Apply(this);

            if (string.IsNullOrWhiteSpace(arch) || !File.Exists(arch))
                return;

            archivePath = Path.GetFullPath(arch);
            txtFile.Text = archivePath;
            txtSave.Text = string.IsNullOrWhiteSpace(outputDirectory)
                ? Path.Combine(Path.GetDirectoryName(archivePath), Path.GetFileNameWithoutExtension(archivePath))
                : Path.GetFullPath(outputDirectory);
            lblSalidaFile.Text = selectedArchiveEntries.Length == 0
                ? "Se extraerá el archivo completo."
                : string.Format("Se extraerán {0} elemento(s) seleccionados.", selectedArchiveEntries.Length);
            lblSalidaFile.Text = Localization.TranslateText(lblSalidaFile.Text);
            startImmediately = autoStart;

            // Inicializa el Timer
            timer = new Timer();
            timer.Interval = 1000; // Intervalo en milisegundos (1 segundo)
            timer.Tick += Timer_Tick;

        }

        private async void extractF_Shown(object sender, EventArgs e)
        {
            if (startImmediately)
                await StartExtractionAsync();
            else
                lblStatusExtract.Text = Localization.TranslateText("Listo para extraer.");
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            await StartExtractionAsync();
        }

        private async Task StartExtractionAsync()
        {
            if (extractionStarted || string.IsNullOrWhiteSpace(archivePath)) return;
            string destination = txtSave.Text.Trim();
            if (string.IsNullOrWhiteSpace(destination))
            {
                _7ZipSharp.Msg.AppMessage.Show(this, "Selecciona una carpeta de destino.", "SharpCompress",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            extractionStarted = true;
            operationRunning = true;
            cancelRequested = false;
            totalOutputBytes = 0;
            extractedOutputBytes = 0;
            latestProgress = 0;
            btnBrowse.Enabled = false;
            cmbConflict.Enabled = false;
            btnStart.Enabled = false;
            btnCComprimir.Enabled = false;
            button1.Enabled = true;
            int conflictPolicy = cmbConflict.SelectedIndex;
            bool closeAfterSuccess = false;
            var extractionErrors = new ConcurrentQueue<string>();
            int[] skippedExistingFiles = { 0 };
            int[] cancelledByConflict = { 0 };
            int[] replaceAllExistingFiles = { 0 };
            try
            {
                prgExtract.Style = ProgressBarStyle.Marquee;
                lblStatusExtract.Text = Localization.TranslateText("Analizando archivo…");
                startTime = DateTime.Now;
                timer.Start();
                prgExtract.Refresh();
                SevenZipCompressor.SetLibraryPath(Path.Combine(Application.StartupPath,
                    Environment.Is64BitProcess ? "7z64.dll" : "7z.dll"));

                bool protegido = await Task.Run(() => EsArchivoProtegido(archivePath));
                if (protegido)
                {
                    using (var formContraseña = new formContraseña())
                    {
                        if (formContraseña.ShowDialog() == DialogResult.OK)
                            password = formContraseña.ContraseñaIngresada;
                        else
                        {
                            operationRunning = false;
                            timer.Stop();
                            btnBrowse.Enabled = true;
                            cmbConflict.Enabled = true;
                            btnStart.Enabled = true;
                            btnCComprimir.Enabled = true;
                            Close();
                            return;
                        }
                    }
                }

                startTime = DateTime.Now;
                timer.Start();
                prgExtract.Value = 0;
                lblStatusExtract.Text = Localization.TranslateText("Preparando extracción…");
                prgExtract.Refresh();
                await Task.Run(() =>
                {
                    Directory.CreateDirectory(destination);
                    using (var extractor = new SevenZipExtractor(archivePath, password))
                    {
                        int extractedFiles = 0;
                        int totalFiles = (int)extractor.FilesCount;
                        var selectedIndexes = selectedArchiveEntries.Length == 0
                            ? null
                            : GetSelectedIndexes(extractor, selectedArchiveEntries);
                        totalOutputBytes = extractor.ArchiveFileData
                            .Where(entry => !entry.IsDirectory && (selectedIndexes == null || selectedIndexes.Contains(entry.Index)))
                            .Sum(entry => entry.Size > long.MaxValue ? long.MaxValue : (long)entry.Size);
                        extractor.FileExtractionStarted += (s, args) =>
                        {
                            if (cancelRequested)
                            {
                                args.Cancel = true;
                                return;
                            }
                            int current = ++extractedFiles;
                            string entryName = args.FileInfo.FileName.Replace('/', '\\');
                            UpdateStatusLabel("Extrayendo archivo " + current + " de " + totalFiles + ": " + Path.GetFileName(entryName));
                        };
                        extractor.Extracting += (s, args) =>
                        {
                            int progress = Math.Max(0, Math.Min(100, (int)args.PercentDone));
                            latestProgress = progress;
                            UpdateProgressBar(progress);
                            UpdateStatusLabel("Extrayendo… " + progress + "%");
                            UpdateOperationMetrics(progress, DateTime.Now - startTime);
                        };
                        extractor.FileExtractionFinished += (s, args) =>
                            System.Threading.Interlocked.Add(ref extractedOutputBytes,
                                args.FileInfo.Size > long.MaxValue ? long.MaxValue : (long)args.FileInfo.Size);
                        extractor.FileExists += (s, args) =>
                            ResolveExistingFile(args, conflictPolicy, skippedExistingFiles, cancelledByConflict, replaceAllExistingFiles);
                        extractor.FileExtractionFailed += (s, args) =>
                        {
                            string failedPath = string.IsNullOrWhiteSpace(args.FileName) ? "Elemento desconocido" : args.FileName;
                            extractionErrors.Enqueue(failedPath + " — " + args.ErrorMessage);
                            UpdateStatusLabel("Error al extraer: " + Path.GetFileName(failedPath.Replace('/', '\\')));
                        };
                        if (selectedArchiveEntries.Length == 0)
                        {
                            extractor.ExtractArchive(destination);
                        }
                        else
                        {
                            int[] indexes = selectedIndexes;
                            if (indexes.Length == 0)
                                throw new InvalidDataException("No se encontraron los elementos seleccionados dentro del archivo.");
                            extractor.ExtractFiles(destination, indexes);
                        }
                    }
                });

                extractionFinished = true;
                prgExtract.Style = ProgressBarStyle.Continuous;
                if (!cancelRequested) prgExtract.Value = 100;
                string[] errors = extractionErrors.ToArray();
                lblStatusExtract.Text = Localization.TranslateText(cancelRequested
                    ? "Extracción cancelada entre elementos."
                    : cancelledByConflict[0] > 0
                    ? "Extracción cancelada por conflicto."
                    : errors.Length == 0
                    ? "Extracción completada."
                    : string.Format("Finalizada con {0} elemento(s) con error.", errors.Length));
                if (skippedExistingFiles[0] > 0)
                    lblStatusExtract.Text += string.Format(" Omitidos: {0}.", skippedExistingFiles[0]);
                if (errors.Length > 0) ShowExtractionErrors(errors);
                if (errors.Length == 0 && !cancelRequested && cancelledByConflict[0] == 0)
                {
                    closeAfterSuccess = true;
                    try
                    {
                        _7ZipSharp.Properties.Settings.Default.LastExtractDirectory = destination;
                        _7ZipSharp.Properties.Settings.Default.Save();
                    }
                    catch (Exception ex) { ErrorLogger.Write(ex, "Saving extraction destination preference"); }
                }
                if (!cancelRequested && cancelledByConflict[0] == 0 && errors.Length == 0)
                    lblTiempo.Text = string.Format("{0} extraídos · {1} · Media {2}/s",
                        FormatSize(extractedOutputBytes), (DateTime.Now - startTime).ToString(@"hh\:mm\:ss"),
                        FormatSize(extractedOutputBytes / Math.Max(0.5, (DateTime.Now - startTime).TotalSeconds)));
                else if (!cancelRequested && cancelledByConflict[0] == 0)
                    lblTiempo.Text = string.Format("{0} · {1} error(es) · {2}",
                        FormatSize(extractedOutputBytes), errors.Length,
                        (DateTime.Now - startTime).ToString(@"hh\:mm\:ss"));
                else if (cancelRequested)
                    lblTiempo.Text = string.Format("Detenida tras {0}   ·   Datos completados: {1}",
                        (DateTime.Now - startTime).ToString(@"hh\:mm\:ss"), FormatSize(extractedOutputBytes));
            }
            catch (Exception ex)
            {
                extractionFinished = true;
                string[] errors = extractionErrors.ToArray();
                lblStatusExtract.Text = Localization.TranslateText(cancelRequested
                    ? "Extracción cancelada entre elementos."
                    : cancelledByConflict[0] > 0
                    ? "Extracción cancelada por conflicto."
                    : errors.Length == 0
                    ? "La extracción no se completó."
                    : string.Format("Finalizada con {0} elemento(s) con error.", errors.Length));
                if (skippedExistingFiles[0] > 0)
                    lblStatusExtract.Text += string.Format(" Omitidos: {0}.", skippedExistingFiles[0]);
                if (cancelRequested || cancelledByConflict[0] > 0)
                {
                    lblTiempo.Text = "Detenida tras " + (DateTime.Now - startTime).ToString(@"hh\:mm\:ss") +
                        "   ·   Datos completados: " + FormatSize(extractedOutputBytes);
                }
                else if (errors.Length > 0)
                    ShowExtractionErrors(errors);
                else
                {
                    ErrorLogger.Write(ex, "Archive extraction");
                    _7ZipSharp.Msg.AppMessage.Show(this, "Ocurrió un error durante la extracción: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                operationRunning = false;
                timer.Stop();
                btnBrowse.Enabled = true;
                cmbConflict.Enabled = true;
                btnStart.Enabled = false;
                btnCComprimir.Enabled = true;
                btnCComprimir.Text = "Cerrar";
                button1.Enabled = false;
                if (closeAfterSuccess)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void ResolveExistingFile(FileOverwriteEventArgs args, int policy,
            int[] skippedExistingFiles, int[] cancelledByConflict, int[] replaceAllExistingFiles)
        {
            if (policy == 1 || System.Threading.Volatile.Read(ref replaceAllExistingFiles[0]) != 0) return;
            if (policy == 2)
            {
                args.FileName = null;
                System.Threading.Interlocked.Increment(ref skippedExistingFiles[0]);
                return;
            }
            if (policy == 3)
            {
                args.FileName = GetUniqueFilePath(args.FileName);
                return;
            }

            if (!Visible)
            {
                args.FileName = null;
                System.Threading.Interlocked.Increment(ref skippedExistingFiles[0]);
                return;
            }

            try
            {
                _7ZipSharp.Msg.OverwriteChoice answer = (_7ZipSharp.Msg.OverwriteChoice)Invoke(
                    new Func<_7ZipSharp.Msg.OverwriteChoice>(() =>
                        _7ZipSharp.Msg.AppMessage.ConfirmOverwrite(this, args.FileName)));
                if (answer == _7ZipSharp.Msg.OverwriteChoice.ReplaceAll)
                {
                    System.Threading.Interlocked.Exchange(ref replaceAllExistingFiles[0], 1);
                }
                else if (answer == _7ZipSharp.Msg.OverwriteChoice.Skip)
                {
                    args.FileName = null;
                    System.Threading.Interlocked.Increment(ref skippedExistingFiles[0]);
                }
                else if (answer == _7ZipSharp.Msg.OverwriteChoice.Cancel)
                {
                    System.Threading.Interlocked.Increment(ref cancelledByConflict[0]);
                    args.Cancel = true;
                }
            }
            catch (InvalidOperationException)
            {
                args.FileName = null;
                System.Threading.Interlocked.Increment(ref skippedExistingFiles[0]);
            }
        }

        private static string GetUniqueFilePath(string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            string name = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);
            string candidate;
            int suffix = 2;
            do
            {
                candidate = Path.Combine(directory, name + " (" + suffix++ + ")" + extension);
            }
            while (File.Exists(candidate) || Directory.Exists(candidate));
            return candidate;
        }

        private void ShowExtractionErrors(string[] errors)
        {
            const int maxVisibleErrors = 20;
            string details = string.Join(Environment.NewLine, errors.Take(maxVisibleErrors));
            if (errors.Length > maxVisibleErrors)
                details += Environment.NewLine + string.Format("… y {0} error(es) más.", errors.Length - maxVisibleErrors);
            _7ZipSharp.Msg.AppMessage.Show(this,
                string.Format("La extracción continuó hasta el final, pero {0} elemento(s) no se pudieron extraer:{1}{1}{2}",
                    errors.Length, Environment.NewLine, details),
                "Extracción con errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string rememberedDirectory = _7ZipSharp.Properties.Settings.Default.LastExtractDirectory;
            if (Directory.Exists(rememberedDirectory)) selectFolderDialog.SelectedPath = rememberedDirectory;
            if (Directory.Exists(txtSave.Text)) selectFolderDialog.SelectedPath = txtSave.Text;
            if (selectFolderDialog.ShowDialog(this) != DialogResult.OK) return;
            txtSave.Text = Path.GetFullPath(selectFolderDialog.SelectedPath);
            try
            {
                _7ZipSharp.Properties.Settings.Default.LastExtractDirectory = txtSave.Text;
                _7ZipSharp.Properties.Settings.Default.Save();
            }
            catch (Exception ex) { ErrorLogger.Write(ex, "Saving extraction destination preference"); }
        }

        private void extractF_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _7ZipSharp.Properties.Settings.Default.ConflictPolicy = cmbConflict.SelectedIndex;
                _7ZipSharp.Properties.Settings.Default.Save();
            }
            catch (Exception ex) { ErrorLogger.Write(ex, "Saving extraction preferences"); }
        }

        private void extractF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (operationRunning)
            {
                e.Cancel = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private bool EsArchivoProtegido(string archivo)
        {
            try
            {
                // Inspect archive headers only; Check() decompresses the whole payload
                // and would double the work before an extraction even begins.
                using (var extractor = new SevenZipExtractor(archivo))
                    return extractor.ArchiveFileData.Any(entry => entry.Encrypted);
            }
            catch
            {
                // Encrypted headers can require the password just to read the file table.
                return true;
            }
        }

        private static int[] GetSelectedIndexes(SevenZipExtractor extractor, IEnumerable<string> selectedPaths)
        {
            string[] selections = selectedPaths.Select(NormalizeArchivePath).ToArray();
            return extractor.ArchiveFileData
                .Where(entry => selections.Any(selected =>
                    string.Equals(NormalizeArchivePath(entry.FileName), selected, StringComparison.OrdinalIgnoreCase) ||
                    NormalizeArchivePath(entry.FileName).StartsWith(selected + "/", StringComparison.OrdinalIgnoreCase)))
                .Select(entry => entry.Index)
                .Distinct()
                .ToArray();
        }

        private static string NormalizeArchivePath(string path)
        {
            string normalized = (path ?? string.Empty).Replace('\\', '/').Trim('/');
            while (normalized.StartsWith("./", StringComparison.Ordinal))
                normalized = normalized.Substring(2);
            return normalized;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            UpdateOperationMetrics(latestProgress, elapsed);
        }

        private void UpdateOperationMetrics(int progress, TimeSpan elapsed)
        {
            if (lblTiempo.InvokeRequired)
            {
                try { lblTiempo.BeginInvoke(new Action(() => UpdateOperationMetrics(progress, elapsed))); }
                catch (InvalidOperationException) { }
                return;
            }
            if (lblTiempo.IsDisposed) return;
            if (totalOutputBytes <= 0 || elapsed.TotalSeconds < 0.5)
            {
                lblTiempo.Text = elapsed.ToString(@"hh\:mm\:ss") + " · Calculando velocidad y ETA…";
                return;
            }
            double completedBytes = totalOutputBytes * Math.Max(0, Math.Min(100, progress)) / 100.0;
            double bytesPerSecond = completedBytes / Math.Max(0.5, elapsed.TotalSeconds);
            TimeSpan remaining = bytesPerSecond > 0
                ? TimeSpan.FromSeconds((totalOutputBytes - completedBytes) / bytesPerSecond)
                : TimeSpan.Zero;
            lblTiempo.Text = string.Format("{0} · {1}/s · ETA {2}",
                elapsed.ToString(@"hh\:mm\:ss"), FormatSize(bytesPerSecond),
                progress >= 100 ? "Finalizando…" : remaining.ToString(@"hh\:mm\:ss"));
        }

        private static string FormatSize(double bytes)
        {
            string[] units = { "B", "KB", "MB", "GB", "TB" };
            int unit = 0;
            while (bytes >= 1024 && unit < units.Length - 1) { bytes /= 1024; unit++; }
            return bytes.ToString(unit == 0 ? "0" : "0.0", System.Globalization.CultureInfo.CurrentCulture) + " " + units[unit];
        }
        private void extractF_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            using (var aboutWindow = new about()) aboutWindow.ShowDialog(this);
        }

        private void UpdateProgressBar(int value)
        {
            if (extractionFinished) return;
            if (prgExtract.IsDisposed || !prgExtract.IsHandleCreated) return;
            if (prgExtract.InvokeRequired)
            {
                try { prgExtract.BeginInvoke(new Action(() =>
                {
                    if (extractionFinished || prgExtract.IsDisposed) return;
                    prgExtract.Style = ProgressBarStyle.Continuous;
                    prgExtract.Value = Math.Max(prgExtract.Minimum, Math.Min(prgExtract.Maximum, value));
                })); }
                catch (InvalidOperationException) { }
            }
            else
            {
                prgExtract.Style = ProgressBarStyle.Continuous;
                prgExtract.Value = Math.Max(prgExtract.Minimum, Math.Min(prgExtract.Maximum, value));
            }
        }

        private void UpdateStatusLabel(string text)
        {
            text = Localization.TranslateText(text);
            if (extractionFinished) return;
            if (lblStatusExtract.IsDisposed || !lblStatusExtract.IsHandleCreated) return;
            if (lblStatusExtract.InvokeRequired)
            {
                try { lblStatusExtract.BeginInvoke(new Action(() =>
                {
                    if (!extractionFinished && !lblStatusExtract.IsDisposed) lblStatusExtract.Text = text;
                })); }
                catch (InvalidOperationException) { }
            }
            else lblStatusExtract.Text = text;
        }

        private void btnCComprimir_Click(object sender, EventArgs e)
        {
            if (operationRunning)
            {
                cancelRequested = true;
                btnCComprimir.Enabled = false;
                lblStatusExtract.Text = Localization.TranslateText("Cancelando… se detendrá al terminar el elemento actual.");
                return;
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Extraer (SharpCompress)";
            notifyIcon1.BalloonTipText = "SharpCompress esta extrayendo en segundo plano\nHaga doble clic en el icono para volver a SharpCompress";
            notifyIcon1.ShowBalloonTip(30000);
            Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Show();
        }
    }
}
