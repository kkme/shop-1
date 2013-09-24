using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Morrison.Models
{
    public class admininfo
    {
        //管理员账号ID
        public int adminid
        {
            get;
            set;
        }
        //管理员账号
        public string adminname
        {
            get;
            set;
        }
        //管理员登录密码
        public string adminpwd
        {
            get;
            set;
        }
        //管理添加日期
        public DateTime adddate
        {
            get;
            set;
        }
        //管理员角色
        public int roleid
        {
            get;
            set;
        }
        //管理修改日期
        public DateTime updatedate
        {
            get;
            set;
        }
    }
}