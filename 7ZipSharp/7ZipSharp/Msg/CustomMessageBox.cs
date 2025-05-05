using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7ZipSharp.Msg
{
    public partial class CustomMessageBox : Form
    {
        private Label lblMensaje;
        private Button btnAceptar;
        private Button btnCancelar;

        public string Result { get; private set; } = "Cancel";

        public CustomMessageBox(string mensaje, string titulo = "Mensaje", MessageBoxButtons botones = MessageBoxButtons.OK)
        {
            // Propiedades del formulario
            this.Text = titulo;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(400, 150);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            // Label de mensaje
            lblMensaje = new Label();
            lblMensaje.Text = mensaje;
            lblMensaje.Location = new Point(20, 20);
            lblMensaje.Size = new Size(360, 50);
            lblMensaje.TextAlign = ContentAlignment.MiddleLeft;
            lblMensaje.AutoSize = false;

            // Botón Aceptar
            btnAceptar = new Button();
            btnAceptar.Text = "Aceptar";
            btnAceptar.Size = new Size(90, 30);
            btnAceptar.Location = new Point(200, 90);
            btnAceptar.Click += btnAceptar_Click;

            // Botón Cancelar
            btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(90, 30);
            btnCancelar.Location = new Point(300, 90);
            btnCancelar.Click += btnCancelar_Click;

            // Agregar controles al formulario
            this.Controls.Add(lblMensaje);
            this.Controls.Add(btnAceptar);
            this.Controls.Add(btnCancelar);

            // Configurar botones según el tipo solicitado
            switch (botones)
            {
                case MessageBoxButtons.OK:
                    btnCancelar.Visible = false;
                    btnAceptar.Location = new Point((this.ClientSize.Width - btnAceptar.Width) / 2, 90);
                    break;

                case MessageBoxButtons.OKCancel:
                    btnAceptar.Text = "Aceptar";
                    btnCancelar.Text = "Cancelar";
                    break;

                case MessageBoxButtons.YesNo:
                    btnAceptar.Text = "Sí";
                    btnCancelar.Text = "No";
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Result = btnAceptar.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Result = btnCancelar.Text;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
