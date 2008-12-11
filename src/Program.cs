using System;
using System.Windows.Forms;
using Autofac;

namespace Tweaker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new Autofac.Builder.ContainerBuilder();
            
            builder.RegisterModule(new ShellModule());
            using (var container = builder.Build())
            {
                Application.Run(container.Resolve<Shell>());
            }
        }




    }
}
