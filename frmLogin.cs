using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Xview.Lander.Login
{
    public class frmLogin : Form    
    {
        // 控件
    	private TextBox textbox_username;
    	private TextBox textbox_password;
        private TextBox textbox_domain;
    	private Button  btnOK;
    	private Button  btnExit;

        public frmLogin()     
        {

            //不显示最大化和最小化按钮
            this.MaximizeBox =false;
            this.MinimizeBox =false;

            //默认可调整大小的边框模式
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //固定的三维边框
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //出现在屏幕正中央
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            //自适应大小
            //this.SizeToContent = SizeToContent.WidthAndHeight;

            //没有标题
            this.FormBorderStyle = FormBorderStyle.None;                
            //任务栏不显示                
            this.ShowInTaskbar = false;

            int tbox_height = 60;
            int tbox_width = 180;
            int btn_height = 50;
            int btn_width  = 80;

            //用户名
            this.textbox_username = new TextBox();
            this.textbox_username.Height = tbox_height;
            this.textbox_username.Width  = tbox_width;
            this.textbox_username.Text = "用户名";
            this.textbox_username.Location = new Point(this.Left+160, this.Top+this.Height/2);

            //密码框
            this.textbox_password = new TextBox();
            this.textbox_password.Height = tbox_height;
            this.textbox_password.Width  = tbox_width;
            this.textbox_password.Text = "密码";
            this.textbox_password.Location = new Point(this.Left+160, this.Top+this.Height/2+40);

            //域名框
            this.textbox_domain = new TextBox();
            this.textbox_domain.Height = tbox_height;
            this.textbox_domain.Width  = tbox_width;
            this.textbox_domain.Text = "域名";
            this.textbox_domain.Location = new Point(this.Left+160, this.Top+this.Height/2+80);

            //确定按钮
        	this.btnOK = new Button();
        	this.btnOK.Text = "确定";
        	this.btnOK.Height = btn_height;
        	this.btnOK.Width = btn_width;
        	this.btnOK.Location = new Point(this.Left+130, this.Bottom-10);
        	this.btnOK.Click += new EventHandler(btnOK_Click);

            //退出按钮
        	this.btnExit = new Button();
        	this.btnExit.Text = "退出";
        	this.btnExit.Height = btn_height;
        	this.btnExit.Width = btn_width;
        	this.btnExit.Location = new Point(this.Left+290, this.Bottom-10);
        	this.btnExit.Click += new EventHandler(btnExit_Click);


            //添加控件
        	this.Controls.Add(this.textbox_username);
        	this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_domain);
        	this.Controls.Add(this.btnOK);
        	this.Controls.Add(this.btnExit);

            //在此添加代码，在登陆窗体显示前先显示欢迎窗体
            //frmWelcome fw = new frmWelcome();
            //fw.Show();  //欢迎窗口
            //System.Threading.Thread.Sleep(2000);  //停留时间2s
            //fw.Close();
            //InitializeComponent();

        }

        /// 覆盖OnLoad方法, 处理窗体第一次被显示时的消息
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            string fbImage = "D:\\csharp\\test.bmp";   
            Bitmap bmp = new Bitmap(fbImage); //图片路径
            this.BackgroundImage = bmp;//设置背景图片
            this.BackgroundImageLayout = ImageLayout.Stretch; //设置背景图片自动适应

            int Desk_Width  = Screen.PrimaryScreen.WorkingArea.Width;  
            int Desk_Height = Screen.PrimaryScreen.WorkingArea.Height; 

            this.Width  = this.textbox_username.Width * 3 ;
            this.Height = this.textbox_username.Height * 20 ; 

            this.Top  = Desk_Height/4 ;
            this.Left = Desk_Width/3  ;

            // 设置按钮的位置
            //this.btnOK.Top = this.Top + this.textbox_username.Height*4  ;
            //this.btnOK.Left = this.Left + this.btnOK.Width;

            // 设置按钮的位置
            //this.btnExit.Top = this.Top - this.textbox_username.Height*5 ;
            //this.btnExit.Left = this.Left + this.btnExit.Width *3;
        }

        //点击确定按钮事件
        private void btnOK_Click(object sender, EventArgs e)     
        {
            //以下开始显示主窗体 并关闭登录窗体
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //单击关闭按钮事件
        private void btnExit_Click(object sender, EventArgs e)    
        {
            Application.Exit();
        }
    }
}
