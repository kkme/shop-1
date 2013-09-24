using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;

namespace TuanFruit.Login
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected string indexzjHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            //左侧图片
            List<webimagesinfo> indexzjimg = webimages.bindwebimages(1, "登录左侧");
            StringBuilder indexzjsb = new StringBuilder();
            foreach (webimagesinfo item in indexzjimg)
            {
                string template = "<a href=\"{0}\" target=\"_blank\"><img src=\"/Files/WebImages/{1}\" style=\"width:550px; height:315px;border:0;\" /></a>";
                indexzjsb.AppendFormat(template, item.imgurl, item.imgname);
            }
            indexzjHTML = indexzjsb.ToString();

        }
    }
}