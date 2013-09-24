using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Morrison.Models;
using Morrison.Helper;

namespace TuanFruit.Manager
{
    public partial class ImagesType : System.Web.UI.Page
    {
        protected string imagestypeHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<webimagesinfo> itlist = webimages.getimagestype();
            foreach (webimagesinfo item in itlist)
            {
                string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{0}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"#\" onclick=\"edititname({2},'{3}')\" style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:delimagestype('{4}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                sb.AppendFormat(template, item.itid, item.imagestype, item.itid, item.imagestype, item.itid);
            }
            imagestypeHTML = sb.ToString();

        }
    }
}