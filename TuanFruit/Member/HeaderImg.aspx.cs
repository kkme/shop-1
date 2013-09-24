using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;

namespace TuanFruit.Member
{
    public partial class HeaderImg : System.Web.UI.Page
    {
        protected string headerimgHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            string memberid = Request.Cookies["tfuid"].Value.ToString();
            userinfo data = user.getuserinfo(memberid);
            headerimgHTML = data.headerimg;
            oimgname.Value=data.headerimg;
        }
        protected void EditHeaderImg(object sender, EventArgs e)
        {
            string userid = Request.Cookies["tfuid"].Value.ToString();
            string uploadName = headerimg.Value;//获取待上传图片的完整路径，包括文件名 
            //string uploadName = InputFile.PostedFile.FileName; 
            string pictureName = oimgname.Value.Trim();//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
            if (headerimg.Value != "")
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
                    string path = Server.MapPath("/Files/HeaderImg/");
                    headerimg.PostedFile.SaveAs(path + pictureName);
                }

                userinfo data = new userinfo();
                data.headerimg = pictureName;
                data.userid = userid;
                bool result = user.changeHeaderImg(data);
                if (result)
                {
                    Response.Write("<script>alert('编辑图片成功！');location.href='/UHeaderImg';</script>");
                }
                else
                {
                    Response.Write("<script>alert('编辑图片失败！');location.href='/UHeaderImg';</script>");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
    }
}