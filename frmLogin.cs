using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.IO;  
using System.Runtime.Serialization.Formatters.Binary;  //引用序列化类  

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
            this.cbBox_username.Text = "<请输入账号>";
            this.cbBox_username.Location = new Point(this.Left+160, this.Top+this.Height/2);
        	this.cbBox_username.Click += new EventHandler(cbBox_username_Click); // 为对象的Click事件增加委托方法
            this.cbBox_username.SelectedIndexChanged += new EventHandler(cbBox_username_SelectedIndexChanged); // 为对象的Click事件增加委托方法

            //密码框
            this.tbBox_password = new TextBox();
            this.tbBox_password.Height = box_height;
            this.tbBox_password.Width  = box_width;
            this.tbBox_password.Text = "<请输入密码>";
            this.tbBox_password.Location = new Point(this.Left+160, this.Top+this.Height/2+40);
        	this.tbBox_password.Click += new EventHandler(tbBox_password_Click); // 为对象的Click事件增加委托方法

            //域名框
            this.cbBox_domain = new ComboBox();
            this.cbBox_domain.Height = box_height;
            this.cbBox_domain.Width  = box_width;
            this.cbBox_domain.Text = "域名";
            this.cbBox_domain.Location = new Point(this.Left+160, this.Top+this.Height/2+80);

            //勾选用户
            this.ckBox_users = new CheckBox();
            this.ckBox_users.Text = "记住账号";
            this.ckBox_users.Height = 16;
            this.ckBox_users.Width = 85;
            this.ckBox_users.Checked = true;
            this.ckBox_users.Location = new Point(this.Left+160, this.Top+this.Height/2+110);

            //勾选自动登录
            this.ckBox_login = new CheckBox();
            this.ckBox_login.Text = "自动登录";
            this.ckBox_login.Height = 16;
            this.ckBox_login.Width = 75;
            this.ckBox_login.Checked = true;
            this.ckBox_login.Location = new Point(this.Left+280, this.Top+this.Height/2+110);
            //this.ckBox_login.Click += new EventHandler(ckBox_login_click); // 为对象的Click事件增加委托方法

            //登录按钮
        	this.btnOK = new Button();
        	this.btnOK.Text = "登录";
        	this.btnOK.Height = btn_height;
        	this.btnOK.Width = btn_width;
        	this.btnOK.Location = new Point(this.Left+130, this.Bottom-10);
        	this.btnOK.Click += new EventHandler(btnOK_Click); // 为对象的Click事件增加委托方法

            //退出按钮
        	this.btnExit = new Button();
        	this.btnExit.Text = "退出";
        	this.btnExit.Height = btn_height;
        	this.btnExit.Width = btn_width;
        	this.btnExit.Location = new Point(this.Left+290, this.Bottom-10);
        	this.btnExit.Click += new EventHandler(btnExit_Click); // 为对象的Click事件增加委托方法

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
            //this.tbBox_password.PasswordChar = '*';
        	this.tbBox_password.Multiline = false;
        }

        //声明一个用户的泛型集合
        List<User> users; 

        /// 覆盖OnLoad方法, 处理窗体第一次被显示时的消息
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            Bitmap bmp = new Bitmap("test.bmp");  //图片路径
            this.BackgroundImage = bmp;                       //设置背景图片
            this.BackgroundImageLayout = ImageLayout.Stretch; //设置背景图片自动适应

            int Desk_Width  = Screen.PrimaryScreen.WorkingArea.Width;  // 获取屏幕宽度 
            int Desk_Height = Screen.PrimaryScreen.WorkingArea.Height; // 获取屏幕高度

            this.Width  = this.cbBox_username.Width * 3 ;
            this.Height = this.cbBox_username.Height * 20 ; 

            this.Top  = Desk_Height/4 ;
            this.Left = Desk_Width/3  ;


            if ( ! File.Exists("userInfo.exe") )
            {
                this.cbBox_username.Text = "<请输入账号>";
                this.tbBox_password.Text = "<请输入密码>";
                users = new List<User>();  // 实例化对象
            }
            else
            {  
                //若文件存在，以只读方式打开文件
                FileStream fs = new FileStream("userInfo.exe", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();  // 创建一个序列化类的对象  
                users = (List<User>)bf.Deserialize(fs);      // 调用反序列化方法，读取用户信息
                //this.cbBox_username.Text = users[0].LoginName;                // 为用户名赋值 
                //this.tbBox_password.Text = users[0].LoingPassword;            // 给密码框赋值  

                //this.cbBox_username.Items.Add(users[0].LoginName.ToString()); // 为用户名赋值 
  
                for (int i = 0; i < users.Count; i++)        // 将用户登录ID读取到下拉框中  
                {  
                    if (i == 0 && users[i].LoingPassword != "")  // 如果第一个用户已经记住密码了。  
                    {  
                        this.ckBox_login.Checked = true;    
                        this.tbBox_password.Text = users[i].LoingPassword;  // 给密码框赋值  
                    }
                    this.cbBox_username.Items.Add(users[i].LoginName.ToString()); // 为用户名赋值 
                }  

                fs.Close();   //关闭文件流  
                this.cbBox_username.SelectedIndex = 0;   // 默认下拉框选中为第一项  
            }  

        }

        //点击确定按钮事件
        private void btnOK_Click(object sender, EventArgs e)     
        {

            if (this.cbBox_username.Text == "" || this.cbBox_username.Text == "<请输入账号>")
            {  
                ToolTip tt = new ToolTip();   //实例化一个气泡对象  
                tt.IsBalloon = true;   //设置气泡对象的显示样式
                tt.ReshowDelay = 100;   // 延迟时间
                tt.ShowAlways = false;
                tt.AutoPopDelay = 100;
                tt.SetToolTip(this.cbBox_username, "请输入账号!"); //设定气泡内容及作用于哪个控件  
                tt.Show("请输入账号!", this.cbBox_username);       //将气泡显示出来  
                return;  
            }  

            if (this.tbBox_password.Text == "" || this.tbBox_password.Text == "<请输入密码>")
            {  
                ToolTip tt = new ToolTip();  
                tt.IsBalloon = true;   //设置气泡对象的显示样式
                tt.SetToolTip(this.tbBox_password, "请输入密码!");  
                tt.Show("请输入密码！", this.tbBox_password);  
                return;  
            }  

            if ( ! File.Exists("userInfo.exe") )
            {
                //users = new List<User>();  // 实例化对象
    　　　　    //为了安全在这里创建了一个userInfo.exe文件(用户信息),也可以命名为其他的文件格式的(可以任意)  
                FileStream fs = new FileStream("userInfo.exe", FileMode.Create, FileAccess.Write);  //创建一个文件流对象  
                BinaryFormatter bf = new BinaryFormatter();  //创建一个序列化和反序列化对象  

                //将下拉框的登录名先保存在变量中, 加密并保存在本地
                string loginName = this.cbBox_username.Text.Trim();       
                string loginPswd = this.tbBox_password.Text.Trim();       

                for (int i = 0; i < this.cbBox_username.Items.Count; i++) // 遍历下拉框中的所有元素  
                { 
                    if (this.cbBox_username.Items[i].ToString() == loginName) // 防止重复
                    {  
                        this.cbBox_username.Items.RemoveAt(i);  //如果当前登录用户在下拉列表中已经存在，则将其移除  
                        break;  
                    }  
                }  
  
                for (int i = 0; i < users.Count; i++)    //遍历用户集合中的所有元素  
                {  
                    if (users[i].LoginName == loginName)  //如果当前登录用户在用户集合中已经存在，则将其移除  
                    {  
                        users.RemoveAt(i);  
                        break;  
                    }  
                }  
  

                //每次都将最后一个登录的用户放插入到第一位
                this.cbBox_username.Items.Insert(0, loginName);
                User user;
                if (this.ckBox_login.Checked == true)    //如果用户要求要记住密码
                {  
                    user = new User(loginName, MyEncrypt.EncryptDES(loginPswd));  //将登录ID和密码一起插入到用户集合中  
                }
                else
                {
                    user = new User(loginName, ""); //否则只插入一个用户名到用户集合中，密码设为空
                }
                users.Insert(0, user);              //在用户集合中插入一个用户
                cbBox_username.SelectedIndex = 0;   //让下拉框选中集合中的第一个 

                bf.Serialize(fs, users);            //将可序列化User用户类对象集合写入到硬盘中
            }


            //返回OK, 显示App窗体
            //启动一个新进程对象，等待进程生成并进入空闲状态 
            MyStartApp sa = new MyStartApp();
            sa.getHandle();

            //以下开始显示主窗体 并关闭登录窗体
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //当下拉框选择的项的值发生改变时  
        private void cbBox_username_SelectedIndexChanged(object sender, EventArgs e)  
        {  
            if (users[this.cbBox_username.SelectedIndex].LoingPassword != "") //如果用户的密码不是为空时  
            {  
                //把用户ID所对应的密码赋给密码框(这时的数据还在用户集合中)  
                this.tbBox_password.Text = users[this.cbBox_username.SelectedIndex].LoingPassword.ToString();
                this.ckBox_login.Checked = true;
            }  
            else
            {
                this.tbBox_password.Text = "";  //如果用户的密码本身就是空，那只能给空值给密码框了。  
                this.ckBox_login.Checked = false;
            }
        }

        //单击关闭按钮事件
        private void btnExit_Click(object sender, EventArgs e)    
        {
            Application.Exit();
        }
    }
}
