
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _7ZipSharp.Msg;
using SevenZip;

namespace _7ZipSharp
{
    public partial class CompressForm : Form
    {
        string FileName;
        string fileEx;
        private bool outputChosenByUser;
        Compress com = new Compress();
        private System.Windows.Forms.Timer timer;
        private DateTime startTime;
        private volatile bool operationFinished;
        private volatile bool cancelRequested;
        private bool operationRunning;
        private bool rootDirectoryChoiceTouched;
        private bool updatingRootDirectoryChoice;
        private long totalInputBytes;
        private int latestProgress;
        private bool updatingCompressionOptions;
        private SelfExtractorOptions selfExtractorOptions;

        public CompressForm() : this((IEnumerable<string>)null, null) { }

        public CompressForm(string file, string type)
            : this(string.IsNullOrWhiteSpace(file) ? null : new[] { file }, type)
        {
        }

        public CompressForm(IEnumerable<string> files, string type)
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            chkRootDir.CheckedChanged += (sender, args) =>
            {
                if (!updatingRootDirectoryChoice)
                    rootDirectoryChoiceTouched = true;
            };

            FormClosed += CompressForm_FormClosed;

            cmbFormato.SelectedIndex = 2;
            cmbNivel.SelectedIndex = 3;
            cmbMetodo.SelectedIndex = 0;
            cmbEncrip.SelectedIndex = 0;
            cmbVolumen.SelectedIndex = 0;
            selfExtractorOptions = SelfExtractorOptions.FromUserSettings();

            // Configuración del ListView
            listViewArchivos.View = View.Details;
            listViewArchivos.Columns.Add("Nombre", 170);
            listViewArchivos.Columns.Add("Tamaño", 86);
            listViewArchivos.Columns.Add("Modificado", 128);
            listViewArchivos.Columns.Add("Ubicación", 204);

            string[] inputFiles = (files ?? Enumerable.Empty<string>())
                .Where(path => System.IO.File.Exists(path) || Directory.Exists(path))
                .Select(Path.GetFullPath)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            foreach (string inputFile in inputFiles)
                AgregarRutaAlListView(inputFile);

            byFileType(type, inputFiles);
            if (string.IsNullOrWhiteSpace(type))
            {
                int rememberedFormat = _7ZipSharp.Properties.Settings.Default.LastArchiveFormat;
                if (rememberedFormat >= 0 && rememberedFormat < cmbFormato.Items.Count)
                {
                    cmbFormato.SelectedIndex = rememberedFormat;
                    fileEx = "." + com.getFileType(this);
                    ActualizarNombrePredeterminado(inputFiles);
                }
            }
            int rememberedProfile = _7ZipSharp.Properties.Settings.Default.CompressionProfile;
            cmbPerfil.SelectedIndex = rememberedProfile >= 0 && rememberedProfile < cmbPerfil.Items.Count ? rememberedProfile : 0;
            ApplyCompressionProfile();
            UpdateCompressionDescription();
            chkCreateSfx.Checked = _7ZipSharp.Properties.Settings.Default.CreateSelfExtracting && com.IsSevenZipFormat(this);
            chkCreateSfx_CheckedChanged(chkCreateSfx, EventArgs.Empty);
            btnComprimir.Enabled = inputFiles.Length > 0;
            Localization.Apply(this);
            ProductUi.Apply(this);
            cmbPerfil.SelectedIndex = rememberedProfile >= 0 && rememberedProfile < cmbPerfil.Items.Count
                ? rememberedProfile : 0;
            ApplyCompressionProfile();
            UpdateCompressionDescription();

            // Inicializa el Timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Intervalo en milisegundos (1 segundo)
            timer.Tick += Timer_Tick;
        }

        private void byFileType(string type, string[] paths)
        {
            if (type == "/fScz" || type == "/comScz")
            {
                Text = "Comprimir como SCZ | SharpCompress " + Application.ProductVersion;
                cmbFormato.SelectedIndex = 4;
            }
            else if (type == "/f7z" || type == "/com7z")
            {
                Text = "Comprimir a 7Zip | SharpCompress " + Application.ProductVersion.ToString();
                cmbFormato.SelectedIndex = 0;
            }
            else if (type == "/fTar" || type == "/comTar")
            {
                Text = "Comprimir a Tar | SharpCompress " + Application.ProductVersion.ToString();
                cmbFormato.SelectedIndex = 1;
            }
            else if (type == "/fZip" || type == "/comZip")
            {
                Text = "Comprimir a Zip | SharpCompress " + Application.ProductVersion.ToString();
                cmbFormato.SelectedIndex = 2;
            }
            else if (type == "/fGz" || type == "/comGz")
            {
                Text = "Comprimir a GZ | SharpCompress " + Application.ProductVersion.ToString();
                cmbFormato.SelectedIndex = 3;
            }
            else
                Text = "Comprimir | SharpCompress " + Application.ProductVersion.ToString();

            fileEx = "." + com.getFileType(this);
            ActualizarNombrePredeterminado(paths);
        }

        private void ActualizarNombrePredeterminado(IEnumerable<string> selectedPaths)
        {
            string[] paths = (selectedPaths ?? Enumerable.Empty<string>())
                .Where(path => File.Exists(path) || Directory.Exists(path))
                .Select(Path.GetFullPath)
                .Where(path => !string.IsNullOrEmpty(path))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            string[] parents = paths.Select(path =>
            {
                string normalized = path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                return Path.GetDirectoryName(normalized) ?? Path.GetPathRoot(normalized);
            }).ToArray();
            string outputDirectory = parents.Length == 0
                ? Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                : ObtenerDirectorioComun(parents);
            string archiveBaseName;
            if (paths.Length == 1)
            {
                string singlePath = paths[0].TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                archiveBaseName = Directory.Exists(paths[0])
                    ? Path.GetFileName(singlePath)
                    : Path.GetFileNameWithoutExtension(singlePath);
            }
            else
            {
                archiveBaseName = Path.GetFileName(outputDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
            }

            if (string.IsNullOrWhiteSpace(archiveBaseName))
            {
                string driveName = Path.GetPathRoot(outputDirectory).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Replace(":", "");
                archiveBaseName = string.IsNullOrEmpty(driveName) ? "Archivos" : "Unidad_" + driveName;
            }

            FileName = archiveBaseName;
            txtSave.Text = Path.Combine(outputDirectory, FileName + fileEx);
            lblSalidaFile.Text = Localization.TranslateText("Nombre del archivo: " + FileName + fileEx);
        }

        private static string ObtenerDirectorioComun(string[] directories)
        {
            string common = Path.GetFullPath(directories[0]);
            foreach (string directory in directories.Skip(1))
            {
                string candidate = Path.GetFullPath(directory);
                while (!EsDirectorioComun(candidate, common))
                {
                    string trimmed = common.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                    string parent = Path.GetDirectoryName(trimmed);
                    if (string.IsNullOrEmpty(parent))
                    {
                        common = Path.GetPathRoot(common);
                        break;
                    }
                    common = parent;
                }
            }
            return common;
        }

        private static bool EsDirectorioComun(string path, string parent)
        {
            string normalizedParent = parent.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            if (path.Equals(normalizedParent, StringComparison.OrdinalIgnoreCase)) return true;
            string prefix = normalizedParent + Path.DirectorySeparatorChar;
            return path.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
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
            if (totalInputBytes <= 0 || elapsed.TotalSeconds < 0.5)
            {
                lblTiempo.Text = elapsed.ToString(@"hh\:mm\:ss") + " · Calculando velocidad y ETA…";
                return;
            }

            double processedBytes = totalInputBytes * Math.Max(0, Math.Min(100, progress)) / 100.0;
            double bytesPerSecond = processedBytes / Math.Max(0.5, elapsed.TotalSeconds);
            TimeSpan remaining = bytesPerSecond > 0
                ? TimeSpan.FromSeconds((totalInputBytes - processedBytes) / bytesPerSecond)
                : TimeSpan.Zero;
            lblTiempo.Text = string.Format("{0} · {1}/s · ETA {2}",
                elapsed.ToString(@"hh\:mm\:ss"), FormatSize(bytesPerSecond), progress >= 100 ? "…" : remaining.ToString(@"hh\:mm\:ss"));
        }

        private static string FormatSize(double bytes)
        {
            string[] units = { "B", "KB", "MB", "GB", "TB" };
            int unit = 0;
            while (bytes >= 1024 && unit < units.Length - 1) { bytes /= 1024; unit++; }
            return bytes.ToString(unit == 0 ? "0" : "0.0", CultureInfo.CurrentCulture) + " " + units[unit];
        }

        private string contrasena = string.Empty;
        private async void btnComprimir_Click(object sender, EventArgs e)
        {
            string stagedOutputPath = null;
            string stagedArchivePath = null;
            bool closeAfterSuccess = false;
            operationFinished = false;
            contrasena = string.Empty;
            bool createSelfExtractor = chkCreateSfx.Checked;
            if (chkPass.Checked)
            {
                if (string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtConfirPass.Text))
                {
                    _7ZipSharp.Msg.AppMessage.Show("Escribe y confirma la contraseña.", "Contraseña requerida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPass.Focus();
                    return;
                }
                if (!string.Equals(txtPass.Text, txtConfirPass.Text, StringComparison.Ordinal))
                {
                    _7ZipSharp.Msg.AppMessage.Show("Las contraseñas no coinciden.", "Revisa la contraseña",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirPass.Focus();
                    return;
                }
                contrasena = txtPass.Text;
            }

            long volumeSize = 0;
            if (chkDividir.Checked && !TryGetVolumeSize(out volumeSize))
                return;
            if (createSelfExtractor && !com.IsSevenZipFormat(this))
            {
                _7ZipSharp.Msg.AppMessage.Show("Los autoextractores requieren el formato 7z o SCZ.", "Formato no compatible",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (createSelfExtractor && chkDividir.Checked)
            {
                _7ZipSharp.Msg.AppMessage.Show("Un autoextractor se genera como un único archivo y no admite volúmenes divididos.",
                    "Opción no compatible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Establece la ruta de la biblioteca DLL según el tipo de procesador
            if (Environment.Is64BitProcess)
            {
                SevenZipCompressor.SetLibraryPath(Application.StartupPath + @"\7z64.dll");
            }
            else
            {
                SevenZipCompressor.SetLibraryPath(Application.StartupPath + @"\7z.dll");
            }
            SevenZipCompressor tmp = new SevenZipCompressor();
            tmp.ArchiveFormat = com.GetSelectedArchiveFormat(this);
            tmp.CompressionLevel = com.GetSelectedCompressionLevel(this);
            tmp.CompressionMethod = com.GetCompressMethod(this);
            tmp.CompressionMode = CompressionMode.Create;
            tmp.IncludeEmptyDirectories = true;
            // Root folders are represented explicitly in archive entry names.
            tmp.PreserveDirectoryRoot = false;

            tmp.VolumeSize = volumeSize;

            if (!string.IsNullOrEmpty(contrasena))
            {
                tmp.ZipEncryptionMethod = com.getEncriptMethod(this);
                tmp.EncryptHeaders = com.IsSevenZipFormat(this) && chkNombres.Checked;
            }

            int startedFiles = 0;
            int totalFiles = 0;
            tmp.FileCompressionStarted += (s, eventArgs) =>
            {
                if (cancelRequested)
                {
                    eventArgs.Cancel = true;
                    return;
                }
                int current = ++startedFiles;
                string entryName = eventArgs.FileName.Replace('/', '\\');
                UpdateStatusLabel("Comprimiendo archivo " + current + " de " + totalFiles + ": " + Path.GetFileName(entryName));
            };
            tmp.Compressing += (s, eventArgs) =>
            {
                int progressPercentage = Math.Max(0, Math.Min(100, (int)eventArgs.PercentDone));
                latestProgress = progressPercentage;
                UpdateProgressBar(progressPercentage);
                UpdateStatusLabel("Comprimiendo… " + progressPercentage + "%");
                UpdateOperationMetrics(progressPercentage, DateTime.Now - startTime);
            };


            try
            {
                string outputPath = Path.GetFullPath(txtSave.Text);
                string[] selectedPaths = listViewArchivos.Items.Cast<ListViewItem>()
                    .Select(item => item.SubItems[3].Text).ToArray();
                bool includeRootDirectory = chkRootDir.Checked;

                startTime = DateTime.Now;
                latestProgress = 0;
                cancelRequested = false;
                operationRunning = true;
                btnComprimir.Enabled = false;
                btnCComprimir.Text = "Cancelar";
                btnCComprimir.Enabled = true;
                button1.Enabled = true;
                timer.Start();

                prgCompress.Style = ProgressBarStyle.Marquee;
                lblStatusCom.Text = Localization.TranslateText("Preparando archivos…");
                Dictionary<string, string> archivosDiccionario = await Task.Run(() =>
                    CrearEntradasArchivo(outputPath, selectedPaths, includeRootDirectory));
                if (cancelRequested) throw new OperationCanceledException();

                if (archivosDiccionario.Count == 0)
                {
                    _7ZipSharp.Msg.AppMessage.Show("Agrega al menos un archivo para comprimir.", "SharpCompress",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int fileEntryCount = archivosDiccionario.Count(entry => entry.Value != null);
                totalFiles = archivosDiccionario.Count;
                totalInputBytes = archivosDiccionario.Values.Where(path => path != null)
                    .Sum(path => new FileInfo(path).Length);
                if (cmbFormato.SelectedIndex == 3 &&
                    (fileEntryCount != 1 || archivosDiccionario.Any(entry => entry.Value == null)))
                {
                    _7ZipSharp.Msg.AppMessage.Show("GZip solo admite un archivo individual. Elige ZIP, 7z o TAR para comprimir carpetas o varios elementos.",
                        "Formato no compatible con selección múltiple", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (archivosDiccionario.Values.Any(path =>
                    path != null && string.Equals(outputPath, Path.GetFullPath(path), StringComparison.OrdinalIgnoreCase)))
                {
                    _7ZipSharp.Msg.AppMessage.Show("El archivo de salida no puede reemplazar uno de los archivos seleccionados.", "SharpCompress",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                prgCompress.Style = ProgressBarStyle.Marquee;
                prgCompress.Value = 0;
                lblStatusCom.Text = Localization.TranslateText("Compresión en curso…");
                prgCompress.Refresh();
                startTime = DateTime.Now;
                latestProgress = 0;
                timer.Start();

                stagedOutputPath = CreateStagingArchivePath(outputPath);
                string operationOutputPath = stagedOutputPath;
                if (createSelfExtractor)
                {
                    stagedArchivePath = stagedOutputPath + ".7z";
                    operationOutputPath = stagedArchivePath;
                }

                await Task.Run(() =>
                {
                    if (!string.IsNullOrEmpty(contrasena))
                        tmp.CompressFileDictionary(archivosDiccionario, operationOutputPath, contrasena);
                    else
                        tmp.CompressFileDictionary(archivosDiccionario, operationOutputPath);
                });

                if (cancelRequested)
                {
                    operationFinished = true;
                    lblStatusCom.Text = Localization.TranslateText("Compresión cancelada entre archivos; no se publicó el archivo parcial.");
                    lblTiempo.Text = "Detenida tras " + (DateTime.Now - startTime).ToString(@"hh\:mm\:ss") + ".";
                    btnCComprimir.Text = "Cerrar";
                    return;
                }

                if (createSelfExtractor)
                {
                    lblStatusCom.Text = Localization.TranslateText("Creando el autoextractor…");
                    prgCompress.Style = ProgressBarStyle.Marquee;
                    btnCComprimir.Enabled = false;
                    var sfxSettings = BuildSelfExtractorSettings(selfExtractorOptions);
                    await Task.Run(() =>
                    {
                        new SevenZipSfx(SfxModule.Default).MakeSfx(stagedArchivePath, sfxSettings, stagedOutputPath);
                        SelfExtractorIcon.Apply(stagedOutputPath, selfExtractorOptions.IconPath);
                    });
                    File.Delete(stagedArchivePath);
                    stagedArchivePath = null;
                    prgCompress.Style = ProgressBarStyle.Continuous;
                    prgCompress.Value = 100;
                    btnCComprimir.Enabled = true;
                }

                long finalOutputBytes = PublishStagedArchive(stagedOutputPath, outputPath);
                stagedOutputPath = null;
                operationFinished = true;
                prgCompress.Style = ProgressBarStyle.Continuous;
                prgCompress.Value = 100;
                double ratio = totalInputBytes == 0 ? 0 : 100.0 * finalOutputBytes / totalInputBytes;
                lblStatusCom.Text = Localization.TranslateText(string.Format("Completado: {0} → {1} ({2:0.0}% del original).",
                    FormatSize(totalInputBytes), FormatSize(finalOutputBytes), ratio));
                lblTiempo.Text = "Total " + (DateTime.Now - startTime).ToString(@"hh\:mm\:ss") +
                    " · Media " + FormatSize(totalInputBytes / Math.Max(0.5, (DateTime.Now - startTime).TotalSeconds)) + "/s";
                btnComprimir.Enabled = false;
                btnCComprimir.Text = "Cerrar";
                button1.Enabled = false;
                SaveUserPreferences();
                timer.Stop();
                closeAfterSuccess = true;
                return;
            }
            catch (Exception ex)
            {
                operationFinished = true;
                lblStatusCom.Text = Localization.TranslateText(cancelRequested ? "Compresión cancelada." : "La compresión no se completó.");
                if (cancelRequested)
                {
                    btnCComprimir.Text = "Cerrar";
                    lblTiempo.Text = "Detenida tras " + (DateTime.Now - startTime).ToString(@"hh\:mm\:ss") + ".";
                    return;
                }
                ErrorLogger.Write(ex, "Archive compression");
                // Maneja cualquier excepción que pueda ocurrir durante la compresión
                _7ZipSharp.Msg.AppMessage.Show("Ocurrió un error durante la compresión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (stagedOutputPath != null)
                {
                    try
                    {
                        string stagingDirectory = Path.GetDirectoryName(stagedOutputPath);
                        foreach (string stagedFile in Directory.GetFiles(stagingDirectory, Path.GetFileName(stagedOutputPath) + "*"))
                            if (string.Equals(stagedFile, stagedOutputPath, StringComparison.OrdinalIgnoreCase) ||
                                IsNumberedVolume(stagedFile, stagedOutputPath))
                                File.Delete(stagedFile);
                    }
                    catch (IOException) { }
                    catch (UnauthorizedAccessException) { }
                }
                if (stagedArchivePath != null)
                {
                    try { if (File.Exists(stagedArchivePath)) File.Delete(stagedArchivePath); }
                    catch (IOException) { }
                    catch (UnauthorizedAccessException) { }
                }
                operationRunning = false;
                // Habilita el botón después de que se complete la compresión o si se produce un error
                timer.Stop();
                if (btnComprimir.Enabled == false && btnCComprimir.Text != "Cerrar")
                    btnComprimir.Enabled = true;
                btnCComprimir.Enabled = true;
                button1.Enabled = false;
                if (closeAfterSuccess)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private static string CreateStagingArchivePath(string outputPath)
        {
            string directory = Path.GetDirectoryName(outputPath);
            string name = Path.GetFileNameWithoutExtension(outputPath);
            string extension = Path.GetExtension(outputPath);
            return Path.Combine(directory, "." + name + "." + Guid.NewGuid().ToString("N") + extension);
        }

        private void CompressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveUserPreferences();
        }

        private void SaveUserPreferences()
        {
            try
            {
                if (cmbFormato.SelectedIndex >= 0) _7ZipSharp.Properties.Settings.Default.LastArchiveFormat = cmbFormato.SelectedIndex;
                if (cmbPerfil.SelectedIndex >= 0) _7ZipSharp.Properties.Settings.Default.CompressionProfile = cmbPerfil.SelectedIndex;
                _7ZipSharp.Properties.Settings.Default.CreateSelfExtracting = chkCreateSfx.Checked;
                if (selfExtractorOptions != null)
                {
                    _7ZipSharp.Properties.Settings.Default.SfxTitle = selfExtractorOptions.Title;
                    _7ZipSharp.Properties.Settings.Default.SfxInstallPath = selfExtractorOptions.InstallPath;
                    _7ZipSharp.Properties.Settings.Default.SfxBeginPrompt = selfExtractorOptions.BeginPrompt;
                    _7ZipSharp.Properties.Settings.Default.SfxRunProgram = selfExtractorOptions.RunProgram;
                    _7ZipSharp.Properties.Settings.Default.SfxIconPath = selfExtractorOptions.IconPath;
                    _7ZipSharp.Properties.Settings.Default.SfxShowProgress = selfExtractorOptions.ShowProgress;
                }
                string directory = Path.GetDirectoryName(txtSave.Text);
                if (!string.IsNullOrWhiteSpace(directory) && Directory.Exists(directory))
                    _7ZipSharp.Properties.Settings.Default.LastOutputDirectory = directory;
                _7ZipSharp.Properties.Settings.Default.Save();
            }
            catch (Exception ex) { ErrorLogger.Write(ex, "Saving compression preferences"); }
        }

        private static long PublishStagedArchive(string stagedPath, string outputPath)
        {
            string directory = Path.GetDirectoryName(stagedPath);
            string stagedName = Path.GetFileName(stagedPath);
            string[] generated = Directory.GetFiles(directory, stagedName + "*")
                .Where(path => string.Equals(path, stagedPath, StringComparison.OrdinalIgnoreCase) ||
                    IsNumberedVolume(path, stagedPath))
                .OrderBy(path => path, StringComparer.OrdinalIgnoreCase).ToArray();
            if (generated.Length == 0)
                throw new IOException("El motor terminó sin generar el archivo de salida esperado.");

            long totalBytes = 0;
            foreach (string source in generated)
            {
                string suffix = source.Substring(stagedPath.Length);
                string destination = outputPath + suffix;
                totalBytes += new FileInfo(source).Length;
                if (File.Exists(destination)) File.Replace(source, destination, null);
                else File.Move(source, destination);
            }

            bool outputIsSplit = generated.Any(path => IsNumberedVolume(path, stagedPath));
            if (outputIsSplit && File.Exists(outputPath)) File.Delete(outputPath);
            foreach (string oldVolume in Directory.GetFiles(directory, Path.GetFileName(outputPath) + ".*"))
            {
                string suffix = oldVolume.Substring(outputPath.Length);
                if (suffix.Length > 1 && suffix[0] == '.' && suffix.Skip(1).All(char.IsDigit) &&
                    !generated.Any(path => string.Equals(path.Substring(stagedPath.Length), suffix, StringComparison.OrdinalIgnoreCase)))
                    File.Delete(oldVolume);
            }
            return totalBytes;
        }

        private static bool IsNumberedVolume(string path, string stagedPath)
        {
            string suffix = path.Substring(stagedPath.Length);
            return suffix.Length > 1 && suffix[0] == '.' && suffix.Skip(1).All(char.IsDigit);
        }

        private void UpdateProgressBar(int value)
        {
            if (operationFinished) return;
            if (prgCompress.IsDisposed || !prgCompress.IsHandleCreated) return;
            if (prgCompress.InvokeRequired)
            {
                try { prgCompress.BeginInvoke(new Action(() =>
                {
                    if (operationFinished || prgCompress.IsDisposed) return;
                    prgCompress.Style = ProgressBarStyle.Continuous;
                    prgCompress.Value = Math.Max(prgCompress.Minimum, Math.Min(prgCompress.Maximum, value));
                })); }
                catch (InvalidOperationException) { }
            }
            else
            {
                prgCompress.Style = ProgressBarStyle.Continuous;
                prgCompress.Value = Math.Max(prgCompress.Minimum, Math.Min(prgCompress.Maximum, value));
            }
        }
        private void UpdateStatusLabel(string text)
        {
            text = Localization.TranslateText(text);
            if (operationFinished) return;
            if (lblStatusCom.IsDisposed || !lblStatusCom.IsHandleCreated) return;
            if (lblStatusCom.InvokeRequired)
            {
                try { lblStatusCom.BeginInvoke(new Action(() =>
                {
                    if (!operationFinished && !lblStatusCom.IsDisposed) lblStatusCom.Text = text;
                })); }
                catch (InvalidOperationException) { }
            }
            else lblStatusCom.Text = text;
        }
        private void btnSaveSel_Click(object sender, EventArgs e)
        {
            SaveCompressFile.FileName = FileName;
            SaveCompressFile.Filter = chkCreateSfx.Checked
                ? "Autoextractor de Windows (*.exe)|*.exe"
                : "Archivo " + com.getFileType(this) + "|*." + com.getFileType(this);
            SaveCompressFile.DefaultExt = chkCreateSfx.Checked ? "exe" : com.getFileType(this);
            SaveCompressFile.AddExtension = true;
            string rememberedDirectory = _7ZipSharp.Properties.Settings.Default.LastOutputDirectory;
            if (Directory.Exists(rememberedDirectory)) SaveCompressFile.InitialDirectory = rememberedDirectory;

            if (SaveCompressFile.ShowDialog() == DialogResult.OK)
            {
                outputChosenByUser = true;
                txtSave.Text = SaveCompressFile.FileName;
                btnComprimir.Enabled = true;
                lblSalidaFile.Text = Localization.TranslateText("Nombre del archivo: " + Path.GetFileName(txtSave.Text));
                SaveUserPreferences();
            }

        }

        private void btnCComprimir_Click(object sender, EventArgs e)
        {
            if (operationRunning)
            {
                cancelRequested = true;
                btnCComprimir.Enabled = false;
                lblStatusCom.Text = Localization.TranslateText("Cancelando… se detendrá al terminar el elemento actual.");
                return;
            }
            Close();
        }

        private void compressForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            using (var aboutWindow = new about()) aboutWindow.ShowDialog(this);
        }

        private void cmbFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedIndex < 0) return;
            if (!com.IsSevenZipFormat(this) && chkCreateSfx.Checked)
                chkCreateSfx.Checked = false;
            updatingCompressionOptions = true;
            com.getMethod(this);
            com.GetForNoPass(this);
            ConfigureEncryptionOptions();
            updatingCompressionOptions = false;

            UpdateOutputExtension();
            UpdateCompressionDescription();
        }

        private void chkCreateSfx_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreateSfx.Checked && !com.IsSevenZipFormat(this))
                chkCreateSfx.Checked = false;
            chkCreateSfx.Enabled = com.IsSevenZipFormat(this);
            btnConfigureSfx.Enabled = chkCreateSfx.Checked;
            UpdateOutputExtension();
        }

        private void UpdateOutputExtension()
        {
            fileEx = chkCreateSfx.Checked ? ".exe" : "." + com.getFileType(this);
            if (!string.IsNullOrWhiteSpace(txtSave.Text))
                txtSave.Text = Path.ChangeExtension(txtSave.Text, fileEx);
            lblSalidaFile.Text = Localization.TranslateText("Nombre del archivo: " + Path.GetFileName(txtSave.Text));
        }

        private async void btnConfigureSfx_Click(object sender, EventArgs e)
        {
            string[] sourcePaths = listViewArchivos.Items.Cast<ListViewItem>()
                .Select(item => item.SubItems[3].Text).ToArray();
            bool includeRoot = chkRootDir.Checked;
            string outputPath = string.IsNullOrWhiteSpace(txtSave.Text) ? string.Empty : Path.GetFullPath(txtSave.Text);
            btnConfigureSfx.Enabled = false;
            UseWaitCursor = true;
            try
            {
                string[] executables = await Task.Run(() => CrearEntradasArchivo(outputPath, sourcePaths, includeRoot)
                    .Keys.Where(path => string.Equals(Path.GetExtension(path.TrimEnd(Path.DirectorySeparatorChar)), ".exe", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(path => path, StringComparer.CurrentCultureIgnoreCase).ToArray());

                using (var dialog = new SfxOptionsForm(selfExtractorOptions, executables))
                {
                    UseWaitCursor = false;
                    if (dialog.ShowDialog(this) != DialogResult.OK) return;
                    selfExtractorOptions = dialog.Options;
                    SaveUserPreferences();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex, "Finding executable files for SFX settings");
                _7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText("No se pudieron analizar los ejecutables de las fuentes seleccionadas."),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
                btnConfigureSfx.Enabled = chkCreateSfx.Checked;
            }
        }

        private static Dictionary<string, string> BuildSelfExtractorSettings(SelfExtractorOptions options)
        {
            return new Dictionary<string, string>
            {
                { "Title", EscapeSfxConfigValue(options.Title) },
                { "InstallPath", EscapeSfxConfigValue(options.InstallPath) },
                { "GUIFlags", "128+8" },
                { "ExtractPathTitle", EscapeSfxConfigValue(options.Title) },
                { "ExtractPathText", Localization.IsEnglish ? "Select the destination folder:" : "Selecciona la carpeta de destino:" },
                { "GUIMode", options.ShowProgress ? "0" : "2" },
                { "Progress", options.ShowProgress ? "yes" : "no" },
                { "BeginPrompt", EscapeSfxConfigValue(options.BeginPrompt) },
                { "RunProgram", EscapeSfxConfigValue(options.RunProgram) }
            }.Where(setting => !string.IsNullOrWhiteSpace(setting.Value))
                .ToDictionary(setting => setting.Key, setting => setting.Value);
        }

        private static string EscapeSfxConfigValue(string value)
        {
            return (value ?? string.Empty).Replace("\\", "\\\\").Replace("\"", "\\\"");
        }

        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingCompressionOptions) return;
            ApplyCompressionProfile();
            UpdateCompressionDescription();
        }

        private void ApplyCompressionProfile()
        {
            int profileIndex = cmbPerfil.SelectedIndex;
            if (profileIndex < 0 || profileIndex == 3) return;

            updatingCompressionOptions = true;
            switch (profileIndex)
            {
                case 0: cmbNivel.SelectedIndex = 3; break; // Normal
                case 1: cmbNivel.SelectedIndex = 1; break; // Fast
                case 2: cmbNivel.SelectedIndex = 5; break; // Ultra
            }
            updatingCompressionOptions = false;
        }

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingCompressionOptions && cmbPerfil.SelectedIndex >= 0 && cmbPerfil.SelectedIndex != 3)
                cmbPerfil.SelectedIndex = 3;
            UpdateCompressionDescription();
        }

        private void cmbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingCompressionOptions && cmbPerfil.SelectedIndex >= 0 && cmbPerfil.SelectedIndex != 3)
                cmbPerfil.SelectedIndex = 3;
            UpdateCompressionDescription();
        }

        private void UpdateCompressionDescription()
        {
            string[] descriptions = {
                "Sin compresión: máxima velocidad y archivos más grandes.",
                "Rápido: menos tiempo de espera, con menor reducción del tamaño.",
                "Ligero: compresión moderada y consumo contenido.",
                "Normal: equilibrio recomendado entre velocidad y tamaño.",
                "Alto: reduce más el tamaño y tarda más.",
                "Máximo: prioriza el tamaño y puede usar más memoria."
            };

            if (cmbFormato.SelectedIndex == 1)
                lblOptionDescription.Text = Localization.TranslateText("TAR solo empaqueta: no aplica compresión, contraseña ni división en volúmenes.");
            else if (cmbFormato.SelectedIndex == 3)
                lblOptionDescription.Text = Localization.TranslateText("GZip comprime un único archivo; no admite contraseña ni división en volúmenes.");
            else if (cmbNivel.SelectedIndex >= 0)
            {
                string formatHint = cmbFormato.SelectedIndex == 4
                    ? " SCZ es el formato SharpCompress basado en 7z: LZMA2, AES-256, cifrado de nombres y volúmenes."
                    : cmbFormato.SelectedIndex == 0
                    ? " 7z admite AES-256 y volúmenes."
                    : " ZIP admite ZipCrypto o AES; no admite volúmenes aquí.";
                lblOptionDescription.Text = Localization.TranslateText(descriptions[cmbNivel.SelectedIndex]) +
                    Localization.TranslateText(formatHint);
                toolTipCompression.SetToolTip(cmbNivel, Localization.TranslateText(descriptions[cmbNivel.SelectedIndex]));
            }

            toolTipCompression.SetToolTip(cmbPerfil, Localization.TranslateText(
                "Los perfiles aplican un nivel recomendado. Al cambiar el nivel o el método, el perfil pasa a Personalizado."));
        }

        private void ConfigureEncryptionOptions()
        {
            bool supportsPassword = com.IsSevenZipFormat(this) || cmbFormato.SelectedIndex == 2;
            grbEncrip.Enabled = supportsPassword && chkPass.Checked;
            chkNombres.Enabled = com.IsSevenZipFormat(this) && chkPass.Checked;
            if (!chkNombres.Enabled) chkNombres.Checked = false;

            cmbEncrip.Items.Clear();
            if (com.IsSevenZipFormat(this))
            {
                cmbEncrip.Items.Add(cmbFormato.SelectedIndex == 4 ? "AES-256 (SCZ/7z)" : "AES-256 (7z)");
                cmbEncrip.SelectedIndex = 0;
                cmbEncrip.Enabled = false;
                label8.Text = "Cifrado:";
            }
            else if (cmbFormato.SelectedIndex == 2)
            {
                cmbEncrip.Items.AddRange(new object[] { "ZipCrypto", "AES-128", "AES-192", "AES-256" });
                cmbEncrip.SelectedIndex = 0;
                cmbEncrip.Enabled = supportsPassword && chkPass.Checked;
                label8.Text = "Cifrado ZIP:";
            }
            else
            {
                cmbEncrip.Items.Add("No disponible en este formato");
                cmbEncrip.SelectedIndex = 0;
                cmbEncrip.Enabled = false;
                label8.Text = "Cifrado:";
            }
            toolTipCompression.SetToolTip(chkNombres,
                "En 7z, cifra también los nombres y la estructura interna del archivo.");
            toolTipCompression.SetToolTip(cmbEncrip,
                com.IsSevenZipFormat(this)
                    ? "Los archivos 7z y SCZ protegidos usan AES-256."
                    : "ZipCrypto ofrece compatibilidad amplia; AES ofrece mayor protección.");
        }

        private bool TryGetVolumeSize(out long sizeInBytes)
        {
            sizeInBytes = 0;
            string value = chkVolumenCus.Checked
                ? txtVolumen.Text.Trim()
                : Convert.ToString(cmbVolumen.SelectedItem, CultureInfo.InvariantCulture);
            long sizeInMegabytes;
            if (!long.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out sizeInMegabytes) ||
                sizeInMegabytes < 1 || sizeInMegabytes > long.MaxValue / (1024L * 1024L))
            {
                _7ZipSharp.Msg.AppMessage.Show("Indica un tamaño de volumen válido de al menos 1 MB.", "Tamaño de volumen no válido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (chkVolumenCus.Checked) txtVolumen.Focus();
                else cmbVolumen.Focus();
                return false;
            }

            sizeInBytes = sizeInMegabytes * 1024L * 1024L;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Comprimir (SharpCompress)";
            notifyIcon1.BalloonTipText = "SharpCompress esta comprimiendo en segundo plano\nHaga doble clic en el icono para volver a SharpCompress";
            notifyIcon1.ShowBalloonTip(30000);
            Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            Show();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(chkShowPass.Checked == true)
            {
                txtPass.UseSystemPasswordChar = false;
                txtConfirPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                txtConfirPass.UseSystemPasswordChar = true;
            }
        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            grbEncrip.Enabled = chkPass.Enabled && chkPass.Checked;
            chkNombres.Enabled = com.IsSevenZipFormat(this) && chkPass.Checked;
            cmbEncrip.Enabled = cmbFormato.SelectedIndex == 2 && chkPass.Checked;
        }

        private void chkVolumenCus_CheckedChanged(object sender, EventArgs e)
        {
            txtVolumen.Enabled = grbVolume.Enabled && chkVolumenCus.Checked;
            cmbVolumen.Enabled = grbVolume.Enabled && !chkVolumenCus.Checked;
        }

        private void txtVolumen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chkDividir_CheckedChanged(object sender, EventArgs e)
        {
            grbVolume.Enabled = chkDividir.Enabled && chkDividir.Checked;
            chkVolumenCus_CheckedChanged(sender, e);
        }

        private void listViewArchivos_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) // Verificar si lo arrastrado son archivos
            {
                e.Effect = DragDropEffects.Copy; // Cambiar el efecto a "copiar"
            }
            else
            {
                e.Effect = DragDropEffects.None; // No permitir si no son archivos
            }
        }

        private void listViewArchivos_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string archivo in archivos)
                {
                    AgregarRutaAlListView(archivo);
                }
            }
        }

        private void AgregarRutaAlListView(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo)) return;
            string fullPath;
            try { fullPath = Path.GetFullPath(rutaArchivo); }
            catch { return; }
            bool isDirectory = Directory.Exists(fullPath);
            if (!isDirectory && !File.Exists(fullPath)) return;

            foreach (ListViewItem item in listViewArchivos.Items)
                if (item.SubItems[3].Text.Equals(fullPath, StringComparison.OrdinalIgnoreCase)) return;

            string name = Path.GetFileName(fullPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
            if (string.IsNullOrEmpty(name)) name = Path.GetPathRoot(fullPath);
            string size = "Carpeta";
            DateTime modified;
            if (isDirectory)
                modified = Directory.GetLastWriteTime(fullPath);
            else
            {
                var info = new FileInfo(fullPath);
                size = string.Format("{0:N0} KB", info.Length / 1024);
                modified = info.LastWriteTime;
            }

            var listItem = new ListViewItem(name);
            listItem.SubItems.Add(size);
            listItem.SubItems.Add(modified.ToString("dd/MM/yyyy HH:mm"));
            listItem.SubItems.Add(fullPath);
            listItem.Tag = isDirectory;
            listViewArchivos.Items.Add(listItem);
            UpdateRootDirectoryDefault();
            lblMensaje.Text = string.Format("{0} elemento(s) para comprimir", listViewArchivos.Items.Count);
            btnComprimir.Enabled = listViewArchivos.Items.Count > 0;
            if (!outputChosenByUser)
                ActualizarNombrePredeterminado(listViewArchivos.Items.Cast<ListViewItem>()
                    .Select(item => item.SubItems[3].Text));
        }

        private void UpdateRootDirectoryDefault()
        {
            if (rootDirectoryChoiceTouched || listViewArchivos == null || chkRootDir == null)
                return;

            bool hasMultipleItems = listViewArchivos.Items.Count > 1;
            bool includesDirectory = listViewArchivos.Items.Cast<ListViewItem>()
                .Any(item => item.Tag is bool && (bool)item.Tag);

            updatingRootDirectoryChoice = true;
            try { chkRootDir.Checked = hasMultipleItems && includesDirectory; }
            finally { updatingRootDirectoryChoice = false; }
        }

        private Dictionary<string, string> CrearEntradasArchivo(string outputPath, IEnumerable<string> selectedPaths, bool includeRootDirectory)
        {
            var entries = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (string sourcePath in selectedPaths)
            {
                if (cancelRequested) throw new OperationCanceledException();
                if (File.Exists(sourcePath))
                {
                    AgregarEntradaUnica(entries, Path.GetFileName(sourcePath), sourcePath);
                    continue;
                }
                if (!Directory.Exists(sourcePath)) continue;

                string normalizedRoot = sourcePath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                string rootName = Path.GetFileName(normalizedRoot);
                string prefix = includeRootDirectory ? rootName + Path.DirectorySeparatorChar : string.Empty;
                var pendingDirectories = new Stack<string>();
                pendingDirectories.Push(sourcePath);
                while (pendingDirectories.Count > 0)
                {
                    if (cancelRequested) throw new OperationCanceledException();
                    string currentDirectory = pendingDirectories.Pop();
                    string[] files = Directory.GetFiles(currentDirectory);
                    string[] childDirectories = Directory.GetDirectories(currentDirectory);

                    foreach (string file in files)
                    {
                        if (cancelRequested) throw new OperationCanceledException();
                        if (string.Equals(Path.GetFullPath(file), outputPath, StringComparison.OrdinalIgnoreCase)) continue;
                        string relativePath = file.Substring(normalizedRoot.Length)
                            .TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                        AgregarEntradaUnica(entries, prefix + relativePath, file);
                    }

                    if (files.Length == 0 && childDirectories.Length == 0)
                    {
                        bool isSelectedRoot = currentDirectory.Equals(sourcePath, StringComparison.OrdinalIgnoreCase);
                        string relativePath = isSelectedRoot
                            ? rootName + Path.DirectorySeparatorChar
                            : currentDirectory.Substring(normalizedRoot.Length)
                                .TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;
                        AgregarEntradaUnica(entries, isSelectedRoot ? relativePath : prefix + relativePath, null);
                    }

                    foreach (string childDirectory in childDirectories)
                        pendingDirectories.Push(childDirectory);
                }
            }
            return entries;
        }

        private static void AgregarEntradaUnica(IDictionary<string, string> entries, string entryName, string sourcePath)
        {
            string normalizedName = entryName.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            if (!entries.ContainsKey(normalizedName))
            {
                entries.Add(normalizedName, sourcePath);
                return;
            }

            bool directoryEntry = sourcePath == null;
            string cleanName = normalizedName.TrimEnd(Path.DirectorySeparatorChar);
            string directory = Path.GetDirectoryName(cleanName);
            string fileName = Path.GetFileName(cleanName);
            string extension = directoryEntry ? string.Empty : Path.GetExtension(fileName);
            string baseName = extension.Length == 0 ? fileName : Path.GetFileNameWithoutExtension(fileName);
            string candidate;
            int suffix = 2;
            do
            {
                string candidateName = baseName + " (" + suffix++ + ")" + extension;
                candidate = string.IsNullOrEmpty(directory) ? candidateName : Path.Combine(directory, candidateName);
                if (directoryEntry) candidate += Path.DirectorySeparatorChar;
            }
            while (entries.ContainsKey(candidate));
            entries.Add(candidate, sourcePath);
        }

        private void btnAgregarCarpeta_Click(object sender, EventArgs e)
        {
            if (SelectCompressFolder.ShowDialog(this) == DialogResult.OK)
                AgregarRutaAlListView(SelectCompressFolder.SelectedPath);
        }

        private void btnAgregarArchivos_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Title = "Agregar archivos para comprimir",
                Filter = "Todos los archivos (*.*)|*.*",
                Multiselect = true,
                CheckFileExists = true
            })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                foreach (string path in dialog.FileNames)
                    AgregarRutaAlListView(path);
            }
        }


        private void removerArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Almacenar los elementos seleccionados en una lista
            List<ListViewItem> itemsToRemove = new List<ListViewItem>();

            // Recorrer los elementos seleccionados y almacenarlos para eliminarlos
            foreach (ListViewItem item in listViewArchivos.SelectedItems)
            {
                itemsToRemove.Add(item);
            }

            // Eliminar los elementos almacenados
            foreach (ListViewItem item in itemsToRemove)
            {
                listViewArchivos.Items.Remove(item);
            }
            UpdateRootDirectoryDefault();
            lblMensaje.Text = string.Format("{0} elemento(s) para comprimir", listViewArchivos.Items.Count);
            btnComprimir.Enabled = listViewArchivos.Items.Count > 0;
            if (!outputChosenByUser)
                ActualizarNombrePredeterminado(listViewArchivos.Items.Cast<ListViewItem>()
                    .Select(item => item.SubItems[3].Text));
        }
    }
}
