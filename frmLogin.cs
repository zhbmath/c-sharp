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
    	private ComboBox cbBox_username;
    	private TextBox  tbBox_password;
        private ComboBox cbBox_domain;
        private CheckBox ckBox_users;  
        private CheckBox ckBox_login; 
    	private Button  btnOK;
    	private Button  btnExit;

        public frmLogin()     
        {
            //不显示最大化和最小化按钮
            this.MaximizeBox =false;
            this.MinimizeBox =false;

            //不显示标题栏,任务栏
            this.FormBorderStyle = FormBorderStyle.None;                
            this.ShowInTaskbar = false;

            //默认可调整大小的边框模式
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //固定的三维边框
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //出现在屏幕正中央
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            //自适应大小
            //this.SizeToContent = SizeToContent.WidthAndHeight;

            int box_height = 60;
            int box_width = 190;
            int btn_height = 50;
            int btn_width  = 80;

            //用户名
            this.cbBox_username = new ComboBox();
            this.cbBox_username.Height = box_height;
            this.cbBox_username.Width  = box_width;
            this.cbBox_username.Text = "请输入账号";
            this.cbBox_username.Location = new Point(this.Left+160, this.Top+this.Height/2);
        	this.cbBox_username.Click += new EventHandler(cbBox_username_Click);

            //密码框
            this.tbBox_password = new TextBox();
            this.tbBox_password.Height = box_height;
            this.tbBox_password.Width  = box_width;
            this.tbBox_password.Text = "请输入密码";
            this.tbBox_password.Location = new Point(this.Left+160, this.Top+this.Height/2+40);
        	this.tbBox_password.Click += new EventHandler(tbBox_password_Click);


            //域名框
           this.cbBox_domain = new ComboBox();
           this.cbBox_domain.Height = box_height;
           this.cbBox_domain.Width  = box_width;
           this.cbBox_domain.Text = "域名";
           this.cbBox_domain.Location = new Point(this.Left+160, this.Top+this.Height/2+80);

            //勾选用户
            this.ckBox_users = new CheckBox();
            this.ckBox_users.Text = "记住用户名";
            this.ckBox_users.Height = 16;
            this.ckBox_users.Width = 85;
            this.ckBox_users.Location = new Point(this.Left+160, this.Top+this.Height/2+110);

            //勾选自动登录
            this.ckBox_login = new CheckBox();
            this.ckBox_login.Text = "自动登录";
            this.ckBox_login.Height = 16;
            this.ckBox_login.Width = 75;
            this.ckBox_login.Location = new Point(this.Left+280, this.Top+this.Height/2+110);

            //登录按钮
        	this.btnOK = new Button();
        	this.btnOK.Text = "登录";
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
        	this.Controls.Add(this.cbBox_username);
        	this.Controls.Add(this.tbBox_password);
            this.Controls.Add(this.cbBox_domain);
            this.Controls.Add(this.ckBox_users);
            this.Controls.Add(this.ckBox_login);
        	this.Controls.Add(this.btnOK);
        	this.Controls.Add(this.btnExit);

            //在此添加代码，在登陆窗体显示前先显示欢迎窗体
            //frmWelcome fw = new frmWelcome();
            //fw.Show();  //欢迎窗口
            //System.Threading.Thread.Sleep(2000);  //停留时间2s
            //fw.Close();
            //InitializeComponent();

        }

        // 设置用户名
        private void set_username(object sender, String username)
        {
            this.cbBox_username.Text = username;
        }

        // 获得用户名
        private String get_username(object sender )
        {
            return this.cbBox_username.Text ;
        }
        // 设置密码
        private void set_password(object sender, String password)
        {
            this.tbBox_password.Text = password;
        }

        // 获得密码
        private String get_password(object sender )
        {
            return this.tbBox_password.Text ;
        }

        // 用户名
        private void cbBox_username_Click(object sender, EventArgs e)
        {
            this.cbBox_username.Text = "";
        }

        // 密码框
        private void tbBox_password_Click(object sender, EventArgs e)
        {
            this.tbBox_password.Text = "";
            this.tbBox_password.PasswordChar = '*';
        	this.tbBox_password.Multiline = false;
        }

        /// 覆盖OnLoad方法, 处理窗体第一次被显示时的消息
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            Bitmap bmp = new Bitmap("D:\\csharp\\test.bmp");      //图片路径
            //Graphics g = Graphics.FromImage(bmp);
            this.BackgroundImage = bmp;            //设置背景图片
            this.BackgroundImageLayout = ImageLayout.Stretch; //设置背景图片自动适应
            //g.Dispose();

            int Desk_Width  = Screen.PrimaryScreen.WorkingArea.Width;  
            int Desk_Height = Screen.PrimaryScreen.WorkingArea.Height; 

            this.Width  = this.cbBox_username.Width * 3 ;
            this.Height = this.cbBox_username.Height * 20 ; 

            this.Top  = Desk_Height/4 ;
            this.Left = Desk_Width/3  ;


            // 设置按钮的位置
            //this.btnOK.Top = this.Top + this.cbBox_username.Height*4  ;
            //this.btnOK.Left = this.Left + this.btnOK.Width;

            // 设置按钮的位置
            //this.btnExit.Top = this.Top - this.cbBox_username.Height*5 ;
            //this.btnExit.Left = this.Left + this.btnExit.Width *3;
        }

        //点击确定按钮事件
        private void btnOK_Click(object sender, EventArgs e)     
        {
            if ( get_username(this) == this.cbBox_username.Text && get_password(this) == this.tbBox_password.Text )  
            {
                //以下开始显示主窗体 并关闭登录窗体
                this.DialogResult = DialogResult.OK;
                this.Close();
            }  
            else  
            {
                MessageBox.Show("账号或密码错误，请重试");  
            }
        }

        //单击关闭按钮事件
        private void btnExit_Click(object sender, EventArgs e)    
        {
            Application.Exit();
        }
    }
}
