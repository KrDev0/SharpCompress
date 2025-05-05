
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
using _7ZipSharp.Msg;
using SevenZip;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _7ZipSharp
{
    public partial class CompressF : Form
    {
        string FileName;
        string fileEx;
        Compress com = new Compress();
        private System.Windows.Forms.Timer timer;
        private DateTime startTime;

        public CompressF(string files, string type)
        {
            InitializeComponent();

            cmbFormato.SelectedIndex = 2;
            cmbNivel.SelectedIndex = 4;
            cmbMetodo.SelectedIndex = 0;
            cmbEncrip.SelectedIndex = 0;

            // Configuración del ListView
            listViewArchivos.View = View.Details;
            listViewArchivos.Columns.Add("Nombre", 200);
            listViewArchivos.Columns.Add("Tamaño", 100);
            listViewArchivos.Columns.Add("Fecha de modificación", 150);
            listViewArchivos.Columns.Add("Ruta", 300); // Nueva columna para la ruta del archivo

            lblSalidaFile.Text = lblSalidaFile.Text.Replace("{0}", FileName + fileEx);

            if(!string.IsNullOrEmpty(files))
                AgregarArchivoAlListView(files);

           byFileType(type,files);

            // Inicializa el Timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Intervalo en milisegundos (1 segundo)
            timer.Tick += Timer_Tick;
        }

        private void byFileType(string type,string files)
        {
            //7ZIP
            if (type == "/f7z")
            {
                Text = "Comprimir a 7Zip | SharpCompress " + Application.ProductVersion.ToString();
                cmbFormato.SelectedIndex = 0;
                FileInfo fileInfo = new FileInfo(files);
                txtSave.Text = fileInfo.FullName.Replace(fileInfo.Extension, ".7z");
                lblSalidaFile.Text = "Archivo de salida: " + fileInfo.Name.Replace(fileInfo.Extension, ".7z");
            }
            //TAR
            else if (type == "/fTar")
            {
                Text = "Comprimir a Tar | SharpCompress " + Application.ProductVersion.ToString();
                cmbFormato.SelectedIndex = 1;
                FileInfo fileInfo = new FileInfo(files);
                txtSave.Text = fileInfo.FullName.Replace(fileInfo.Extension, ".tar");
                lblSalidaFile.Text = "Archivo de salida: " + fileInfo.Name.Replace(fileInfo.Extension, ".tar");
            }
            //ZIP
            else if (type == "/fZip")
            {
                Text = "Comprimir a Zip | SharpCompress " + Application.ProductVersion.ToString();
                cmbFormato.SelectedIndex = 2;
                FileInfo fileInfo = new FileInfo(files);
                txtSave.Text = fileInfo.FullName.Replace(fileInfo.Extension, ".zip");
                lblSalidaFile.Text = "Archivo de salida: " + fileInfo.Name.Replace(fileInfo.Extension, ".zip");
            }
            //GZ
            else if (type == "/fGz")
            {
                Text = "Comprimir a GZ | SharpCompress " + Application.ProductVersion.ToString();
                cmbFormato.SelectedIndex = 4;
                FileInfo fileInfo = new FileInfo(files);
                txtSave.Text = fileInfo.FullName.Replace(fileInfo.Extension, ".gz");
                lblSalidaFile.Text = "Archivo de salida: " + fileInfo.Name.Replace(fileInfo.Extension, ".gz");
            }
            else
                Text = "Comprimir | SharpCompress " + Application.ProductVersion.ToString();
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
                    MessageBox.Show("No se ha establecido una contraseña", "No se puede iniciar la compresión", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
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
            tmp.PreserveDirectoryRoot = chkRootDir.Checked;

            if (grbVolume.Enabled == true)
            {
                if (chkVolumenCus.Checked == true)
                    tmp.VolumeSize = Convert.ToInt32(txtVolumen.Text) * 1024 * 1024;
                else
                    tmp.VolumeSize = Convert.ToInt32(cmbVolumen.SelectedItem.ToString()) * 1024 * 1024;
            }

            if (grbEncrip.Enabled == true)
            {
                if (!string.IsNullOrEmpty(contrasena))
                {
                    tmp.ZipEncryptionMethod = com.getEncriptMethod(this);
                }
                if (chkNombres.Checked == true)
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

           
            try
            {
                // Crear un diccionario donde el nombre del archivo es la clave, y la ruta completa es el valor.
                Dictionary<string, string> archivosDiccionario = new Dictionary<string, string>();

                foreach (ListViewItem item in listViewArchivos.Items)
                {
                    string nombreArchivo = item.Text; // Obtener el nombre del archivo desde el ListViewItem
                    string rutaArchivo = item.SubItems[3].Text; // Obtener la ruta desde la columna de ruta

                    if (!archivosDiccionario.ContainsKey(nombreArchivo)) // Evitar duplicados de nombre
                    {
                        archivosDiccionario.Add(nombreArchivo, rutaArchivo); // Guardar la ruta como valor
                    }
                }

                await Task.Run(() =>
                {
                    // Inicia la compresión de la carpeta completa
                    if (!string.IsNullOrEmpty(contrasena))
                        tmp.CompressFileDictionary(archivosDiccionario, txtSave.Text, contrasena);
                    else
                        tmp.CompressFileDictionary(archivosDiccionario, txtSave.Text);

                    // Inicia el cronómetro
                    startTime = DateTime.Now;
                    // Deshabilita el botón mientras se realiza la compresión
                    btnComprimir.Enabled = false;
                    button1.Enabled = true;
                    timer.Start();
                });

                lblStatusCom.Text = "Compresión finalizada...";
                Application.Exit();
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la compresión
                MessageBox.Show("Ocurrió un error durante la compresión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
        private void btnSaveSel_Click(object sender, EventArgs e)
        {
            SaveCompressFile.FileName = FileName;
            SaveCompressFile.Filter = "Archivo " + com.getFileType(this) + "|*." + com.getFileType(this);

            if (SaveCompressFile.ShowDialog() == DialogResult.OK)
            {
                txtSave.Text = SaveCompressFile.FileName;
                btnComprimir.Enabled = true;
                lblSalidaFile.Text = "Archivo de salida: " + FileName + fileEx;
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
                "Compilación: 0505.25may\n" +
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
                com.getMethod(this);
                com.GetForNoPass(this);
                txtSave.Text = txtSave.Text.Replace(fileEx, "." + com.getFileType(this));
                fileEx = "." + com.getFileType(this);
                lblSalidaFile.Text = "Archivo de salida: " + FileName + fileEx;
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
                    AgregarArchivoAlListView(archivo);
                }
            }
        }

        private void AgregarArchivoAlListView(string rutaArchivo)
        {
            FileInfo fileInfo = new FileInfo(rutaArchivo);

            if (!fileInfo.Exists) return; // Asegura que el archivo existe

            bool archivoExiste = false;
            foreach (ListViewItem item in listViewArchivos.Items)
            {
                if (item.SubItems[3].Text.Equals(fileInfo.FullName, StringComparison.OrdinalIgnoreCase))
                {
                    archivoExiste = true;
                    break;
                }
            }

            if (!archivoExiste)
            {
                ListViewItem item = new ListViewItem(fileInfo.Name);
                item.SubItems.Add($"{fileInfo.Length / 1024} KB");
                item.SubItems.Add(fileInfo.LastWriteTime.ToString("dd/MM/yyyy HH:mm"));
                item.SubItems.Add(fileInfo.FullName);

                listViewArchivos.Items.Add(item);
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
        }
    }
}