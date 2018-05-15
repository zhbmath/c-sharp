using System;
using System.Windows.Forms;
 
namespace Xview.Lander.Login {
 
    /// 继承Form类, 定义新的窗体类
    public class frmMain : Form {

        private Button button;   // 按钮类字段
        private TextBox textbox; // 文本框类字段
 
        /// 构造器
        public frmMain() {

            //不显示最大化和最小化按钮
            this.MaximizeBox =false;
            this.MinimizeBox =false;

            //默认可调整大小的边框模式
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //固定的三维边框
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //出现在屏幕正中央
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // 初始化按钮对象
            this.button = new Button();
            this.button.Text = "test";
            this.button.Width  = 40;
            this.button.Height = 50;

            // 为按钮对象的Click事件增加委托方法
            this.button.Click += new EventHandler(ButtonClick);
 
            // 初始化文本框对象
            this.textbox = new TextBox();
            this.textbox.Width = 180;
            this.textbox.Height = 80;
 
            // 实例化一个MyButton按钮对象并加入到窗体上
            this.Controls.Add(this.button);
            // 将文本框加入到窗体上
            this.Controls.Add(this.textbox);
        }
 
        /// 覆盖OnLoad方法, 处理窗体第一次被显示时的消息
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            // 设置按钮的位置
            this.button.Top  = (this.Height - this.button.Height) / 4;
            this.button.Left = (this.Width  - this.button.Width ) / 4;
            this.textbox.Top = (this.Height - this.textbox.Height ) / 2;
            this.textbox.Left = (this.Width - this.textbox.Width ) / 2;
        }
       
        // 委托方法, 处理按钮被点击事件
        private void ButtonClick(object sender, EventArgs e) {
            // 显示一个消息对话框
            MessageBox.Show("登录成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // 修改文本框控件的内容
            this.textbox.Text = "Main form ";  
        }

    }
 
    static class Program {

        /// 应用程序的主入口点。
	    [STAThread]
        static void Main() {
 
            // 为应用程序启动高级外观样式(Windows XP以上有效)
            Application.EnableVisualStyles();
            // 为应用程序内控件上文本绘制启动GDI+(如果参数为true, 则使用传统的GDI)
            Application.SetCompatibleTextRenderingDefault(false);
 
            // Application.Run(new frmMain());  // 注视掉原来的启动

            //Splash.LoadAndRun(new frmMain());

            // 显示主窗体前，显示登录窗口
	        frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {   
                Application.Run(new frmMain()); // 显示主窗体
            }
        }
    }
}
