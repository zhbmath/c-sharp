using System;
using System.Windows.Forms;
 
namespace Xview.Lander.Login {
 
    /// 继承Form类, 定义新的窗体类
    public class frmMain : Form {

        /// 按钮类字段
        private Button button;
 
        /// 文本框类字段
        private TextBox textbox;
 
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
            this.button.Width  = 80;
            this.button.Height = 90;

            // 为按钮对象的Click事件增加委托方法
            this.button.Click += new EventHandler(ButtonClick);
 
            // 初始化文本框对象
            this.textbox = new TextBox();
            this.textbox.Left = 10;
            this.textbox.Top = 10;
 
            // 实例化一个MyButton按钮对象并加入到窗体上
            this.Controls.Add(this.button);
            // 将文本框加入到窗体上
            this.Controls.Add(this.textbox);
        }
 
        /// 覆盖OnLoad方法, 处理窗体第一次被显示时的消息
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            // 设置按钮的位置
            this.button.Top  = (this.Height - this.button.Height) / 2;
            this.button.Left = (this.Width  - this.button.Width ) / 2;
        }
       
        /// 委托方法, 处理按钮被点击事件
        private void ButtonClick(object sender, EventArgs e) {
            // 显示一个消息对话框
            MessageBox.Show("Main form");
            // 将文本框控件的内容该为Hello
            this.textbox.Text = "Main form has display";
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
 
            // Application.Run(new MyForm());  // 注视掉原来的启动

            // 显示主窗体前，显示登录窗口
	        frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {   
                Application.Run(new frmMain()); // 显示主窗体
            }
        }
    }
}
