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
    public partial class TJType : System.Web.UI.Page
    {
        protected string tjtypeHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<categoryinfo> ntlist = category.gettjtype();
            foreach (categoryinfo item in ntlist)
            {
                string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{0}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"javascript:edittjname('{2}','{3}')\"  style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:deltjtype('{4}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                sb.AppendFormat(template, item.tjtypeid, item.tjtype, item.tjtypeid, item.tjtype, item.tjtypeid);
            }
            tjtypeHTML = sb.ToString();

        }
    }
}