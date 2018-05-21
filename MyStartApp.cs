using System;
using System.Diagnostics;

namespace Xview.Lander.Login
{
	public class MyStartApp
    {
        private string exeName;
        private string exeArgs;
    	Process process = null;
        IntPtr appWin;

        public MyStartApp()
        {
            //this.exeName = @"C:\Program Files (x86)\Microsoft Office\Office12\WINWORD.exe";
            //this.exeArgs = @"";
            this.exeName = @"C:\Program Files (x86)\sihuatech\xview-lander\package.nw\terminal\windows\bin\remote-viewer.exe";
            this.exeArgs = @"spice://192.168.202.42:5900";
        }

        //public string ExeName
        //{
            //get { return exeName; }
            //set { exeName = value; }
        //}

        public IntPtr getHandle()
        {
            try
            {
                //启动进程
                process = System.Diagnostics.Process.Start(this.exeName, this.exeArgs);
                //等待进程生成并进入空闲状态
                process.WaitForInputIdle();
                //获得主窗口句柄
                appWin = process.MainWindowHandle;
            }
            catch //(Exception e)
            {
                //MessageBox.Show(this, e.Message, "Error: When process is created.");
            }
            return appWin;
        }
    } // End of Class
}