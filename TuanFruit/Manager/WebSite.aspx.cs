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
    public partial class WebSite : System.Web.UI.Page
    {
        protected string websitetypeHTML;
        protected string websitelistHTML;
        protected string websitepageHTML;
        protected void Page_Load(object sender, EventArgs e)
        {            
            StringBuilder sb = new StringBuilder();
            List<websitetypeinfo> itlist = websitetype.getwebsitetype();
            sb.Append("<select id=\"wtid\" name=\"wtid\" style=\"width:120px; border:solid 1px #cacaca; height:20px;\">");
            foreach (websitetypeinfo item in itlist)
            {
                string template = "<option value=\"{0}\">{1}</option>";
                sb.AppendFormat(template, item.wtid, item.websitetype);
            }
            sb.Append("</select>");
            websitetypeHTML = sb.ToString();

            int page = 1;
            if (Request.QueryString["page"] != null)
            {
                page = TypeParse.DbObjToInt(page, 1);
            }
            pageinfo pdata = new pageinfo();
            pdata.curpageindex =page;
            pdata.pagesize = 10;
            pdata.where = "websitetype.wtid=website.wtid";
            pdata.recordcount = websitetype.getwebsitecount();
            pdata.tablename = "website ,websitetype";
            pdata.fieldlist = "website.wsid,website.wtid,websitetype.websitetype,website.websitecontent";
            pdata.sorttype = 2;
            pdata.primarykey = "wsid";            
            pdata.totalpagecount = (pdata.recordcount % pdata.pagesize == 0 ? pdata.recordcount / pdata.pagesize : pdata.recordcount / pdata.pagesize + 1);
            if (pdata.totalpagecount == 0)
            {
                pdata.totalpagecount = 1;
            }

            List<websitetypeinfo> websitelist = websitetype.getwebsite(pdata);
            StringBuilder imgsb = new StringBuilder();
            foreach (websitetypeinfo item in websitelist)
            {
                string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" style=\"padding:5px 0;\">{0}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\" style=\"padding:0 0 0 5px;\"><div align=\"center\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"/Manager/EditWebSite.aspx/?wsid={2}\" target=\"_blank\" style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:delwebsite('{3}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                imgsb.AppendFormat(template, item.wsid, item.websitetype, item.wsid, item.wsid);
            }
            websitelistHTML = imgsb.ToString();

        }
    }
}