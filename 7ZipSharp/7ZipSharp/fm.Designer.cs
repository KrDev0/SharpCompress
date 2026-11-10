using MaterialSkin.Controls;
namespace _7ZipSharp
{
    partial class fm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnComprimir;
        private System.Windows.Forms.ToolStripMenuItem btnExtraer;
        private System.Windows.Forms.ToolStripMenuItem btnExtraerTodo;
        private System.Windows.Forms.ToolStripMenuItem btnExtraerSeleccion;
        private System.Windows.Forms.ToolStripMenuItem btnVerificar;
        private System.Windows.Forms.ToolStripMenuItem btnAcerca;
        private System.Windows.Forms.ToolStripMenuItem mnuVista;
        private System.Windows.Forms.ToolStripMenuItem detallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnCDir;
        private System.Windows.Forms.ToolStripMenuItem iconosGrandesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iconosMedianosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tituloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanishLanguageItem;
        private System.Windows.Forms.ToolStripMenuItem englishLanguageItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.Panel pathPanel;
        private MaterialSkin.Controls.MaterialFlatButton backButton;
        private MaterialSkin.Controls.MaterialFlatButton upButton;
        private MaterialSkin.Controls.MaterialFlatButton refreshButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField addressBox;
        private MaterialSkin.Controls.MaterialFlatButton goButton;
        private System.Windows.Forms.TableLayoutPanel browserLayout;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Label navigationHeading;
        private System.Windows.Forms.TreeView navigationTree;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.ListView listViewArchivos;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ColumnHeader columnHeaderModified;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.Panel emptyPanel;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm));
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.abrirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnComprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCDir = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExtraer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExtraerTodo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExtraerSeleccion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVerificar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVista = new System.Windows.Forms.ToolStripMenuItem();
            this.detallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconosMedianosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconosGrandesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tituloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAcerca = new System.Windows.Forms.ToolStripMenuItem();
            this.languageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishLanguageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishLanguageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathPanel = new System.Windows.Forms.Panel();
            this.backButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.upButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.refreshButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.addressBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.goButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.browserLayout = new System.Windows.Forms.TableLayoutPanel();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.navigationTree = new System.Windows.Forms.TreeView();
            this.navigationHeading = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.listViewArchivos = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.emptyPanel = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainLayout.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pathPanel.SuspendLayout();
            this.browserLayout.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.emptyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // mainLayout
            //
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.menuStrip1, 0, 0);
            this.mainLayout.Controls.Add(this.pathPanel, 0, 1);
            this.mainLayout.Controls.Add(this.browserLayout, 0, 2);
            this.mainLayout.Controls.Add(this.statusStrip, 0, 3);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.mainLayout.Size = new System.Drawing.Size(1160, 760);
            this.mainLayout.TabIndex = 0;
            //
            // menuStrip1
            //
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirArchivoToolStripMenuItem,
            this.btnComprimir,
            this.btnCDir,
            this.btnExtraer,
            this.mnuVista,
            this.btnAcerca,
            this.languageMenuItem,
            this.settingsMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 4, 8, 4);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1160, 70);
            this.menuStrip1.TabIndex = 1;
            //
            // abrirArchivoToolStripMenuItem
            //
            this.abrirArchivoToolStripMenuItem.AutoSize = false;
            this.abrirArchivoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirArchivoToolStripMenuItem.Image")));
            this.abrirArchivoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.abrirArchivoToolStripMenuItem.Name = "abrirArchivoToolStripMenuItem";
            this.abrirArchivoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.abrirArchivoToolStripMenuItem.Size = new System.Drawing.Size(110, 60);
            this.abrirArchivoToolStripMenuItem.Text = "Abrir archivo";
            this.abrirArchivoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.abrirArchivoToolStripMenuItem.Click += new System.EventHandler(this.abrirArchivoToolStripMenuItem_Click);
            //
            // btnComprimir
            //
            this.btnComprimir.AutoSize = false;
            this.btnComprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnComprimir.Image")));
            this.btnComprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnComprimir.Name = "btnComprimir";
            this.btnComprimir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.btnComprimir.Size = new System.Drawing.Size(110, 60);
            this.btnComprimir.Text = "Comprimir";
            this.btnComprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnComprimir.Click += new System.EventHandler(this.btnComprimir_Click);
            //
            // btnCDir
            //
            this.btnCDir.AutoSize = false;
            this.btnCDir.Image = ((System.Drawing.Image)(resources.GetObject("btnCDir.Image")));
            this.btnCDir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCDir.Name = "btnCDir";
            this.btnCDir.Size = new System.Drawing.Size(110, 60);
            this.btnCDir.Text = "Comprimir carpeta";
            this.btnCDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCDir.ToolTipText = "Comprimir la carpeta actual";
            this.btnCDir.Visible = false;
            this.btnCDir.Click += new System.EventHandler(this.btnCDir_Click);
            //
            // btnExtraer
            //
            this.btnExtraer.AutoSize = false;
            this.btnExtraer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExtraerTodo,
            this.btnExtraerSeleccion,
            this.btnVerificar});
            this.btnExtraer.Image = ((System.Drawing.Image)(resources.GetObject("btnExtraer.Image")));
            this.btnExtraer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.btnExtraer.Size = new System.Drawing.Size(110, 60);
            this.btnExtraer.Text = "Extraer";
            this.btnExtraer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExtraer.Click += new System.EventHandler(this.btnExtraer_Click);
            //
            // btnExtraerTodo
            //
            this.btnExtraerTodo.Name = "btnExtraerTodo";
            this.btnExtraerTodo.Size = new System.Drawing.Size(166, 22);
            this.btnExtraerTodo.Text = "Extraer todo";
            this.btnExtraerTodo.Click += new System.EventHandler(this.btnExtraerTodo_Click);
            //
            // btnExtraerSeleccion
            //
            this.btnExtraerSeleccion.Enabled = false;
            this.btnExtraerSeleccion.Name = "btnExtraerSeleccion";
            this.btnExtraerSeleccion.Size = new System.Drawing.Size(166, 22);
            this.btnExtraerSeleccion.Text = "Extraer selección";
            this.btnExtraerSeleccion.Click += new System.EventHandler(this.btnExtraerSeleccion_Click);
            //
            // btnVerificar
            //
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(166, 22);
            this.btnVerificar.Text = "Probar integridad";
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            //
            // mnuVista
            //
            this.mnuVista.AutoSize = false;
            this.mnuVista.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detallesToolStripMenuItem,
            this.listaToolStripMenuItem,
            this.iconosMedianosToolStripMenuItem,
            this.iconosGrandesToolStripMenuItem,
            this.tituloToolStripMenuItem});
            this.mnuVista.Image = ((System.Drawing.Image)(resources.GetObject("mnuVista.Image")));
            this.mnuVista.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuVista.Name = "mnuVista";
            this.mnuVista.Size = new System.Drawing.Size(110, 60);
            this.mnuVista.Text = "Vista";
            this.mnuVista.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            //
            // detallesToolStripMenuItem
            //
            this.detallesToolStripMenuItem.Checked = true;
            this.detallesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.detallesToolStripMenuItem.Name = "detallesToolStripMenuItem";
            this.detallesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.detallesToolStripMenuItem.Text = "Detalles";
            this.detallesToolStripMenuItem.Click += new System.EventHandler(this.detallesToolStripMenuItem_Click_1);
            //
            // listaToolStripMenuItem
            //
            this.listaToolStripMenuItem.Name = "listaToolStripMenuItem";
            this.listaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.listaToolStripMenuItem.Text = "Lista";
            this.listaToolStripMenuItem.Click += new System.EventHandler(this.listaToolStripMenuItem_Click);
            //
            // iconosMedianosToolStripMenuItem
            //
            this.iconosMedianosToolStripMenuItem.Name = "iconosMedianosToolStripMenuItem";
            this.iconosMedianosToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.iconosMedianosToolStripMenuItem.Text = "Iconos";
            this.iconosMedianosToolStripMenuItem.Click += new System.EventHandler(this.iconosMedianosToolStripMenuItem_Click);
            //
            // iconosGrandesToolStripMenuItem
            //
            this.iconosGrandesToolStripMenuItem.Name = "iconosGrandesToolStripMenuItem";
            this.iconosGrandesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.iconosGrandesToolStripMenuItem.Text = "Iconos grandes";
            this.iconosGrandesToolStripMenuItem.Click += new System.EventHandler(this.iconosGrandesToolStripMenuItem_Click);
            //
            // tituloToolStripMenuItem
            //
            this.tituloToolStripMenuItem.Name = "tituloToolStripMenuItem";
            this.tituloToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.tituloToolStripMenuItem.Text = "Mosaico";
            this.tituloToolStripMenuItem.Click += new System.EventHandler(this.tituloToolStripMenuItem_Click);
            //
            // btnAcerca
            //
            this.btnAcerca.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAcerca.AutoSize = false;
            this.btnAcerca.Image = ((System.Drawing.Image)(resources.GetObject("btnAcerca.Image")));
            this.btnAcerca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAcerca.Name = "btnAcerca";
            this.btnAcerca.Size = new System.Drawing.Size(110, 60);
            this.btnAcerca.Text = "Acerca de";
            this.btnAcerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAcerca.Click += new System.EventHandler(this.btnAcerca_Click);
            //
            // languageMenuItem
            //
            this.languageMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.languageMenuItem.AutoSize = false;
            this.languageMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spanishLanguageItem,
            this.englishLanguageItem});
            this.languageMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("languageMenuItem.Image")));
            this.languageMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.languageMenuItem.Name = "languageMenuItem";
            this.languageMenuItem.Size = new System.Drawing.Size(110, 60);
            this.languageMenuItem.Text = "Idioma";
            this.languageMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            //
            // spanishLanguageItem
            //
            this.spanishLanguageItem.Name = "spanishLanguageItem";
            this.spanishLanguageItem.Size = new System.Drawing.Size(115, 22);
            this.spanishLanguageItem.Text = "Español";
            this.spanishLanguageItem.Click += new System.EventHandler(this.spanishLanguageItem_Click);
            //
            // englishLanguageItem
            //
            this.englishLanguageItem.Name = "englishLanguageItem";
            this.englishLanguageItem.Size = new System.Drawing.Size(115, 22);
            this.englishLanguageItem.Text = "English";
            this.englishLanguageItem.Click += new System.EventHandler(this.englishLanguageItem_Click);
            //
            // settingsMenuItem
            //
            this.settingsMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.settingsMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsMenuItem.Image")));
            this.settingsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(95, 62);
            this.settingsMenuItem.Text = "Configuración";
            this.settingsMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            //
            // pathPanel
            //
            this.pathPanel.BackColor = System.Drawing.Color.White;
            this.pathPanel.Controls.Add(this.backButton);
            this.pathPanel.Controls.Add(this.upButton);
            this.pathPanel.Controls.Add(this.refreshButton);
            this.pathPanel.Controls.Add(this.addressBox);
            this.pathPanel.Controls.Add(this.goButton);
            this.pathPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathPanel.Location = new System.Drawing.Point(3, 73);
            this.pathPanel.Name = "pathPanel";
            this.pathPanel.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
            this.pathPanel.Size = new System.Drawing.Size(1154, 46);
            this.pathPanel.TabIndex = 2;
            //
            // backButton
            //
            this.backButton.AutoSize = false;
            this.backButton.Depth = 0;
            this.backButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Icon = null;
            this.backButton.Location = new System.Drawing.Point(6, 5);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.backButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.backButton.Name = "backButton";
            this.backButton.Primary = false;
            this.backButton.Size = new System.Drawing.Size(36, 36);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "←";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            //
            // upButton
            //
            this.upButton.AutoSize = false;
            this.upButton.Depth = 0;
            this.upButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upButton.Icon = null;
            this.upButton.Location = new System.Drawing.Point(46, 5);
            this.upButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.upButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.upButton.Name = "upButton";
            this.upButton.Primary = false;
            this.upButton.Size = new System.Drawing.Size(36, 36);
            this.upButton.TabIndex = 1;
            this.upButton.Text = "↑";
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            //
            // refreshButton
            //
            this.refreshButton.AutoSize = false;
            this.refreshButton.Depth = 0;
            this.refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Icon = null;
            this.refreshButton.Location = new System.Drawing.Point(86, 5);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.refreshButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Primary = false;
            this.refreshButton.Size = new System.Drawing.Size(36, 36);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "↻";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            //
            // addressBox
            //
            this.addressBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressBox.BackColor = System.Drawing.Color.White;
            this.addressBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addressBox.Depth = 0;
            this.addressBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addressBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.addressBox.Hint = "";
            this.addressBox.Location = new System.Drawing.Point(129, 13);
            this.addressBox.MaxLength = 32767;
            this.addressBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.addressBox.Name = "addressBox";
            this.addressBox.PasswordChar = '\0';
            this.addressBox.ReadOnly = false;
            this.addressBox.SelectedText = "";
            this.addressBox.SelectionLength = 0;
            this.addressBox.SelectionStart = 0;
            this.addressBox.Size = new System.Drawing.Size(968, 21);
            this.addressBox.TabIndex = 3;
            this.addressBox.TabStop = false;
            this.addressBox.UseSystemPasswordChar = false;
            this.addressBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addressBox_KeyDown);
            //
            // goButton
            //
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.AutoSize = false;
            this.goButton.Depth = 0;
            this.goButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.goButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goButton.Icon = null;
            this.goButton.Location = new System.Drawing.Point(1109, 5);
            this.goButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.goButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.goButton.Name = "goButton";
            this.goButton.Primary = false;
            this.goButton.Size = new System.Drawing.Size(36, 36);
            this.goButton.TabIndex = 4;
            this.goButton.Text = "Ir";
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            //
            // browserLayout
            //
            this.browserLayout.ColumnCount = 2;
            this.browserLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.browserLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.browserLayout.Controls.Add(this.navigationPanel, 0, 0);
            this.browserLayout.Controls.Add(this.contentPanel, 1, 0);
            this.browserLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserLayout.Location = new System.Drawing.Point(3, 125);
            this.browserLayout.Name = "browserLayout";
            this.browserLayout.RowCount = 1;
            this.browserLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.browserLayout.Size = new System.Drawing.Size(1154, 607);
            this.browserLayout.TabIndex = 3;
            //
            // navigationPanel
            //
            this.navigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.navigationPanel.Controls.Add(this.navigationTree);
            this.navigationPanel.Controls.Add(this.navigationHeading);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.Location = new System.Drawing.Point(3, 3);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(219, 601);
            this.navigationPanel.TabIndex = 0;
            //
            // navigationTree
            //
            this.navigationTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.navigationTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.navigationTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationTree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.navigationTree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.navigationTree.FullRowSelect = true;
            this.navigationTree.HideSelection = false;
            this.navigationTree.Indent = 22;
            this.navigationTree.ItemHeight = 38;
            this.navigationTree.Location = new System.Drawing.Point(0, 34);
            this.navigationTree.Name = "navigationTree";
            this.navigationTree.ShowLines = false;
            this.navigationTree.ShowPlusMinus = false;
            this.navigationTree.ShowRootLines = false;
            this.navigationTree.Size = new System.Drawing.Size(219, 567);
            this.navigationTree.TabIndex = 0;
            this.navigationTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.navigationTree_BeforeExpand);
            this.navigationTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.navigationTree_AfterSelect);
            //
            // navigationHeading
            //
            this.navigationHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.navigationHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(119)))), ((int)(((byte)(135)))));
            this.navigationHeading.Location = new System.Drawing.Point(0, 0);
            this.navigationHeading.Name = "navigationHeading";
            this.navigationHeading.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.navigationHeading.Size = new System.Drawing.Size(219, 34);
            this.navigationHeading.TabIndex = 1;
            this.navigationHeading.Text = "UBICACIONES";
            this.navigationHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // contentPanel
            //
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.listViewArchivos);
            this.contentPanel.Controls.Add(this.emptyPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(228, 3);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(1);
            this.contentPanel.Size = new System.Drawing.Size(923, 601);
            this.contentPanel.TabIndex = 1;
            //
            // listViewArchivos
            //
            this.listViewArchivos.AllowDrop = true;
            this.listViewArchivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewArchivos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderType,
            this.columnHeaderSize,
            this.columnHeaderModified});
            this.listViewArchivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewArchivos.FullRowSelect = true;
            this.listViewArchivos.HideSelection = false;
            this.listViewArchivos.LargeImageList = this.imageListLarge;
            this.listViewArchivos.Location = new System.Drawing.Point(1, 1);
            this.listViewArchivos.Name = "listViewArchivos";
            this.listViewArchivos.Size = new System.Drawing.Size(921, 599);
            this.listViewArchivos.SmallImageList = this.imageListSmall;
            this.listViewArchivos.TabIndex = 0;
            this.listViewArchivos.UseCompatibleStateImageBehavior = false;
            this.listViewArchivos.View = System.Windows.Forms.View.Details;
            this.listViewArchivos.ItemActivate += new System.EventHandler(this.listViewArchivos_ItemActivate);
            this.listViewArchivos.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewArchivos_DragDrop);
            this.listViewArchivos.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewArchivos_DragEnter);
            //
            // columnHeaderName
            //
            this.columnHeaderName.Name = "columnHeaderName";
            this.columnHeaderName.Text = "Nombre";
            this.columnHeaderName.Width = 320;
            //
            // columnHeaderType
            //
            this.columnHeaderType.Name = "columnHeaderType";
            this.columnHeaderType.Text = "Tipo";
            this.columnHeaderType.Width = 105;
            //
            // columnHeaderSize
            //
            this.columnHeaderSize.Name = "columnHeaderSize";
            this.columnHeaderSize.Text = "Tamaño";
            this.columnHeaderSize.Width = 115;
            //
            // columnHeaderModified
            //
            this.columnHeaderModified.Name = "columnHeaderModified";
            this.columnHeaderModified.Text = "Modificado";
            this.columnHeaderModified.Width = 155;
            //
            // imageListLarge
            //
            this.imageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListLarge.ImageSize = new System.Drawing.Size(48, 48);
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            //
            // imageListSmall
            //
            this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListSmall.ImageSize = new System.Drawing.Size(24, 24);
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            //
            // emptyPanel
            //
            this.emptyPanel.BackColor = System.Drawing.Color.White;
            this.emptyPanel.Controls.Add(this.picLogo);
            this.emptyPanel.Controls.Add(this.lblArchivo);
            this.emptyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emptyPanel.Location = new System.Drawing.Point(1, 1);
            this.emptyPanel.Name = "emptyPanel";
            this.emptyPanel.Size = new System.Drawing.Size(921, 599);
            this.emptyPanel.TabIndex = 1;
            this.emptyPanel.Visible = false;
            //
            // picLogo
            //
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(762, 399);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(132, 120);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            //
            // lblArchivo
            //
            this.lblArchivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(119)))), ((int)(((byte)(135)))));
            this.lblArchivo.Location = new System.Drawing.Point(727, 527);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(346, 19);
            this.lblArchivo.TabIndex = 1;
            this.lblArchivo.Text = "Abre un archivo o selecciona una carpeta para explorar.";
            //
            // statusStrip
            //
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 735);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1160, 25);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 4;
            //
            // statusLabel
            //
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(105)))), ((int)(((byte)(121)))));
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(32, 20);
            this.statusLabel.Text = "Listo";
            //
            // fm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1160, 760);
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(850, 560);
            this.Name = "fm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpCompress";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pathPanel.ResumeLayout(false);
            this.browserLayout.ResumeLayout(false);
            this.navigationPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.emptyPanel.ResumeLayout(false);
            this.emptyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
