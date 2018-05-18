
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing.Design;
using System.IO;
using System.Drawing;
 
namespace Xview.Lander.Login {
 
    /// 继承Form类, 定义新的窗体类
    public class frmMain : Form {

        private Button btnTest; // 按钮类字段
        private Panel  pnlTest; // 文本框类字段

        Process p = null;
        IntPtr appWin;
        private string exeName; 

        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
        CharSet = CharSet.Unicode, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]

        private static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern long GetWindowLong(IntPtr hwnd, int nIndex);


        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        private static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

        //private static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);

        private const int SWP_NOOWNERZORDER = 0x200;
        private const int SWP_NOREDRAW = 0x8;
        private const int SWP_NOZORDER = 0x4;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int WS_EX_MDICHILD = 0x40;
        private const int SWP_FRAMECHANGED = 0x20;
        private const int SWP_NOACTIVATE = 0x10;
        private const int SWP_ASYNCWINDOWPOS = 0x4000;
        private const int SWP_NOMOVE = 0x2;
        private const int SWP_NOSIZE = 0x1;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CLOSE = 0x10;
        private const int WS_CHILD = 0x40000000;
 
        /// 构造器
        public frmMain() {

            //不显示最大化和最小化按钮
            //this.MaximizeBox =false;
            //this.MinimizeBox =false;

            //默认可调整大小的边框模式
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //固定的三维边框
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //出现在屏幕正中央
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // 初始化按钮对象
            this.btnTest = new Button();
            this.btnTest.Text = "test";
            this.btnTest.Width  = 40;
            this.btnTest.Height = 50;
            this.btnTest.Click += new EventHandler(btnStart_Click); // 为按钮对象的Click事件增加委托方法
 
 
            // 实例化一个MyButton按钮对象并加入到窗体上
            this.Controls.Add(this.btnTest);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //启动要嵌入的应用程序进程
            this.exeName = @"C:\Program Files (x86)\sihuatech\xview-lander\package.nw\terminal\windows\bin\remote-viewer.exe";
            p = null; 
            try 
            {
              // Start the process 
              p = System.Diagnostics.Process.Start(this.exeName); 
            
              // Wait for process to be created and enter idle condition 
              p.WaitForInputIdle(); 
            
              // Get the main handle
              appWin = p.MainWindowHandle; 
            } 
            catch (Exception ex) 
            { 
              MessageBox.Show(this, ex.Message, "Error"); 
            }

            //调用Windows API将启动的应用程序窗口嵌入自定义的控件(这里用的是Panel控件)
            // Put it into this form
            SetParent(appWin, this.Handle);//this在这里是Panel控件

            // Remove border and whatnot
            SetWindowLong(appWin, GWL_STYLE, WS_VISIBLE);

            // Move the window to overlay it on this window
            MoveWindow(appWin, 0, 0, this.Width, this.Height, true);


        }

        //设置被嵌入的窗体大小随宿主窗体改变
        protected override void OnResize(EventArgs e)
        {
          if (this.appWin != IntPtr.Zero)
          {
            MoveWindow(appWin, 0, 0, this.Width, this.Height, true);
          }
          base.OnResize (e);
        }

        //设置被嵌入的窗体应用程序在宿主程序关闭时也关闭
        protected override void OnHandleDestroyed(EventArgs e)
        {
          // Stop the application
          if (appWin != IntPtr.Zero)
          {
            // Post a colse message
            PostMessage(appWin, WM_CLOSE, 0, 0);

            // Delay for it to get the message
            System.Threading.Thread.Sleep(1000);

            // Clear internal handle
            appWin = IntPtr.Zero;
          }
          base.OnHandleDestroyed (e);
        }

        /// 覆盖OnLoad方法, 处理窗体第一次被显示时的消息
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            // 设置按钮的位置
            this.btnTest.Top  = (this.Height - this.btnTest.Height) / 4;
            this.btnTest.Left = (this.Width  - this.btnTest.Width ) / 4;
        }
       
        // 委托方法, 处理按钮被点击事件
        private void btnTest_Click(object sender, EventArgs e) {
            // 显示一个消息对话框
            MessageBox.Show("登录成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }

// End of File 
}
