using System;
using System.Windows.Forms;

namespace Xview.Lander.Login {

    public class frmWelcome : Form {

        private TextBox textbox;
        private Label  label1;
 
        public frmWelcome() {

            //不显示最大化和最小化
            this.MaximizeBox =false;
            this.MinimizeBox =false;

            //默认可调整大小的边框模式
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //固定的三维边框
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //出现在屏幕正中央
            //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            //没有标题
            this.FormBorderStyle = FormBorderStyle.None;                
            //任务栏不显示                
            this.ShowInTaskbar = false;

            // 初始化文本框对象
            this.textbox = new TextBox();
            this.textbox.Left = 10;
            this.textbox.Top  = 10;
            this.textbox.Text = "Welcome textbox";

            this.label1 = new Label();
            this.label1.Left = 20;
            this.label1.Top  = 20;
            this.label1.Text = "label1";

            // 将文本框加入到窗体上
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.label1);
        }

        /*private void timer1_Tick(object sender, EventArgs e) 
        { 
            if (this.Opacity < 1) 
            { 
                //每单位时间增加的透明度数 
                this.Opacity += 0.05; 
            } 
            else 
            { 
                this.timer1.Stop(); 
                this.Hide(); 
                //frmWelcome.Show(); 
            } 
        } */

        public static void SetMid(Form form)
        {
            // 每次在用户屏幕居中窗体
            form.SetBounds((Screen.GetBounds(form).Width / 2) - (form.Width / 2),
            (Screen.GetBounds(form).Height / 2) - (form.Height / 2),
            form.Width, form.Height, BoundsSpecified.Location);
        }

        /// 覆盖OnResize方法, 处理窗体第一次被显示时的消息
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int x = (int)(0.5 * (this.Width - label1.Width));
            int y = label1.Location.Y;
            label1.Location = new System.Drawing.Point(x,y);
        }

        /// 覆盖OnLoad方法, 处理窗体第一次被显示时的消息
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
 
            //timer1_Tick();
            OnResize(e);
            SetMid(this);
            // 设置按钮的位置
            this.textbox.Top = (this.Height - this.textbox.Height) / 2;
            this.textbox.Left = (this.Width - this.textbox.Width) / 2;
        }

    }
}