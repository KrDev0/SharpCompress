using _7ZipSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

static class Program
{

    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Primera instancia de la aplicación
        if (args.Length > 0) // Verifica si hay argumentos
        {
            /*****************************************************************************/
            string[] modosCom = { "/com", "/comTar", "/comGz", "/comZip", "/com7z" };
            string modoCom = modosCom.FirstOrDefault(flag => args.Contains(flag));

            if (!string.IsNullOrEmpty(modoCom))
            {
                string arch = args.Length > 1 ? args[1] : string.Empty;
                string tipo = modoCom == "/com" ? null : modoCom;
                Application.Run(new CompressD(arch, arch, tipo));
            }
            /*****************************************************************************/
            string[] modos = { "/files", "/fTar", "/fGz", "/fZip", "/f7z" };
            string modo = modos.FirstOrDefault(flag => args.Contains(flag));

            if (!string.IsNullOrEmpty(modo))
            {
                string arch = args.Length > 1 ? args[1] : string.Empty;
                string tipo = modo == "/files" ? null : modo;
                Application.Run(new CompressF(arch, tipo));
            }
            /*****************************************************************************/
            else if (args.Contains("/ext"))
            {
                // Manejo de extracción
                string arch = args.Length > 1 ? args[1] : string.Empty; // Obtiene el archivo a extraer
                Application.Run(new extractF(arch));
            }
            /*****************************************************************************/
            else if (args.Contains("/open") || args.Contains("/openD"))
            {
                // Manejo de abrir archivo
                string arch = args.Length > 1 ? args[1] : string.Empty; // Obtiene el archivo a abrir
                string dir = args.Length > 1 ? args[0] : string.Empty; // Obtiene el archivo a abrir
                Application.Run(new fm(arch, dir));
            }
        }
        else
        {
            // Si no hay argumentos, simplemente inicia el formulario principal o uno por defecto
            Application.Run(new fm(null, "/personal"));
        }
    }
}
