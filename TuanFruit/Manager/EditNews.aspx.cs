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
    public partial class EditNews : System.Web.UI.Page
    {
        protected newsinfo newsinfoDATA;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["newsid"] != null)
            {
                int inewsid = TypeParse.DbObjToInt(Request.QueryString["newsid"].ToString(), 0);
                newsinfo data = news.getnewsinfo(inewsid.ToString());
                newsinfoDATA = data;
                if (!Page.IsPostBack)
                {
                    List<newsinfo> ntlist = news.getnewstype();
                    ntid.DataSource = ntlist;
                    ntid.DataTextField = "newstype";
                    ntid.DataValueField = "ntid";
                    ntid.DataBind();
                    for (int i = 0; i < ntid.Items.Count; i++)
                    {
                        if (ntid.Items[i].Value == data.ntid.ToString())
                        {
                            ntid.SelectedIndex = i;
                        }
                    }

                    ListItem l1 = new ListItem();
                    l1.Value = "0";
                    l1.Text = "普通";
                    ListItem l2 = new ListItem();
                    l2.Value = "1";
                    l2.Text = "置顶";
                    istop.Items.Add(l1);
                    istop.Items.Add(l2);
                    if (data.istop == 0)
                    {
                        for (int k = 0; k < istop.Items.Count; k++)
                        {
                            if (istop.Items[k].Value == "0")
                            {
                                istop.SelectedIndex = k;
                            }
                        }
                    }
                    if (data.istop == 1)
                    {
                        for (int k = 0; k < istop.Items.Count; k++)
                        {
                            if (istop.Items[k].Value == "1")
                            {
                                istop.SelectedIndex = k;
                            }
                        }
                    }
                    newsfrom.Value = data.newsfrom;
                    newstitle.Value = data.newstitle;
                    newswriter.Value = data.newswriter;
                    oldnewsimg.Value = data.newsimg;
                    snewsid.Value = inewsid.ToString();
                    newsnote.Value = data.newsnote;
                    editor_id.Value = data.ninfo;

                }
            }
        }

        protected void EditNewsInfo(object sender, EventArgs e)
        {
            string uid = "";
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
            string pictureName =oldnewsimg.Value.Trim();//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
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
                data.ntid = TypeParse.DbObjToInt(ntid.SelectedValue, 0);
                data.istop = TypeParse.DbObjToInt(istop.SelectedValue, 0);
                data.newsfrom = newsfrom.Value.Trim();
                data.newswriter = newswriter.Value.Trim();
                data.newsnote = newsnote.Value.Trim();
                data.userid = uid;
                data.ninfo = editor_id.Value;
                data.adddate = DateTime.Now;
                data.newsimg = pictureName;
                data.newsstate = 1;
                data.newsid =TypeParse.DbObjToInt(snewsid.Value,0);

                bool result = news.editnewsinfo(data);
                if (result)
                {
                    Response.Write("<script>alert('编辑新闻成功！');location.href='/Manager/NewsList.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('编辑新闻失败！');location.href='/Manager/NewsList.aspx';</script>");
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