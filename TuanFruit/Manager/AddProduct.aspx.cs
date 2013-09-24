using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Models;
using Morrison.Helper;

namespace TuanFruit.Manager
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //大目录
                List<categoryinfo> bclist = category.getbigcategory();
                bcID.DataSource = bclist;
                bcID.DataTextField = "bigcategory";
                bcID.DataValueField = "bigcategoryid";
                bcID.DataBind();
                //小目录
                List<categoryinfo> sclist = category.getsmallcategorybyid(TypeParse.DbObjToInt(bcID.SelectedValue, 0));
                scID.DataSource = sclist;
                scID.DataTextField = "smallcategory";
                scID.DataValueField = "smallcategoryid";
                scID.DataBind();
                //产品产地
                List<categoryinfo> cdlist = category.getplace();
                placeID.DataSource = cdlist;
                placeID.DataTextField = "place";
                placeID.DataValueField = "placeid";
                placeID.DataBind();
                //推荐类型
                List<categoryinfo> tjlist = category.gettjtype();
                tjtypeID.DataSource =tjlist;
                tjtypeID.DataTextField = "tjtype";
                tjtypeID.DataValueField = "tjtypeid";
                tjtypeID.DataBind();
            }

        }

        protected void AddProductInfo(object sender, EventArgs e)
        {
            string uploadName = imgfile.Value;//获取待上传图片的完整路径，包括文件名 
            //string uploadName = InputFile.PostedFile.FileName; 
            string pictureName = "noimg.jpg";//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
            if (imgfile.Value != "")
            {
                int idx = uploadName.LastIndexOf(".");
                string suffix = uploadName.Substring(idx);//获得上传的图片的后缀名 
                if (suffix.ToLower() != ".bmp" && suffix.ToLower() != ".jpg" && suffix.ToLower() != ".jpeg" && suffix.ToLower() != ".png" && suffix.ToLower() != ".gif")
                {
                    imgnote.InnerHtml = "<span style=\"color:red\">上传文件必须是图片格式！</span>";
                    return;
                }
                pictureName = DateTime.Now.Ticks.ToString() + suffix;
            }
            try
            {
                if (uploadName != "")
                {
                    string path = Server.MapPath("/Files/Product/");
                    imgfile.PostedFile.SaveAs(path + pictureName);
                }
                productinfo data = new productinfo();
                data.productimg = pictureName;
                data.productname = productname.Value.Trim();
                data.productcode = productcode.Value.Trim();
                data.productprice =Convert.ToDecimal(TypeParse.DbObjToString(productprice.Value, "100.00"));
                data.vipprice = Convert.ToDecimal(TypeParse.DbObjToString(vipprice.Value, "100.00"));
                data.productbrief = productbrief.Value;
                data.productintroduce = editor_id.Value;
                data.smallcategoryid = TypeParse.DbObjToInt(scID.SelectedValue, 1);
                data.bigcategoryid = TypeParse.DbObjToInt(bcID.SelectedValue, 1);
                data.brand = brand.Value.Trim();
                data.punit = punit.Value.Trim();
                data.tjtypeid = TypeParse.DbObjToInt(tjtypeID.SelectedValue, 1);
                data.placeid = TypeParse.DbObjToInt(placeID.SelectedValue, 1);
                data.salestate = 0;
                data.adddate = DateTime.Now;
                data.editdate = DateTime.Now;

                bool result = product.addproduct(data);
                if (result)
                {
                    Response.Write("<script>alert('添加产品成功！');location.href='/Manager/ProductList.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('添加产品失败！');location.href='/Manager/ProductList.aspx';</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void ChangeSmallSelect(object sender, EventArgs e)
        {
            List<categoryinfo> sclist = category.getsmallcategorybyid(TypeParse.DbObjToInt(bcID.SelectedValue, 0));
            scID.DataSource = sclist;
            scID.DataTextField = "smallcategory";
            scID.DataValueField = "smallcategoryid";
            scID.DataBind();
        }

    }
}