using SurfJockey.RegistryManagement;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows;
using AppResources = SurfJockey.Properties.Resources;

namespace SurfJockey
{
    public partial class App : Application
    {
        private readonly RegistryManager _registryManager = new RegistryManager();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.GetArgBool(AppResources.MakeAppDefaultBrowserArg))
            {
                MakeDefaultBrowser();
            }
            else
            {
                //var mainWindow = new MainWindow();
                //mainWindow.Show();

                LaunchSelfToMakeDefaultBrowser();
            }
        }

        private void MakeDefaultBrowser()
        {
            RegistryManager.CreateProgId();
            Shutdown();
        }

        private static void LaunchSelfToMakeDefaultBrowser()
        {
            var startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Assembly.GetExecutingAssembly().CodeBase;
            startInfo.Arguments = AppResources.MakeAppDefaultBrowserArg;
            startInfo.Verb = "runas";

            Process.Start(startInfo);
        }

        private static bool IsAdministrator()
        {
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
