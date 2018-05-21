// 主程序
using System;
using System.Windows.Forms;
 
namespace Xview.Lander.Login {

    static class Program {

        /// 应用程序的主入口点。
	    [STAThread]
        static void Main() {
 
            // 为应用程序启动高级外观样式(Windows XP以上有效)
            Application.EnableVisualStyles();
            // 为应用程序内控件上文本绘制启动GDI+(如果参数为true, 则使用传统的GDI)
            Application.SetCompatibleTextRenderingDefault(false);
 
            //Application.Run(new frmMain());   // 注视掉原来的启动
            Application.Run(new frmLogin());   // 注视掉原来的启动
            //Splash.LoadAndRun(new frmMain()); // 启动一个新的线程

            // 显示主窗体前，显示登录窗口gg
	        //frmLogin frmLogin = new frmLogin();
            //if (frmLogin.ShowDialog() == DialogResult.OK)
            //{   
            //    //Application.Run(new frmMain()); // 显示主窗体
            //    Application.Run(new FormDisplay()); // 显示主窗体
            //}
        }
    }
}