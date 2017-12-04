using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NetMonitor.Code
{
    public class Imp_NetCore
    {
        [DllImport("NetCore.dll")]
        private static extern int fntest();


        public static int test()
        {
            return fntest();
        }
    }
}
