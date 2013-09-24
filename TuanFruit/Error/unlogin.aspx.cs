using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TuanFruit.Error
{
    public partial class unlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["g_adminid"] != null)
            {
                HttpCookie ucookie = Request.Cookies["g_adminid"];
                ucookie.Values.Clear();
                ucookie.Expires = DateTime.Now.AddYears(-1);
                Response.AppendCookie(ucookie);
                Response.Redirect("/Index.aspx");
            }
            else
            {
                Response.Redirect("/Index.aspx");
            }

        }
    }
}