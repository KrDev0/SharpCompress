using MaterialSkin.Controls;
namespace _7ZipSharp.Msg
{
    partial class CustomMessageBox
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.Panel messagePanel;
        private System.Windows.Forms.Panel iconPanel;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.FlowLayoutPanel actions;
        private MaterialFlatButton btnPrimary;
        private MaterialFlatButton btnSecondary;
        private MaterialFlatButton btnTertiary;
        private MaterialFlatButton btnAll;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.iconPanel = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.actions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrimary = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnSecondary = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnTertiary = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnAll = new MaterialSkin.Controls.MaterialFlatButton();
            this.layout.SuspendLayout();
            this.messagePanel.SuspendLayout();
            this.actions.SuspendLayout();
            this.SuspendLayout();
            // layout
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Controls.Add(this.messagePanel, 0, 0);
            this.layout.Controls.Add(this.actions, 0, 1);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
            this.layout.RowCount = 2;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.layout.Name = "layout";
            // messagePanel
            this.messagePanel.AutoScroll = true;
            this.messagePanel.BackColor = System.Drawing.Color.White;
            this.messagePanel.Controls.Add(this.lblMensaje);
            this.messagePanel.Controls.Add(this.iconPanel);
            this.messagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messagePanel.Name = "messagePanel";
            // iconPanel
            this.iconPanel.BackColor = System.Drawing.Color.White;
            this.iconPanel.Location = new System.Drawing.Point(4, 5);
            this.iconPanel.Name = "iconPanel";
            this.iconPanel.Size = new System.Drawing.Size(42, 42);
            this.iconPanel.TabIndex = 0;
            // lblMensaje
            this.lblMensaje.AutoSize = false;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(43, 55, 69);
            this.lblMensaje.Location = new System.Drawing.Point(58, 4);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(400, 70);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "Mensaje";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // actions
            this.actions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actions.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.actions.Name = "actions";
            this.actions.WrapContents = false;
            this.actions.Controls.Add(this.btnTertiary);
            this.actions.Controls.Add(this.btnSecondary);
            this.actions.Controls.Add(this.btnAll);
            this.actions.Controls.Add(this.btnPrimary);
            // btnPrimary
            this.btnPrimary.AutoSize = false;
            this.btnPrimary.Primary = true;
            this.btnPrimary.Name = "btnPrimary";
            this.btnPrimary.Size = new System.Drawing.Size(104, 32);
            this.btnPrimary.Text = "Aceptar";
            this.btnPrimary.UseVisualStyleBackColor = true;
            // btnSecondary
            this.btnSecondary.AutoSize = false;
            this.btnSecondary.Primary = false;
            this.btnSecondary.Name = "btnSecondary";
            this.btnSecondary.Size = new System.Drawing.Size(96, 32);
            this.btnSecondary.Text = "Cancelar";
            this.btnSecondary.UseVisualStyleBackColor = true;
            // btnTertiary
            this.btnTertiary.AutoSize = false;
            this.btnTertiary.Primary = false;
            this.btnTertiary.Name = "btnTertiary";
            this.btnTertiary.Size = new System.Drawing.Size(104, 32);
            this.btnTertiary.Text = "Cancelar";
            this.btnTertiary.UseVisualStyleBackColor = true;
            // btnAll
            this.btnAll.AutoSize = false;
            this.btnAll.Primary = false;
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(112, 32);
            this.btnAll.Text = "Sí a todo";
            this.btnAll.UseVisualStyleBackColor = true;
            // CustomMessageBox
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 220);
            this.Controls.Add(this.layout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mensaje";
            this.layout.ResumeLayout(false);
            this.messagePanel.ResumeLayout(false);
            this.actions.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
    }
}