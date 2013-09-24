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
    public partial class EditSmallCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["scid"] != null)
            {
                int iscid = TypeParse.DbObjToInt(Request.QueryString["scid"].ToString(), 0);
                categoryinfo data = category.getsmallcategoryinfo(iscid);
                if (!Page.IsPostBack)
                {
                    List<categoryinfo> gylist = category.getbigcategory();
                    bcID.DataSource = gylist;
                    bcID.DataValueField = "bigcategoryid";
                    bcID.DataTextField = "bigcategory";
                    bcID.DataBind();
                    for (int i = 0; i < bcID.Items.Count; i++)
                    {
                        if (bcID.Items[i].Value == data.bigcategoryid.ToString())
                        {
                            bcID.SelectedIndex = i;
                        }
                    }
                    smallcategory.Value = data.smallcategory;
                    smallcategoryid.Value = data.smallcategoryid.ToString();
                }              
            }
        }
        protected void EditSmallCategoryInfo(object sender, EventArgs e)
        {
            categoryinfo data = new categoryinfo();
            data.smallcategory = smallcategory.Value.Trim();
            data.bigcategoryid = TypeParse.DbObjToInt(bcID.SelectedValue, 0);
            data.smallcategoryid = TypeParse.DbObjToInt(smallcategoryid.Value, 0);

            bool result = category.editsmallcategory(data);
            if (result)
            {
                Response.Write("<script>alert('编辑产品小类成功！');location.href='/Manager/SmallCategory.aspx';</script>");
                return;
            }
            else
            {
                Response.Write("<script>alert('编辑产品小类失败！');location.href='/Manager/SmallCategory.aspx';</script>");
                return;
            }
        }
    }
}