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
    public partial class EditProduct : System.Web.UI.Page
    {
        protected productinfo productinfoDATA; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["productid"] != null)
            {
                int id = TypeParse.DbObjToInt(Request.QueryString["productid"].ToString(), 0);
                productinfo data = product.getproductinfo(id);
                productinfoDATA = data;
                if (!Page.IsPostBack)
                {
                    productname.Value = data.productname;
                    productcode.Value = data.productcode;
                    productprice.Value = data.productprice.ToString();
                    productbrief.Value = data.productbrief;
                    sproductid.Value = data.productid.ToString();
                    oldproductimg.Value = data.productimg;
                    vipprice.Value = data.vipprice.ToString();
                    editor_id.Value = data.productintroduce;
                    brand.Value=data.brand;
                    punit.Value=data.punit;

                    //大目录
                    List<categoryinfo> bclist = category.getbigcategory();
                    bcID.DataSource = bclist;
                    bcID.DataTextField = "bigcategory";
                    bcID.DataValueField = "bigcategoryid";
                    bcID.DataBind();
                    for (int k = 0; k < bcID.Items.Count; k++)
                    {
                        if (bcID.Items[k].Value == data.bigcategoryid.ToString())
                        {
                            bcID.SelectedIndex = k;
                        }
                    }
                    
                    //小目录
                    List<categoryinfo> sclist = category.getsmallcategorybyid(TypeParse.DbObjToInt(bcID.SelectedValue, 0));
                    scID.DataSource = sclist;
                    scID.DataTextField = "smallcategory";
                    scID.DataValueField = "smallcategoryid";
                    scID.DataBind();
                    for (int n = 0; n < scID.Items.Count; n++)
                    {
                        if (scID.Items[n].Value == data.smallcategoryid.ToString())
                        {
                            scID.SelectedIndex = n;
                        }
                    }

                    //推荐类型
                    List<categoryinfo> tjlist = category.gettjtype();
                    tjtypeID.DataSource = tjlist;
                    tjtypeID.DataTextField = "tjtype";
                    tjtypeID.DataValueField = "tjtypeid";
                    tjtypeID.DataBind();
                    for (int k = 0; k < tjtypeID.Items.Count; k++)
                    {
                        if (tjtypeID.Items[k].Value == data.tjtypeid.ToString())
                        {
                            tjtypeID.SelectedIndex = k;
                        }
                    }

                    //产地
                    List<categoryinfo> cdlist = category.getplace();
                    placeID.DataSource = cdlist;
                    placeID.DataTextField = "place";
                    placeID.DataValueField = "placeid";
                    placeID.DataBind();
                    for (int k = 0; k < placeID.Items.Count; k++)
                    {
                        if (placeID.Items[k].Value == data.placeid.ToString())
                        {
                            placeID.SelectedIndex = k;
                        }
                    }
                }
            }
        }

        protected void EditProductInfo(object sender, EventArgs e)
        {
            string uploadName = imgfile.Value;//获取待上传图片的完整路径，包括文件名 
            //string uploadName = InputFile.PostedFile.FileName; 
            string pictureName = oldproductimg.Value;//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
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
                data.productprice = Convert.ToDecimal(TypeParse.DbObjToString(productprice.Value, "100.00"));
                data.vipprice = Convert.ToDecimal(TypeParse.DbObjToString(vipprice.Value, "100.00"));
                data.productbrief = productbrief.Value;
                data.productintroduce = editor_id.Value;
                data.smallcategoryid = TypeParse.DbObjToInt(scID.SelectedValue, 1);
                data.bigcategoryid = TypeParse.DbObjToInt(bcID.SelectedValue, 1);
                data.productid = TypeParse.DbObjToInt(sproductid.Value, 0);
                data.brand = brand.Value.Trim();
                data.punit = punit.Value.Trim();
                data.tjtypeid = TypeParse.DbObjToInt(tjtypeID.SelectedValue, 1);
                data.placeid = TypeParse.DbObjToInt(placeID.SelectedValue, 1);
                data.salestate = 0;                
                data.editdate = DateTime.Now;

                bool result = product.editproduct(data);
                if (result)
                {
                    Response.Write("<script>alert('编辑产品成功！');location.href='/Manager/ProductList.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('编辑产品失败！');location.href='/Manager/ProductList.aspx';</script>");
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