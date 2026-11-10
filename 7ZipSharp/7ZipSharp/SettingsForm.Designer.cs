using MaterialSkin.Controls;
namespace _7ZipSharp
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTabControl tabs;
        private MaterialSkin.Controls.MaterialTabSelector tabSelector;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabCompression;
        private System.Windows.Forms.TabPage tabExtraction;
        private System.Windows.Forms.TabPage tabExplorer;
        private System.Windows.Forms.Label lblLanguage;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;
        private System.Windows.Forms.Label lblBrowserView;
        private MaterialSkin.Controls.MaterialComboBox cmbBrowserView;
        private System.Windows.Forms.GroupBox groupIcon;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIconPath;
        private MaterialSkin.Controls.MaterialFlatButton btnBrowseIcon;
        private MaterialSkin.Controls.MaterialFlatButton btnResetIcon;
        private MaterialSkin.Controls.MaterialFlatButton btnOpenLogs;
        private MaterialSkin.Controls.MaterialFlatButton btnReset;
        private System.Windows.Forms.Label lblFormat;
        private MaterialSkin.Controls.MaterialComboBox cmbArchiveFormat;
        private System.Windows.Forms.Label lblProfile;
        private MaterialSkin.Controls.MaterialComboBox cmbCompressionProfile;
        private MaterialSkin.Controls.MaterialCheckBox chkSfxByDefault;
        private System.Windows.Forms.Label lblOutputFolder;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtOutputFolder;
        private MaterialSkin.Controls.MaterialFlatButton btnOutputBrowse;
        private System.Windows.Forms.Label lblExtractFolder;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtExtractFolder;
        private MaterialSkin.Controls.MaterialFlatButton btnExtractBrowse;
        private System.Windows.Forms.Label lblConflict;
        private MaterialSkin.Controls.MaterialComboBox cmbConflict;
        private System.Windows.Forms.Label lblIntegrationIntro;
        private System.Windows.Forms.Label lblIntegrationStatus;
        private System.Windows.Forms.Label lblIntegrationNote;
        private MaterialSkin.Controls.MaterialFlatButton btnRepairIntegration;
        private MaterialSkin.Controls.MaterialFlatButton btnRemoveIntegration;
        private System.Windows.Forms.Label lblDefaultAppsTitle;
        private System.Windows.Forms.Label lblDefaultAppsNote;
        private MaterialSkin.Controls.MaterialFlatButton btnChooseDefaultApps;
        private MaterialSkin.Controls.MaterialFlatButton btnSave;
        private MaterialSkin.Controls.MaterialFlatButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabs = new MaterialSkin.Controls.MaterialTabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            this.lblBrowserView = new System.Windows.Forms.Label();
            this.cmbBrowserView = new MaterialSkin.Controls.MaterialComboBox();
            this.groupIcon = new System.Windows.Forms.GroupBox();
            this.txtIconPath = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnBrowseIcon = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnResetIcon = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnOpenLogs = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnReset = new MaterialSkin.Controls.MaterialFlatButton();
            this.tabCompression = new System.Windows.Forms.TabPage();
            this.lblFormat = new System.Windows.Forms.Label();
            this.cmbArchiveFormat = new MaterialSkin.Controls.MaterialComboBox();
            this.lblProfile = new System.Windows.Forms.Label();
            this.cmbCompressionProfile = new MaterialSkin.Controls.MaterialComboBox();
            this.chkSfxByDefault = new MaterialSkin.Controls.MaterialCheckBox();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.txtOutputFolder = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnOutputBrowse = new MaterialSkin.Controls.MaterialFlatButton();
            this.tabExtraction = new System.Windows.Forms.TabPage();
            this.lblExtractFolder = new System.Windows.Forms.Label();
            this.txtExtractFolder = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnExtractBrowse = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblConflict = new System.Windows.Forms.Label();
            this.cmbConflict = new MaterialSkin.Controls.MaterialComboBox();
            this.tabExplorer = new System.Windows.Forms.TabPage();
            this.lblIntegrationIntro = new System.Windows.Forms.Label();
            this.lblIntegrationStatus = new System.Windows.Forms.Label();
            this.lblIntegrationNote = new System.Windows.Forms.Label();
            this.btnRepairIntegration = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnRemoveIntegration = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblDefaultAppsTitle = new System.Windows.Forms.Label();
            this.lblDefaultAppsNote = new System.Windows.Forms.Label();
            this.btnChooseDefaultApps = new MaterialSkin.Controls.MaterialFlatButton();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.btnSave = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupIcon.SuspendLayout();
            this.tabCompression.SuspendLayout();
            this.tabExtraction.SuspendLayout();
            this.tabExplorer.SuspendLayout();
            this.SuspendLayout();
            //
            // tabs
            //
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabGeneral);
            this.tabs.Controls.Add(this.tabCompression);
            this.tabs.Controls.Add(this.tabExtraction);
            this.tabs.Controls.Add(this.tabExplorer);
            this.tabs.Depth = 0;
            this.tabs.Location = new System.Drawing.Point(12, 60);
            this.tabs.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(626, 330);
            this.tabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabs.TabIndex = 0;
            //
            // tabGeneral
            //
            this.tabGeneral.Controls.Add(this.lblLanguage);
            this.tabGeneral.Controls.Add(this.cmbLanguage);
            this.tabGeneral.Controls.Add(this.lblBrowserView);
            this.tabGeneral.Controls.Add(this.cmbBrowserView);
            this.tabGeneral.Controls.Add(this.groupIcon);
            this.tabGeneral.Controls.Add(this.btnOpenLogs);
            this.tabGeneral.Controls.Add(this.btnReset);
            this.tabGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(12);
            this.tabGeneral.Size = new System.Drawing.Size(618, 302);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            //
            // lblLanguage
            //
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(18, 24);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(44, 15);
            this.lblLanguage.TabIndex = 2;
            this.lblLanguage.Text = "Idioma";
            //
            // cmbLanguage
            //
            this.cmbLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLanguage.ItemHeight = 25;
            this.cmbLanguage.Items.AddRange(new object[] {
            "Español",
            "English"});
            this.cmbLanguage.Location = new System.Drawing.Point(18, 39);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(155, 31);
            this.cmbLanguage.TabIndex = 3;
            //
            // lblBrowserView
            //
            this.lblBrowserView.AutoSize = true;
            this.lblBrowserView.Location = new System.Drawing.Point(190, 24);
            this.lblBrowserView.Name = "lblBrowserView";
            this.lblBrowserView.Size = new System.Drawing.Size(95, 15);
            this.lblBrowserView.TabIndex = 4;
            this.lblBrowserView.Text = "Vista de archivos";
            //
            // cmbBrowserView
            //
            this.cmbBrowserView.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBrowserView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrowserView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBrowserView.ItemHeight = 25;
            this.cmbBrowserView.Items.AddRange(new object[] {
            "Detalles",
            "Lista",
            "Iconos",
            "Iconos grandes",
            "Mosaico"});
            this.cmbBrowserView.Location = new System.Drawing.Point(190, 39);
            this.cmbBrowserView.Name = "cmbBrowserView";
            this.cmbBrowserView.Size = new System.Drawing.Size(230, 31);
            this.cmbBrowserView.TabIndex = 5;
            //
            // groupIcon
            //
            this.groupIcon.Controls.Add(this.txtIconPath);
            this.groupIcon.Controls.Add(this.btnBrowseIcon);
            this.groupIcon.Controls.Add(this.btnResetIcon);
            this.groupIcon.Location = new System.Drawing.Point(18, 82);
            this.groupIcon.Name = "groupIcon";
            this.groupIcon.Size = new System.Drawing.Size(574, 82);
            this.groupIcon.TabIndex = 6;
            this.groupIcon.TabStop = false;
            this.groupIcon.Text = "Icono del menú contextual";
            //
            // txtIconPath
            //
            this.txtIconPath.BackColor = System.Drawing.Color.White;
            this.txtIconPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIconPath.Depth = 0;
            this.txtIconPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.txtIconPath.Hint = "";
            this.txtIconPath.Location = new System.Drawing.Point(16, 30);
            this.txtIconPath.MaxLength = 32767;
            this.txtIconPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIconPath.Name = "txtIconPath";
            this.txtIconPath.PasswordChar = '\0';
            this.txtIconPath.ReadOnly = true;
            this.txtIconPath.SelectedText = "";
            this.txtIconPath.SelectionLength = 0;
            this.txtIconPath.SelectionStart = 0;
            this.txtIconPath.Size = new System.Drawing.Size(300, 21);
            this.txtIconPath.TabIndex = 0;
            this.txtIconPath.TabStop = false;
            this.txtIconPath.UseSystemPasswordChar = false;
            //
            // btnBrowseIcon
            //
            this.btnBrowseIcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseIcon.BackColor = System.Drawing.Color.White;
            this.btnBrowseIcon.Depth = 0;
            this.btnBrowseIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseIcon.Icon = null;
            this.btnBrowseIcon.Location = new System.Drawing.Point(326, 28);
            this.btnBrowseIcon.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowseIcon.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowseIcon.Name = "btnBrowseIcon";
            this.btnBrowseIcon.Primary = false;
            this.btnBrowseIcon.Size = new System.Drawing.Size(98, 36);
            this.btnBrowseIcon.TabIndex = 1;
            this.btnBrowseIcon.Text = "Examinar…";
            this.btnBrowseIcon.UseVisualStyleBackColor = true;
            this.btnBrowseIcon.Click += new System.EventHandler(this.btnBrowseIcon_Click);
            //
            // btnResetIcon
            //
            this.btnResetIcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnResetIcon.BackColor = System.Drawing.Color.White;
            this.btnResetIcon.Depth = 0;
            this.btnResetIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetIcon.Icon = null;
            this.btnResetIcon.Location = new System.Drawing.Point(432, 28);
            this.btnResetIcon.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnResetIcon.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnResetIcon.Name = "btnResetIcon";
            this.btnResetIcon.Primary = false;
            this.btnResetIcon.Size = new System.Drawing.Size(93, 36);
            this.btnResetIcon.TabIndex = 2;
            this.btnResetIcon.Text = "Restaurar";
            this.btnResetIcon.UseVisualStyleBackColor = true;
            this.btnResetIcon.Click += new System.EventHandler(this.btnResetIcon_Click);
            //
            // btnOpenLogs
            //
            this.btnOpenLogs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenLogs.BackColor = System.Drawing.Color.White;
            this.btnOpenLogs.Depth = 0;
            this.btnOpenLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenLogs.Icon = null;
            this.btnOpenLogs.Location = new System.Drawing.Point(18, 184);
            this.btnOpenLogs.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOpenLogs.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenLogs.Name = "btnOpenLogs";
            this.btnOpenLogs.Primary = false;
            this.btnOpenLogs.Size = new System.Drawing.Size(207, 36);
            this.btnOpenLogs.TabIndex = 7;
            this.btnOpenLogs.Text = "Abrir carpeta de registros";
            this.btnOpenLogs.UseVisualStyleBackColor = true;
            this.btnOpenLogs.Click += new System.EventHandler(this.btnOpenLogs_Click);
            //
            // btnReset
            //
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Depth = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Icon = null;
            this.btnReset.Location = new System.Drawing.Point(233, 184);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReset.Name = "btnReset";
            this.btnReset.Primary = false;
            this.btnReset.Size = new System.Drawing.Size(309, 36);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Restaurar preferencias predeterminadas";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // tabCompression
            //
            this.tabCompression.Controls.Add(this.lblFormat);
            this.tabCompression.Controls.Add(this.cmbArchiveFormat);
            this.tabCompression.Controls.Add(this.lblProfile);
            this.tabCompression.Controls.Add(this.cmbCompressionProfile);
            this.tabCompression.Controls.Add(this.chkSfxByDefault);
            this.tabCompression.Controls.Add(this.lblOutputFolder);
            this.tabCompression.Controls.Add(this.txtOutputFolder);
            this.tabCompression.Controls.Add(this.btnOutputBrowse);
            this.tabCompression.Location = new System.Drawing.Point(4, 24);
            this.tabCompression.Name = "tabCompression";
            this.tabCompression.Padding = new System.Windows.Forms.Padding(12);
            this.tabCompression.Size = new System.Drawing.Size(618, 302);
            this.tabCompression.TabIndex = 1;
            this.tabCompression.Text = "Compresión";
            this.tabCompression.UseVisualStyleBackColor = true;
            //
            // lblFormat
            //
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(20, 28);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(140, 15);
            this.lblFormat.TabIndex = 0;
            this.lblFormat.Text = "Formato predeterminado";
            //
            // cmbArchiveFormat
            //
            this.cmbArchiveFormat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbArchiveFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArchiveFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbArchiveFormat.ItemHeight = 25;
            this.cmbArchiveFormat.Items.AddRange(new object[] {
            "7z",
            "TAR",
            "ZIP",
            "GZip",
            "SCZ"});
            this.cmbArchiveFormat.Location = new System.Drawing.Point(20, 49);
            this.cmbArchiveFormat.Name = "cmbArchiveFormat";
            this.cmbArchiveFormat.Size = new System.Drawing.Size(190, 31);
            this.cmbArchiveFormat.TabIndex = 1;
            //
            // lblProfile
            //
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(236, 28);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(122, 15);
            this.lblProfile.TabIndex = 2;
            this.lblProfile.Text = "Perfil predeterminado";
            //
            // cmbCompressionProfile
            //
            this.cmbCompressionProfile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCompressionProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompressionProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCompressionProfile.ItemHeight = 25;
            this.cmbCompressionProfile.Items.AddRange(new object[] {
            "Equilibrado",
            "Rápido",
            "Menor tamaño",
            "Personalizado"});
            this.cmbCompressionProfile.Location = new System.Drawing.Point(239, 49);
            this.cmbCompressionProfile.Name = "cmbCompressionProfile";
            this.cmbCompressionProfile.Size = new System.Drawing.Size(210, 31);
            this.cmbCompressionProfile.TabIndex = 3;
            //
            // chkSfxByDefault
            //
            this.chkSfxByDefault.AutoSize = true;
            this.chkSfxByDefault.Depth = 0;
            this.chkSfxByDefault.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkSfxByDefault.Location = new System.Drawing.Point(23, 97);
            this.chkSfxByDefault.Margin = new System.Windows.Forms.Padding(0);
            this.chkSfxByDefault.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkSfxByDefault.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkSfxByDefault.Name = "chkSfxByDefault";
            this.chkSfxByDefault.Ripple = true;
            this.chkSfxByDefault.Size = new System.Drawing.Size(302, 30);
            this.chkSfxByDefault.TabIndex = 4;
            this.chkSfxByDefault.Text = "Crear autoextractor de Windows por defecto";
            this.chkSfxByDefault.UseVisualStyleBackColor = true;
            //
            // lblOutputFolder
            //
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(20, 153);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(184, 15);
            this.lblOutputFolder.TabIndex = 5;
            this.lblOutputFolder.Text = "Carpeta predeterminada de salida";
            //
            // txtOutputFolder
            //
            this.txtOutputFolder.BackColor = System.Drawing.Color.White;
            this.txtOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutputFolder.Depth = 0;
            this.txtOutputFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.txtOutputFolder.Hint = "";
            this.txtOutputFolder.Location = new System.Drawing.Point(23, 174);
            this.txtOutputFolder.MaxLength = 32767;
            this.txtOutputFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.PasswordChar = '\0';
            this.txtOutputFolder.ReadOnly = false;
            this.txtOutputFolder.SelectedText = "";
            this.txtOutputFolder.SelectionLength = 0;
            this.txtOutputFolder.SelectionStart = 0;
            this.txtOutputFolder.Size = new System.Drawing.Size(414, 21);
            this.txtOutputFolder.TabIndex = 6;
            this.txtOutputFolder.TabStop = false;
            this.txtOutputFolder.UseSystemPasswordChar = false;
            //
            // btnOutputBrowse
            //
            this.btnOutputBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOutputBrowse.BackColor = System.Drawing.Color.White;
            this.btnOutputBrowse.Depth = 0;
            this.btnOutputBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutputBrowse.Icon = null;
            this.btnOutputBrowse.Location = new System.Drawing.Point(444, 167);
            this.btnOutputBrowse.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOutputBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOutputBrowse.Name = "btnOutputBrowse";
            this.btnOutputBrowse.Primary = false;
            this.btnOutputBrowse.Size = new System.Drawing.Size(98, 36);
            this.btnOutputBrowse.TabIndex = 7;
            this.btnOutputBrowse.Text = "Examinar…";
            this.btnOutputBrowse.UseVisualStyleBackColor = true;
            this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
            //
            // tabExtraction
            //
            this.tabExtraction.Controls.Add(this.lblExtractFolder);
            this.tabExtraction.Controls.Add(this.txtExtractFolder);
            this.tabExtraction.Controls.Add(this.btnExtractBrowse);
            this.tabExtraction.Controls.Add(this.lblConflict);
            this.tabExtraction.Controls.Add(this.cmbConflict);
            this.tabExtraction.Location = new System.Drawing.Point(4, 24);
            this.tabExtraction.Name = "tabExtraction";
            this.tabExtraction.Padding = new System.Windows.Forms.Padding(12);
            this.tabExtraction.Size = new System.Drawing.Size(618, 302);
            this.tabExtraction.TabIndex = 2;
            this.tabExtraction.Text = "Extracción";
            this.tabExtraction.UseVisualStyleBackColor = true;
            //
            // lblExtractFolder
            //
            this.lblExtractFolder.AutoSize = true;
            this.lblExtractFolder.Location = new System.Drawing.Point(20, 28);
            this.lblExtractFolder.Name = "lblExtractFolder";
            this.lblExtractFolder.Size = new System.Drawing.Size(208, 15);
            this.lblExtractFolder.TabIndex = 0;
            this.lblExtractFolder.Text = "Carpeta predeterminada de extracción";
            //
            // txtExtractFolder
            //
            this.txtExtractFolder.BackColor = System.Drawing.Color.White;
            this.txtExtractFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExtractFolder.Depth = 0;
            this.txtExtractFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.txtExtractFolder.Hint = "";
            this.txtExtractFolder.Location = new System.Drawing.Point(23, 49);
            this.txtExtractFolder.MaxLength = 32767;
            this.txtExtractFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtExtractFolder.Name = "txtExtractFolder";
            this.txtExtractFolder.PasswordChar = '\0';
            this.txtExtractFolder.ReadOnly = false;
            this.txtExtractFolder.SelectedText = "";
            this.txtExtractFolder.SelectionLength = 0;
            this.txtExtractFolder.SelectionStart = 0;
            this.txtExtractFolder.Size = new System.Drawing.Size(414, 21);
            this.txtExtractFolder.TabIndex = 1;
            this.txtExtractFolder.TabStop = false;
            this.txtExtractFolder.UseSystemPasswordChar = false;
            //
            // btnExtractBrowse
            //
            this.btnExtractBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExtractBrowse.BackColor = System.Drawing.Color.White;
            this.btnExtractBrowse.Depth = 0;
            this.btnExtractBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtractBrowse.Icon = null;
            this.btnExtractBrowse.Location = new System.Drawing.Point(450, 41);
            this.btnExtractBrowse.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExtractBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExtractBrowse.Name = "btnExtractBrowse";
            this.btnExtractBrowse.Primary = false;
            this.btnExtractBrowse.Size = new System.Drawing.Size(98, 36);
            this.btnExtractBrowse.TabIndex = 2;
            this.btnExtractBrowse.Text = "Examinar…";
            this.btnExtractBrowse.UseVisualStyleBackColor = true;
            this.btnExtractBrowse.Click += new System.EventHandler(this.btnExtractBrowse_Click);
            //
            // lblConflict
            //
            this.lblConflict.AutoSize = true;
            this.lblConflict.Location = new System.Drawing.Point(20, 101);
            this.lblConflict.Name = "lblConflict";
            this.lblConflict.Size = new System.Drawing.Size(173, 15);
            this.lblConflict.TabIndex = 3;
            this.lblConflict.Text = "Al encontrar archivos existentes";
            //
            // cmbConflict
            //
            this.cmbConflict.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbConflict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConflict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbConflict.ItemHeight = 25;
            this.cmbConflict.Items.AddRange(new object[] {
            "Preguntar en cada conflicto",
            "Reemplazar archivos existentes",
            "Omitir archivos existentes",
            "Conservar ambos archivos"});
            this.cmbConflict.Location = new System.Drawing.Point(23, 122);
            this.cmbConflict.Name = "cmbConflict";
            this.cmbConflict.Size = new System.Drawing.Size(538, 31);
            this.cmbConflict.TabIndex = 4;
            //
            // tabExplorer
            //
            this.tabExplorer.AutoScroll = true;
            this.tabExplorer.Controls.Add(this.label1);
            this.tabExplorer.Controls.Add(this.lblIntegrationIntro);
            this.tabExplorer.Controls.Add(this.lblIntegrationStatus);
            this.tabExplorer.Controls.Add(this.lblIntegrationNote);
            this.tabExplorer.Controls.Add(this.btnRepairIntegration);
            this.tabExplorer.Controls.Add(this.btnRemoveIntegration);
            this.tabExplorer.Controls.Add(this.lblDefaultAppsTitle);
            this.tabExplorer.Controls.Add(this.lblDefaultAppsNote);
            this.tabExplorer.Controls.Add(this.btnChooseDefaultApps);
            this.tabExplorer.Location = new System.Drawing.Point(4, 24);
            this.tabExplorer.Name = "tabExplorer";
            this.tabExplorer.Padding = new System.Windows.Forms.Padding(12);
            this.tabExplorer.Size = new System.Drawing.Size(618, 302);
            this.tabExplorer.TabIndex = 3;
            this.tabExplorer.Text = "Explorer";
            this.tabExplorer.UseVisualStyleBackColor = true;
            //
            // lblIntegrationIntro
            //
            this.lblIntegrationIntro.Location = new System.Drawing.Point(22, 25);
            this.lblIntegrationIntro.Name = "lblIntegrationIntro";
            this.lblIntegrationIntro.Size = new System.Drawing.Size(538, 52);
            this.lblIntegrationIntro.TabIndex = 0;
            this.lblIntegrationIntro.Text = "Administra la integración del menú contextual de Windows. Reparar vuelve a regist" +
    "rar las opciones y actualiza el icono. Desactivar elimina las entradas de SharpC" +
    "ompress.";
            //
            // lblIntegrationStatus
            //
            this.lblIntegrationStatus.AutoSize = true;
            this.lblIntegrationStatus.Location = new System.Drawing.Point(22, 100);
            this.lblIntegrationStatus.Name = "lblIntegrationStatus";
            this.lblIntegrationStatus.Size = new System.Drawing.Size(133, 15);
            this.lblIntegrationStatus.TabIndex = 1;
            this.lblIntegrationStatus.Text = "Estado de la integración";
            //
            // lblIntegrationNote
            //
            this.lblIntegrationNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(112)))), ((int)(((byte)(127)))));
            this.lblIntegrationNote.Location = new System.Drawing.Point(22, 129);
            this.lblIntegrationNote.Name = "lblIntegrationNote";
            this.lblIntegrationNote.Size = new System.Drawing.Size(538, 42);
            this.lblIntegrationNote.TabIndex = 2;
            this.lblIntegrationNote.Text = "La reparación requiere confirmar el aviso de permisos de Windows. El cambio se ap" +
    "lica a todo el equipo.";
            //
            // btnRepairIntegration
            //
            this.btnRepairIntegration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRepairIntegration.BackColor = System.Drawing.Color.White;
            this.btnRepairIntegration.Depth = 0;
            this.btnRepairIntegration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepairIntegration.Icon = null;
            this.btnRepairIntegration.Location = new System.Drawing.Point(22, 179);
            this.btnRepairIntegration.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRepairIntegration.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRepairIntegration.Name = "btnRepairIntegration";
            this.btnRepairIntegration.Primary = false;
            this.btnRepairIntegration.Size = new System.Drawing.Size(232, 36);
            this.btnRepairIntegration.TabIndex = 3;
            this.btnRepairIntegration.Text = "Reparar / activar integración";
            this.btnRepairIntegration.UseVisualStyleBackColor = true;
            this.btnRepairIntegration.Click += new System.EventHandler(this.btnRepairIntegration_Click);
            //
            // btnRemoveIntegration
            //
            this.btnRemoveIntegration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveIntegration.BackColor = System.Drawing.Color.White;
            this.btnRemoveIntegration.Depth = 0;
            this.btnRemoveIntegration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveIntegration.Icon = null;
            this.btnRemoveIntegration.Location = new System.Drawing.Point(262, 179);
            this.btnRemoveIntegration.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemoveIntegration.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveIntegration.Name = "btnRemoveIntegration";
            this.btnRemoveIntegration.Primary = false;
            this.btnRemoveIntegration.Size = new System.Drawing.Size(186, 36);
            this.btnRemoveIntegration.TabIndex = 4;
            this.btnRemoveIntegration.Text = "Desactivar integración";
            this.btnRemoveIntegration.UseVisualStyleBackColor = true;
            this.btnRemoveIntegration.Click += new System.EventHandler(this.btnRemoveIntegration_Click);
            //
            // lblDefaultAppsTitle
            //
            this.lblDefaultAppsTitle.AutoSize = true;
            this.lblDefaultAppsTitle.Location = new System.Drawing.Point(22, 221);
            this.lblDefaultAppsTitle.Name = "lblDefaultAppsTitle";
            this.lblDefaultAppsTitle.Size = new System.Drawing.Size(224, 15);
            this.lblDefaultAppsTitle.TabIndex = 5;
            this.lblDefaultAppsTitle.Text = "Formatos comprimidos predeterminados";
            //
            // lblDefaultAppsNote
            //
            this.lblDefaultAppsNote.Location = new System.Drawing.Point(22, 243);
            this.lblDefaultAppsNote.Name = "lblDefaultAppsNote";
            this.lblDefaultAppsNote.Size = new System.Drawing.Size(538, 38);
            this.lblDefaultAppsNote.TabIndex = 6;
            this.lblDefaultAppsNote.Text = "Registra SharpCompress para formatos de archivo y abre la configuración de Window" +
    "s para elegir cuáles serán predeterminados.";
            //
            // btnChooseDefaultApps
            //
            this.btnChooseDefaultApps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChooseDefaultApps.BackColor = System.Drawing.Color.White;
            this.btnChooseDefaultApps.Depth = 0;
            this.btnChooseDefaultApps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseDefaultApps.Icon = null;
            this.btnChooseDefaultApps.Location = new System.Drawing.Point(22, 287);
            this.btnChooseDefaultApps.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnChooseDefaultApps.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnChooseDefaultApps.Name = "btnChooseDefaultApps";
            this.btnChooseDefaultApps.Primary = false;
            this.btnChooseDefaultApps.Size = new System.Drawing.Size(271, 36);
            this.btnChooseDefaultApps.TabIndex = 7;
            this.btnChooseDefaultApps.Text = "Elegir formatos predeterminados…";
            this.btnChooseDefaultApps.UseVisualStyleBackColor = true;
            this.btnChooseDefaultApps.Click += new System.EventHandler(this.btnChooseDefaultApps_Click);
            //
            // tabSelector
            //
            this.tabSelector.BaseTabControl = this.tabs;
            this.tabSelector.Depth = 0;
            this.tabSelector.Location = new System.Drawing.Point(12, 12);
            this.tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.Size = new System.Drawing.Size(626, 48);
            this.tabSelector.TabIndex = 3;
            //
            // btnSave
            //
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Depth = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(458, 402);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = false;
            this.btnSave.Size = new System.Drawing.Size(82, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Depth = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(548, 402);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = false;
            this.btnCancel.Size = new System.Drawing.Size(86, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 8;
            //
            // SettingsForm
            //
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(650, 453);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabSelector);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuración de SharpCompress";
            this.tabs.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.groupIcon.ResumeLayout(false);
            this.tabCompression.ResumeLayout(false);
            this.tabCompression.PerformLayout();
            this.tabExtraction.ResumeLayout(false);
            this.tabExtraction.PerformLayout();
            this.tabExplorer.ResumeLayout(false);
            this.tabExplorer.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label1;
    }
}
