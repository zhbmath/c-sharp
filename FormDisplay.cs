using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Xview.Lander.Login 
{
    public partial class FormDisplay : Form
    {
        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
            CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
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

        private Button button1; // 按钮类字段
        IntPtr appWin;          // 子窗口句柄

        public FormDisplay()
        {
            //InitializeComponent();
            // 初始化按钮对象属性
            this.button1 = new Button();
            this.button1.Text = "Connect";
            this.button1.Width  = 80;
            this.button1.Height = 50;
            // 为按钮对象的Click事件增加委托方法
            this.button1.Click += new EventHandler(button1_Click); 

            // 实例化一个按钮对象并加入到窗体上
            this.Controls.Add(this.button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //启动一个新进程对象，等待进程生成并进入空闲状态 
                MyStartApp sa = new MyStartApp();
                appWin = sa.getHandle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error: When process is created.");
            }

            // 把进程嵌入父窗口
            SetParent(appWin, this.Handle);
            // Remove border and whatnot
            SetWindowLong(appWin, GWL_STYLE, WS_VISIBLE);
            // Move the window to overlay it on this window
            MoveWindow(appWin, 0, 0, this.Width, this.Height, true);
        }

        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //process.Kill();
            }
            catch { }
        }

        private void form_Resize(object sender, EventArgs e)
        {
            if (this.appWin != IntPtr.Zero)
            {
                MoveWindow(appWin, 0, 0, this.Width, this.Height, true);
            }
            //base.OnResize(e);
        }
    }
}