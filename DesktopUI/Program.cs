using Autofac;
using DesktopUI.Library;
using DesktopUI.Library.Data;
using DesktopUI.Library.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = ConfigureContainer();
            container.BeginLifetimeScope();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainWindow = container.Resolve<MainWindow>();

            Application.Run(mainWindow);
        }

        /// <summary>
        /// Configures the Dependency Injection container
        /// </summary>
        /// <returns>A configured container</returns>
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Random>().SingleInstance();

            builder.RegisterType<SqlRepository>().As<IRepository>();

            builder.RegisterType<DataGenerator>();

            builder.RegisterType<DataGenerationWorker>();

            builder.RegisterType<MainWindow>();

            return builder.Build();
        }
    }
}
