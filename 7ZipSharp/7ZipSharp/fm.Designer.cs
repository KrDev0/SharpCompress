namespace _7ZipSharp
{
    partial class fm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm));
            this.listViewArchivos = new System.Windows.Forms.ListView();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnComprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExtraer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAcerca = new System.Windows.Forms.ToolStripMenuItem();
            this.separador1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVista = new System.Windows.Forms.ToolStripMenuItem();
            this.detallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCDir = new System.Windows.Forms.ToolStripMenuItem();
            this.iconosGrandesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separador2 = new System.Windows.Forms.ToolStripMenuItem();
            this.iconosMedianosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tituloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewArchivos
            // 
            this.listViewArchivos.AllowDrop = true;
            this.listViewArchivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewArchivos.HideSelection = false;
            this.listViewArchivos.LargeImageList = this.imageListLarge;
            this.listViewArchivos.Location = new System.Drawing.Point(0, 64);
            this.listViewArchivos.Name = "listViewArchivos";
            this.listViewArchivos.Size = new System.Drawing.Size(800, 386);
            this.listViewArchivos.SmallImageList = this.imageListSmall;
            this.listViewArchivos.TabIndex = 0;
            this.listViewArchivos.UseCompatibleStateImageBehavior = false;
            this.listViewArchivos.View = System.Windows.Forms.View.Details;
            this.listViewArchivos.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewArchivos_DragDrop);
            this.listViewArchivos.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewArchivos_DragEnter);
            // 
            // imageListLarge
            // 
            this.imageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListLarge.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 64);
            this.panel1.TabIndex = 2;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(326, 155);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(148, 140);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            this.picLogo.Visible = false;
            // 
            // lblArchivo
            // 
            this.lblArchivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.BackColor = System.Drawing.Color.White;
            this.lblArchivo.Location = new System.Drawing.Point(312, 298);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(177, 13);
            this.lblArchivo.TabIndex = 4;
            this.lblArchivo.Text = "Arrastre un archivo comprimido aquí";
            this.lblArchivo.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirArchivoToolStripMenuItem,
            this.separador2,
            this.btnCDir,
            this.btnComprimir,
            this.btnExtraer,
            this.btnAcerca,
            this.separador1,
            this.mnuVista});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 64);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnComprimir
            // 
            this.btnComprimir.AutoSize = false;
            this.btnComprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnComprimir.Image")));
            this.btnComprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnComprimir.Name = "btnComprimir";
            this.btnComprimir.Size = new System.Drawing.Size(77, 60);
            this.btnComprimir.Text = "Comprimir";
            this.btnComprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnComprimir.Click += new System.EventHandler(this.btnComprimir_Click);
            // 
            // btnExtraer
            // 
            this.btnExtraer.AutoSize = false;
            this.btnExtraer.Image = ((System.Drawing.Image)(resources.GetObject("btnExtraer.Image")));
            this.btnExtraer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.Size = new System.Drawing.Size(77, 60);
            this.btnExtraer.Text = "Extraer";
            this.btnExtraer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExtraer.Click += new System.EventHandler(this.btnExtraer_Click);
            // 
            // btnAcerca
            // 
            this.btnAcerca.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAcerca.AutoSize = false;
            this.btnAcerca.Image = ((System.Drawing.Image)(resources.GetObject("btnAcerca.Image")));
            this.btnAcerca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAcerca.Name = "btnAcerca";
            this.btnAcerca.Size = new System.Drawing.Size(77, 60);
            this.btnAcerca.Text = "Acerca de";
            this.btnAcerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAcerca.Click += new System.EventHandler(this.btnAcerca_Click);
            // 
            // separador1
            // 
            this.separador1.AutoSize = false;
            this.separador1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.separador1.Enabled = false;
            this.separador1.Name = "separador1";
            this.separador1.Size = new System.Drawing.Size(1, 60);
            // 
            // mnuVista
            // 
            this.mnuVista.AutoSize = false;
            this.mnuVista.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detallesToolStripMenuItem,
            this.iconosGrandesToolStripMenuItem,
            this.iconosMedianosToolStripMenuItem,
            this.listaToolStripMenuItem,
            this.tituloToolStripMenuItem});
            this.mnuVista.Image = ((System.Drawing.Image)(resources.GetObject("mnuVista.Image")));
            this.mnuVista.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuVista.Name = "mnuVista";
            this.mnuVista.Size = new System.Drawing.Size(77, 60);
            this.mnuVista.Text = "Vista";
            this.mnuVista.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // detallesToolStripMenuItem
            // 
            this.detallesToolStripMenuItem.Checked = true;
            this.detallesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.detallesToolStripMenuItem.Name = "detallesToolStripMenuItem";
            this.detallesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.detallesToolStripMenuItem.Text = "Detalles";
            this.detallesToolStripMenuItem.Click += new System.EventHandler(this.detallesToolStripMenuItem_Click_1);
            // 
            // btnCDir
            // 
            this.btnCDir.AutoSize = false;
            this.btnCDir.AutoToolTip = true;
            this.btnCDir.Image = ((System.Drawing.Image)(resources.GetObject("btnCDir.Image")));
            this.btnCDir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCDir.Name = "btnCDir";
            this.btnCDir.Size = new System.Drawing.Size(77, 60);
            this.btnCDir.Text = "C. Directorio";
            this.btnCDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCDir.ToolTipText = "Comprimir Directorio Actual";
            this.btnCDir.Click += new System.EventHandler(this.btnCDir_Click);
            // 
            // iconosGrandesToolStripMenuItem
            // 
            this.iconosGrandesToolStripMenuItem.Name = "iconosGrandesToolStripMenuItem";
            this.iconosGrandesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iconosGrandesToolStripMenuItem.Text = "Iconos grandes";
            this.iconosGrandesToolStripMenuItem.Click += new System.EventHandler(this.iconosGrandesToolStripMenuItem_Click);
            // 
            // abrirArchivoToolStripMenuItem
            // 
            this.abrirArchivoToolStripMenuItem.AutoSize = false;
            this.abrirArchivoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirArchivoToolStripMenuItem.Image")));
            this.abrirArchivoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.abrirArchivoToolStripMenuItem.Name = "abrirArchivoToolStripMenuItem";
            this.abrirArchivoToolStripMenuItem.Size = new System.Drawing.Size(77, 60);
            this.abrirArchivoToolStripMenuItem.Text = "Abrir archivo";
            this.abrirArchivoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.abrirArchivoToolStripMenuItem.Click += new System.EventHandler(this.abrirArchivoToolStripMenuItem_Click);
            // 
            // separador2
            // 
            this.separador2.AutoSize = false;
            this.separador2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.separador2.Enabled = false;
            this.separador2.Name = "separador2";
            this.separador2.Size = new System.Drawing.Size(1, 60);
            // 
            // iconosMedianosToolStripMenuItem
            // 
            this.iconosMedianosToolStripMenuItem.Name = "iconosMedianosToolStripMenuItem";
            this.iconosMedianosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iconosMedianosToolStripMenuItem.Text = "Iconos medianos";
            this.iconosMedianosToolStripMenuItem.Click += new System.EventHandler(this.iconosMedianosToolStripMenuItem_Click);
            // 
            // listaToolStripMenuItem
            // 
            this.listaToolStripMenuItem.Name = "listaToolStripMenuItem";
            this.listaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listaToolStripMenuItem.Text = "Lista";
            this.listaToolStripMenuItem.Click += new System.EventHandler(this.listaToolStripMenuItem_Click);
            // 
            // tituloToolStripMenuItem
            // 
            this.tituloToolStripMenuItem.Name = "tituloToolStripMenuItem";
            this.tituloToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tituloToolStripMenuItem.Text = "Mosaico";
            this.tituloToolStripMenuItem.Click += new System.EventHandler(this.tituloToolStripMenuItem_Click);
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.listViewArchivos);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(330, 366);
            this.Name = "fm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpCompress - File Manager";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewArchivos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnComprimir;
        private System.Windows.Forms.ToolStripMenuItem btnExtraer;
        private System.Windows.Forms.ToolStripMenuItem btnAcerca;
        private System.Windows.Forms.ToolStripMenuItem separador1;
        private System.Windows.Forms.ToolStripMenuItem mnuVista;
        private System.Windows.Forms.ToolStripMenuItem detallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnCDir;
        private System.Windows.Forms.ToolStripMenuItem iconosGrandesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separador2;
        private System.Windows.Forms.ToolStripMenuItem iconosMedianosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tituloToolStripMenuItem;
    }
}