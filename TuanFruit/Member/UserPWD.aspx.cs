using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;

namespace TuanFruit.Member
{
    public partial class UserPWD : System.Web.UI.Page
    {
        protected string uidstr;
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = "";
            if (Request.Cookies["tfuid"] != null)
            {
                uid = TypeParse.DbObjToString(Request.Cookies["tfuid"].Value, "");
            }
            else
            {
                Response.Redirect("/UserLog");
            }
            uidstr = uid;           

        }
    }
}