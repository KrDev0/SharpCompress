using System;
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
        public extractF(string arch)
        {
            InitializeComponent();
            Text = "Extractor | SharpCompress " + Application.ProductVersion.ToString();

            txtFile.Text = arch;
            txtSave.Text = arch;
            txtSave.Text = txtSave.Text.Replace(Path.GetExtension(arch), "");
            lblSalidaFile.Text = "Directorio de salida: " + Path.GetFileName(txtSave.Text);

            extraer(arch);

            // Inicializa el Timer
            timer = new Timer();
            timer.Interval = 1000; // Intervalo en milisegundos (1 segundo)
            timer.Tick += Timer_Tick;

            // Inicia el cronómetro
            startTime = DateTime.Now;
            timer.Start();

        }

        string contraseña;
        private void extraer(string arch)
        {
            try
            {
                // Verificar si el archivo está protegido por contraseña
                bool protegido = EsArchivoProtegido(arch);
                
                if (protegido == true)
                {
                    // Mostrar el formulario para ingresar la contraseña
                    using (var formContraseña = new formContraseña())
                    {
                        if (formContraseña.ShowDialog() == DialogResult.OK)
                        {
                            contraseña = formContraseña.ContraseñaIngresada;
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                    extract(contraseña);
                }
                else
                    extract(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private bool EsArchivoProtegido(string archivo)
        {
            try
            {
                using (var extractor = new SevenZipExtractor(archivo))
                {
                    // Verificar si el archivo necesita contraseña
                    return !extractor.Check();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar la protección por contraseña: {ex.Message}");
                return false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Calcula el tiempo transcurrido
            TimeSpan elapsed = DateTime.Now - startTime;

            // Muestra el tiempo transcurrido en un Label
            lblTiempo.Text = "Tiempo transcurrido: " + elapsed.ToString(@"hh\:mm\:ss");
        }
        private void extractF_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("SharpCompress\n\n" +
                "Versión: " + Application.ProductVersion.ToString()+ "\n" +
                "Compilación: 240324mar\n" +
                "SevenZipSharp: 0.5.6.0\n" +
                "7Z Plugin: 22.1.0.0\n" +
                "7-Zip Shell Extension: 23.1.0.0\n" +
                "Desarrollado por: KrDev",
                "Acerca de",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void extract(string pass)
        {
            // Establece la ruta de la biblioteca DLL según el tipo de procesador
            if (Environment.Is64BitProcess)
            {
                SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + @"\7z64.dll");
            }
            else
            {
                SevenZip.SevenZipCompressor.SetLibraryPath(Application.StartupPath + @"\7z.dll");
            }
            try
            {
                await Task.Run(() =>
                {
                   using(SevenZipExtractor tmp = new SevenZipExtractor(txtFile.Text,pass))
                    {
                        tmp.Extracting += (s, eventArgs) =>
                        {
                            int progressPercentage = (int)(((double)eventArgs.PercentDone / 100) * 100);

                            // Actualiza la ProgressBar
                            UpdateProgressBar(progressPercentage);

                            // Actualiza el Label de estado
                            UpdateStatusLabel("Extrayendo " + progressPercentage + "% completado...");
                        };

                        tmp.ExtractArchive(txtSave.Text);
                    }
                });

            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la extracción
                MessageBox.Show("Ocurrió un error durante la extracción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Habilita la ProgressBar y el botón después de que se complete la extracción o si se produce un error
                Application.Exit();
            }
        }

        private void UpdateProgressBar(int value)
        {
            if (prgExtract.InvokeRequired)
            {
                prgExtract.Invoke(new Action(() => prgExtract.Value = value));
            }
            else
            {
                prgExtract.Value = value;
            }
        }

        private void UpdateStatusLabel(string text)
        {
            if (lblStatusExtract.InvokeRequired)
            {
                lblStatusExtract.Invoke(new Action(() => lblStatusExtract.Text = text));
            }
            else
            {
                lblStatusExtract.Text = text;
            }
        }

        private void btnCComprimir_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
