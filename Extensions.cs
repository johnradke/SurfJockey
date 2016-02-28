using Microsoft.Win32;
using System.Linq;
using System.Windows;

namespace SurfJockey
{
    public static class Extensions
    {
        public static void EnsureContainsSubKey(this RegistryKey key, string subkey)
        {
            if (!key.ContainsSubKey(subkey))
            {
                key.CreateSubKey(subkey);
            }
        }

        public static bool ContainsSubKey(this RegistryKey key, string subkey)
        {
            return key.GetSubKeyNames().Contains(subkey);
        }

        public static bool GetArgBool(this StartupEventArgs e, string argName)
        {
            return e.Args.Contains(argName);
        }
    }
}
