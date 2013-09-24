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
    public partial class EditWebSite : System.Web.UI.Page
    {
        protected websitetypeinfo websiteinfoDATA;
        protected string websitetypeHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["wsid"] != null)
            {
                int id = TypeParse.DbObjToInt(Request.QueryString["wsid"].ToString(), 0);
                websitetypeinfo data = websitetype.getwebsiteinfo(id);
                websiteinfoDATA = data;

                if (!Page.IsPostBack)
                {
                    StringBuilder sb = new StringBuilder();
                    List<websitetypeinfo> itlist = websitetype.getwebsitetype();
                    sb.Append("<select id=\"wtid\" name=\"wtid\" style=\"width:120px; border:solid 1px #cacaca; height:20px;\">");
                    foreach (websitetypeinfo item in itlist)
                    {
                        string template;
                        if (item.wtid == data.wtid)
                        {
                            template = "<option value=\"{0}\" selected=\"selected\">{1}</option>";
                        }
                        else
                        {
                            template = "<option value=\"{0}\">{1}</option>";
                        }
                        sb.AppendFormat(template, item.wtid, item.websitetype);
                    }
                    sb.Append("</select>");
                    websitetypeHTML = sb.ToString();
                }                
            }
            else
            {
                Response.Redirect("/Manager/WebSite.aspx");
            }          

        }
    }
}