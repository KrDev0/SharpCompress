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
            this.btnCComprimir = new System.Windows.Forms.Button();
            this.prgExtract = new System.Windows.Forms.ProgressBar();
            this.lblStatusExtract = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // lblSalidaFile
            // 
            this.lblSalidaFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSalidaFile.AutoSize = true;
            this.lblSalidaFile.Location = new System.Drawing.Point(27, 95);
            this.lblSalidaFile.Name = "lblSalidaFile";
            this.lblSalidaFile.Size = new System.Drawing.Size(21, 15);
            this.lblSalidaFile.TabIndex = 33;
            this.lblSalidaFile.Text = "{0}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Archivo a extraer:";
            // 
            // btnCComprimir
            // 
            this.btnCComprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCComprimir.Location = new System.Drawing.Point(392, 154);
            this.btnCComprimir.Name = "btnCComprimir";
            this.btnCComprimir.Size = new System.Drawing.Size(98, 24);
            this.btnCComprimir.TabIndex = 19;
            this.btnCComprimir.Text = "Cancelar";
            this.btnCComprimir.UseVisualStyleBackColor = true;
            this.btnCComprimir.Click += new System.EventHandler(this.btnCComprimir_Click);
            // 
            // prgExtract
            // 
            this.prgExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prgExtract.Location = new System.Drawing.Point(12, 129);
            this.prgExtract.Name = "prgExtract";
            this.prgExtract.Size = new System.Drawing.Size(478, 20);
            this.prgExtract.TabIndex = 18;
            // 
            // lblStatusExtract
            // 
            this.lblStatusExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatusExtract.AutoSize = true;
            this.lblStatusExtract.Location = new System.Drawing.Point(12, 113);
            this.lblStatusExtract.Name = "lblStatusExtract";
            this.lblStatusExtract.Size = new System.Drawing.Size(32, 15);
            this.lblStatusExtract.TabIndex = 20;
            this.lblStatusExtract.Text = "Listo";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(12, 27);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(478, 23);
            this.txtFile.TabIndex = 26;
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(12, 69);
            this.txtSave.Name = "txtSave";
            this.txtSave.ReadOnly = true;
            this.txtSave.Size = new System.Drawing.Size(478, 23);
            this.txtSave.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Extraer en:";
            // 
            // lblTiempo
            // 
            this.lblTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(12, 159);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(120, 15);
            this.lblTiempo.TabIndex = 34;
            this.lblTiempo.Text = "Tiempo transcurrido: ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(270, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 24);
            this.button1.TabIndex = 35;
            this.button1.Text = "Segundo plano";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SharpCompress";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // extractF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 190);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
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
        private System.Windows.Forms.Button btnCComprimir;
        private System.Windows.Forms.ProgressBar prgExtract;
        private System.Windows.Forms.Label lblStatusExtract;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}