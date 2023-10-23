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
            this.cmbMetodo.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Metodo:";
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
            this.cmbFormato.TabIndex = 13;
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
            this.cmbNivel.TabIndex = 11;
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
            this.txtDir.TabIndex = 9;
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(12, 110);
            this.txtSave.Name = "txtSave";
            this.txtSave.ReadOnly = true;
            this.txtSave.Size = new System.Drawing.Size(397, 23);
            this.txtSave.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
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
            this.btnSelDir.TabIndex = 5;
            this.btnSelDir.Text = "Seleccionar";
            this.btnSelDir.UseVisualStyleBackColor = true;
            this.btnSelDir.Click += new System.EventHandler(this.btnSelDir_Click);
            // 
            // btnSaveSel
            // 
            this.btnSaveSel.Location = new System.Drawing.Point(415, 108);
            this.btnSaveSel.Name = "btnSaveSel";
            this.btnSaveSel.Size = new System.Drawing.Size(75, 24);
            this.btnSaveSel.TabIndex = 4;
            this.btnSaveSel.Text = "Seleccionar";
            this.btnSaveSel.UseVisualStyleBackColor = true;
            this.btnSaveSel.Click += new System.EventHandler(this.btnSaveSel_Click);
            // 
            // lblStatusCom
            // 
            this.lblStatusCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatusCom.AutoSize = true;
            this.lblStatusCom.Location = new System.Drawing.Point(12, 155);
            this.lblStatusCom.Name = "lblStatusCom";
            this.lblStatusCom.Size = new System.Drawing.Size(32, 15);
            this.lblStatusCom.TabIndex = 3;
            this.lblStatusCom.Text = "Listo";
            // 
            // prgCompress
            // 
            this.prgCompress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prgCompress.Location = new System.Drawing.Point(12, 171);
            this.prgCompress.Name = "prgCompress";
            this.prgCompress.Size = new System.Drawing.Size(478, 20);
            this.prgCompress.TabIndex = 1;
            // 
            // btnCComprimir
            // 
            this.btnCComprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCComprimir.Location = new System.Drawing.Point(177, 196);
            this.btnCComprimir.Name = "btnCComprimir";
            this.btnCComprimir.Size = new System.Drawing.Size(75, 24);
            this.btnCComprimir.TabIndex = 2;
            this.btnCComprimir.Text = "Cancelar";
            this.btnCComprimir.UseVisualStyleBackColor = true;
            this.btnCComprimir.Click += new System.EventHandler(this.btnCComprimir_Click);
            // 
            // btnComprimir
            // 
            this.btnComprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComprimir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnComprimir.Location = new System.Drawing.Point(380, 196);
            this.btnComprimir.Name = "btnComprimir";
            this.btnComprimir.Size = new System.Drawing.Size(110, 24);
            this.btnComprimir.TabIndex = 1;
            this.btnComprimir.Text = "Comprimir";
            this.btnComprimir.UseVisualStyleBackColor = true;
            this.btnComprimir.Click += new System.EventHandler(this.btnComprimir_Click);
            // 
            // lblSalidaFile
            // 
            this.lblSalidaFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSalidaFile.AutoSize = true;
            this.lblSalidaFile.Location = new System.Drawing.Point(12, 136);
            this.lblSalidaFile.Name = "lblSalidaFile";
            this.lblSalidaFile.Size = new System.Drawing.Size(117, 15);
            this.lblSalidaFile.TabIndex = 16;
            this.lblSalidaFile.Text = "Archivo de salida: {0}";
            // 
            // lblTiempo
            // 
            this.lblTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(12, 201);
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
            this.button1.Location = new System.Drawing.Point(258, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 24);
            this.button1.TabIndex = 36;
            this.button1.Text = "Segundo plano";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CompressF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 232);
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
    }
}

