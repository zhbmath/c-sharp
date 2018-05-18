using System;  
using System.Collections.Generic;  
using System.ComponentModel;  
using System.Data;  
using System.Drawing;  
using System.Text;  
using System.Windows.Forms;  
using System.IO;  
using System.Runtime.Serialization.Formatters.Binary;  //引用序列化类  
  
namespace MemoryPassword  
{  
    public partial class LoginForm : Form  
    {  
        public LoginForm()  
        {  
            InitializeComponent();  
        }  
  
        private void btnExit_Click(object sender, EventArgs e)  
        {  
            this.Close();  
        }  
  
        List<User> users;   //声明一个用户的泛型集合  
        private void LoginForm_Load(object sender, EventArgs e)  
        {  
              
            if (File.Exists("userInfo.exe"))  
            {  
                /*创建文件流对象 参数1:文件的(相对)路径也可以再另一个文件夹下如:User(文件夹)/userInfo.exe  
                                 参数2:指定操作系统打开文件的方式 
                                 参数3:指定文件的访问类型(这里为只读)  */     
  
    //为了安全在这里创建了一个userInfo.exe文件(用户信息),也可以命名为其他的文件格式的(可以任意)                       
                FileStream fs = new FileStream("userInfo.exe", FileMode.Open, FileAccess.Read); //使用第6个构造函数  
  
                BinaryFormatter bf = new BinaryFormatter();  //创建一个序列化和反序列化类的对象  
                users = (List<User>)bf.Deserialize(fs);  //调用反序列化方法，从文件userInfo.exe中读取对象信息  
  
                for (int i = 0; i < users.Count; i++)//将集合中的用户登录ID读取到下拉框中  
                {  
                    if (i == 0 && users[i].LoingPassword != "")  //如果第一个用户已经记住密码了。  
                    {  
                        this.chkMemoryPwd.Checked = true;    
                        this.txtPwd.Text = users[i].LoingPassword;  //给密码框赋值  
                    }  
                    this.cboLgoinName.Items.Add(users[i].LoginName.ToString());  
                }  
                fs.Close();   //关闭文件流  
                this.cboLgoinName.SelectedIndex = 0;   //默认下拉框选中为第一项  
            }  
            else  
            {  
                users = new List<User>();  
                cboLgoinName.Text = "<请输入您的用户名>";  
            }  
        }  
  
        private void btnLogin_Click(object sender, EventArgs e)  
        {  
            if (this.cboLgoinName.Text == "" || this.cboLgoinName.Text == "<请输入您的用户名>")  
            {  
                ToolTip tt = new ToolTip();   //实例化一个气泡对象  
                tt.IsBalloon = true;   //设置气泡对象的显示样式。如果false就是一个方块型的提示框  
                tt.SetToolTip(this.cboLgoinName, "请输入用户名！");  //设定气泡的内容及作用于哪个控件  
                tt.Show("请输入用户名！", this.cboLgoinName);   //将气泡显示出来  
                return;  
            }  
            else if (this.txtPwd.Text == "")  
            {  
                ToolTip tt = new ToolTip();  
                tt.IsBalloon = true;   //如果false就是一个方块型的提示框  
                tt.SetToolTip(this.txtPwd, "请输入用户密码！");  
                tt.Show("请输入用户密码！", this.txtPwd);  
                return;  
            }  
            //...................可以加密并(本地)记住密码了  
  
            string loginName = this.cboLgoinName.Text.Trim();  //将下拉框的登录名先保存在变量中  
            for (int i = 0; i < this.cboLgoinName.Items.Count; i++)  //遍历下拉框中的所有元素  
            {  
                if (this.cboLgoinName.Items[i].ToString() == loginName)  
                {  
                    this.cboLgoinName.Items.RemoveAt(i);  //如果当前登录用户在下拉列表中已经存在，则将其移除  
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
  
            this.cboLgoinName.Items.Insert(0, loginName);  //每次都将最后一个登录的用户放插入到第一位  
            User user;  
            if (this.chkMemoryPwd.Checked == true)    //如果用户要求要记住密码  
            {  
                string newPwd = MyEncrypt.EncryptDES(this.txtPwd.Text.Trim());  //***********如果用户要求记住密码则对该密码进行加密***************  
                user = new User(loginName, newPwd);  //将登录ID和密码一起插入到用户集合中  
            }  
            else  
                user = new User(loginName, "");  //否则只插入一个用户名到用户集合中，密码设为空  
            users.Insert(0, user);   //在用户集合中插入一个用户  
            cboLgoinName.SelectedIndex = 0;   //让下拉框选中集合中的第一个  
        }  
  
        //当窗体关闭之后  
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)  
        {  
  
　　　　//为了安全在这里创建了一个userInfo.exe文件(用户信息),也可以命名为其他的文件格式的(可以任意)  
            FileStream fs = new FileStream("userInfo.exe", FileMode.Create, FileAccess.Write);  //创建一个文件流对象  
            BinaryFormatter bf = new BinaryFormatter();  //创建一个序列化和反序列化对象  
            bf.Serialize(fs, users);   //要先将User类先设为可以序列化(即在类的前面加[Serializable])。将用户集合信息写入到硬盘中  
            fs.Close();   //关闭文件流  
        }  
  
        //当下拉框选择的项的值发生改变时  
        private void cboLgoinName_SelectedIndexChanged(object sender, EventArgs e)  
        {  
            if (users[this.cboLgoinName.SelectedIndex].LoingPassword != "") //如果用户的密码不是为空时  
            {  
                //把用户ID所对应的密码赋给密码框(这时的数据还在用户集合中)  
                this.txtPwd.Text = users[this.cboLgoinName.SelectedIndex].LoingPassword.ToString();  
                this.chkMemoryPwd.Checked = true;    
            }  
            else  
            {  
                this.txtPwd.Text = "";  //如果用户的密码本身就是空，那只能给空值给密码框了。  
                this.chkMemoryPwd.Checked = false;  
            }  
        }  
    }  
}  