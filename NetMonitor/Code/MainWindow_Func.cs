using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using NetMonitor.Code;

namespace NetMonitor
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 窗体初始化
        /// </summary>
        public void Init()
        {
        }

        #region 窗体打印功能

        private volatile object v_uiInvokeOver = false;
        private object m_retObj = null;

        public object UI_Access_Out(E_UI_Ins ins, int timeOut, params object[] parameters)
        {
            lock (v_uiInvokeOver)
            {
                v_uiInvokeOver = false;

                int @out = timeOut;
                Application.Current.Dispatcher.Invoke(() =>
                {
                    UI_Access(ins, @out, parameters);
                });

                if (timeOut > 0)
                {   // need to wait for response
                    int waitTime = 0;
                    while ((bool)v_uiInvokeOver)
                    {
                        if (timeOut <= 0)
                        {
                            MyNetException.ThrowIt(MyNetException.TIME_OUT, "界面调用超时:" + ins);
                        }
                        waitTime = timeOut < 50 ? timeOut : 50;
                        Thread.Sleep(waitTime);
                        timeOut -= waitTime;
                    }
                    Console.WriteLine("UI_Access_Out:"+ timeOut);
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
        /// 
        /// </summary>
        public enum E_UI_Ins
        {
            displaylog = 1
        }
    }

    #endregion

}
