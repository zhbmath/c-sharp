using System;
using System.Windows.Forms;
using System.Threading;

namespace Xview.Lander.Login {

    public partial class Splash : Form 
    { 
        public Splash() 
        { 
            //InitializeComponent(); 
        }
        public void KillMe(object o, EventArgs e)
        {
        	this.Close();
        }

        /// 加载并显示主窗体 
        public static void LoadAndRun(Form form) 
        { 
            //订阅主窗体的句柄创建事件 
            form.HandleCreated += delegate
            { 
                //启动新线程来显示Splash窗体 
                new Thread(new ThreadStart(delegate
                { 
                    Splash sp = new Splash(); 
                    //sp.Show();   //显示欢迎窗口
                    System.Threading.Thread.Sleep(2000);  //欢迎窗口停留时间2s

                    //订阅主窗体的Shown事件 
                    form.Shown += delegate
                    { 
                        //通知Splash窗体关闭自身 
                        sp.Invoke(new EventHandler(sp.KillMe)); 
                        sp.Dispose(); 
                    }; 
                    //显示Splash窗体 
                    Application.Run(sp);
                })).Start(); 
            }; 
            //显示主窗体 
            Application.Run(form); 
        }

        protected override void OnLoad(EventArgs e) 
        { 
            base.OnLoad(e); 
        }
    }
}