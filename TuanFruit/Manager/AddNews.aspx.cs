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
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<newsinfo> newslist = news.getnewstype();
                ntID.DataSource = newslist;
                ntID.DataTextField = "newstype";
                ntID.DataValueField = "ntid";
                ntID.DataBind();
            }

        }
        protected void AddNewsInfo(object sender, EventArgs e)
        {
            string uid="";
            if (Request.Cookies["g_adminid"] != null)
            {
                uid = TypeParse.DbObjToString(Request.Cookies["g_adminid"].Value, "");
            }
            else
            {
                Response.Redirect("/Login/AdminLogin.aspx");
            }
            string uploadName = newsimg.Value;//获取待上传图片的完整路径，包括文件名 
            //string uploadName = InputFile.PostedFile.FileName; 
            string pictureName = "noimg.jpg";//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
            if (newsimg.Value != "")
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
                    string path = Server.MapPath("/Files/NewsImages/");
                    newsimg.PostedFile.SaveAs(path + pictureName);
                }
                newsinfo data = new newsinfo();
                data.newstitle = newstitle.Value.Trim();
                data.ntid = TypeParse.DbObjToInt(ntID.SelectedValue, 0);
                data.istop = TypeParse.DbObjToInt(istop.SelectedValue, 0);
                data.newsfrom = newsfrom.Value.Trim();
                data.newswriter = newswriter.Value.Trim();
                data.newsnote = newsnote.Value.Trim();
                data.userid = uid;
                data.ninfo =editor_id.Value; 
                data.adddate = DateTime.Now;
                data.newsimg = pictureName;
                data.newsstate = 1;

                bool result = news.addnews(data);
                if (result)
                {
                    Response.Write("<script>alert('添加新闻成功！');location.href='/Manager/NewsList.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('添加新闻失败！');location.href='/Manager/NewsList.aspx';</script>");
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