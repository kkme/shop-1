using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;

namespace TuanFruit.Views.Shared
{
    public partial class mtop : System.Web.UI.UserControl
    {
        protected string accountsHtml;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["g_adminid"] != null)
            {
                string userid = Request.Cookies["g_adminid"].Value.ToString();
                int adminid = Int32.Parse(userid);
                admininfo data = admin.getAdminInfo(adminid);
                accountsHtml = "<span class=\"yellow\">" + data.adminname + "</span>";
            }
            else
            {
                Response.Redirect("/Login/AdminLogin.aspx");
            }
        }
    }
}