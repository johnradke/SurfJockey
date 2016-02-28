using Microsoft.Win32;
using SurfJockey.Properties;

namespace SurfJockey.RegistryManagement
{
    public class CreateProgIdStep : IRegistryStep
    {
        public void Do()
        {
            using (var classesKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes", true))
            {
                classesKey.EnsureContainsSubKey(Resources.ProgId);
            }
        }

        public void Undo()
        {
            using (var classesKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes", true))
            {
                classesKey.DeleteSubKeyTree(Resources.ProgId);
            }
        }
    }
}
