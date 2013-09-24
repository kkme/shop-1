using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Morrison.Models
{
    public class userinfo
    {
        //用户ID
        public string userid
        {
            get;
            set;
        }
        //昵称
        public string accounts
        {
            get;
            set;
        }
        //联系地址
        public string address
        {
            get;
            set;
        }
        //登录账号-email
        public string email
        {
            get;
            set;
        }
        //注册密码
        private string _pwd = "";
        public string pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        //注册密码MD5
        public string MD5pwd
        {
            get
            {
                return _pwd == "" ? "" :_pwd;
            }
        }

        //用户固定电话
        public string tel
        {
            get;
            set;
        }
        //用户手机
        public string mobile
        {
            get;
            set;
        }

        //头像
        public string headerimg
        {
            get;
            set;
        }

        //真实姓名
        public string truename
        {
            get;
            set;
        }
        //qq
        public string qq
        {
            get;
            set;
        }

        //个人所在公司
        public string company
        {
            get;
            set;
        }

        //注册日期
        public DateTime adddate
        {
            get;
            set;
        }
        //账号类型ID
        public int atid
        {
            get;
            set;
        }
        //账号类型
        public string accountstype
        {
            get;
            set;
        }
        //账号折扣
        public decimal atdiscount
        {
            get;
            set;
        }
    }
}
