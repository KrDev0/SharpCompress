namespace _7ZipSharp
{
    partial class CompressF
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompressF));
            this.cmbMetodo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFormato = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNivel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelDir = new System.Windows.Forms.Button();
            this.btnSaveSel = new System.Windows.Forms.Button();
            this.lblStatusCom = new System.Windows.Forms.Label();
            this.prgCompress = new System.Windows.Forms.ProgressBar();
            this.btnCComprimir = new System.Windows.Forms.Button();
            this.btnComprimir = new System.Windows.Forms.Button();
            this.SaveCompressFile = new System.Windows.Forms.SaveFileDialog();
            this.SelectCompressFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblSalidaFile = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.chkPass = new System.Windows.Forms.CheckBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConfirPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEncrip = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grbEncrip = new System.Windows.Forms.GroupBox();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.grbVolume = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbVolumen = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkVolumenCus = new System.Windows.Forms.CheckBox();
            this.txtVolumen = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkNombres = new System.Windows.Forms.CheckBox();
            this.chkDividir = new System.Windows.Forms.CheckBox();
            this.grbEncrip.SuspendLayout();
            this.grbVolume.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMetodo
            // 
            this.cmbMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodo.FormattingEnabled = true;
            this.cmbMetodo.Items.AddRange(new object[] {
            "Deflate (Por defecto)",
            "Deflate64",
            "BZip2",
            "LZMA",
            "PPMd"});
            this.cmbMetodo.Location = new System.Drawing.Point(264, 68);
            this.cmbMetodo.Name = "cmbMetodo";
            this.cmbMetodo.Size = new System.Drawing.Size(145, 23);
            this.cmbMetodo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Método:";
            // 
            // cmbFormato
            // 
            this.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormato.FormattingEnabled = true;
            this.cmbFormato.Items.AddRange(new object[] {
            "7z",
            "Tar",
            "Zip"});
            this.cmbFormato.Location = new System.Drawing.Point(138, 68);
            this.cmbFormato.Name = "cmbFormato";
            this.cmbFormato.Size = new System.Drawing.Size(120, 23);
            this.cmbFormato.TabIndex = 2;
            this.cmbFormato.SelectedIndexChanged += new System.EventHandler(this.cmbFormato_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Formato:";
            // 
            // cmbNivel
            // 
            this.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.Items.AddRange(new object[] {
            "Rápido",
            "Alto",
            "Bajo",
            "Ninguno",
            "Normal",
            "Ultra"});
            this.cmbNivel.Location = new System.Drawing.Point(12, 68);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(120, 23);
            this.cmbNivel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nivel:";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(12, 27);
            this.txtDir.Name = "txtDir";
            this.txtDir.ReadOnly = true;
            this.txtDir.Size = new System.Drawing.Size(397, 23);
            this.txtDir.TabIndex = 13;
            this.txtDir.TabStop = false;
            // 
            // txtSave
            // 
            this.txtSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSave.Location = new System.Drawing.Point(12, 291);
            this.txtSave.Name = "txtSave";
            this.txtSave.ReadOnly = true;
            this.txtSave.Size = new System.Drawing.Size(397, 23);
            this.txtSave.TabIndex = 14;
            this.txtSave.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Guardar archivo en:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Directorio a comprimir:";
            // 
            // btnSelDir
            // 
            this.btnSelDir.Location = new System.Drawing.Point(415, 25);
            this.btnSelDir.Name = "btnSelDir";
            this.btnSelDir.Size = new System.Drawing.Size(75, 24);
            this.btnSelDir.TabIndex = 0;
            this.btnSelDir.Text = "Seleccionar";
            this.btnSelDir.UseVisualStyleBackColor = true;
            this.btnSelDir.Click += new System.EventHandler(this.btnSelDir_Click);
            // 
            // btnSaveSel
            // 
            this.btnSaveSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveSel.Location = new System.Drawing.Point(415, 289);
            this.btnSaveSel.Name = "btnSaveSel";
            this.btnSaveSel.Size = new System.Drawing.Size(75, 24);
            this.btnSaveSel.TabIndex = 9;
            this.btnSaveSel.Text = "Seleccionar";
            this.btnSaveSel.UseVisualStyleBackColor = true;
            this.btnSaveSel.Click += new System.EventHandler(this.btnSaveSel_Click);
            // 
            // lblStatusCom
            // 
            this.lblStatusCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatusCom.AutoSize = true;
            this.lblStatusCom.Location = new System.Drawing.Point(12, 339);
            this.lblStatusCom.Name = "lblStatusCom";
            this.lblStatusCom.Size = new System.Drawing.Size(32, 15);
            this.lblStatusCom.TabIndex = 3;
            this.lblStatusCom.Text = "Listo";
            // 
            // prgCompress
            // 
            this.prgCompress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prgCompress.Location = new System.Drawing.Point(12, 355);
            this.prgCompress.Name = "prgCompress";
            this.prgCompress.Size = new System.Drawing.Size(478, 25);
            this.prgCompress.TabIndex = 1;
            // 
            // btnCComprimir
            // 
            this.btnCComprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCComprimir.Location = new System.Drawing.Point(177, 385);
            this.btnCComprimir.Name = "btnCComprimir";
            this.btnCComprimir.Size = new System.Drawing.Size(75, 24);
            this.btnCComprimir.TabIndex = 14;
            this.btnCComprimir.Text = "Cancelar";
            this.btnCComprimir.UseVisualStyleBackColor = true;
            this.btnCComprimir.Click += new System.EventHandler(this.btnCComprimir_Click);
            // 
            // btnComprimir
            // 
            this.btnComprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComprimir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnComprimir.Location = new System.Drawing.Point(380, 385);
            this.btnComprimir.Name = "btnComprimir";
            this.btnComprimir.Size = new System.Drawing.Size(110, 24);
            this.btnComprimir.TabIndex = 12;
            this.btnComprimir.Text = "Comprimir";
            this.btnComprimir.UseVisualStyleBackColor = true;
            this.btnComprimir.Click += new System.EventHandler(this.btnComprimir_Click);
            // 
            // lblSalidaFile
            // 
            this.lblSalidaFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSalidaFile.AutoSize = true;
            this.lblSalidaFile.Location = new System.Drawing.Point(12, 317);
            this.lblSalidaFile.Name = "lblSalidaFile";
            this.lblSalidaFile.Size = new System.Drawing.Size(117, 15);
            this.lblSalidaFile.TabIndex = 16;
            this.lblSalidaFile.Text = "Archivo de salida: {0}";
            // 
            // lblTiempo
            // 
            this.lblTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(12, 388);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(0, 15);
            this.lblTiempo.TabIndex = 35;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SharpCompress";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(258, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 24);
            this.button1.TabIndex = 13;
            this.button1.Text = "Segundo plano";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkPass
            // 
            this.chkPass.AutoSize = true;
            this.chkPass.Location = new System.Drawing.Point(19, 100);
            this.chkPass.Name = "chkPass";
            this.chkPass.Size = new System.Drawing.Size(155, 19);
            this.chkPass.TabIndex = 4;
            this.chkPass.Text = "Proteger con contraseña";
            this.chkPass.UseVisualStyleBackColor = true;
            this.chkPass.CheckedChanged += new System.EventHandler(this.chkPass_CheckedChanged);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(83, 22);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(160, 23);
            this.txtPass.TabIndex = 5;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 39;
            this.label6.Text = "Contraseña:";
            // 
            // txtConfirPass
            // 
            this.txtConfirPass.Location = new System.Drawing.Point(312, 22);
            this.txtConfirPass.Name = "txtConfirPass";
            this.txtConfirPass.Size = new System.Drawing.Size(160, 23);
            this.txtConfirPass.TabIndex = 6;
            this.txtConfirPass.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 39;
            this.label7.Text = "Confirmar:";
            // 
            // cmbEncrip
            // 
            this.cmbEncrip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncrip.FormattingEnabled = true;
            this.cmbEncrip.Items.AddRange(new object[] {
            "ZipCrypto",
            "AES-128",
            "AES-192",
            "AES-256"});
            this.cmbEncrip.Location = new System.Drawing.Point(83, 51);
            this.cmbEncrip.Name = "cmbEncrip";
            this.cmbEncrip.Size = new System.Drawing.Size(160, 23);
            this.cmbEncrip.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 39;
            this.label8.Text = "Encriptado:";
            // 
            // grbEncrip
            // 
            this.grbEncrip.Controls.Add(this.chkNombres);
            this.grbEncrip.Controls.Add(this.chkShowPass);
            this.grbEncrip.Controls.Add(this.txtConfirPass);
            this.grbEncrip.Controls.Add(this.txtPass);
            this.grbEncrip.Controls.Add(this.cmbEncrip);
            this.grbEncrip.Controls.Add(this.label6);
            this.grbEncrip.Controls.Add(this.label8);
            this.grbEncrip.Controls.Add(this.label7);
            this.grbEncrip.Enabled = false;
            this.grbEncrip.Location = new System.Drawing.Point(12, 103);
            this.grbEncrip.Name = "grbEncrip";
            this.grbEncrip.Size = new System.Drawing.Size(478, 102);
            this.grbEncrip.TabIndex = 41;
            this.grbEncrip.TabStop = false;
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Location = new System.Drawing.Point(251, 51);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(128, 19);
            this.chkShowPass.TabIndex = 8;
            this.chkShowPass.Text = "Mostrar contraseña";
            this.chkShowPass.UseVisualStyleBackColor = true;
            this.chkShowPass.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);
            // 
            // grbVolume
            // 
            this.grbVolume.Controls.Add(this.label11);
            this.grbVolume.Controls.Add(this.txtVolumen);
            this.grbVolume.Controls.Add(this.chkVolumenCus);
            this.grbVolume.Controls.Add(this.label10);
            this.grbVolume.Controls.Add(this.cmbVolumen);
            this.grbVolume.Controls.Add(this.label9);
            this.grbVolume.Enabled = false;
            this.grbVolume.Location = new System.Drawing.Point(12, 214);
            this.grbVolume.Name = "grbVolume";
            this.grbVolume.Size = new System.Drawing.Size(478, 54);
            this.grbVolume.TabIndex = 42;
            this.grbVolume.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 15);
            this.label9.TabIndex = 40;
            this.label9.Text = "Tamaño de volúmenes:";
            // 
            // cmbVolumen
            // 
            this.cmbVolumen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVolumen.FormattingEnabled = true;
            this.cmbVolumen.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "100",
            "150",
            "300"});
            this.cmbVolumen.Location = new System.Drawing.Point(134, 20);
            this.cmbVolumen.Name = "cmbVolumen";
            this.cmbVolumen.Size = new System.Drawing.Size(64, 23);
            this.cmbVolumen.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(199, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 15);
            this.label10.TabIndex = 42;
            this.label10.Text = "MB";
            // 
            // chkVolumenCus
            // 
            this.chkVolumenCus.AutoSize = true;
            this.chkVolumenCus.Location = new System.Drawing.Point(230, 23);
            this.chkVolumenCus.Name = "chkVolumenCus";
            this.chkVolumenCus.Size = new System.Drawing.Size(149, 19);
            this.chkVolumenCus.TabIndex = 10;
            this.chkVolumenCus.Text = "Volumen personalizado";
            this.chkVolumenCus.UseVisualStyleBackColor = true;
            this.chkVolumenCus.CheckedChanged += new System.EventHandler(this.chkVolumenCus_CheckedChanged);
            // 
            // txtVolumen
            // 
            this.txtVolumen.Enabled = false;
            this.txtVolumen.Location = new System.Drawing.Point(376, 20);
            this.txtVolumen.Name = "txtVolumen";
            this.txtVolumen.Size = new System.Drawing.Size(63, 23);
            this.txtVolumen.TabIndex = 11;
            this.txtVolumen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVolumen_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(445, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 15);
            this.label11.TabIndex = 45;
            this.label11.Text = "MB";
            // 
            // chkNombres
            // 
            this.chkNombres.AutoSize = true;
            this.chkNombres.Enabled = false;
            this.chkNombres.Location = new System.Drawing.Point(83, 77);
            this.chkNombres.Name = "chkNombres";
            this.chkNombres.Size = new System.Drawing.Size(166, 19);
            this.chkNombres.TabIndex = 40;
            this.chkNombres.Text = "Cifrar nombres de ficheros";
            this.chkNombres.UseVisualStyleBackColor = true;
            // 
            // chkDividir
            // 
            this.chkDividir.AutoSize = true;
            this.chkDividir.Enabled = false;
            this.chkDividir.Location = new System.Drawing.Point(19, 211);
            this.chkDividir.Name = "chkDividir";
            this.chkDividir.Size = new System.Drawing.Size(195, 19);
            this.chkDividir.TabIndex = 43;
            this.chkDividir.Text = "Dividir en volúmenes (7zip - Tar)";
            this.chkDividir.UseVisualStyleBackColor = true;
            this.chkDividir.CheckedChanged += new System.EventHandler(this.chkDividir_CheckedChanged);
            // 
            // CompressF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 419);
            this.Controls.Add(this.chkDividir);
            this.Controls.Add(this.chkPass);
            this.Controls.Add(this.grbVolume);
            this.Controls.Add(this.grbEncrip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblSalidaFile);
            this.Controls.Add(this.cmbMetodo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFormato);
            this.Controls.Add(this.btnComprimir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCComprimir);
            this.Controls.Add(this.cmbNivel);
            this.Controls.Add(this.prgCompress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatusCom);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.btnSaveSel);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.btnSelDir);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompressF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.compressForm_HelpButtonClicked);
            this.grbEncrip.ResumeLayout(false);
            this.grbEncrip.PerformLayout();
            this.grbVolume.ResumeLayout(false);
            this.grbVolume.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCComprimir;
        private System.Windows.Forms.Button btnComprimir;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelDir;
        private System.Windows.Forms.Button btnSaveSel;
        private System.Windows.Forms.Label lblStatusCom;
        private System.Windows.Forms.ProgressBar prgCompress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SaveFileDialog SaveCompressFile;
        private System.Windows.Forms.FolderBrowserDialog SelectCompressFolder;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmbNivel;
        public System.Windows.Forms.ComboBox cmbFormato;
        public System.Windows.Forms.ComboBox cmbMetodo;
        private System.Windows.Forms.Label lblSalidaFile;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtConfirPass;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cmbEncrip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grbEncrip;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.GroupBox grbVolume;
        public System.Windows.Forms.ComboBox cmbVolumen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVolumen;
        private System.Windows.Forms.CheckBox chkVolumenCus;
        private System.Windows.Forms.CheckBox chkNombres;
        private System.Windows.Forms.CheckBox chkDividir;
    }
}

