using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpCompress.Archives;
using SharpCompress.Readers;

namespace _7ZipSharp
{
    public partial class fm : Form
    {
        private readonly Stack<BrowserLocation> backHistory = new Stack<BrowserLocation>();
        private readonly List<ArchiveEntry> archiveEntries = new List<ArchiveEntry>();
        private readonly Dictionary<string, int> extensionIcons = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private string directorio;
        private string archivo;
        private string archiveDirectory = string.Empty;
        private int folderIconIndex;
        private int genericFileIconIndex;
        private ContextMenuStrip fileContextMenu;
        private ToolStripMenuItem hashSha256MenuItem;
        private ToolStripMenuItem hashSha1MenuItem;
        private ToolStripMenuItem propertiesMenuItem;
        private TreeNode hoveredNavigationNode;

        public fm() : this(null, "/personal") { }

        public fm(string arch, string tip)
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            ConfigureFileList();
            ApplySavedView();
            AllowDrop = true;
            DragEnter += listViewArchivos_DragEnter;
            DragDrop += listViewArchivos_DragDrop;
            contentPanel.AllowDrop = true;
            contentPanel.DragEnter += listViewArchivos_DragEnter;
            contentPanel.DragDrop += listViewArchivos_DragDrop;
            emptyPanel.AllowDrop = true;
            emptyPanel.DragEnter += listViewArchivos_DragEnter;
            emptyPanel.DragDrop += listViewArchivos_DragDrop;
            InitializeIcons();
            ConfigureNavigationTree();
            addressBox.Text = Localization.TranslateText("Inicio");
            UpdateCommands();
            FormClosed += fm_FormClosed;

            string command = tip ?? string.Empty;
            if (command.Contains("/personal"))
            {
                ShowHome();
            }
            else if (command.Contains("/openD") && Directory.Exists(arch))
            {
                NavigateToFolder(arch, false);
            }
            else if (!string.IsNullOrWhiteSpace(arch) && File.Exists(arch))
            {
                OpenPath(arch, false);
            }
            else
            {
                ShowHome();
            }

            Localization.Apply(this);
            ProductUi.Apply(this);
            RefreshLanguagePreference();
            spanishLanguageItem.Checked = !Localization.IsEnglish;
            englishLanguageItem.Checked = Localization.IsEnglish;
        }

        private void ConfigureFileList()
        {
            listViewArchivos.View = View.Details;
            listViewArchivos.MultiSelect = true;
            listViewArchivos.GridLines = false;
            listViewArchivos.FullRowSelect = true;
            listViewArchivos.HideSelection = false;
            listViewArchivos.SelectedIndexChanged += (s, e) => UpdateCommands();
            listViewArchivos.Resize += (s, e) => ResizeNameColumn();
            listViewArchivos.ColumnClick += (s, e) => SortRows(e.Column);
            ConfigureFileContextMenu();
            ResizeNameColumn();
        }

        private void ConfigureFileContextMenu()
        {
            fileContextMenu = new ContextMenuStrip();
            hashSha256MenuItem = new ToolStripMenuItem("Calcular SHA-256", null, hashMenuItem_Click) { Tag = "SHA256" };
            hashSha1MenuItem = new ToolStripMenuItem("Calcular SHA-1", null, hashMenuItem_Click) { Tag = "SHA1" };
            propertiesMenuItem = new ToolStripMenuItem("Propiedades", null, propertiesMenuItem_Click);
            fileContextMenu.Items.Add(hashSha256MenuItem);
            fileContextMenu.Items.Add(hashSha1MenuItem);
            fileContextMenu.Items.Add(new ToolStripSeparator());
            fileContextMenu.Items.Add(propertiesMenuItem);
            fileContextMenu.Opening += fileContextMenu_Opening;
            listViewArchivos.ContextMenuStrip = fileContextMenu;
            listViewArchivos.MouseDown += listViewArchivos_MouseDown;
        }

        private void listViewArchivos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            ListViewItem hit = listViewArchivos.GetItemAt(e.X, e.Y);
            if (hit != null && !hit.Selected)
            {
                listViewArchivos.SelectedItems.Clear();
                hit.Selected = true;
            }
        }

        private void fileContextMenu_Opening(object sender, CancelEventArgs e)
        {
            bool canHash = listViewArchivos.SelectedItems.Count == 1 && IsHashable(listViewArchivos.SelectedItems[0].Tag);
            hashSha256MenuItem.Enabled = canHash;
            hashSha1MenuItem.Enabled = canHash;
            propertiesMenuItem.Enabled = listViewArchivos.SelectedItems.Count == 1;
            e.Cancel = listViewArchivos.SelectedItems.Count == 0;
        }

        private static bool IsHashable(object tag)
        {
            string path = tag as string;
            return (path != null && File.Exists(path)) || (tag is ArchiveEntry && !((ArchiveEntry)tag).IsDirectory);
        }

        private async void hashMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewArchivos.SelectedItems.Count != 1) return;
            ListViewItem selected = listViewArchivos.SelectedItems[0];
            string algorithm = (string)((ToolStripItem)sender).Tag;
            try
            {
                UseWaitCursor = true;
                hashSha256MenuItem.Enabled = hashSha1MenuItem.Enabled = false;
                string hash = await Task.Run(() => ComputeSelectedHash(selected.Tag, algorithm));
                Clipboard.SetText(hash);
                _7ZipSharp.Msg.AppMessage.Show(this, algorithm + ":\r\n" + hash + "\r\n\r\nLa firma se copió al portapapeles.",
                    "SharpCompress", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex, "Calculating archive browser hash");
                ShowError("No se pudo calcular la firma. " + ex.Message);
            }
            finally
            {
                UseWaitCursor = false;
                fileContextMenu_Opening(fileContextMenu, new CancelEventArgs());
            }
        }

        private string ComputeSelectedHash(object tag, string algorithm)
        {
            using (HashAlgorithm hasher = algorithm == "SHA1" ? (HashAlgorithm)SHA1.Create() : SHA256.Create())
            {
                string filePath = tag as string;
                if (filePath != null)
                {
                    using (Stream stream = File.OpenRead(filePath))
                        return BitConverter.ToString(hasher.ComputeHash(stream)).Replace("-", string.Empty);
                }

                ArchiveEntry selected = tag as ArchiveEntry;
                if (selected == null || string.IsNullOrEmpty(archivo)) throw new InvalidOperationException("No se seleccionó un archivo.");
                using (Stream archiveFile = File.OpenRead(archivo))
                using (IArchive archive = ArchiveFactory.OpenArchive(archiveFile, new ReaderOptions()))
                {
                    IArchiveEntry entry = archive.Entries.FirstOrDefault(item =>
                        string.Equals(NormalizeArchivePath(item.Key), selected.Path, StringComparison.OrdinalIgnoreCase));
                    if (entry == null) throw new FileNotFoundException("No se encontró la entrada en el archivo.");
                    using (Stream content = entry.OpenEntryStream())
                        return BitConverter.ToString(hasher.ComputeHash(content)).Replace("-", string.Empty);
                }
            }
        }

        private void propertiesMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewArchivos.SelectedItems.Count != 1) return;
            ListViewItem item = listViewArchivos.SelectedItems[0];
            string details;
            string path = item.Tag as string;
            if (path != null)
            {
                FileSystemInfo info = Directory.Exists(path) ? (FileSystemInfo)new DirectoryInfo(path) : new FileInfo(path);
                info.Refresh();
                string size = info is FileInfo ? FormatSize(((FileInfo)info).Length) : FormatSize(GetDirectorySize(path));
                details = "Nombre: " + info.Name + "\r\nTipo: " + (info is DirectoryInfo ? "Carpeta" : GetFileType(info.Name)) +
                    "\r\nTamaño: " + size + "\r\nModificado: " + info.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss") +
                    "\r\nRuta: " + info.FullName;
            }
            else
            {
                ArchiveEntry entry = (ArchiveEntry)item.Tag;
                details = "Nombre: " + entry.Name + "\r\nTipo: " + (entry.IsDirectory ? "Carpeta" : GetFileType(entry.Name)) +
                    "\r\nTamaño: " + (entry.IsDirectory ? "—" : FormatSize(entry.Size)) +
                    "\r\nModificado: " + (entry.Modified.HasValue ? entry.Modified.Value.ToString("dd/MM/yyyy HH:mm:ss") : "—") +
                    "\r\nRuta: " + archivo + "\\" + entry.Path.Replace('/', '\\');
            }
            _7ZipSharp.Msg.AppMessage.Show(this, details, "Propiedades", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static long GetDirectorySize(string path)
        {
            long size = 0;
            foreach (string file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
            {
                try { size += new FileInfo(file).Length; }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }
            }
            return size;
        }

        private void ResizeNameColumn()
        {
            if (listViewArchivos.Columns.Count == 0) return;
            int fixedWidth = 105 + 115 + 155 + SystemInformation.VerticalScrollBarWidth + 8;
            listViewArchivos.Columns[0].Width = Math.Max(220, listViewArchivos.ClientSize.Width - fixedWidth);
        }

        private void SortRows(int column)
        {
            listViewArchivos.ListViewItemSorter = new ListViewRowComparer(column);
            listViewArchivos.Sort();
        }

        private void ConfigureNavigationTree()
        {
            navigationTree.BackColor = Color.FromArgb(247, 249, 251);
            navigationTree.ForeColor = Color.FromArgb(43, 55, 69);
            navigationTree.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular);
            navigationTree.ImageList = imageListSmall;
            navigationTree.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            navigationTree.FullRowSelect = true;
            navigationTree.HideSelection = false;
            navigationTree.Indent = 22;
            navigationTree.ItemHeight = 38;
            navigationTree.ShowLines = false;
            navigationTree.ShowPlusMinus = false;
            navigationTree.ShowRootLines = false;
            navigationTree.DrawNode += navigationTree_DrawNode;
            navigationTree.MouseDown += navigationTree_MouseDown;
            navigationTree.MouseMove += navigationTree_MouseMove;
            navigationTree.MouseLeave += navigationTree_MouseLeave;

            navigationTree.BeginUpdate();
            navigationTree.Nodes.Clear();

            TreeNode favorites = navigationTree.Nodes.Add("Carpetas frecuentes");
            AddKnownFolder(favorites, "Escritorio", Environment.SpecialFolder.DesktopDirectory);
            AddKnownFolder(favorites, "Documentos", Environment.SpecialFolder.MyDocuments);
            AddKnownFolder(favorites, "Imágenes", Environment.SpecialFolder.MyPictures);
            string downloads = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            if (Directory.Exists(downloads)) AddFolderNode(favorites, "Descargas", downloads);
            favorites.Expand();

            TreeNode computer = navigationTree.Nodes.Add("Este equipo");
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                try
                {
                    if (!drive.IsReady) continue;
                    string label = string.IsNullOrWhiteSpace(drive.VolumeLabel)
                        ? drive.Name
                        : string.Format("{0} ({1})", drive.VolumeLabel, drive.Name.TrimEnd('\\'));
                    AddFolderNode(computer, label, drive.RootDirectory.FullName);
                }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }
            }
            computer.Expand();
            navigationTree.EndUpdate();
        }

        private void AddKnownFolder(TreeNode parent, string label, Environment.SpecialFolder folder)
        {
            string path = Environment.GetFolderPath(folder);
            if (Directory.Exists(path)) AddFolderNode(parent, label, path);
        }

        private void AddFolderNode(TreeNode parent, string label, string path)
        {
            var node = new TreeNode(label)
            {
                Tag = path,
                ImageIndex = folderIconIndex,
                SelectedImageIndex = folderIconIndex
            };
            try
            {
                if (Directory.EnumerateDirectories(path).Any()) node.Nodes.Add(new TreeNode(""));
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
            parent.Nodes.Add(node);
        }

        private void navigationTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            string path = e.Node.Tag as string;
            if (string.IsNullOrEmpty(path) || e.Node.Nodes.Count == 0 || e.Node.Nodes[0].Tag != null) return;

            e.Node.Nodes.Clear();
            try
            {
                foreach (string child in Directory.EnumerateDirectories(path).OrderBy(value => value, StringComparer.CurrentCultureIgnoreCase))
                    AddFolderNode(e.Node, Path.GetFileName(child), child);
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
        }

        private void navigationTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag as string;
            if (!string.IsNullOrEmpty(path) && Directory.Exists(path)) NavigateToFolder(path, true);
        }

        private void navigationTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            TreeNode node = navigationTree.GetNodeAt(e.Location);
            if (node == null) return;

            int expanderX = 7 + node.Level * navigationTree.Indent;
            if (node.Nodes.Count > 0 && e.X >= expanderX - 4 && e.X <= expanderX + 15)
            {
                if (node.IsExpanded) node.Collapse();
                else node.Expand();
                return;
            }

            navigationTree.SelectedNode = node;
        }

        private void navigationTree_MouseMove(object sender, MouseEventArgs e)
        {
            TreeNode node = navigationTree.GetNodeAt(e.Location);
            if (ReferenceEquals(node, hoveredNavigationNode)) return;
            TreeNode previous = hoveredNavigationNode;
            hoveredNavigationNode = node;
            InvalidateNavigationNode(previous);
            InvalidateNavigationNode(hoveredNavigationNode);
        }

        private void navigationTree_MouseLeave(object sender, EventArgs e)
        {
            TreeNode previous = hoveredNavigationNode;
            hoveredNavigationNode = null;
            InvalidateNavigationNode(previous);
        }

        private void InvalidateNavigationNode(TreeNode node)
        {
            if (node != null && !navigationTree.IsDisposed && navigationTree.IsHandleCreated)
                navigationTree.Invalidate(new Rectangle(0, node.Bounds.Top, navigationTree.ClientSize.Width, navigationTree.ItemHeight));
        }

        private void navigationTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            TreeView tree = (TreeView)sender;
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle row = new Rectangle(5, e.Bounds.Top + 1,
                Math.Max(0, tree.ClientSize.Width - 10), tree.ItemHeight - 2);
            bool isSection = e.Node.Level == 0 && e.Node.Tag == null;
            bool isSelected = !isSection && e.Node == tree.SelectedNode;
            bool isHovered = !isSection && e.Node == hoveredNavigationNode && !isSelected;

            if (isSelected)
            {
                using (var path = CreateRoundedRectangle(row, 7))
                using (var brush = new SolidBrush(Color.FromArgb(255, 244, 204)))
                    graphics.FillPath(brush, path);
                using (var accent = new SolidBrush(Color.FromArgb(255, 215, 63)))
                    graphics.FillRectangle(accent, row.Left, row.Top + 7, 3, row.Height - 14);
            }
            else if (isHovered)
            {
                using (var path = CreateRoundedRectangle(row, 7))
                using (var brush = new SolidBrush(Color.FromArgb(236, 241, 246)))
                    graphics.FillPath(brush, path);
            }

            int expanderX = 7 + e.Node.Level * tree.Indent;
            int iconX = 25 + e.Node.Level * tree.Indent;
            if (e.Node.Nodes.Count > 0)
                DrawNavigationChevron(graphics, expanderX, row.Top + row.Height / 2, e.Node.IsExpanded);

            if (isSection)
                DrawNavigationSectionIcon(graphics, e.Node.Text, new Rectangle(iconX, row.Top + 9, 20, 20));
            else if (tree.ImageList != null && e.Node.ImageIndex >= 0 && e.Node.ImageIndex < tree.ImageList.Images.Count)
                tree.ImageList.Draw(graphics, iconX, row.Top + (row.Height - tree.ImageList.ImageSize.Height) / 2, e.Node.ImageIndex);

            int textX = iconX + 28;
            Rectangle textBounds = new Rectangle(textX, row.Top, Math.Max(0, row.Right - textX - 8), row.Height);
            bool selected = isSelected;
            string text = isSection ? e.Node.Text.ToUpperInvariant() : e.Node.Text;
            using (var font = new Font("Segoe UI", isSection ? 8.25F : 9.25F,
                isSection || selected ? FontStyle.Bold : FontStyle.Regular))
            {
                Color textColor = isSection
                    ? Color.FromArgb(107, 120, 135)
                    : Color.FromArgb(43, 55, 69);
                TextRenderer.DrawText(graphics, text, font, textBounds, textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
            }
        }

        private static GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static void DrawNavigationChevron(Graphics graphics, int x, int y, bool expanded)
        {
            Point[] points = expanded
                ? new[] { new Point(x - 3, y - 1), new Point(x, y + 2), new Point(x + 3, y - 1) }
                : new[] { new Point(x - 1, y - 3), new Point(x + 2, y), new Point(x - 1, y + 3) };
            using (var pen = new Pen(Color.FromArgb(120, 134, 150), 1.7F))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                graphics.DrawLines(pen, points);
            }
        }

        private static void DrawNavigationSectionIcon(Graphics graphics, string title, Rectangle bounds)
        {
            using (var pen = new Pen(Color.FromArgb(111, 127, 145), 1.7F))
            using (var fill = new SolidBrush(Color.FromArgb(111, 127, 145)))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                if (string.Equals(title, "Este equipo", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(title, "This PC", StringComparison.OrdinalIgnoreCase))
                {
                    Rectangle screen = new Rectangle(bounds.X + 2, bounds.Y + 2, 16, 12);
                    graphics.DrawRectangle(pen, screen);
                    graphics.DrawLine(pen, bounds.X + 10, bounds.Y + 14, bounds.X + 10, bounds.Y + 17);
                    graphics.DrawLine(pen, bounds.X + 6, bounds.Y + 18, bounds.X + 14, bounds.Y + 18);
                }
                else
                {
                    PointF center = new PointF(bounds.X + bounds.Width / 2F, bounds.Y + bounds.Height / 2F);
                    var star = new PointF[10];
                    for (int i = 0; i < star.Length; i++)
                    {
                        double angle = -Math.PI / 2 + i * Math.PI / 5;
                        float radius = i % 2 == 0 ? 8.5F : 3.8F;
                        star[i] = new PointF(center.X + (float)Math.Cos(angle) * radius,
                            center.Y + (float)Math.Sin(angle) * radius);
                    }
                    graphics.FillPolygon(fill, star);
                }
            }
        }

        private void InitializeIcons()
        {
            imageListSmall.Images.Clear();
            imageListLarge.Images.Clear();
            extensionIcons.Clear();
            AddIconPair(SystemIcons.Application);
            genericFileIconIndex = 0;
            folderIconIndex = 0;
            using (Icon folderIcon = GetShellIcon("folder", false, true))
            {
                if (folderIcon != null)
                {
                    AddIconPair(folderIcon);
                    folderIconIndex = imageListSmall.Images.Count - 1;
                }
            }
            if (folderIconIndex == 0) folderIconIndex = genericFileIconIndex;
        }

        private void AddIconPair(Icon icon)
        {
            imageListSmall.Images.Add(ResizeIcon(icon, imageListSmall.ImageSize));
            imageListLarge.Images.Add(ResizeIcon(icon, imageListLarge.ImageSize));
        }

        private static Bitmap ResizeIcon(Icon icon, Size size)
        {
            var bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawIcon(icon, new Rectangle(Point.Empty, size));
            }
            return bitmap;
        }

        private int GetFileIconIndex(string path)
        {
            return GetFileIconIndex(path, File.Exists(path));
        }

        private int GetFileIconIndex(string path, bool useFilesystemPath)
        {
            string extension = Path.GetExtension(path) ?? string.Empty;
            string cacheKey = useFilesystemPath && (extension.Equals(".exe", StringComparison.OrdinalIgnoreCase) ||
                extension.Equals(".lnk", StringComparison.OrdinalIgnoreCase))
                ? Path.GetFullPath(path)
                : extension;
            int index;
            if (extensionIcons.TryGetValue(cacheKey, out index)) return index;

            using (Icon icon = GetShellIcon(path, useFilesystemPath, false))
            {
                if (icon != null)
                {
                    AddIconPair(icon);
                    index = imageListSmall.Images.Count - 1;
                    extensionIcons[cacheKey] = index;
                    return index;
                }
            }

            extensionIcons[cacheKey] = genericFileIconIndex;
            return genericFileIconIndex;
        }

        private static Icon GetShellIcon(string path, bool useFilesystemPath, bool directory)
        {
            const uint SHGFI_ICON = 0x00000100;
            const uint SHGFI_USEFILEATTRIBUTES = 0x00000010;
            const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
            const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
            var info = new ShellFileInfo();
            string queryPath = useFilesystemPath ? path :
                (directory ? "folder" : "SharpCompress" + (Path.GetExtension(path) ?? string.Empty));
            uint attributes = directory ? FILE_ATTRIBUTE_DIRECTORY : FILE_ATTRIBUTE_NORMAL;
            uint flags = SHGFI_ICON | (useFilesystemPath ? 0 : SHGFI_USEFILEATTRIBUTES);
            if (SHGetFileInfo(queryPath, attributes, ref info, (uint)Marshal.SizeOf(typeof(ShellFileInfo)), flags) == IntPtr.Zero || info.IconHandle == IntPtr.Zero)
                return null;
            try { return (Icon)Icon.FromHandle(info.IconHandle).Clone(); }
            finally { DestroyIcon(info.IconHandle); }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct ShellFileInfo
        {
            public IntPtr IconHandle;
            public int IconIndex;
            public uint Attributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string DisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] public string TypeName;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SHGetFileInfo(string path, uint fileAttributes, ref ShellFileInfo fileInfo, uint fileInfoSize, uint flags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr iconHandle);

        private void NavigateToFolder(string path, bool remember)
        {
            if (!Directory.Exists(path))
            {
                ShowError("No se puede abrir la carpeta seleccionada.");
                return;
            }
            if (remember) RememberCurrentLocation();

            try
            {
                directorio = Path.GetFullPath(path);
                archivo = null;
                archiveDirectory = string.Empty;
                archiveEntries.Clear();
                listViewArchivos.BeginUpdate();
                listViewArchivos.Items.Clear();
                InitializeIcons();

                foreach (FileSystemInfo entry in new DirectoryInfo(directorio).GetFileSystemInfos()
                    .OrderBy(item => item is DirectoryInfo ? 0 : 1)
                    .ThenBy(item => item.Name, StringComparer.CurrentCultureIgnoreCase))
                {
                    bool isDirectory = entry is DirectoryInfo;
                    long size = 0;
                    if (!isDirectory)
                    {
                        try { size = ((FileInfo)entry).Length; }
                        catch (IOException) { }
                        catch (UnauthorizedAccessException) { }
                    }
                    AddListRow(entry.Name, isDirectory ? "Carpeta" : GetFileType(entry.Name),
                        isDirectory ? string.Empty : FormatSize(size), entry.LastWriteTime.ToString("dd/MM/yyyy HH:mm"),
                        isDirectory ? folderIconIndex : GetFileIconIndex(entry.FullName, true), entry.FullName);
                }
                listViewArchivos.EndUpdate();
                addressBox.Text = directorio;
            addressBox.ReadOnly = false;
            goButton.Enabled = true;
                UpdateEmptyState();
                statusLabel.Text = Localization.TranslateText(string.Format("{0} elementos", listViewArchivos.Items.Count));
                Text = Path.GetFileName(directorio.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar))
                    + " — SharpCompress";
                UpdateCommands();
            }
            catch (Exception ex)
            {
                listViewArchivos.EndUpdate();
                ErrorLogger.Write(ex, "Reading a folder");
                ShowError("No se pudo leer la carpeta. " + ex.Message);
            }
        }

        private void OpenPath(string path, bool remember)
        {
            if (Directory.Exists(path))
            {
                NavigateToFolder(path, remember);
                return;
            }
            if (!File.Exists(path))
            {
                ShowError("No se encontró el archivo o la carpeta indicada.");
                return;
            }

            if (remember) RememberCurrentLocation();
            OpenArchive(path);
        }

        private void OpenArchive(string path)
        {
            try
            {
                var entries = new List<ArchiveEntry>();
                using (FileStream stream = File.OpenRead(path))
                using (IArchive archive = ArchiveFactory.OpenArchive(stream, new ReaderOptions()))
                {
                    foreach (IArchiveEntry entry in archive.Entries)
                    {
                        string key = NormalizeArchivePath(entry.Key);
                        if (string.IsNullOrEmpty(key)) continue;
                        entries.Add(new ArchiveEntry
                        {
                            Name = GetArchiveName(key),
                            Path = key,
                            IsDirectory = entry.IsDirectory,
                            Size = entry.Size,
                            Modified = entry.LastModifiedTime
                        });
                    }
                }

                archiveEntries.Clear();
                archiveEntries.AddRange(entries);
                archivo = Path.GetFullPath(path);
                directorio = null;
                archiveDirectory = string.Empty;
                ShowArchiveFolder(string.Empty, false);
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex, "Opening an archive");
                ShowError("No se pudo abrir el archivo comprimido. " + ex.Message);
            }
        }

        private void ShowArchiveFolder(string folder, bool remember)
        {
            if (remember) RememberCurrentLocation();
            archiveDirectory = NormalizeArchivePath(folder);
            string prefix = string.IsNullOrEmpty(archiveDirectory) ? string.Empty : archiveDirectory + "/";
            var children = new Dictionary<string, ArchiveEntry>(StringComparer.OrdinalIgnoreCase);

            foreach (ArchiveEntry entry in archiveEntries)
            {
                if (!entry.Path.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) continue;
                string relative = entry.Path.Substring(prefix.Length);
                if (string.IsNullOrEmpty(relative)) continue;
                int separator = relative.IndexOf('/');
                if (separator >= 0)
                {
                    string childName = relative.Substring(0, separator);
                    string childPath = prefix + childName;
                    if (!children.ContainsKey(childPath))
                    {
                        children.Add(childPath, new ArchiveEntry { Name = childName, Path = childPath, IsDirectory = true });
                    }
                }
                else
                {
                    children[entry.Path] = entry;
                }
            }

            listViewArchivos.BeginUpdate();
            listViewArchivos.Items.Clear();
            InitializeIcons();
            foreach (ArchiveEntry entry in children.Values
                .OrderBy(item => item.IsDirectory ? 0 : 1)
                .ThenBy(item => item.Name, StringComparer.CurrentCultureIgnoreCase))
            {
                AddListRow(entry.Name, entry.IsDirectory ? "Carpeta" : GetFileType(entry.Name),
                    entry.IsDirectory ? string.Empty : FormatSize(entry.Size),
                    entry.Modified.HasValue ? entry.Modified.Value.ToString("dd/MM/yyyy HH:mm") : "—",
                    entry.IsDirectory ? folderIconIndex : GetFileIconIndex(entry.Name, false), entry);
            }
            listViewArchivos.EndUpdate();
            UpdateEmptyState();
            addressBox.Text = string.IsNullOrEmpty(archiveDirectory)
                ? archivo
                : archivo + "  ›  " + archiveDirectory.Replace('/', Path.DirectorySeparatorChar);
            addressBox.ReadOnly = true;
            goButton.Enabled = false;
            statusLabel.Text = Localization.TranslateText(string.Format("{0} elementos", listViewArchivos.Items.Count));
            Text = Path.GetFileName(archivo) + " — SharpCompress";
            UpdateCommands();
        }

        private void AddListRow(string name, string type, string size, string modified, int imageIndex, object tag)
        {
            var item = new ListViewItem(name, imageIndex) { Tag = tag };
            item.SubItems.Add(type);
            item.SubItems.Add(size);
            item.SubItems.Add(modified);
            listViewArchivos.Items.Add(item);
        }

        private void listViewArchivos_ItemActivate(object sender, EventArgs e)
        {
            if (listViewArchivos.SelectedItems.Count == 0) return;
            ListViewItem item = listViewArchivos.SelectedItems[0];
            string filePath = item.Tag as string;
            if (filePath != null)
            {
                if (Directory.Exists(filePath)) NavigateToFolder(filePath, true);
                else if (File.Exists(filePath) && IsArchive(filePath)) OpenPath(filePath, true);
                else if (File.Exists(filePath))
                {
                    try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true }); }
                    catch (Exception ex)
                    {
                        ErrorLogger.Write(ex, "Opening a selected archive entry");
                        ShowError("No se pudo abrir el archivo. " + ex.Message);
                    }
                }
                return;
            }

            ArchiveEntry archiveEntry = item.Tag as ArchiveEntry;
            if (archiveEntry != null && archiveEntry.IsDirectory)
                ShowArchiveFolder(archiveEntry.Path, true);
        }

        private void ShowHome()
        {
            directorio = null;
            archivo = null;
            archiveDirectory = string.Empty;
            archiveEntries.Clear();
            listViewArchivos.Items.Clear();
            addressBox.Text = Localization.TranslateText("Inicio");
            addressBox.ReadOnly = false;
            goButton.Enabled = true;
            UpdateEmptyState();
            statusLabel.Text = Localization.TranslateText("Listo");
            Text = "SharpCompress";
            UpdateCommands();
        }

        private void RememberCurrentLocation()
        {
            if (!string.IsNullOrEmpty(directorio)) backHistory.Push(new BrowserLocation { FolderPath = directorio });
            else if (!string.IsNullOrEmpty(archivo)) backHistory.Push(new BrowserLocation { ArchivePath = archivo, ArchiveFolder = archiveDirectory });
        }

        private void GoBack()
        {
            if (backHistory.Count == 0) return;
            BrowserLocation location = backHistory.Pop();
            if (!string.IsNullOrEmpty(location.FolderPath)) NavigateToFolder(location.FolderPath, false);
            else if (!string.IsNullOrEmpty(location.ArchivePath))
            {
                if (!string.Equals(archivo, location.ArchivePath, StringComparison.OrdinalIgnoreCase)) OpenArchive(location.ArchivePath);
                ShowArchiveFolder(location.ArchiveFolder, false);
            }
        }

        private void GoUp()
        {
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(archiveDirectory))
            {
                int separator = archiveDirectory.LastIndexOf('/');
                ShowArchiveFolder(separator < 0 ? string.Empty : archiveDirectory.Substring(0, separator), true);
            }
            else if (!string.IsNullOrEmpty(directorio))
            {
                DirectoryInfo parent = Directory.GetParent(directorio);
                if (parent != null) NavigateToFolder(parent.FullName, true);
            }
        }

        private void RefreshLocation()
        {
            if (!string.IsNullOrEmpty(directorio)) NavigateToFolder(directorio, false);
            else if (!string.IsNullOrEmpty(archivo))
            {
                string currentArchive = archivo;
                string currentPath = archiveDirectory;
                OpenArchive(currentArchive);
                ShowArchiveFolder(currentPath, false);
            }
        }

        private void UpdateEmptyState()
        {
            bool empty = listViewArchivos.Items.Count == 0;
            emptyPanel.Visible = empty;
            if (!empty) return;
            lblArchivo.Text = string.IsNullOrEmpty(directorio) && string.IsNullOrEmpty(archivo)
                ? "Abre un archivo o selecciona una carpeta para explorar."
                : "Esta ubicación no contiene elementos.";
        }

        private void UpdateCommands()
        {
            btnExtraer.Enabled = !string.IsNullOrEmpty(archivo);
            btnExtraerTodo.Enabled = !string.IsNullOrEmpty(archivo);
            btnVerificar.Enabled = !string.IsNullOrEmpty(archivo);
            btnExtraerSeleccion.Enabled = !string.IsNullOrEmpty(archivo) &&
                listViewArchivos.SelectedItems.Count > 0 &&
                listViewArchivos.SelectedItems.Cast<ListViewItem>().All(item => item.Tag is ArchiveEntry);
            btnCDir.Enabled = !string.IsNullOrEmpty(directorio);
            bool selectionIsCompressible = listViewArchivos.SelectedItems.Count > 0 &&
                listViewArchivos.SelectedItems.Cast<ListViewItem>()
                    .All(item => item.Tag is string path && (File.Exists(path) || Directory.Exists(path)));
            btnComprimir.Enabled = !string.IsNullOrEmpty(directorio) && selectionIsCompressible;
            backButton.Enabled = backHistory.Count > 0;
            upButton.Enabled = (!string.IsNullOrEmpty(directorio) && Directory.GetParent(directorio) != null)
                || (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(archiveDirectory));
            goButton.Enabled = !addressBox.ReadOnly;
        }

        private void abrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Title = "Abrir archivo comprimido",
                Filter = "Archivos comprimidos|*.7z;*.scz;*.scz.*;*.zip;*.rar;*.tar;*.gz;*.bz2;*.xz;*.cab;*.wim;*.lz;*.lzma;*.arj;*.lzh;*.lha;*.iso;*.chm;*.rpm;*.deb;*.cpio;*.z;*.lzip;*.lz4;*.zst|Todos los archivos|*.*",
                CheckFileExists = true
            })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK) OpenPath(dialog.FileName, true);
            }
        }

        private void btnCDir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(directorio)) return;
            using (var dialog = new CompressForm(new[] { directorio }, null)) dialog.ShowDialog(this);
        }

        private void btnComprimir_Click(object sender, EventArgs e)
        {
            string[] selectedPaths = listViewArchivos.SelectedItems.Cast<ListViewItem>()
                .Select(item => item.Tag as string)
                .Where(path => !string.IsNullOrEmpty(path))
                .ToArray();
            if (selectedPaths.Length == 0) return;

            if (selectedPaths.Length > 0 && selectedPaths.All(path => File.Exists(path) || Directory.Exists(path)))
            {
                using (var dialog = new CompressForm(selectedPaths, null)) dialog.ShowDialog(this);
            }
        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(archivo)) return;
            using (var dialog = new extractF(archivo, null, null, true)) dialog.ShowDialog(this);
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(archivo)) return;
            using (var dialog = new VerifyArchiveForm(archivo)) dialog.ShowDialog(this);
        }

        private void btnExtraerSeleccion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(archivo)) return;
            string[] selectedEntryPaths = GetSelectedArchiveEntryPaths();
            if (selectedEntryPaths.Length == 0)
            {
                ShowError("Selecciona uno o varios elementos del archivo comprimido.");
                return;
            }

            using (var dialog = new extractF(archivo, null, selectedEntryPaths, true))
                dialog.ShowDialog(this);
        }

        private string[] GetSelectedArchiveEntryPaths()
        {
            var paths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (ListViewItem selectedItem in listViewArchivos.SelectedItems)
            {
                ArchiveEntry selectedEntry = selectedItem.Tag as ArchiveEntry;
                if (selectedEntry == null) continue;

                string selectedPath = NormalizeArchivePath(selectedEntry.Path);
                if (selectedEntry.IsDirectory)
                {
                    string prefix = selectedPath + "/";
                    foreach (ArchiveEntry child in archiveEntries.Where(entry =>
                        entry.Path.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)))
                        paths.Add(child.Path);
                    paths.Add(selectedPath);
                }
                else
                {
                    paths.Add(selectedPath);
                }
            }
            return paths.ToArray();
        }

        private void btnExtraerTodo_Click(object sender, EventArgs e)
        {
            btnExtraer_Click(sender, e);
        }

        private void btnAcerca_Click(object sender, EventArgs e)
        {
            using (var dialog = new about()) dialog.ShowDialog(this);
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SettingsForm()) dialog.ShowDialog(this);
        }

        internal void RefreshLanguagePreference()
        {
            bool english = Localization.IsEnglish;
            spanishLanguageItem.Checked = !english;
            englishLanguageItem.Checked = english;
        }

        internal void RefreshApplicationPreferences()
        {
            ApplySavedView();
            RefreshLanguagePreference();
        }

        private void backButton_Click(object sender, EventArgs e) { GoBack(); }
        private void upButton_Click(object sender, EventArgs e) { GoUp(); }
        private void refreshButton_Click(object sender, EventArgs e) { RefreshLocation(); }
        private void goButton_Click(object sender, EventArgs e) { NavigateFromAddress(); }

        private void addressBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            NavigateFromAddress();
        }

        private void NavigateFromAddress()
        {
            string path = addressBox.Text.Trim();
            if (Directory.Exists(path) || File.Exists(path)) OpenPath(path, true);
            else ShowError("Escribe una ruta válida a una carpeta o archivo comprimido.");
        }

        private void detallesToolStripMenuItem_Click_1(object sender, EventArgs e) { SetView(View.Details, detallesToolStripMenuItem); }
        private void iconosGrandesToolStripMenuItem_Click(object sender, EventArgs e) { SetView(View.LargeIcon, iconosGrandesToolStripMenuItem); }
        private void iconosMedianosToolStripMenuItem_Click(object sender, EventArgs e) { SetView(View.SmallIcon, iconosMedianosToolStripMenuItem); }
        private void listaToolStripMenuItem_Click(object sender, EventArgs e) { SetView(View.List, listaToolStripMenuItem); }
        private void tituloToolStripMenuItem_Click(object sender, EventArgs e) { SetView(View.Tile, tituloToolStripMenuItem); }

        private void SetView(View view, ToolStripMenuItem selected)
        {
            listViewArchivos.View = view;
            foreach (ToolStripMenuItem item in new[] { detallesToolStripMenuItem, listaToolStripMenuItem,
                iconosMedianosToolStripMenuItem, iconosGrandesToolStripMenuItem, tituloToolStripMenuItem })
                item.Checked = item == selected;
        }

        private void ApplySavedView()
        {
            int savedView = _7ZipSharp.Properties.Settings.Default.BrowserView;
            View view = Enum.IsDefined(typeof(View), savedView) ? (View)savedView : View.Details;
            ToolStripMenuItem selected = view == View.List ? listaToolStripMenuItem
                : view == View.SmallIcon ? iconosMedianosToolStripMenuItem
                : view == View.LargeIcon ? iconosGrandesToolStripMenuItem
                : view == View.Tile ? tituloToolStripMenuItem : detallesToolStripMenuItem;
            SetView(view, selected);
        }

        private void fm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _7ZipSharp.Properties.Settings.Default.BrowserView = (int)listViewArchivos.View;
                _7ZipSharp.Properties.Settings.Default.Save();
            }
            catch (Exception ex) { ErrorLogger.Write(ex, "Saving browser preferences"); }
        }

        private void spanishLanguageItem_Click(object sender, EventArgs e)
        {
            Localization.SetLanguage("es");
            Localization.Apply(this);
            ProductUi.Apply(this);
            spanishLanguageItem.Checked = true;
            englishLanguageItem.Checked = false;
        }

        private void englishLanguageItem_Click(object sender, EventArgs e)
        {
            Localization.SetLanguage("en");
            Localization.Apply(this);
            ProductUi.Apply(this);
            spanishLanguageItem.Checked = false;
            englishLanguageItem.Checked = true;
        }

        private void listViewArchivos_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void listViewArchivos_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (paths == null || paths.Length == 0) return;
            paths = paths.Where(path => File.Exists(path) || Directory.Exists(path))
                .Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
            if (paths.Length == 0) return;

            if (paths.Length == 1 && Directory.Exists(paths[0]))
            {
                NavigateToFolder(paths[0], true);
                return;
            }
            if (paths.Length == 1 && IsArchive(paths[0]))
            {
                OpenPath(paths[0], true);
                return;
            }

            using (var dialog = new CompressForm(paths, null))
                dialog.ShowDialog(this);
        }

        private static string GetFileType(string name)
        {
            string extension = Path.GetExtension(name);
            return string.IsNullOrEmpty(extension) ? "Archivo" : extension.TrimStart('.').ToUpperInvariant() + " · Archivo";
        }

        private static string FormatSize(long size)
        {
            string[] units = { "B", "KB", "MB", "GB", "TB" };
            double value = size;
            int unit = 0;
            while (value >= 1024 && unit < units.Length - 1) { value /= 1024; unit++; }
            return unit == 0 ? string.Format("{0} {1}", size, units[unit]) : string.Format("{0:0.##} {1}", value, units[unit]);
        }

        private static bool IsArchive(string path)
        {
            string fileName = Path.GetFileName(path);
            int volumeMarker = fileName.LastIndexOf(".scz.", StringComparison.OrdinalIgnoreCase);
            if (volumeMarker >= 0)
            {
                string volumeNumber = fileName.Substring(volumeMarker + 5);
                if (volumeNumber.Length >= 3 && volumeNumber.All(char.IsDigit)) return true;
            }

            string extension = Path.GetExtension(path);
            return new[] { ".7z", ".scz", ".zip", ".rar", ".tar", ".gz", ".bz2", ".xz", ".cab", ".wim", ".lz", ".lzma", ".arj", ".lzh", ".lha", ".iso", ".chm", ".rpm", ".deb", ".cpio", ".z", ".lzip", ".lz4", ".zst" }
                .Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        private static string NormalizeArchivePath(string path)
        {
            return (path ?? string.Empty).Replace('\\', '/').Trim('/');
        }

        private static string GetArchiveName(string path)
        {
            int separator = path.LastIndexOf('/');
            return separator < 0 ? path : path.Substring(separator + 1);
        }

        private void ShowError(string message)
        {
            _7ZipSharp.Msg.AppMessage.Show(this, message, "SharpCompress", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private sealed class ArchiveEntry
        {
            public string Name { get; set; }
            public string Path { get; set; }
            public bool IsDirectory { get; set; }
            public long Size { get; set; }
            public DateTime? Modified { get; set; }
        }

        private sealed class BrowserLocation
        {
            public string FolderPath { get; set; }
            public string ArchivePath { get; set; }
            public string ArchiveFolder { get; set; }
        }

        private sealed class ListViewRowComparer : System.Collections.IComparer
        {
            private readonly int column;

            public ListViewRowComparer(int column)
            {
                this.column = column;
            }

            public int Compare(object x, object y)
            {
                var left = x as ListViewItem;
                var right = y as ListViewItem;
                if (left == null || right == null) return 0;
                int index = Math.Min(column, Math.Min(left.SubItems.Count - 1, right.SubItems.Count - 1));
                int result = StringComparer.CurrentCultureIgnoreCase.Compare(left.SubItems[index].Text, right.SubItems[index].Text);
                return result != 0 ? result : StringComparer.CurrentCultureIgnoreCase.Compare(left.Text, right.Text);
            }
        }
    }
}
