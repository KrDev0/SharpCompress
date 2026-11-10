using MaterialSkin.Controls;

﻿namespace _7ZipSharp
{
    partial class CompressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompressForm));
            this.toolTipCompression = new System.Windows.Forms.ToolTip(this.components);
            this.cmbMetodo = new MaterialSkin.Controls.MaterialComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFormato = new MaterialSkin.Controls.MaterialComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNivel = new MaterialSkin.Controls.MaterialComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSave = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveSel = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblStatusCom = new System.Windows.Forms.Label();
            this.prgCompress = new MaterialSkin.Controls.MaterialProgressBar();
            this.btnCComprimir = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnComprimir = new MaterialSkin.Controls.MaterialFlatButton();
            this.SaveCompressFile = new System.Windows.Forms.SaveFileDialog();
            this.SelectCompressFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblSalidaFile = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.chkPass = new MaterialSkin.Controls.MaterialCheckBox();
            this.txtPass = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConfirPass = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEncrip = new MaterialSkin.Controls.MaterialComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grbEncrip = new System.Windows.Forms.GroupBox();
            this.chkNombres = new MaterialSkin.Controls.MaterialCheckBox();
            this.chkShowPass = new MaterialSkin.Controls.MaterialCheckBox();
            this.grbVolume = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVolumen = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.chkVolumenCus = new MaterialSkin.Controls.MaterialCheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbVolumen = new MaterialSkin.Controls.MaterialComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkDividir = new MaterialSkin.Controls.MaterialCheckBox();
            this.chkRootDir = new MaterialSkin.Controls.MaterialCheckBox();
            this.listViewArchivos = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnAgregarCarpeta = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnAgregarArchivos = new MaterialSkin.Controls.MaterialFlatButton();
            this.grbCompression = new System.Windows.Forms.GroupBox();
            this.cmbPerfil = new MaterialSkin.Controls.MaterialComboBox();
            this.labelPerfil = new System.Windows.Forms.Label();
            this.lblOptionDescription = new System.Windows.Forms.Label();
            this.chkCreateSfx = new MaterialSkin.Controls.MaterialCheckBox();
            this.btnConfigureSfx = new MaterialSkin.Controls.MaterialFlatButton();
            this.grbEncrip.SuspendLayout();
            this.grbVolume.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.grbCompression.SuspendLayout();
            this.SuspendLayout();
            //
            // cmbMetodo
            //
            this.cmbMetodo.BackColor = System.Drawing.Color.White;
            this.cmbMetodo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMetodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.cmbMetodo.FormattingEnabled = true;
            this.cmbMetodo.ItemHeight = 25;
            this.cmbMetodo.Items.AddRange(new object[] {
            "Deflate (Por defecto)",
            "Deflate64",
            "BZip2",
            "LZMA",
            "PPMd"});
            this.cmbMetodo.Location = new System.Drawing.Point(423, 34);
            this.cmbMetodo.Name = "cmbMetodo";
            this.cmbMetodo.Size = new System.Drawing.Size(167, 31);
            this.cmbMetodo.TabIndex = 3;
            this.cmbMetodo.SelectedIndexChanged += new System.EventHandler(this.cmbMetodo_SelectedIndexChanged);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(423, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Método:";
            //
            // cmbFormato
            //
            this.cmbFormato.BackColor = System.Drawing.Color.White;
            this.cmbFormato.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFormato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.cmbFormato.FormattingEnabled = true;
            this.cmbFormato.ItemHeight = 25;
            this.cmbFormato.Items.AddRange(new object[] {
            "7z",
            "Tar",
            "Zip",
            "gz",
            "SCZ"});
            this.cmbFormato.Location = new System.Drawing.Point(171, 34);
            this.cmbFormato.Name = "cmbFormato";
            this.cmbFormato.Size = new System.Drawing.Size(82, 31);
            this.cmbFormato.TabIndex = 2;
            this.cmbFormato.SelectedIndexChanged += new System.EventHandler(this.cmbFormato_SelectedIndexChanged);
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label5.Location = new System.Drawing.Point(171, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Formato:";
            //
            // cmbNivel
            //
            this.cmbNivel.BackColor = System.Drawing.Color.White;
            this.cmbNivel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivel.DropDownWidth = 240;
            this.cmbNivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNivel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.ItemHeight = 25;
            this.cmbNivel.Items.AddRange(new object[] {
            "Ninguno",
            "Rápido",
            "Bajo",
            "Normal",
            "Alto",
            "Ultra"});
            this.cmbNivel.Location = new System.Drawing.Point(265, 34);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(145, 31);
            this.cmbNivel.TabIndex = 1;
            this.cmbNivel.SelectedIndexChanged += new System.EventHandler(this.cmbNivel_SelectedIndexChanged);
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(265, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nivel:";
            //
            // txtSave
            //
            this.txtSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSave.BackColor = System.Drawing.Color.White;
            this.txtSave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSave.Depth = 0;
            this.txtSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.txtSave.Hint = "";
            this.txtSave.Location = new System.Drawing.Point(16, 577);
            this.txtSave.MaxLength = 32767;
            this.txtSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSave.Name = "txtSave";
            this.txtSave.PasswordChar = '\0';
            this.txtSave.ReadOnly = true;
            this.txtSave.SelectedText = "";
            this.txtSave.SelectionLength = 0;
            this.txtSave.SelectionStart = 0;
            this.txtSave.Size = new System.Drawing.Size(487, 21);
            this.txtSave.TabIndex = 14;
            this.txtSave.TabStop = false;
            this.txtSave.UseSystemPasswordChar = false;
            //
            // label3
            //
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(16, 558);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Guardar archivo en:";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Elementos a comprimir:";
            //
            // btnSaveSel
            //
            this.btnSaveSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveSel.BackColor = System.Drawing.Color.White;
            this.btnSaveSel.Depth = 0;
            this.btnSaveSel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.btnSaveSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btnSaveSel.Icon = null;
            this.btnSaveSel.Location = new System.Drawing.Point(511, 569);
            this.btnSaveSel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveSel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveSel.Name = "btnSaveSel";
            this.btnSaveSel.Primary = false;
            this.btnSaveSel.Size = new System.Drawing.Size(97, 36);
            this.btnSaveSel.TabIndex = 9;
            this.btnSaveSel.Text = "Examinar...";
            this.btnSaveSel.UseVisualStyleBackColor = false;
            this.btnSaveSel.Click += new System.EventHandler(this.btnSaveSel_Click);
            //
            // lblStatusCom
            //
            this.lblStatusCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusCom.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatusCom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.lblStatusCom.Location = new System.Drawing.Point(13, 630);
            this.lblStatusCom.Name = "lblStatusCom";
            this.lblStatusCom.Size = new System.Drawing.Size(604, 18);
            this.lblStatusCom.TabIndex = 3;
            this.lblStatusCom.Text = "Listo";
            //
            // prgCompress
            //
            this.prgCompress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgCompress.Depth = 0;
            this.prgCompress.Location = new System.Drawing.Point(13, 653);
            this.prgCompress.MouseState = MaterialSkin.MouseState.HOVER;
            this.prgCompress.Name = "prgCompress";
            this.prgCompress.Size = new System.Drawing.Size(608, 5);
            this.prgCompress.TabIndex = 1;
            //
            // btnCComprimir
            //
            this.btnCComprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCComprimir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCComprimir.BackColor = System.Drawing.Color.White;
            this.btnCComprimir.Depth = 0;
            this.btnCComprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.btnCComprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCComprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btnCComprimir.Icon = null;
            this.btnCComprimir.Location = new System.Drawing.Point(299, 671);
            this.btnCComprimir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCComprimir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCComprimir.Name = "btnCComprimir";
            this.btnCComprimir.Primary = false;
            this.btnCComprimir.Size = new System.Drawing.Size(86, 36);
            this.btnCComprimir.TabIndex = 14;
            this.btnCComprimir.Text = "Cancelar";
            this.btnCComprimir.UseVisualStyleBackColor = false;
            this.btnCComprimir.Click += new System.EventHandler(this.btnCComprimir_Click);
            //
            // btnComprimir
            //
            this.btnComprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComprimir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnComprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(63)))));
            this.btnComprimir.Depth = 0;
            this.btnComprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.btnComprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprimir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnComprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btnComprimir.Icon = null;
            this.btnComprimir.Location = new System.Drawing.Point(529, 671);
            this.btnComprimir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnComprimir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnComprimir.Name = "btnComprimir";
            this.btnComprimir.Primary = false;
            this.btnComprimir.Size = new System.Drawing.Size(94, 36);
            this.btnComprimir.TabIndex = 12;
            this.btnComprimir.Text = "Comprimir";
            this.btnComprimir.UseVisualStyleBackColor = false;
            this.btnComprimir.Click += new System.EventHandler(this.btnComprimir_Click);
            //
            // lblSalidaFile
            //
            this.lblSalidaFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalidaFile.AutoSize = true;
            this.lblSalidaFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSalidaFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.lblSalidaFile.Location = new System.Drawing.Point(13, 601);
            this.lblSalidaFile.Name = "lblSalidaFile";
            this.lblSalidaFile.Size = new System.Drawing.Size(117, 15);
            this.lblSalidaFile.TabIndex = 16;
            this.lblSalidaFile.Text = "Archivo de salida: {0}";
            //
            // lblTiempo
            //
            this.lblTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiempo.AutoEllipsis = true;
            this.lblTiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.lblTiempo.Location = new System.Drawing.Point(10, 661);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(281, 28);
            this.lblTiempo.TabIndex = 35;
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // notifyIcon1
            //
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SharpCompress";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            //
            // button1
            //
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Depth = 0;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(393, 671);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.Primary = false;
            this.button1.Size = new System.Drawing.Size(128, 36);
            this.button1.TabIndex = 13;
            this.button1.Text = "Segundo plano";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // chkPass
            //
            this.chkPass.AutoSize = true;
            this.chkPass.Depth = 0;
            this.chkPass.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkPass.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.chkPass.Location = new System.Drawing.Point(16, 330);
            this.chkPass.Margin = new System.Windows.Forms.Padding(0);
            this.chkPass.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkPass.Name = "chkPass";
            this.chkPass.Ripple = true;
            this.chkPass.Size = new System.Drawing.Size(182, 30);
            this.chkPass.TabIndex = 4;
            this.chkPass.Text = "Proteger con contraseña";
            this.chkPass.UseVisualStyleBackColor = true;
            this.chkPass.CheckedChanged += new System.EventHandler(this.chkPass_CheckedChanged);
            //
            // txtPass
            //
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Depth = 0;
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.txtPass.Hint = "";
            this.txtPass.Location = new System.Drawing.Point(83, 30);
            this.txtPass.MaxLength = 32767;
            this.txtPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '\0';
            this.txtPass.ReadOnly = false;
            this.txtPass.SelectedText = "";
            this.txtPass.SelectionLength = 0;
            this.txtPass.SelectionStart = 0;
            this.txtPass.Size = new System.Drawing.Size(200, 21);
            this.txtPass.TabIndex = 5;
            this.txtPass.TabStop = false;
            this.txtPass.UseSystemPasswordChar = true;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label6.Location = new System.Drawing.Point(10, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 39;
            this.label6.Text = "Contraseña:";
            //
            // txtConfirPass
            //
            this.txtConfirPass.BackColor = System.Drawing.Color.White;
            this.txtConfirPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirPass.Depth = 0;
            this.txtConfirPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.txtConfirPass.Hint = "";
            this.txtConfirPass.Location = new System.Drawing.Point(83, 59);
            this.txtConfirPass.MaxLength = 32767;
            this.txtConfirPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConfirPass.Name = "txtConfirPass";
            this.txtConfirPass.PasswordChar = '\0';
            this.txtConfirPass.ReadOnly = false;
            this.txtConfirPass.SelectedText = "";
            this.txtConfirPass.SelectionLength = 0;
            this.txtConfirPass.SelectionStart = 0;
            this.txtConfirPass.Size = new System.Drawing.Size(200, 21);
            this.txtConfirPass.TabIndex = 6;
            this.txtConfirPass.TabStop = false;
            this.txtConfirPass.UseSystemPasswordChar = true;
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label7.Location = new System.Drawing.Point(18, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 39;
            this.label7.Text = "Confirmar:";
            //
            // cmbEncrip
            //
            this.cmbEncrip.BackColor = System.Drawing.Color.White;
            this.cmbEncrip.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEncrip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEncrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.cmbEncrip.FormattingEnabled = true;
            this.cmbEncrip.ItemHeight = 25;
            this.cmbEncrip.Items.AddRange(new object[] {
            "ZipCrypto",
            "AES-128",
            "AES-192",
            "AES-256"});
            this.cmbEncrip.Location = new System.Drawing.Point(83, 116);
            this.cmbEncrip.Name = "cmbEncrip";
            this.cmbEncrip.Size = new System.Drawing.Size(200, 31);
            this.cmbEncrip.TabIndex = 7;
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label8.Location = new System.Drawing.Point(10, 119);
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
            this.grbEncrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(63)))));
            this.grbEncrip.Location = new System.Drawing.Point(16, 363);
            this.grbEncrip.Name = "grbEncrip";
            this.grbEncrip.Size = new System.Drawing.Size(302, 192);
            this.grbEncrip.TabIndex = 41;
            this.grbEncrip.TabStop = false;
            this.grbEncrip.Text = "Seguridad del archivo";
            //
            // chkNombres
            //
            this.chkNombres.AutoSize = true;
            this.chkNombres.Depth = 0;
            this.chkNombres.Enabled = false;
            this.chkNombres.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkNombres.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkNombres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.chkNombres.Location = new System.Drawing.Point(40, 150);
            this.chkNombres.Margin = new System.Windows.Forms.Padding(0);
            this.chkNombres.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkNombres.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkNombres.Name = "chkNombres";
            this.chkNombres.Ripple = true;
            this.chkNombres.Size = new System.Drawing.Size(253, 30);
            this.chkNombres.TabIndex = 40;
            this.chkNombres.Text = "Cifrar nombres de ficheros (7z/SCZ)";
            this.chkNombres.UseVisualStyleBackColor = true;
            //
            // chkShowPass
            //
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Depth = 0;
            this.chkShowPass.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShowPass.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkShowPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.chkShowPass.Location = new System.Drawing.Point(83, 83);
            this.chkShowPass.Margin = new System.Windows.Forms.Padding(0);
            this.chkShowPass.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkShowPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Ripple = true;
            this.chkShowPass.Size = new System.Drawing.Size(151, 30);
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
            this.grbVolume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(63)))));
            this.grbVolume.Location = new System.Drawing.Point(324, 363);
            this.grbVolume.Name = "grbVolume";
            this.grbVolume.Size = new System.Drawing.Size(300, 82);
            this.grbVolume.TabIndex = 42;
            this.grbVolume.TabStop = false;
            this.grbVolume.Text = "Tamaño de cada parte";
            //
            // label11
            //
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label11.Location = new System.Drawing.Point(232, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 15);
            this.label11.TabIndex = 45;
            this.label11.Text = "MB";
            //
            // txtVolumen
            //
            this.txtVolumen.BackColor = System.Drawing.Color.White;
            this.txtVolumen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVolumen.Depth = 0;
            this.txtVolumen.Enabled = false;
            this.txtVolumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.txtVolumen.Hint = "";
            this.txtVolumen.Location = new System.Drawing.Point(164, 46);
            this.txtVolumen.MaxLength = 32767;
            this.txtVolumen.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtVolumen.Name = "txtVolumen";
            this.txtVolumen.PasswordChar = '\0';
            this.txtVolumen.ReadOnly = false;
            this.txtVolumen.SelectedText = "";
            this.txtVolumen.SelectionLength = 0;
            this.txtVolumen.SelectionStart = 0;
            this.txtVolumen.Size = new System.Drawing.Size(63, 21);
            this.txtVolumen.TabIndex = 11;
            this.txtVolumen.TabStop = false;
            this.txtVolumen.UseSystemPasswordChar = false;
            this.txtVolumen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVolumen_KeyPress);
            //
            // chkVolumenCus
            //
            this.chkVolumenCus.AutoSize = true;
            this.chkVolumenCus.Depth = 0;
            this.chkVolumenCus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkVolumenCus.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkVolumenCus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.chkVolumenCus.Location = new System.Drawing.Point(13, 49);
            this.chkVolumenCus.Margin = new System.Windows.Forms.Padding(0);
            this.chkVolumenCus.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkVolumenCus.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkVolumenCus.Name = "chkVolumenCus";
            this.chkVolumenCus.Ripple = true;
            this.chkVolumenCus.Size = new System.Drawing.Size(175, 30);
            this.chkVolumenCus.TabIndex = 10;
            this.chkVolumenCus.Text = "Volumen personalizado";
            this.chkVolumenCus.UseVisualStyleBackColor = true;
            this.chkVolumenCus.CheckedChanged += new System.EventHandler(this.chkVolumenCus_CheckedChanged);
            //
            // label10
            //
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label10.Location = new System.Drawing.Point(232, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 15);
            this.label10.TabIndex = 42;
            this.label10.Text = "MB";
            //
            // cmbVolumen
            //
            this.cmbVolumen.BackColor = System.Drawing.Color.White;
            this.cmbVolumen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbVolumen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVolumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVolumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.cmbVolumen.FormattingEnabled = true;
            this.cmbVolumen.ItemHeight = 25;
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
            this.cmbVolumen.Location = new System.Drawing.Point(163, 20);
            this.cmbVolumen.Name = "cmbVolumen";
            this.cmbVolumen.Size = new System.Drawing.Size(64, 31);
            this.cmbVolumen.TabIndex = 9;
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.label9.Location = new System.Drawing.Point(10, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 15);
            this.label9.TabIndex = 40;
            this.label9.Text = "Tamaño por parte:";
            //
            // chkDividir
            //
            this.chkDividir.AutoSize = true;
            this.chkDividir.Depth = 0;
            this.chkDividir.Enabled = false;
            this.chkDividir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDividir.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkDividir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.chkDividir.Location = new System.Drawing.Point(324, 330);
            this.chkDividir.Margin = new System.Windows.Forms.Padding(0);
            this.chkDividir.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkDividir.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkDividir.Name = "chkDividir";
            this.chkDividir.Ripple = true;
            this.chkDividir.Size = new System.Drawing.Size(217, 30);
            this.chkDividir.TabIndex = 43;
            this.chkDividir.Text = "Dividir en volúmenes (7z/SCZ)";
            this.chkDividir.UseVisualStyleBackColor = true;
            this.chkDividir.CheckedChanged += new System.EventHandler(this.chkDividir_CheckedChanged);
            //
            // chkRootDir
            //
            this.chkRootDir.AutoSize = true;
            this.chkRootDir.Depth = 0;
            this.chkRootDir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRootDir.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkRootDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.chkRootDir.Location = new System.Drawing.Point(445, 8);
            this.chkRootDir.Margin = new System.Windows.Forms.Padding(0);
            this.chkRootDir.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkRootDir.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkRootDir.Name = "chkRootDir";
            this.chkRootDir.Ripple = true;
            this.chkRootDir.Size = new System.Drawing.Size(178, 30);
            this.chkRootDir.TabIndex = 44;
            this.chkRootDir.Text = "Mantener directorio raíz";
            this.chkRootDir.UseVisualStyleBackColor = true;
            //
            // listViewArchivos
            //
            this.listViewArchivos.AllowDrop = true;
            this.listViewArchivos.BackColor = System.Drawing.Color.White;
            this.listViewArchivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewArchivos.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewArchivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.listViewArchivos.FullRowSelect = true;
            this.listViewArchivos.HideSelection = false;
            this.listViewArchivos.Location = new System.Drawing.Point(16, 42);
            this.listViewArchivos.Name = "listViewArchivos";
            this.listViewArchivos.Size = new System.Drawing.Size(608, 148);
            this.listViewArchivos.TabIndex = 45;
            this.listViewArchivos.UseCompatibleStateImageBehavior = false;
            this.listViewArchivos.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewArchivos_DragDrop);
            this.listViewArchivos.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewArchivos_DragEnter);
            //
            // contextMenuStrip1
            //
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerArchivoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 26);
            //
            // removerArchivoToolStripMenuItem
            //
            this.removerArchivoToolStripMenuItem.Name = "removerArchivoToolStripMenuItem";
            this.removerArchivoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.removerArchivoToolStripMenuItem.Text = "Remover elemento";
            this.removerArchivoToolStripMenuItem.Click += new System.EventHandler(this.removerArchivoToolStripMenuItem_Click);
            //
            // lblMensaje
            //
            this.lblMensaje.BackColor = System.Drawing.Color.White;
            this.lblMensaje.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.lblMensaje.Location = new System.Drawing.Point(324, 204);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(300, 15);
            this.lblMensaje.TabIndex = 46;
            this.lblMensaje.Text = "Agregue archivos o carpetas para comprimir";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // btnAgregarCarpeta
            //
            this.btnAgregarCarpeta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarCarpeta.BackColor = System.Drawing.Color.White;
            this.btnAgregarCarpeta.Depth = 0;
            this.btnAgregarCarpeta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.btnAgregarCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCarpeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btnAgregarCarpeta.Icon = null;
            this.btnAgregarCarpeta.Location = new System.Drawing.Point(16, 196);
            this.btnAgregarCarpeta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregarCarpeta.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregarCarpeta.Name = "btnAgregarCarpeta";
            this.btnAgregarCarpeta.Primary = false;
            this.btnAgregarCarpeta.Size = new System.Drawing.Size(138, 36);
            this.btnAgregarCarpeta.TabIndex = 47;
            this.btnAgregarCarpeta.Text = "Agregar carpeta";
            this.btnAgregarCarpeta.UseVisualStyleBackColor = false;
            this.btnAgregarCarpeta.Click += new System.EventHandler(this.btnAgregarCarpeta_Click);
            //
            // btnAgregarArchivos
            //
            this.btnAgregarArchivos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarArchivos.BackColor = System.Drawing.Color.White;
            this.btnAgregarArchivos.Depth = 0;
            this.btnAgregarArchivos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.btnAgregarArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarArchivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btnAgregarArchivos.Icon = null;
            this.btnAgregarArchivos.Location = new System.Drawing.Point(162, 196);
            this.btnAgregarArchivos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregarArchivos.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregarArchivos.Name = "btnAgregarArchivos";
            this.btnAgregarArchivos.Primary = false;
            this.btnAgregarArchivos.Size = new System.Drawing.Size(147, 36);
            this.btnAgregarArchivos.TabIndex = 48;
            this.btnAgregarArchivos.Text = "Agregar archivos";
            this.btnAgregarArchivos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarArchivos.UseVisualStyleBackColor = false;
            this.btnAgregarArchivos.Click += new System.EventHandler(this.btnAgregarArchivos_Click);
            //
            // grbCompression
            //
            this.grbCompression.Controls.Add(this.cmbMetodo);
            this.grbCompression.Controls.Add(this.label1);
            this.grbCompression.Controls.Add(this.cmbNivel);
            this.grbCompression.Controls.Add(this.label4);
            this.grbCompression.Controls.Add(this.cmbFormato);
            this.grbCompression.Controls.Add(this.label5);
            this.grbCompression.Controls.Add(this.cmbPerfil);
            this.grbCompression.Controls.Add(this.labelPerfil);
            this.grbCompression.Controls.Add(this.lblOptionDescription);
            this.grbCompression.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(63)))));
            this.grbCompression.Location = new System.Drawing.Point(16, 241);
            this.grbCompression.Name = "grbCompression";
            this.grbCompression.Size = new System.Drawing.Size(608, 86);
            this.grbCompression.TabIndex = 49;
            this.grbCompression.TabStop = false;
            this.grbCompression.Text = "Formato y compresión";
            //
            // cmbPerfil
            //
            this.cmbPerfil.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPerfil.FormattingEnabled = true;
            this.cmbPerfil.ItemHeight = 25;
            this.cmbPerfil.Items.AddRange(new object[] {
            "Equilibrado",
            "Más rápido",
            "Menor tamaño",
            "Personalizado"});
            this.cmbPerfil.Location = new System.Drawing.Point(12, 34);
            this.cmbPerfil.Name = "cmbPerfil";
            this.cmbPerfil.Size = new System.Drawing.Size(148, 31);
            this.cmbPerfil.TabIndex = 0;
            this.cmbPerfil.SelectedIndexChanged += new System.EventHandler(this.cmbPerfil_SelectedIndexChanged);
            //
            // labelPerfil
            //
            this.labelPerfil.AutoSize = true;
            this.labelPerfil.Location = new System.Drawing.Point(12, 16);
            this.labelPerfil.Name = "labelPerfil";
            this.labelPerfil.Size = new System.Drawing.Size(37, 15);
            this.labelPerfil.TabIndex = 15;
            this.labelPerfil.Text = "Perfil:";
            //
            // lblOptionDescription
            //
            this.lblOptionDescription.AutoEllipsis = true;
            this.lblOptionDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(101)))), ((int)(((byte)(110)))));
            this.lblOptionDescription.Location = new System.Drawing.Point(12, 62);
            this.lblOptionDescription.Name = "lblOptionDescription";
            this.lblOptionDescription.Size = new System.Drawing.Size(580, 16);
            this.lblOptionDescription.TabIndex = 16;
            this.lblOptionDescription.Text = "Equilibrado: buena relación entre velocidad y tamaño.";
            //
            // chkCreateSfx
            //
            this.chkCreateSfx.AutoSize = true;
            this.chkCreateSfx.Depth = 0;
            this.chkCreateSfx.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkCreateSfx.Location = new System.Drawing.Point(324, 452);
            this.chkCreateSfx.Margin = new System.Windows.Forms.Padding(0);
            this.chkCreateSfx.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkCreateSfx.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkCreateSfx.Name = "chkCreateSfx";
            this.chkCreateSfx.Ripple = true;
            this.chkCreateSfx.Size = new System.Drawing.Size(188, 30);
            this.chkCreateSfx.TabIndex = 50;
            this.chkCreateSfx.Text = "Crear autoextractor (.exe)";
            this.chkCreateSfx.UseVisualStyleBackColor = true;
            this.chkCreateSfx.CheckedChanged += new System.EventHandler(this.chkCreateSfx_CheckedChanged);
            //
            // btnConfigureSfx
            //
            this.btnConfigureSfx.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfigureSfx.BackColor = System.Drawing.Color.White;
            this.btnConfigureSfx.Depth = 0;
            this.btnConfigureSfx.Enabled = false;
            this.btnConfigureSfx.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.btnConfigureSfx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigureSfx.Icon = null;
            this.btnConfigureSfx.Location = new System.Drawing.Point(466, 488);
            this.btnConfigureSfx.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfigureSfx.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfigureSfx.Name = "btnConfigureSfx";
            this.btnConfigureSfx.Primary = false;
            this.btnConfigureSfx.Size = new System.Drawing.Size(113, 36);
            this.btnConfigureSfx.TabIndex = 51;
            this.btnConfigureSfx.Text = "Configurar…";
            this.btnConfigureSfx.UseVisualStyleBackColor = true;
            this.btnConfigureSfx.Click += new System.EventHandler(this.btnConfigureSfx_Click);
            //
            // CompressForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(636, 722);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.grbCompression);
            this.Controls.Add(this.chkCreateSfx);
            this.Controls.Add(this.btnConfigureSfx);
            this.Controls.Add(this.btnAgregarCarpeta);
            this.Controls.Add(this.btnAgregarArchivos);
            this.Controls.Add(this.listViewArchivos);
            this.Controls.Add(this.chkRootDir);
            this.Controls.Add(this.chkDividir);
            this.Controls.Add(this.chkPass);
            this.Controls.Add(this.grbVolume);
            this.Controls.Add(this.grbEncrip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblSalidaFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnComprimir);
            this.Controls.Add(this.btnCComprimir);
            this.Controls.Add(this.prgCompress);
            this.Controls.Add(this.lblStatusCom);
            this.Controls.Add(this.btnSaveSel);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.compressForm_HelpButtonClicked);
            this.grbEncrip.ResumeLayout(false);
            this.grbEncrip.PerformLayout();
            this.grbVolume.ResumeLayout(false);
            this.grbVolume.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.grbCompression.ResumeLayout(false);
            this.grbCompression.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialFlatButton btnCComprimir;
        private MaterialSkin.Controls.MaterialFlatButton btnComprimir;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialFlatButton btnSaveSel;
        private System.Windows.Forms.Label lblStatusCom;
        private MaterialSkin.Controls.MaterialProgressBar prgCompress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SaveFileDialog SaveCompressFile;
        private System.Windows.Forms.FolderBrowserDialog SelectCompressFolder;
        private System.Windows.Forms.Label label1;
        public MaterialSkin.Controls.MaterialComboBox cmbNivel;
        public MaterialSkin.Controls.MaterialComboBox cmbFormato;
        public MaterialSkin.Controls.MaterialComboBox cmbMetodo;
        private System.Windows.Forms.GroupBox grbCompression;
        private System.Windows.Forms.Label lblSalidaFile;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private MaterialSkin.Controls.MaterialFlatButton button1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPass;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtConfirPass;
        private System.Windows.Forms.Label label7;
        public MaterialSkin.Controls.MaterialComboBox cmbEncrip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grbEncrip;
        private MaterialSkin.Controls.MaterialCheckBox chkShowPass;
        private System.Windows.Forms.GroupBox grbVolume;
        public MaterialSkin.Controls.MaterialComboBox cmbVolumen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtVolumen;
        private MaterialSkin.Controls.MaterialCheckBox chkVolumenCus;
        private MaterialSkin.Controls.MaterialCheckBox chkNombres;
        public MaterialSkin.Controls.MaterialCheckBox chkPass;
        public MaterialSkin.Controls.MaterialCheckBox chkDividir;
        public MaterialSkin.Controls.MaterialCheckBox chkRootDir;
        private System.Windows.Forms.ListView listViewArchivos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removerArchivoToolStripMenuItem;
        private System.Windows.Forms.Label lblMensaje;
        private MaterialSkin.Controls.MaterialFlatButton btnAgregarCarpeta;
        private MaterialSkin.Controls.MaterialFlatButton btnAgregarArchivos;
        private MaterialSkin.Controls.MaterialComboBox cmbPerfil;
        private System.Windows.Forms.Label labelPerfil;
        private System.Windows.Forms.Label lblOptionDescription;
        private MaterialSkin.Controls.MaterialCheckBox chkCreateSfx;
        private MaterialSkin.Controls.MaterialFlatButton btnConfigureSfx;
        private System.Windows.Forms.ToolTip toolTipCompression;
    }
}
