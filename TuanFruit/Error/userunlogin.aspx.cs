using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TuanFruit.Error
{
    public partial class userunlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["tfuid"] != null)
            {
                HttpCookie ucookie = Request.Cookies["tfuid"];
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