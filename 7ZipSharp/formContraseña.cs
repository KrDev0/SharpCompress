using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7ZipSharp
{
    public partial class formContraseña : Form
    {
        public formContraseña()
        {
            InitializeComponent();
            txtContraseña.Select();
        }
        public string ContraseñaIngresada;
        private void button1_Click(object sender, EventArgs e)
        {
            ContraseñaIngresada = txtContraseña.Text;
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnAceptar.Select();
        }
    }
}
