using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7ZipSharp
{
    internal partial class SettingsForm : Form
    {
        private static readonly View[] BrowserViews = { View.Details, View.List, View.SmallIcon, View.LargeIcon, View.Tile };

        internal SettingsForm()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            LoadSettingsIntoControls();
            Localization.Apply(this);
            ProductUi.Apply(this);
            UpdateIntegrationStatus();
        }

        private void LoadSettingsIntoControls()
        {
            var settings = Properties.Settings.Default;
            cmbLanguage.SelectedIndex = settings.UiLanguage == "en" ? 1 : 0;
            cmbBrowserView.SelectedIndex = Array.IndexOf(BrowserViews, (View)settings.BrowserView);
            if (cmbBrowserView.SelectedIndex < 0) cmbBrowserView.SelectedIndex = 0;
            txtIconPath.Text = settings.ApplicationIconPath ?? string.Empty;
            cmbArchiveFormat.SelectedIndex = settings.LastArchiveFormat >= 0 && settings.LastArchiveFormat < cmbArchiveFormat.Items.Count
                ? settings.LastArchiveFormat : 2;
            cmbCompressionProfile.SelectedIndex = settings.CompressionProfile >= 0 && settings.CompressionProfile < cmbCompressionProfile.Items.Count
                ? settings.CompressionProfile : 0;
            chkSfxByDefault.Checked = settings.CreateSelfExtracting;
            txtOutputFolder.Text = settings.LastOutputDirectory ?? string.Empty;
            txtExtractFolder.Text = settings.LastExtractDirectory ?? string.Empty;
            cmbConflict.SelectedIndex = settings.ConflictPolicy >= 0 && settings.ConflictPolicy < cmbConflict.Items.Count
                ? settings.ConflictPolicy : 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string iconPath = txtIconPath.Text.Trim();
            if (!string.IsNullOrWhiteSpace(iconPath))
            {
                if (!File.Exists(iconPath))
                {
                    ShowWarning("No se encuentra el archivo de icono seleccionado.");
                    return;
                }
                try { using (var icon = new Icon(iconPath)) { } }
                catch (ArgumentException) { ShowWarning("Selecciona un archivo de icono .ico válido."); return; }
            }

            string outputFolder = txtOutputFolder.Text.Trim();
            string extractFolder = txtExtractFolder.Text.Trim();
            if (!ValidateFolder(outputFolder, "La carpeta de salida no existe.") ||
                !ValidateFolder(extractFolder, "La carpeta de extracción no existe.")) return;

            try
            {
                var settings = Properties.Settings.Default;
                settings.UiLanguage = cmbLanguage.SelectedIndex == 1 ? "en" : "es";
                settings.ApplicationIconPath = iconPath;
                settings.BrowserView = (int)BrowserViews[cmbBrowserView.SelectedIndex];
                settings.LastArchiveFormat = cmbArchiveFormat.SelectedIndex;
                settings.CompressionProfile = cmbCompressionProfile.SelectedIndex;
                settings.CreateSelfExtracting = chkSfxByDefault.Checked;
                settings.LastOutputDirectory = outputFolder;
                settings.LastExtractDirectory = extractFolder;
                settings.ConflictPolicy = cmbConflict.SelectedIndex;
                settings.Save();
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex, "Saving application settings");
                ShowWarning("No se pudieron guardar los cambios. Revisa el registro de errores.");
                return;
            }

            foreach (Form form in Application.OpenForms)
            {
                Localization.Apply(form);
                ProductUi.Apply(form);
                var mainForm = form as fm;
                if (mainForm != null) mainForm.RefreshApplicationPreferences();
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateFolder(string path, string message)
        {
            if (string.IsNullOrWhiteSpace(path) || Directory.Exists(path)) return true;
            ShowWarning(message);
            return false;
        }

        private void btnBrowseIcon_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = "Iconos de Windows (*.ico)|*.ico",
                CheckFileExists = true,
                Multiselect = false,
                Title = Localization.TranslateText("Seleccionar icono")
            })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK) txtIconPath.Text = dialog.FileName;
            }
        }

        private void btnResetIcon_Click(object sender, EventArgs e)
        {
            txtIconPath.Clear();
        }

        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            BrowseFolder(txtOutputFolder, "Seleccionar carpeta predeterminada de salida");
        }

        private void btnExtractBrowse_Click(object sender, EventArgs e)
        {
            BrowseFolder(txtExtractFolder, "Seleccionar carpeta predeterminada de extracción");
        }

        private void BrowseFolder(Control target, string title)
        {
            using (var dialog = new FolderBrowserDialog { Description = Localization.TranslateText(title), ShowNewFolderButton = true })
            {
                if (Directory.Exists(target.Text)) dialog.SelectedPath = target.Text;
                if (dialog.ShowDialog(this) == DialogResult.OK) target.Text = dialog.SelectedPath;
            }
        }

        private async void btnRepairIntegration_Click(object sender, EventArgs e)
        {
            await RunIntegrationAction(() => ShellIntegrationManager.StartElevatedRepair(txtIconPath.Text.Trim()),
                "Integración del menú contextual reparada correctamente.");
        }

        private async void btnRemoveIntegration_Click(object sender, EventArgs e)
        {
            await RunIntegrationAction(ShellIntegrationManager.StartElevatedRemoval,
                "Se quitó la integración del menú contextual de este equipo.");
        }

        private async Task RunIntegrationAction(Action action, string successMessage)
        {
            btnRepairIntegration.Enabled = false;
            btnRemoveIntegration.Enabled = false;
            lblIntegrationStatus.Text = Localization.TranslateText("Esperando la confirmación de Windows…");
            try
            {
                await Task.Run(action);
                UpdateIntegrationStatus();
                _7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText(successMessage), Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception ex) when (ex.NativeErrorCode == 1223)
            {
                lblIntegrationStatus.Text = Localization.TranslateText("No se hicieron cambios: se canceló la solicitud de permisos.");
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex, "Updating Windows Explorer integration");
                lblIntegrationStatus.Text = Localization.TranslateText("No se pudo actualizar la integración. Consulta el registro de errores.");
                _7ZipSharp.Msg.AppMessage.Show(this, lblIntegrationStatus.Text, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRepairIntegration.Enabled = true;
                btnRemoveIntegration.Enabled = true;
            }
        }

        private void UpdateIntegrationStatus()
        {
            lblIntegrationStatus.Text = ShellIntegrationManager.IsMachineIntegrationInstalled
                ? Localization.TranslateText("La integración de Explorer está activa en este equipo.")
                : Localization.TranslateText("La integración de Explorer no está activa en este equipo.");
        }

        private void btnOpenLogs_Click(object sender, EventArgs e)
        {
            try
            {
                string directory = Path.GetDirectoryName(ErrorLogger.LogPath);
                Directory.CreateDirectory(directory);
                Process.Start(new ProcessStartInfo("explorer.exe", "\"" + directory + "\"") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex, "Opening error log folder");
                ShowWarning("No se pudo abrir la carpeta de registros.");
            }
        }

        private void btnChooseDefaultApps_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("ms-settings:defaultapps") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex, "Opening Windows default app settings");
                ShowWarning("No se pudo abrir la configuración de aplicaciones predeterminadas de Windows.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (_7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText("¿Restaurar las preferencias predeterminadas de SharpCompress?"),
                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Properties.Settings.Default.Reset();
            LoadSettingsIntoControls();
            foreach (Form form in Application.OpenForms)
            {
                Localization.Apply(form);
                ProductUi.Apply(form);
                var mainForm = form as fm;
                if (mainForm != null) mainForm.RefreshApplicationPreferences();
            }
        }

        private void ShowWarning(string message)
        {
            _7ZipSharp.Msg.AppMessage.Show(this, Localization.TranslateText(message), Text,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
