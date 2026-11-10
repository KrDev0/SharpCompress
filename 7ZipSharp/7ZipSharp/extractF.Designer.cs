using MaterialSkin.Controls;
namespace _7ZipSharp
{
    partial class extractF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(extractF));
            this.lblSalidaFile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCComprimir = new MaterialSkin.Controls.MaterialFlatButton();
            this.prgExtract = new MaterialSkin.Controls.MaterialProgressBar();
            this.lblStatusExtract = new System.Windows.Forms.Label();
            this.txtFile = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtSave = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.button1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnBrowse = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnStart = new MaterialSkin.Controls.MaterialFlatButton();
            this.cmbConflict = new MaterialSkin.Controls.MaterialComboBox();
            this.lblConflict = new System.Windows.Forms.Label();
            this.selectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            //
            // lblSalidaFile
            //
            this.lblSalidaFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSalidaFile.AutoSize = true;
            this.lblSalidaFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSalidaFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.lblSalidaFile.Location = new System.Drawing.Point(12, 93);
            this.lblSalidaFile.Name = "lblSalidaFile";
            this.lblSalidaFile.Size = new System.Drawing.Size(21, 15);
            this.lblSalidaFile.TabIndex = 33;
            this.lblSalidaFile.Text = "{0}";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Archivo a extraer:";
            //
            // btnCComprimir
            //
            this.btnCComprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCComprimir.AutoSize = false;
            this.btnCComprimir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCComprimir.BackColor = System.Drawing.Color.White;
            this.btnCComprimir.Depth = 0;
            this.btnCComprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.btnCComprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCComprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btnCComprimir.Icon = null;
            this.btnCComprimir.Location = new System.Drawing.Point(468, 196);
            this.btnCComprimir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCComprimir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCComprimir.Name = "btnCComprimir";
            this.btnCComprimir.Primary = false;
            this.btnCComprimir.Size = new System.Drawing.Size(86, 36);
            this.btnCComprimir.TabIndex = 19;
            this.btnCComprimir.Text = "Cancelar";
            this.btnCComprimir.UseVisualStyleBackColor = false;
            this.btnCComprimir.Click += new System.EventHandler(this.btnCComprimir_Click);
            //
            // prgExtract
            //
            this.prgExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prgExtract.Location = new System.Drawing.Point(12, 167);
            this.prgExtract.Name = "prgExtract";
            this.prgExtract.Size = new System.Drawing.Size(626, 20);
            this.prgExtract.TabIndex = 18;
            //
            // lblStatusExtract
            //
            this.lblStatusExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatusExtract.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatusExtract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.lblStatusExtract.Location = new System.Drawing.Point(12, 147);
            this.lblStatusExtract.Name = "lblStatusExtract";
            this.lblStatusExtract.Size = new System.Drawing.Size(626, 18);
            this.lblStatusExtract.TabIndex = 20;
            this.lblStatusExtract.Text = "Listo";
            //
            // txtFile
            //
            this.txtFile.BackColor = System.Drawing.Color.White;
            this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFile.Depth = 0;
            this.txtFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.txtFile.Hint = "";
            this.txtFile.Location = new System.Drawing.Point(12, 27);
            this.txtFile.MaxLength = 32767;
            this.txtFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFile.Name = "txtFile";
            this.txtFile.PasswordChar = '\0';
            this.txtFile.ReadOnly = true;
            this.txtFile.SelectedText = "";
            this.txtFile.SelectionLength = 0;
            this.txtFile.SelectionStart = 0;
            this.txtFile.Size = new System.Drawing.Size(626, 21);
            this.txtFile.TabIndex = 26;
            this.txtFile.TabStop = false;
            this.txtFile.UseSystemPasswordChar = false;
            //
            // txtSave
            //
            this.txtSave.BackColor = System.Drawing.Color.White;
            this.txtSave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSave.Depth = 0;
            this.txtSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.txtSave.Hint = "";
            this.txtSave.Location = new System.Drawing.Point(12, 69);
            this.txtSave.MaxLength = 32767;
            this.txtSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSave.Name = "txtSave";
            this.txtSave.PasswordChar = '\0';
            this.txtSave.ReadOnly = true;
            this.txtSave.SelectedText = "";
            this.txtSave.SelectionLength = 0;
            this.txtSave.SelectionStart = 0;
            this.txtSave.Size = new System.Drawing.Size(520, 21);
            this.txtSave.TabIndex = 25;
            this.txtSave.TabStop = false;
            this.txtSave.UseSystemPasswordChar = false;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Extraer en:";
            //
            // lblTiempo
            //
            this.lblTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTiempo.AutoEllipsis = true;
            this.lblTiempo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.lblTiempo.Location = new System.Drawing.Point(12, 203);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(313, 18);
            this.lblTiempo.TabIndex = 34;
            this.lblTiempo.Text = "Tiempo transcurrido: ";
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // button1
            //
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = false;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Depth = 0;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(332, 196);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.Primary = false;
            this.button1.Size = new System.Drawing.Size(128, 36);
            this.button1.TabIndex = 35;
            this.button1.Text = "Segundo plano";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // notifyIcon1
            //
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SharpCompress";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            //
            // btnBrowse
            //
            this.btnBrowse.AutoSize = false;
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.Depth = 0;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btnBrowse.Icon = null;
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(540, 66);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Primary = false;
            this.btnBrowse.Size = new System.Drawing.Size(98, 36);
            this.btnBrowse.TabIndex = 36;
            this.btnBrowse.Text = "Examinar…";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            //
            // btnStart
            //
            this.btnStart.AutoSize = false;
            this.btnStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(63)))));
            this.btnStart.Depth = 0;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(63)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btnStart.Icon = null;
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(562, 196);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStart.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStart.Name = "btnStart";
            this.btnStart.Primary = false;
            this.btnStart.Size = new System.Drawing.Size(75, 36);
            this.btnStart.TabIndex = 37;
            this.btnStart.Text = "Extraer";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
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
            this.cmbConflict.Location = new System.Drawing.Point(100, 107);
            this.cmbConflict.Name = "cmbConflict";
            this.cmbConflict.Size = new System.Drawing.Size(538, 31);
            this.cmbConflict.TabIndex = 39;
            //
            // lblConflict
            //
            this.lblConflict.AutoSize = true;
            this.lblConflict.Location = new System.Drawing.Point(12, 114);
            this.lblConflict.Name = "lblConflict";
            this.lblConflict.Size = new System.Drawing.Size(66, 15);
            this.lblConflict.TabIndex = 38;
            this.lblConflict.Text = "Si ya existe:";
            //
            // selectFolderDialog
            //
            this.selectFolderDialog.Description = "Selecciona la carpeta donde se extraerán los elementos.";
            //
            // extractF
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 237);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cmbConflict);
            this.Controls.Add(this.lblConflict);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblSalidaFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCComprimir);
            this.Controls.Add(this.prgExtract);
            this.Controls.Add(this.lblStatusExtract);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "extractF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.extractF_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalidaFile;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialFlatButton btnCComprimir;
        private MaterialSkin.Controls.MaterialProgressBar prgExtract;
        private System.Windows.Forms.Label lblStatusExtract;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFile;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTiempo;
        private MaterialSkin.Controls.MaterialFlatButton button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private MaterialSkin.Controls.MaterialFlatButton btnBrowse;
        private MaterialSkin.Controls.MaterialFlatButton btnStart;
        private MaterialSkin.Controls.MaterialComboBox cmbConflict;
        private System.Windows.Forms.Label lblConflict;
        private System.Windows.Forms.FolderBrowserDialog selectFolderDialog;
    }
}
