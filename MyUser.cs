using System;
using System.Collections.Generic;
using System.Text;

namespace Xview.Lander.Login
{  
    [Serializable]  //表示这个类可以被序列化  
    public class User
    {
        string _loginName;
        string _loingPassword;

        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }

        public string LoingPassword
        {
            get
            {
                if (_loingPassword != "") return MyEncrypt.DecryptDES(_loingPassword);
                return _loingPassword;
            }
            set { _loingPassword = value; }
        }
  
        public User(string loginName, string loginPswd)
        {
            _loginName = loginName;
            _loingPassword = loginPswd;
        }
    }
}