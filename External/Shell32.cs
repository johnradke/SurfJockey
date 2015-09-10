using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SurfJockey.External
{
    public class Shell32
    {
        [DllImport("shell32.dll")]
        public static extern void SHChangeNotify(HChangeNotifyEventID wEventId,
                                           HChangeNotifyFlags uFlags,
                                           IntPtr dwItem1,
                                           IntPtr dwItem2);
    }
}
