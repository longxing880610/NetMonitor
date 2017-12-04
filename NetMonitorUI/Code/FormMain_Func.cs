using System;
using System.Threading;
using System.Windows.Forms;
using NetMonitor.Code;

namespace NetMonitorUI
{
    public partial class FormMain
    {
        /// <summary>
        ///     窗体初始化
        /// </summary>
        private void Init()
        {
            m_delegate_Uiaccessout = UI_Access;
        }

        #region 窗体打印功能

        delegate object Delegate_UIAccess_Out(E_UI_Ins ins, int timeOut, params object[] parameters);

        private Delegate_UIAccess_Out m_delegate_Uiaccessout;

        private volatile object v_uiInvokeOver = false;
        private readonly object m_retObj = null;

        public object UI_Access_Out(E_UI_Ins ins, int timeOut, params object[] parameters)
        {
            lock (v_uiInvokeOver)
            {
                v_uiInvokeOver = false;

                var @out = timeOut;

                Invoke(m_delegate_Uiaccessout, ins, timeOut, parameters);

                if (timeOut > 0)
                {
                    // need to wait for response
                    var waitTime = 0;
                    while ((bool) v_uiInvokeOver)
                    {
                        if (timeOut <= 0)
                        {
                            MyNetException.ThrowIt(MyNetException.TIME_OUT, "界面调用超时:" + ins);
                        }
                        waitTime = timeOut < 50 ? timeOut : 50;
                        Thread.Sleep(waitTime);
                        timeOut -= waitTime;
                    }
                    Console.WriteLine("UI_Access_Out:" + timeOut);
                    return m_retObj;
                }
            }


            return null;
        }

        private object UI_Access(E_UI_Ins ins, int timeOut, params object[] parameters)
        {
            switch (ins)
            {
                case E_UI_Ins.displaylog:
                    break;
                default:
                    MyNetException.ThrowIt(MyNetException.FUNC_NOT_SUPPORT, "调用功能不支持:" + ins);
                    break;
            }

            if (timeOut > 0)
            {
                v_uiInvokeOver = true;
            }

            return null;
        }

        /// <summary>
        /// </summary>
        public enum E_UI_Ins
        {
            displaylog = 1
        }
    }

    #endregion
}