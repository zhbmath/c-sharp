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
    public partial class frmLogin : Form    
    {
    	private TextBox textbox_username;
    	private TextBox textbox_password;
    	private Button btnOK;
    	private Button btnExit;

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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            //用户名
            this.textbox_username = new TextBox();
            this.textbox_username.Height = 40;
            this.textbox_username.Width  = 180;
            this.textbox_username.Location = new Point(81, 32);
            this.textbox_username.Text = "用户名";

            //密码框
            this.textbox_password = new TextBox();
            this.textbox_password.Height = 60;
            this.textbox_password.Width  = 180;
            this.textbox_password.Location = new Point(81, 62);
            this.textbox_password.Text = "密码";

            //确定按钮
        	this.btnOK = new Button();
        	this.btnOK.Text = "Ok";
        	this.btnOK.Height = 40;
        	this.btnOK.Width = 50;
        	this.btnOK.Click += new EventHandler(btnOK_Click);

            //退出按钮
        	this.btnExit = new Button();
        	this.btnExit.Text = "Exit";
        	this.btnExit.Height = 40;
        	this.btnExit.Width = 50;
        	this.btnExit.Click += new EventHandler(btnExit_Click);

            //添加控件
        	this.Controls.Add(this.textbox_username);
        	this.Controls.Add(this.textbox_password);
        	this.Controls.Add(this.btnOK);
        	this.Controls.Add(this.btnExit);

            //在此添加代码，在登陆窗体显示前先显示欢迎窗体
            frmWelcome fw = new frmWelcome();
            fw.Show();  //show出欢迎窗口
            System.Threading.Thread.Sleep(2000);  //欢迎窗口停留时间2s
            fw.Close();
            //InitializeComponent();
        }

        /// 覆盖OnLoad方法, 处理窗体第一次被显示时的消息
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            // 设置按钮的位置
            this.btnOK.Top = (this.Height - this.btnOK.Height) / 2;
            this.btnOK.Left = (this.Width - this.btnOK.Width) / 2;

            // 设置按钮的位置
            this.btnExit.Top = (this.Height - this.btnExit.Height) / 2;
            this.btnExit.Left = (this.Width - this.btnExit.Width) / 4;
        }


        private void btnOK_Click(object sender, EventArgs e)     //点击确定按钮事件
        {
           // MessageBox.Show("登录成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //以下开始显示主窗体 并关闭登录窗体
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnExit_Click(object sender, EventArgs e)    //单击关闭按钮事件
        {
            Application.Exit();
        }
    }
}
