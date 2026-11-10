using MaterialSkin.Controls;
namespace _7ZipSharp
{
    partial class VerifyArchiveForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblArchive;
        private System.Windows.Forms.ListView listResults;
        private System.Windows.Forms.ColumnHeader columnEntry;
        private System.Windows.Forms.ColumnHeader columnState;
        private System.Windows.Forms.ColumnHeader columnDetails;
        private MaterialSkin.Controls.MaterialProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private MaterialSkin.Controls.MaterialFlatButton btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyArchiveForm));
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblArchive = new System.Windows.Forms.Label();
            this.listResults = new System.Windows.Forms.ListView();
            this.columnEntry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new MaterialSkin.Controls.MaterialProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new MaterialSkin.Controls.MaterialFlatButton();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            //
            // mainLayout
            //
            this.mainLayout.BackColor = System.Drawing.Color.White;
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.mainLayout.Controls.Add(this.lblHeading, 0, 0);
            this.mainLayout.Controls.Add(this.lblArchive, 0, 1);
            this.mainLayout.Controls.Add(this.listResults, 0, 2);
            this.mainLayout.Controls.Add(this.progressBar, 0, 3);
            this.mainLayout.Controls.Add(this.lblStatus, 0, 4);
            this.mainLayout.Controls.Add(this.btnClose, 1, 4);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(16);
            this.mainLayout.RowCount = 5;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.Size = new System.Drawing.Size(790, 500);
            this.mainLayout.TabIndex = 0;
            //
            // lblHeading
            //
            this.lblHeading.AutoSize = true;
            this.mainLayout.SetColumnSpan(this.lblHeading, 2);
            this.lblHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblHeading.Location = new System.Drawing.Point(19, 16);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(752, 32);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Verificación de integridad";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblArchive
            //
            this.lblArchive.AutoEllipsis = true;
            this.mainLayout.SetColumnSpan(this.lblArchive, 2);
            this.lblArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblArchive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(101)))), ((int)(((byte)(110)))));
            this.lblArchive.Location = new System.Drawing.Point(19, 48);
            this.lblArchive.Name = "lblArchive";
            this.lblArchive.Size = new System.Drawing.Size(752, 30);
            this.lblArchive.TabIndex = 1;
            this.lblArchive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // listResults
            //
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEntry,
            this.columnState,
            this.columnDetails});
            this.mainLayout.SetColumnSpan(this.listResults, 2);
            this.listResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResults.FullRowSelect = true;
            this.listResults.GridLines = true;
            this.listResults.HideSelection = false;
            this.listResults.Location = new System.Drawing.Point(19, 81);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(752, 342);
            this.listResults.TabIndex = 2;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            //
            // columnEntry
            //
            this.columnEntry.Text = "Elemento";
            this.columnEntry.Width = 330;
            //
            // columnState
            //
            this.columnState.Text = "Resultado";
            this.columnState.Width = 105;
            //
            // columnDetails
            //
            this.columnDetails.Text = "Detalles";
            this.columnDetails.Width = 290;
            //
            // progressBar
            //
            this.mainLayout.SetColumnSpan(this.progressBar, 2);
            this.progressBar.Depth = 0;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(19, 429);
            this.progressBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(752, 5);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            //
            // lblStatus
            //
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(19, 444);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(648, 40);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Preparando…";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnClose
            //
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Depth = 0;
            this.btnClose.Enabled = false;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(674, 450);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = false;
            this.btnClose.Size = new System.Drawing.Size(96, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // VerifyArchiveForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 500);
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(620, 360);
            this.Name = "VerifyArchiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
