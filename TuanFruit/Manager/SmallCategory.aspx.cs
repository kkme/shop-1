using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Models;
using Morrison.Helper;
using System.Text;

namespace TuanFruit.Manager
{
    public partial class SmallCategory : System.Web.UI.Page
    {
        protected string smallcategorylistHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<categoryinfo> calist = category.getsmallcategory();
            StringBuilder casb = new StringBuilder();
            foreach (categoryinfo item in calist)
            {
                string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" style=\"padding:5px 0;\">{0}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" style=\"padding:0 0 0 5px;\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"/Manager/EditSmallCategory.aspx/?scid={2}\"  style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:delsmallcategory('{3}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                casb.AppendFormat(template, item.smallcategory, item.bigcategory, item.smallcategoryid, item.smallcategoryid);
            }
            smallcategorylistHTML = casb.ToString();
            if (!Page.IsPostBack)
            {
                List<categoryinfo> gylist = category.getbigcategory();
                bcID.DataSource = gylist;
                bcID.DataTextField = "bigcategory";
                bcID.DataValueField = "bigcategoryid";
                bcID.DataBind();
            }
        }
        protected void AddSmallCategory(object sender, EventArgs e)
        {
            categoryinfo data = new categoryinfo();
            data.smallcategory = smallcategory.Value.Trim();
            data.bigcategoryid = TypeParse.DbObjToInt(bcID.SelectedValue, 0);

            bool result = category.addsmallcategory(data);
            if (result)
            {
                Response.Write("<script>alert('添加产品小类成功！');location.href='/Manager/SmallCategory.aspx';</script>");
                return;
            }
            else
            {
                Response.Write("<script>alert('添加产品小类失败！');location.href='/Manager/SmallCategory.aspx';</script>");
                return;
            }
        }

    }
}