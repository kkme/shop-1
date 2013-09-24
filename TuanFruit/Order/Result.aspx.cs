using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;

namespace TuanFruit.Order
{
    public partial class Result : System.Web.UI.Page
    {
        protected string logoimgHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            //图片绑定
            List<webimagesinfo> webimageslist = webimages.bindwebimages(1, "企业LOGO");
            StringBuilder webimagessb = new StringBuilder();
            foreach (webimagesinfo item in webimageslist)
            {
                string template = "<a href=\"{0}\" target=\"_blank\"><img src=\"/Files/WebImages/{1}\" alt=\"\" target=\"_blank\"/></a>";
                webimagessb.AppendFormat(template, item.imgurl, item.imgname);
            }
            logoimgHTML = webimagessb.ToString();
        }
    }
}