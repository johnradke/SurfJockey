using Microsoft.Win32;
using SurfJockey.External;
using SurfJockey.RegistryManagement;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows;

namespace SurfJockey
{
    public partial class App : Application
    {
        private const string _makeAppDefaultBrowserArg = "MAKEMEDEFAULT";
        private readonly RegistryManager _registryManager = new RegistryManager();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Shell32.SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);

            if (IsAdministrator() && e.Args.Contains(_makeAppDefaultBrowserArg))
            {
                MakeDefaultBrowser();
            }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            File.WriteAllText(Path.Combine(path, "test.txt"), "blah");

            var thing = Registry.LocalMachine.OpenSubKey("SOFTWARE");

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void MakeDefaultBrowser()
        {
            Shutdown();
        }

        private static void LaunchSelfToMakeDefaultBrowser()
        {
            var startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Assembly.GetExecutingAssembly().CodeBase;
            startInfo.Arguments = _makeAppDefaultBrowserArg;
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
