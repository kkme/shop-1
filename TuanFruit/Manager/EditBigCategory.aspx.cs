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
    public partial class EditBigCategory : System.Web.UI.Page
    {
        protected string bigcategoryimgHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["bigcategoryid"] != null)
            {
                int bcid = TypeParse.DbObjToInt(Request.QueryString["bigcategoryid"].ToString(), 0);
                categoryinfo data = category.getbigcategoryinfo(bcid);
                bigcategoryimgHTML = data.bigcategoryimg;
                if (!Page.IsPostBack)
                {
                    bigcategoryid.Value = data.bigcategoryid.ToString();
                    bigcategoryname.Value = data.bigcategory;
                    oimgname.Value = data.bigcategoryimg;
                }
            }
        }
        protected void EditBigcategory(object sender, EventArgs e)
        {
            string uploadName = imgfile.Value;//获取待上传图片的完整路径，包括文件名 
            //string uploadName = InputFile.PostedFile.FileName; 
            string pictureName = oimgname.Value.Trim();//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
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
                    string path = Server.MapPath("/Files/WebImages/");
                    imgfile.PostedFile.SaveAs(path + pictureName);
                }
                categoryinfo data = new categoryinfo();
                data.bigcategoryimg = pictureName;
                data.bigcategory = bigcategoryname.Value.Trim();
                data.bigcategoryid =TypeParse.DbObjToInt(bigcategoryid.Value,0);
                bool result = category.editbigcategory(data);
                if (result)
                {
                    Response.Write("<script>alert('修改大目录成功！');location.href='/Manager/BigCategory.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('修改大目录失败！');location.href='/Manager/BigCategory.aspx';</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}