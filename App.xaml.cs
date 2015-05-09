using SurfJockey.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SurfJockey
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            File.WriteAllText(Path.Combine(path, "test.txt"), "blah");

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
