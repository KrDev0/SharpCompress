using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SevenZip;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Tar;
using SharpCompress.Archives.Zip;

namespace _7ZipSharp
{
    public partial class fm : Form
    {
        string directorio;
        string archivo;

        public fm(string arch,string tip)
        {
            InitializeComponent();

            listViewArchivos.Columns.Add("Nombre", 200);
            listViewArchivos.Columns.Add("Tipo", 100);
            listViewArchivos.Columns.Add("Tamaño", 100);
            listViewArchivos.Columns.Add("Fecha de modificación", 150);
            listViewArchivos.Columns.Add("Ruta", 700);

            if (tip.Contains("/personal"))
            {
                picLogo.Visible = true;
                lblArchivo.Visible = true;
            }
            else if (tip.Contains("/openD"))
                { directorio = arch;  CargarCarpeta(arch); }
            else
                { archivo = arch;  AbrirArchivo(arch); }
        }

        // Método para abrir una carpeta
        private void CargarCarpeta(string dir)
        {
            // Obtener la ruta de la carpeta
            string carpetaPersonal = dir;

            listViewArchivos.Items.Clear();
            imageListSmall.Images.Clear();
            imageListLarge.Images.Clear();

            // Configurar tamaños de iconos según el estilo de vista
            imageListSmall.ImageSize = new Size(16, 16);
            imageListLarge.ImageSize = new Size(32, 32);

            // Diccionario para almacenar iconos únicos según la extensión del archivo
            Dictionary<string, int> extensionToImageIndex = new Dictionary<string, int>();

            // Icono predeterminado en caso de error
            Icon defaultIcon = SystemIcons.Application;
            imageListSmall.Images.Add(ResizeIcon(defaultIcon, imageListSmall.ImageSize));
            imageListLarge.Images.Add(ResizeIcon(defaultIcon, imageListLarge.ImageSize));
            int defaultIconIndex = 0;

            // Cargar icono de carpeta desde explorer.exe
            Icon folderIcon = Icon.ExtractAssociatedIcon(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\explorer.exe");
            imageListSmall.Images.Add(ResizeIcon(folderIcon, imageListSmall.ImageSize));
            imageListLarge.Images.Add(ResizeIcon(folderIcon, imageListLarge.ImageSize));
            int folderIconIndex = imageListSmall.Images.Count - 1;

            // Obtener los archivos y carpetas en la carpeta especificada
            var directorio = new DirectoryInfo(carpetaPersonal);
            var elementos = directorio.GetFileSystemInfos();

            // Agregar los elementos al ListView y obtener iconos
            foreach (var elemento in elementos)
            {
                ListViewItem item = new ListViewItem(elemento.Name);

                // Añadir tipo (Carpeta o Archivo)
                item.SubItems.Add(elemento.Attributes.HasFlag(FileAttributes.Directory) ? "Carpeta" : "Archivo");

                // Añadir tamaño si es un archivo
                if (!elemento.Attributes.HasFlag(FileAttributes.Directory))
                {
                    // Obtener el tamaño del archivo y añadirlo como subelemento
                    long fileSize = ((FileInfo)elemento).Length;
                    item.SubItems.Add($"{fileSize / 1024} KB");  // Tamaño en KB
                    string extension = Path.GetExtension(elemento.Name).ToLower();

                    // Obtener o agregar el icono para la extensión del archivo
                    if (!extensionToImageIndex.ContainsKey(extension))
                    {
                        try
                        {
                            // Crear archivo temporal para extraer el icono
                            string tempFileName = Path.ChangeExtension(Path.GetTempFileName(), extension);
                            using (File.Create(tempFileName)) { } // Crear archivo vacío con esa extensión

                            Icon icon = Icon.ExtractAssociatedIcon(tempFileName);
                            if (icon != null)
                            {
                                // Redimensionar icono para ambos ImageLists
                                imageListSmall.Images.Add(ResizeIcon(icon, imageListSmall.ImageSize));
                                imageListLarge.Images.Add(ResizeIcon(icon, imageListLarge.ImageSize));
                                extensionToImageIndex[extension] = imageListSmall.Images.Count - 1;
                            }
                            else
                            {
                                extensionToImageIndex[extension] = defaultIconIndex;
                            }

                            // Eliminar el archivo temporal
                            File.Delete(tempFileName);
                        }
                        catch
                        {
                            extensionToImageIndex[extension] = defaultIconIndex;
                        }
                    }

                    // Asignar el icono correspondiente al ListViewItem
                    item.ImageIndex = extensionToImageIndex[extension];
                }
                else
                {
                    // Para carpetas, asignar el icono de carpeta específico
                    item.ImageIndex = folderIconIndex;
                    item.SubItems.Add(""); // Añadir columna vacía para el tamaño
                }

                // Añadir fecha de modificación
                item.SubItems.Add(elemento.LastWriteTime.ToString("dd/MM/yyyy HH:mm"));

                // Añadir ruta completa
                item.SubItems.Add(elemento.FullName);

                // Agregar el ítem al ListView
                listViewArchivos.Items.Add(item);
            }
        }


        public void AbrirArchivo(string arch)
        {
            try
            {
                // Limpia el ListView antes de agregar nuevos elementos
                listViewArchivos.Items.Clear();
                imageListSmall.Images.Clear();
                imageListLarge.Images.Clear();

                // Configurar tamaños de iconos según el estilo de vista
                imageListSmall.ImageSize = new Size(16, 16);
                imageListLarge.ImageSize = new Size(32, 32);  // Ajusta según el estilo del ListView o tu preferencia

                // Diccionario para almacenar iconos únicos según la extensión del archivo
                Dictionary<string, int> extensionToImageIndex = new Dictionary<string, int>();

                // Icono predeterminado en caso de error
                Icon defaultIcon = SystemIcons.Application;
                imageListSmall.Images.Add(ResizeIcon(defaultIcon, imageListSmall.ImageSize));
                imageListLarge.Images.Add(ResizeIcon(defaultIcon, imageListLarge.ImageSize));
                int defaultIconIndex = 0;

                // Cargar icono de carpeta desde Shell32.dll
                Icon folderIcon = Icon.ExtractAssociatedIcon(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\explorer.exe");
                imageListSmall.Images.Add(ResizeIcon(folderIcon, imageListSmall.ImageSize));
                imageListLarge.Images.Add(ResizeIcon(folderIcon, imageListLarge.ImageSize));
                int folderIconIndex = imageListSmall.Images.Count - 1;

                // Determinar el tipo de archivo a partir de la extensión
                using (var stream = File.OpenRead(arch))
                {
                    IArchive archive = ArchiveFactory.Open(stream);

                    if (archive != null)
                    {
                        // Recorrer cada entrada en el archivo
                        foreach (var entry in archive.Entries)
                        {
                            string extension = Path.GetExtension(entry.Key).ToLower();
                            bool isDirectory = entry.IsDirectory;

                            // Crear un nuevo ListViewItem para cada entrada
                            var item = new ListViewItem(entry.Key);
                            item.SubItems.Add(isDirectory ? "Carpeta" : "Archivo");

                            if (!isDirectory)
                            {
                                // Añadir tamaño si es un archivo
                                item.SubItems.Add($"{entry.Size / 1024} KB"); // Tamaño en KB

                                // Verificar si ya tenemos un icono para esta extensión
                                if (!extensionToImageIndex.ContainsKey(extension))
                                {
                                    try
                                    {
                                        // Crear archivo temporal para extraer el icono
                                        string tempFileName = Path.ChangeExtension(Path.GetTempFileName(), extension);
                                        using (File.Create(tempFileName)) { } // Crear archivo vacío con esa extensión

                                        Icon icon = Icon.ExtractAssociatedIcon(tempFileName);
                                        if (icon != null)
                                        {
                                            // Redimensionar icono para ambos ImageLists
                                            imageListSmall.Images.Add(ResizeIcon(icon, imageListSmall.ImageSize));
                                            imageListLarge.Images.Add(ResizeIcon(icon, imageListLarge.ImageSize));
                                            extensionToImageIndex[extension] = imageListSmall.Images.Count - 1;
                                        }
                                        else
                                        {
                                            extensionToImageIndex[extension] = defaultIconIndex;
                                        }

                                        // Eliminar el archivo temporal
                                        File.Delete(tempFileName);
                                    }
                                    catch
                                    {
                                        extensionToImageIndex[extension] = defaultIconIndex;
                                    }
                                }

                                // Asignar el icono correspondiente al ListViewItem
                                item.ImageIndex = extensionToImageIndex[extension];
                            }
                            else
                            {
                                // Si es una carpeta, usar el icono de carpeta
                                item.ImageIndex = folderIconIndex;
                                item.SubItems.Add(""); // Dejar tamaño en blanco para carpetas
                            }

                            // Añadir fecha de modificación y ruta (en este caso, la clave del archivo comprimido)
                            item.SubItems.Add(entry.LastModifiedTime?.ToString("dd/MM/yyyy HH:mm") ?? "N/A");
                            item.SubItems.Add(entry.Key);

                            // Agregar el ítem al ListView
                            listViewArchivos.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // Método para redimensionar el icono a un tamaño específico
        private Bitmap ResizeIcon(Icon icon, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawIcon(icon, new Rectangle(Point.Empty, size));
            }
            return bitmap;
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
                string archivos = (string)e.Data.GetData(DataFormats.FileDrop);
                AbrirArchivo(archivos);
                picLogo.Visible = false;
                lblArchivo.Visible = false;
            }
        }


        private void btnCDir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(directorio))
            {
                MessageBox.Show("Debe abrir un directorio para poder comprimirlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
                new CompressD(directorio, directorio, null).ShowDialog();

        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(archivo))
            {
                MessageBox.Show("Debe abrir un archivo para poder extraerlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
                new extractF(archivo).ShowDialog();
        }

        private void btnComprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(archivo))
            {
                MessageBox.Show("Debe abrir un archivo para poder comprimirlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
                new CompressF(archivo, null).ShowDialog();
        }

        private void abrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Archivos comprimidos|*.zip;*.7z;*.tar;*.gz;|Todos los archivos|*.*";
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                string archivo = openFile.FileName;
                AbrirArchivo(archivo);
                this.archivo = archivo;
                picLogo.Visible = false;
                lblArchivo.Visible = false;
            }
        }

        private void detallesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listViewArchivos.View = View.Details;
            detallesToolStripMenuItem.Checked = true;
            iconosGrandesToolStripMenuItem.Checked = false;
            iconosMedianosToolStripMenuItem.Checked = false;
            listaToolStripMenuItem.Checked = false;
            tituloToolStripMenuItem.Checked = false;
        }

        private void iconosGrandesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewArchivos.View = View.LargeIcon;
            detallesToolStripMenuItem.Checked = false;
            iconosGrandesToolStripMenuItem.Checked = true;
            iconosMedianosToolStripMenuItem.Checked = false;
            listaToolStripMenuItem.Checked = false;
            tituloToolStripMenuItem.Checked = false;
        }

        private void iconosMedianosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewArchivos.View = View.SmallIcon;
            detallesToolStripMenuItem.Checked = false;
            iconosGrandesToolStripMenuItem.Checked = false;
            iconosMedianosToolStripMenuItem.Checked = true;
            listaToolStripMenuItem.Checked = false;
            tituloToolStripMenuItem.Checked = false;
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewArchivos.View = View.List;
            detallesToolStripMenuItem.Checked = false;
            iconosGrandesToolStripMenuItem.Checked = false;
            iconosMedianosToolStripMenuItem.Checked = false;
            listaToolStripMenuItem.Checked = true;
            tituloToolStripMenuItem.Checked = false;
        }

        private void tituloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewArchivos.View = View.Tile;
            detallesToolStripMenuItem.Checked = false;
            iconosGrandesToolStripMenuItem.Checked = false;
            iconosMedianosToolStripMenuItem.Checked = false;
            listaToolStripMenuItem.Checked = false;
            tituloToolStripMenuItem.Checked = true;
        }

        private void btnAcerca_Click(object sender, EventArgs e)
        {
            new about().ShowDialog();
        }
    }
}
