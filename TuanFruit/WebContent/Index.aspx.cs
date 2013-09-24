using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Models;
using Morrison.Helper;
using System.Text;

namespace TuanFruit.WebContent
{
    public partial class Index : System.Web.UI.Page
    {
        protected string categorylistHTML;
        protected string ctitleHTML;
        protected string contentHTML;
        protected string bannerHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //网站内容目录
                List<websitetypeinfo> itlist = websitetype.getwebsitetype();
                StringBuilder itsb = new StringBuilder();
                foreach (websitetypeinfo item in itlist)
                {
                    string template = "<li><span class=\"newslipoint\"></span><a href=\"/WS/{0}\">{1}</a></li>";
                    itsb.AppendFormat(template, item.wtid, item.websitetype);
                }
                categorylistHTML = itsb.ToString();

                if (RouteData.Values["contenttype"] != null && RouteData.Values["contenttype"].ToString() != "")
                {
                    string k = RouteData.Values["contenttype"].ToString();
                    string wstype = "关于我们";
                    switch (k)
                    {
                        case "1":
                            wstype = "关于我们";
                            break;
                        case "3":
                            wstype = "联系我们";
                            break;
                        case "4":
                            wstype = "人才招聘";
                            break;
                        default:
                            wstype = "关于我们";
                            break;
                    }

                    websitetypeinfo item = websitetype.getwebsiteinfobytype(wstype);
                    ctitleHTML = item.websitetype;
                    contentHTML = item.websitecontent;
                }
                else
                {
                    string wstype = "关于我们";
                    websitetypeinfo item = websitetype.getwebsiteinfobytype(wstype);
                    ctitleHTML = item.websitetype;
                    contentHTML = item.websitecontent;
                   }
            }

        }
    }
}