using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;

namespace TuanFruit.Manager
{
    public partial class EditAdminPwd : System.Web.UI.Page
    {
        protected string adminnameHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            admininfo item = new admininfo();
            if (Request.QueryString["adminid"] != null)
            {
                string aid = Request.QueryString["adminid"].ToString();
                item = admin.getAdminInfo(TypeParse.DbObjToInt(aid, 0));
                adminnameHTML = item.adminname;
            }

        }
    }
}