using System;
using System.Windows.Forms;

namespace Tweaker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var shell = new Shell(args))
            {
                Application.Run(shell);
            }
        }
    }
}
