using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using SevenZip;

namespace _7ZipSharp
{
    public partial class CompressF : Form
    {
        string FileName;
        string fileEx;
        Compress com = new Compress();
        private System.Windows.Forms.Timer timer;
        private DateTime startTime;

        public CompressF(string folder, string output)
        {
            InitializeComponent();
            Text = "Comprimir | SharpCompress " + Application.ProductVersion.ToString();

            cmbFormato.SelectedIndex = 2;
            cmbNivel.SelectedIndex = 4;
            cmbMetodo.SelectedIndex = 2;
            cmbEncrip.SelectedIndex = 0;

            txtDir.Text = folder;
            txtSave.Text = output;

            FileName = Path.GetFileName(txtDir.Text);

            txtSave.Text = txtSave.Text.Replace(FileName , FileName + "." +com.getFileType(this));
            fileEx = "." + com.getFileType(this);

            lblSalidaFile.Text = lblSalidaFile.Text.Replace("{0}",FileName + fileEx);

            // Inicializa el Timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Intervalo en milisegundos (1 segundo)
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Calcula el tiempo transcurrido
            TimeSpan elapsed = DateTime.Now - startTime;

            // Muestra el tiempo transcurrido en un Label
            lblTiempo.Text = "Tiempo transcurrido: " + elapsed.ToString(@"hh\:mm\:ss");
        }

        string contrasena = "";
        private async void btnComprimir_Click(object sender, EventArgs e)
        {
            //Primero valido si tendra contraseña o no
            if (chkPass.Checked == true)
            {
                //valido que los campos de la contraseña no esten en blanco o sean nulos
                if (!string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtConfirPass.Text))
                {
                    //valido que ambos textos (contraseñas) sean las mismas
                    if (txtPass.Text == txtConfirPass.Text)
                        contrasena = txtConfirPass.Text;
                }
                else
                {
                    MessageBox.Show("No se ha establecido una contraseña", "No se puede iniciar la compresión", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }
            }

            // Establece la ruta de la biblioteca DLL según el tipo de procesador
            if (Environment.Is64BitProcess)
            {
                SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + @"\7z64.dll");
            }
            else
            {
                SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + @"\7z.dll");
            }
            SevenZip.SevenZipCompressor tmp = new SevenZip.SevenZipCompressor();
            tmp.ArchiveFormat = com.GetSelectedArchiveFormat(this);
            tmp.CompressionLevel = com.GetSelectedCompressionLevel(this);
            tmp.CompressionMethod = com.GetCompressMethod(this);
            tmp.CompressionMode = CompressionMode.Create;
            tmp.IncludeEmptyDirectories = true;

            if(grbVolume.Enabled == true)
            {
                if (chkVolumenCus.Checked == true)
                    tmp.VolumeSize = Convert.ToInt32(txtVolumen.Text) * 1024 * 1024;
                else
                    tmp.VolumeSize = Convert.ToInt32(cmbVolumen.SelectedItem.ToString()) * 1024 * 1024;
            }

            if(grbEncrip.Enabled == true)
            {
                if (!string.IsNullOrEmpty(contrasena))
                {
                    tmp.ZipEncryptionMethod = com.getEncriptMethod(this);
                }
                if(chkNombres.Checked == true)
                    tmp.EncryptHeaders = true;
            }

            // Configura el evento para el progreso
            tmp.Compressing += (s, eventArgs) =>
            {
                int progressPercentage = (int)(((double)eventArgs.PercentDone / 100) * 100);

                // Actualiza la ProgressBar
                UpdateProgressBar(progressPercentage);

                // Actualiza el Label de estado
                UpdateStatusLabel("Comprimiendo " + progressPercentage + "% completado...");
            };

            // Inicia el cronómetro
            startTime = DateTime.Now;
            // Deshabilita el botón mientras se realiza la compresión
            btnComprimir.Enabled = false;
            button1.Enabled = true;
            timer.Start();

            try
            {
                await Task.Run(() =>
                {
                    // Inicia la compresión de la carpeta completa
                   if(!string.IsNullOrEmpty(contrasena))
                        tmp.CompressDirectory(txtDir.Text, txtSave.Text,contrasena);
                    else
                        tmp.CompressDirectory(txtDir.Text, txtSave.Text);
                });

                lblStatusCom.Text = "Compresión finalizada...";
                Application.Exit();
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la compresión
                MessageBox.Show("Ocurrió un error durante la compresión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Habilita el botón después de que se complete la compresión o si se produce un error
                btnComprimir.Enabled = true;
            }
        }
        private void UpdateProgressBar(int value)
        {
            if (prgCompress.InvokeRequired)
            {
                prgCompress.Invoke(new Action(() => prgCompress.Value = value));
            }
            else
            {
                prgCompress.Value = value;
            }
        }
        private void UpdateStatusLabel(string text)
        {
            if (lblStatusCom.InvokeRequired)
            {
                lblStatusCom.Invoke(new Action(() => lblStatusCom.Text = text));
            }
            else
            {
                lblStatusCom.Text = text;
            }
        }
        private void btnSelDir_Click(object sender, EventArgs e)
        {
            if (SelectCompressFolder.ShowDialog() == DialogResult.OK)
            {
                txtDir.Text = SelectCompressFolder.SelectedPath;
                FileName = Path.GetFileName(txtDir.Text);
                btnSaveSel.Enabled = true;
            }
        }

        private void btnSaveSel_Click(object sender, EventArgs e)
        {
            SaveCompressFile.FileName = FileName;
            SaveCompressFile.Filter = "Archivo " + com.getFileType(this) + "|*." + com.getFileType(this);

            if (SaveCompressFile.ShowDialog() == DialogResult.OK)
            {
                txtSave.Text = SaveCompressFile.FileName;
                btnComprimir.Enabled = true;
            }
                
        }

        private void btnCComprimir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void compressForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("SharpCompress\n\n" +
                "Versión: " + Application.ProductVersion.ToString() + "\n" +
                "Compilación: 240324mar\n" +
                "SevenZipSharp: 0.5.6.0\n" +
                "7Z Plugin: 22.1.0.0\n" +
                "7-Zip Shell Extension: 23.1.0.0\n" +
                "Desarrollado por: KrDev",
                "Acerca de",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void cmbFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSave.Text = txtSave.Text.Replace(fileEx, "." + com.getFileType(this));
                fileEx = "." + com.getFileType(this);
                lblSalidaFile.Text = "Archivo de salida: " + FileName + fileEx;
                com.getMethod(this);
                com.GetForTar(this);

                ///ZIP
                chkDividir.Enabled = cmbFormato.SelectedIndex == 2 ? false : true;

                ///TAR
                chkPass.Enabled = cmbFormato.SelectedIndex == 1 ? false : true;

                ///7ZIP
                chkNombres.Enabled = cmbFormato.SelectedIndex == 0 ? true : false;

                ///
                chkPass.Checked = false;
                chkDividir.Checked = false;
            }
            catch {  }
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
            //Operador ternario para practicar un poco
            grbEncrip.Enabled = chkPass.Checked ? true : false;
        }

        private void chkVolumenCus_CheckedChanged(object sender, EventArgs e)
        {
            //Operador ternario para practicar un poco
            txtVolumen.Enabled = chkVolumenCus.Checked ? true : false;
            cmbVolumen.Enabled = chkVolumenCus.Checked ? false : true;
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
            grbVolume.Enabled = chkDividir.Checked ? true : false;
        }
    }
}
