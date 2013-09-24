using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;

namespace TuanFruit.Shared
{
    public partial class memberleft : System.Web.UI.UserControl
    {
        protected string headerimgHTML;
        protected string accountHTML;
        protected string atHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["tfuid"] != null)
            {
                string userid = Request.Cookies["tfuid"].Value.ToString();
                userinfo item = user.getuserinfo(userid);
                headerimgHTML = item.headerimg;
                accountHTML = item.accounts;
                atHTML = item.accountstype;
            }
            else
            {
                Response.Redirect("/UserLog?relurl=/UIndex");
            }

        }
    }
}