using MaterialSkin.Controls;
namespace _7ZipSharp
{
    partial class SfxOptionsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupPackage;
        private System.Windows.Forms.Label lblTitle;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTitle;
        private System.Windows.Forms.Label lblInstallPath;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtInstallPath;
        private MaterialSkin.Controls.MaterialFlatButton btnBrowseInstallPath;
        private System.Windows.Forms.GroupBox groupActions;
        private System.Windows.Forms.Label lblPrompt;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBeginPrompt;
        private System.Windows.Forms.Label lblRunProgram;
        private MaterialSkin.Controls.MaterialComboBox cmbRunProgram;
        private MaterialSkin.Controls.MaterialCheckBox chkShowProgress;
        private System.Windows.Forms.GroupBox groupAppearance;
        private System.Windows.Forms.Label lblIcon;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIconPath;
        private MaterialSkin.Controls.MaterialFlatButton btnBrowseIcon;
        private MaterialSkin.Controls.MaterialFlatButton btnClearIcon;
        private MaterialSkin.Controls.MaterialFlatButton btnAccept;
        private MaterialSkin.Controls.MaterialFlatButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SfxOptionsForm));
            this.groupPackage = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblInstallPath = new System.Windows.Forms.Label();
            this.txtInstallPath = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnBrowseInstallPath = new MaterialSkin.Controls.MaterialFlatButton();
            this.groupActions = new System.Windows.Forms.GroupBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtBeginPrompt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblRunProgram = new System.Windows.Forms.Label();
            this.cmbRunProgram = new MaterialSkin.Controls.MaterialComboBox();
            this.chkShowProgress = new MaterialSkin.Controls.MaterialCheckBox();
            this.groupAppearance = new System.Windows.Forms.GroupBox();
            this.lblIcon = new System.Windows.Forms.Label();
            this.txtIconPath = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnBrowseIcon = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnClearIcon = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnAccept = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialFlatButton();
            this.groupPackage.SuspendLayout();
            this.groupActions.SuspendLayout();
            this.groupAppearance.SuspendLayout();
            this.SuspendLayout();
            //
            // groupPackage
            //
            this.groupPackage.Controls.Add(this.lblTitle);
            this.groupPackage.Controls.Add(this.txtTitle);
            this.groupPackage.Controls.Add(this.lblInstallPath);
            this.groupPackage.Controls.Add(this.txtInstallPath);
            this.groupPackage.Controls.Add(this.btnBrowseInstallPath);
            this.groupPackage.Location = new System.Drawing.Point(16, 12);
            this.groupPackage.Name = "groupPackage";
            this.groupPackage.Size = new System.Drawing.Size(604, 134);
            this.groupPackage.TabIndex = 1;
            this.groupPackage.TabStop = false;
            this.groupPackage.Text = "Paquete y destino";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(14, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(38, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Título";
            //
            // txtTitle
            //
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.BackColor = System.Drawing.Color.White;
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitle.Depth = 0;
            this.txtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.txtTitle.Hint = "";
            this.txtTitle.Location = new System.Drawing.Point(17, 43);
            this.txtTitle.MaxLength = 120;
            this.txtTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.ReadOnly = false;
            this.txtTitle.SelectedText = "";
            this.txtTitle.SelectionLength = 0;
            this.txtTitle.SelectionStart = 0;
            this.txtTitle.Size = new System.Drawing.Size(570, 21);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TabStop = false;
            this.txtTitle.UseSystemPasswordChar = false;
            //
            // lblInstallPath
            //
            this.lblInstallPath.AutoSize = true;
            this.lblInstallPath.Location = new System.Drawing.Point(14, 76);
            this.lblInstallPath.Name = "lblInstallPath";
            this.lblInstallPath.Size = new System.Drawing.Size(121, 15);
            this.lblInstallPath.TabIndex = 2;
            this.lblInstallPath.Text = "Carpeta de extracción";
            //
            // txtInstallPath
            //
            this.txtInstallPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstallPath.BackColor = System.Drawing.Color.White;
            this.txtInstallPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInstallPath.Depth = 0;
            this.txtInstallPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.txtInstallPath.Hint = "";
            this.txtInstallPath.Location = new System.Drawing.Point(17, 95);
            this.txtInstallPath.MaxLength = 240;
            this.txtInstallPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtInstallPath.Name = "txtInstallPath";
            this.txtInstallPath.PasswordChar = '\0';
            this.txtInstallPath.ReadOnly = false;
            this.txtInstallPath.SelectedText = "";
            this.txtInstallPath.SelectionLength = 0;
            this.txtInstallPath.SelectionStart = 0;
            this.txtInstallPath.Size = new System.Drawing.Size(472, 21);
            this.txtInstallPath.TabIndex = 3;
            this.txtInstallPath.TabStop = false;
            this.txtInstallPath.UseSystemPasswordChar = false;
            //
            // btnBrowseInstallPath
            //
            this.btnBrowseInstallPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseInstallPath.BackColor = System.Drawing.Color.White;
            this.btnBrowseInstallPath.Depth = 0;
            this.btnBrowseInstallPath.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnBrowseInstallPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseInstallPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.btnBrowseInstallPath.Icon = null;
            this.btnBrowseInstallPath.Location = new System.Drawing.Point(496, 89);
            this.btnBrowseInstallPath.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowseInstallPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowseInstallPath.Name = "btnBrowseInstallPath";
            this.btnBrowseInstallPath.Primary = false;
            this.btnBrowseInstallPath.Size = new System.Drawing.Size(98, 36);
            this.btnBrowseInstallPath.TabIndex = 4;
            this.btnBrowseInstallPath.Text = "Examinar…";
            this.btnBrowseInstallPath.UseVisualStyleBackColor = true;
            this.btnBrowseInstallPath.Click += new System.EventHandler(this.btnBrowseInstallPath_Click);
            //
            // groupActions
            //
            this.groupActions.Controls.Add(this.lblPrompt);
            this.groupActions.Controls.Add(this.txtBeginPrompt);
            this.groupActions.Controls.Add(this.lblRunProgram);
            this.groupActions.Controls.Add(this.cmbRunProgram);
            this.groupActions.Controls.Add(this.chkShowProgress);
            this.groupActions.Location = new System.Drawing.Point(16, 152);
            this.groupActions.Name = "groupActions";
            this.groupActions.Size = new System.Drawing.Size(604, 195);
            this.groupActions.TabIndex = 2;
            this.groupActions.TabStop = false;
            this.groupActions.Text = "Experiencia de extracción";
            //
            // lblPrompt
            //
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(14, 25);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(142, 15);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "Mensaje inicial (opcional)";
            //
            // txtBeginPrompt
            //
            this.txtBeginPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeginPrompt.BackColor = System.Drawing.Color.White;
            this.txtBeginPrompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBeginPrompt.Depth = 0;
            this.txtBeginPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.txtBeginPrompt.Hint = "";
            this.txtBeginPrompt.Location = new System.Drawing.Point(17, 44);
            this.txtBeginPrompt.MaxLength = 300;
            this.txtBeginPrompt.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBeginPrompt.Name = "txtBeginPrompt";
            this.txtBeginPrompt.PasswordChar = '\0';
            this.txtBeginPrompt.ReadOnly = false;
            this.txtBeginPrompt.SelectedText = "";
            this.txtBeginPrompt.SelectionLength = 0;
            this.txtBeginPrompt.SelectionStart = 0;
            this.txtBeginPrompt.Size = new System.Drawing.Size(570, 21);
            this.txtBeginPrompt.TabIndex = 1;
            this.txtBeginPrompt.TabStop = false;
            this.txtBeginPrompt.UseSystemPasswordChar = false;
            //
            // lblRunProgram
            //
            this.lblRunProgram.AutoSize = true;
            this.lblRunProgram.Location = new System.Drawing.Point(14, 79);
            this.lblRunProgram.Name = "lblRunProgram";
            this.lblRunProgram.Size = new System.Drawing.Size(350, 15);
            this.lblRunProgram.TabIndex = 2;
            this.lblRunProgram.Text = "Ejecutable al terminar (archivo incluido o ruta dentro del archivo)";
            //
            // cmbRunProgram
            //
            this.cmbRunProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRunProgram.BackColor = System.Drawing.Color.White;
            this.cmbRunProgram.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRunProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRunProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRunProgram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.cmbRunProgram.ItemHeight = 25;
            this.cmbRunProgram.Location = new System.Drawing.Point(17, 108);
            this.cmbRunProgram.MaxLength = 300;
            this.cmbRunProgram.Name = "cmbRunProgram";
            this.cmbRunProgram.Size = new System.Drawing.Size(570, 31);
            this.cmbRunProgram.TabIndex = 3;
            //
            // chkShowProgress
            //
            this.chkShowProgress.AutoSize = true;
            this.chkShowProgress.Depth = 0;
            this.chkShowProgress.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShowProgress.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkShowProgress.Location = new System.Drawing.Point(17, 150);
            this.chkShowProgress.Margin = new System.Windows.Forms.Padding(0);
            this.chkShowProgress.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkShowProgress.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkShowProgress.Name = "chkShowProgress";
            this.chkShowProgress.Ripple = true;
            this.chkShowProgress.Size = new System.Drawing.Size(230, 30);
            this.chkShowProgress.TabIndex = 4;
            this.chkShowProgress.Text = "Mostrar la interfaz de extracción";
            this.chkShowProgress.UseVisualStyleBackColor = true;
            //
            // groupAppearance
            //
            this.groupAppearance.Controls.Add(this.lblIcon);
            this.groupAppearance.Controls.Add(this.txtIconPath);
            this.groupAppearance.Controls.Add(this.btnBrowseIcon);
            this.groupAppearance.Controls.Add(this.btnClearIcon);
            this.groupAppearance.Location = new System.Drawing.Point(16, 353);
            this.groupAppearance.Name = "groupAppearance";
            this.groupAppearance.Size = new System.Drawing.Size(604, 100);
            this.groupAppearance.TabIndex = 3;
            this.groupAppearance.TabStop = false;
            this.groupAppearance.Text = "Apariencia";
            //
            // lblIcon
            //
            this.lblIcon.AutoSize = true;
            this.lblIcon.Location = new System.Drawing.Point(14, 28);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(181, 15);
            this.lblIcon.TabIndex = 0;
            this.lblIcon.Text = "Icono propio del archivo .exe SFX";
            //
            // txtIconPath
            //
            this.txtIconPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIconPath.BackColor = System.Drawing.Color.White;
            this.txtIconPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIconPath.Depth = 0;
            this.txtIconPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.txtIconPath.Hint = "";
            this.txtIconPath.Location = new System.Drawing.Point(17, 50);
            this.txtIconPath.MaxLength = 32767;
            this.txtIconPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIconPath.Name = "txtIconPath";
            this.txtIconPath.PasswordChar = '\0';
            this.txtIconPath.ReadOnly = true;
            this.txtIconPath.SelectedText = "";
            this.txtIconPath.SelectionLength = 0;
            this.txtIconPath.SelectionStart = 0;
            this.txtIconPath.Size = new System.Drawing.Size(396, 21);
            this.txtIconPath.TabIndex = 1;
            this.txtIconPath.TabStop = false;
            this.txtIconPath.UseSystemPasswordChar = false;
            //
            // btnBrowseIcon
            //
            this.btnBrowseIcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseIcon.BackColor = System.Drawing.Color.White;
            this.btnBrowseIcon.Depth = 0;
            this.btnBrowseIcon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnBrowseIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.btnBrowseIcon.Icon = null;
            this.btnBrowseIcon.Location = new System.Drawing.Point(420, 43);
            this.btnBrowseIcon.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowseIcon.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowseIcon.Name = "btnBrowseIcon";
            this.btnBrowseIcon.Primary = false;
            this.btnBrowseIcon.Size = new System.Drawing.Size(98, 36);
            this.btnBrowseIcon.TabIndex = 2;
            this.btnBrowseIcon.Text = "Examinar…";
            this.btnBrowseIcon.UseVisualStyleBackColor = true;
            this.btnBrowseIcon.Click += new System.EventHandler(this.btnBrowseIcon_Click);
            //
            // btnClearIcon
            //
            this.btnClearIcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearIcon.BackColor = System.Drawing.Color.White;
            this.btnClearIcon.Depth = 0;
            this.btnClearIcon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnClearIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.btnClearIcon.Icon = null;
            this.btnClearIcon.Location = new System.Drawing.Point(526, 43);
            this.btnClearIcon.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClearIcon.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClearIcon.Name = "btnClearIcon";
            this.btnClearIcon.Primary = false;
            this.btnClearIcon.Size = new System.Drawing.Size(68, 36);
            this.btnClearIcon.TabIndex = 3;
            this.btnClearIcon.Text = "Quitar";
            this.btnClearIcon.UseVisualStyleBackColor = true;
            this.btnClearIcon.Click += new System.EventHandler(this.btnClearIcon_Click);
            //
            // btnAccept
            //
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(63)))));
            this.btnAccept.Depth = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Icon = null;
            this.btnAccept.Location = new System.Drawing.Point(454, 462);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAccept.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Primary = false;
            this.btnAccept.Size = new System.Drawing.Size(72, 36);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aplicar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Depth = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(534, 462);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = false;
            this.btnCancel.Size = new System.Drawing.Size(86, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            // SfxOptionsForm
            //
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(636, 513);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.groupAppearance);
            this.Controls.Add(this.groupActions);
            this.Controls.Add(this.groupPackage);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SfxOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opciones del autoextractor";
            this.groupPackage.ResumeLayout(false);
            this.groupPackage.PerformLayout();
            this.groupActions.ResumeLayout(false);
            this.groupActions.PerformLayout();
            this.groupAppearance.ResumeLayout(false);
            this.groupAppearance.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
