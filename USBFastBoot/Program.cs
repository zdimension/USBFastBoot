using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace USBFastBoot
{
    [SupportedOSPlatform("windows")]
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
