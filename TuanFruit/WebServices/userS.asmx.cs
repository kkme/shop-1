using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Morrison.Helper;
using Morrison.Models;

namespace TuanFruit.WebServices
{
    /// <summary>
    /// userS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class userS : System.Web.Services.WebService
    {

        [WebMethod]//检查邮箱
        public string checkemail(string email)
        {
            bool result = user.checkemail(email);
            if (result)
            {
                return "f";
            }
            else
            {
                return "t";
            }
        }

        [WebMethod]//检查账号
        public string checkaccount(string account)
        {
            bool result = user.checkaccount(account);
            if (result)
            {
                return "f";
            }
            else
            {
                return "t";
            }
        }

        [WebMethod]//检查账号
        public string checkaccounts(string accounts, string userid)
        {
            bool result = user.checkaccounts(accounts, userid);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        [WebMethod]//检查修改的密码
        public string checkeditpwd(string pwd, string userid)
        {
            userinfo item = new userinfo();
            item.pwd =Des.MD5(pwd);
            item.userid = userid;
            bool result = user.checkpwd(item);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        [WebMethod]//email登录
        public string emaillogin(string pwd, string email)
        {
            userinfo item = new userinfo();
            item.pwd =Des.MD5(HttpUtility.UrlDecode(pwd));
            item.email =HttpUtility.UrlDecode(email);
            bool result = user.emaillogin(item);
            if (result)
            {
                string uid = user.getuidbyemail(item);
                return uid;
            }
            else
            {
                return "f";
            }
        }

        [WebMethod]//账号登录
        public string userlogin(string pwd, string accounts)
        {
            userinfo item = new userinfo();
            item.pwd = Des.MD5(HttpUtility.UrlDecode(pwd));
            item.accounts = HttpUtility.UrlDecode(accounts);
            bool result = user.usernamelogin(item);
            if (result)
            {
                string uid = user.getuseridbyusername(item);
                return uid;
            }
            else
            {
                return "f";
            }
        }

        [WebMethod]//会员注册
        public string register(string account,string pwd, string email)
        {
            userinfo item = new userinfo();
            item.accounts = HttpUtility.UrlDecode(account);
            item.pwd =Des.MD5(HttpUtility.UrlDecode(pwd));
            item.email =HttpUtility.UrlDecode(email);
            item.adddate = DateTime.Now;
            item.atid = 1;
            Random r = new Random();
            int num = r.Next(1, 72);
            item.headerimg = num.ToString() + ".jpg";
            bool result = user.adduser(item);
            if (result)
            {
                string uid = user.getuidbyemail(item);
                HttpCookie uidcookie = new HttpCookie("tfuid");
                uidcookie.Value = uid.ToString();
                HttpContext.Current.Response.Cookies.Add(uidcookie);   
                return "t";
            }
            else
            {
                return "f";
            }
        }

        [WebMethod]//修改密码
        public string editpwd(string pwd, string userid)
        {
            userinfo item = new userinfo();
            item.pwd =Des.MD5(pwd);
            item.userid = userid;
            bool result = user.changePwd(item);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }      

        [WebMethod]//删除收货地址
        public string deladdress(string addressid)
        {
            int id = TypeParse.DbObjToInt(addressid, 0);
            bool result = address.deladdress(id);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        [WebMethod]//设置默认收货地址
        public string setisdefault(string addressid)
        {
            int id = TypeParse.DbObjToInt(addressid, 0);
            bool result = address.setisdefault(id);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }
       
    }
}
