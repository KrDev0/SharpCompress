using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7ZipSharp
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string folder = args[1];
            string salida = args[1];

            string arch = args[1];

            if(args.Contains("/com"))
            Application.Run(new CompressF(folder , salida));

            if (args.Contains("/ext"))
                Application.Run(new extractF(arch));
        }
    }
}
