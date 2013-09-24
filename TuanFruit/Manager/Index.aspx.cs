using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;

namespace TuanFruit.Manager
{
    public partial class Index : System.Web.UI.Page
    {
        protected string adminlistHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<admininfo> adminlist = admin.getAdminList();

            StringBuilder sb = new StringBuilder();
            foreach (admininfo item in adminlist)
            {
                string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{0}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{2}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">系统管理员</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"/Manager/EditAdminPwd.aspx/?adminid={3}\" style=\"color:blue;cursor:pointer;\">修改密码</a>&nbsp;&nbsp;&nbsp; <a href=\"javascript:deladmin('{4}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                sb.AppendFormat(template, item.adddate, item.adminname, item.adminid, item.adminid, item.adminid);
            }
            adminlistHTML = sb.ToString();

        }
    }
}