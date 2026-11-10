using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7ZipSharp
{
    partial class about : Form
    {
        private Timer animTimer;
        private float velocidad = 0;
        private float gravedad = 0.8f;
        private float rebote = -0.6f;
        private int sueloY;
        private bool animando = false;
        public about()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            labelVersion.Text = "Versión: " + Application.ProductVersion;
            label1.Text = "Aplicación para gestionar archivos comprimidos";
            label2.Text = "Creado por KrDev";
            label3.Text = "Formatos: 7z · SCZ · ZIP · TAR · GZip · SFX Windows";
            label4.Text = "Motores: 7-Zip y SharpCompress";
            label5.Text = "Copyright © 2023–2026 KrDev";
            label6.Text = "Arquitectura: " + (Environment.Is64BitProcess ? "x64" : "x86");

            Localization.Apply(this);
            ProductUi.Apply(this);

            // Suponiendo que el PictureBox se llama picLogo
            picLogo.Click += PicLogo_Click;

            // Suelo: la posición final de la caída
            sueloY = picLogo.Location.Y + 200;

            // Timer de animación
            animTimer = new Timer();
            animTimer.Interval = 15;
            animTimer.Tick += AnimTimer_Tick;
        }

        private void PicLogo_Click(object sender, EventArgs e)
        {
            if (animando) return;

            animando = true;
            velocidad = 0;
            animTimer.Start();
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            Point current = picLogo.Location;
            velocidad += gravedad;
            current.Y += (int)velocidad;

            if (current.Y >= sueloY)
            {
                current.Y = sueloY;
                velocidad *= rebote;

                // Detener animación si el rebote es muy pequeño
                if (Math.Abs(velocidad) < 1)
                {
                    animTimer.Stop();
                    animando = false;
                    return;
                }
            }

            picLogo.Location = current;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _7ZipSharp.Msg.AppMessage.Show(Properties.Resources.LICENCE,"Términos de uso",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
