using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;

namespace TuanFruit.News
{
    public partial class Index : System.Web.UI.Page
    {
        protected string newstitleHTML;
        protected string newscontentHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["newsid"] != null)
            {
                string nid = RouteData.Values["newsid"].ToString();
                newsinfo item = news.getnewsinfo(nid);
                newstitleHTML = item.newstitle;
                newscontentHTML = item.ninfo;
            }
            else
            {
                Response.Redirect("/Default");
            }        

        }
    }
}