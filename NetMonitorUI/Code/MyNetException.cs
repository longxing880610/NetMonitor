using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetMonitor.Code
{
    class MyNetException : Exception
    {
        public const int TIME_OUT = 1;
        public const int FUNC_NOT_SUPPORT = 2;

        private MyNetException(int reason, string msg)
        {
            Message = msg;
            Reason = reason;
        }

        public override string Message { get; }
        public int Reason { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public static void ThrowIt(int reason, string msg)
        {
            throw new MyNetException(reason, msg);
        }
    }
}
