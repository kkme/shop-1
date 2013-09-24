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
    public partial class BigCategory : System.Web.UI.Page
    {
        protected string bigcategorylistHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<categoryinfo> list = category.getbigcategory();
            StringBuilder sb = new StringBuilder();
            foreach (categoryinfo item in list)
            {
                string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" style=\"padding:5px 0;\"><img src=\"/Files/WebImages/{0}\" style=\"width:120px;height:50px;\"/></div></td><td height=\"20\" bgcolor=\"#FFFFFF\" style=\"padding:0 0 0 5px;\"><div align=\"center\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"/Manager/EditBigCategory.aspx/?bigcategoryid={2}\" target=\"_blank\" style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:delbigcategory('{3}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                sb.AppendFormat(template, item.bigcategoryimg, item.bigcategory, item.bigcategoryid, item.bigcategoryid);
            }
            bigcategorylistHTML = sb.ToString();

        }
        protected void AddBigCategory(object sender, EventArgs e)
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
                    string path = Server.MapPath("/Files/WebImages/");
                    imgfile.PostedFile.SaveAs(path + pictureName);
                }
                categoryinfo data = new categoryinfo();
                data.bigcategoryimg = pictureName;
                data.bigcategory = bigcategoryname.Value.Trim();
                bool result = category.addbigcategory(data);
                if (result)
                {
                    Response.Write("<script>alert('添加大目录成功！');location.href='/Manager/BigCategory.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('添加大目录失败！');location.href='/Manager/BigCategory.aspx';</script>");
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