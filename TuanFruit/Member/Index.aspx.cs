using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;

namespace TuanFruit.Member
{
    public partial class Index : System.Web.UI.Page
    {
        protected userinfo UInfoDATA;
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid="";
            if (Request.Cookies["tfuid"] != null)
            {
                uid = TypeParse.DbObjToString(Request.Cookies["tfuid"].Value, "");
            }
            else
            {
                Response.Redirect("/UserLog");
            }            
            userinfo userdata = user.getuserinfo(uid);
            UInfoDATA = userdata;
            if (!Page.IsPostBack)
            {
                txtaccounts.Value = userdata.accounts;
                txttruename.Value = userdata.truename;
                txtqq.Value = userdata.qq;
                txtcompany.Value = userdata.company;
                txtmobile.Value = userdata.mobile;
                txttel.Value = userdata.tel;
                userid.Value = userdata.userid.ToString();
                txtaddress.Value = userdata.address;
            }

        }
        protected void EditUserInfo(object sender, EventArgs e)
        {
            string uid="";
            if (Request.Cookies["tfuid"] != null)
            {
                uid = TypeParse.DbObjToString(Request.Cookies["tfuid"].Value, "");
            }
            else
            {
                Response.Redirect("/UserLog");
            }

            bool result1 = user.checkaccounts(txtaccounts.Value.Trim(), uid);
            if (result1)
            {
                accountsnote.InnerHtml = "<span class=\"red\">该账号已经被注册，请使用其他账号</span>";
                return;
            }          

            userinfo item = new userinfo();
            item.userid = uid;
            item.accounts = txtaccounts.Value;
            item.address = txtaddress.Value;
            item.qq = txtqq.Value;
            item.truename = txttruename.Value;
            item.tel = txttel.Value;
            item.mobile = txtmobile.Value;
            item.company = txtcompany.Value;
            bool result = user.updateUserInfo(item);
            if (result)
            {
                Response.Write("<script>alert('提交资料成功！');location.href='/UIndex';</script>");                
            }
            else
            {
                Response.Write("<script>alert('提交资料失败！');location.href='/UIndex';</script>");                
            }
        }
    }
}