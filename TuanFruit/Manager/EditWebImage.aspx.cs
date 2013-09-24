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
    public partial class EditWebImage : System.Web.UI.Page
    {
        protected webimagesinfo webimagesinfoDATA;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["wiid"] != null)
            {
                int wiid = TypeParse.DbObjToInt(Request.QueryString["wiid"].ToString(), 0);
                webimagesinfo data = webimages.getwebimagesinfo(wiid);
                webimagesinfoDATA = data;
                if (!Page.IsPostBack)
                {
                    List<webimagesinfo> itlist = webimages.getimagestype();
                    itID.DataSource = itlist;
                    itID.DataTextField = "imagestype";
                    itID.DataValueField = "itid";
                    itID.DataBind();
                    for (int i = 0; i < itID.Items.Count; i++)
                    {
                        if (itID.Items[i].Value == data.itid.ToString())
                        {
                            itID.SelectedIndex = i;
                        }
                    }
                    imgcor.Value = data.imgcor;
                    imginfo.Value = data.imginfo;
                    imgurl.Value = data.imgurl;
                    swiid.Value = wiid.ToString();
                    oimgname.Value = data.imgname;

                }
            }
        }
        protected void EditWebImages(object sender, EventArgs e)
        {
            string s_imginfo = imginfo.Value.Trim();
            string s_imgcor = imgcor.Value.Trim();
            string s_imgurl = imgurl.Value.Trim();
            int s_itid = TypeParse.DbObjToInt(itID.SelectedValue, 0);

            string uploadName = imgname.Value;//获取待上传图片的完整路径，包括文件名 
            //string uploadName = InputFile.PostedFile.FileName; 
            string pictureName = oimgname.Value.Trim();//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
            if (imgname.Value != "")
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
                    imgname.PostedFile.SaveAs(path + pictureName);
                }
                webimagesinfo item = new webimagesinfo();
                item.imgcor = s_imgcor;
                item.imginfo = s_imginfo;
                item.imgname = pictureName;
                item.imgurl = s_imgurl;
                item.itid = s_itid;
                item.wiid = TypeParse.DbObjToInt(swiid.Value, 0);
                bool result = webimages.editwebimages(item);
                if (result)
                {
                    Response.Write("<script>alert('编辑图片成功！');location.href='/Manager/WebImages.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('编辑图片失败！');location.href='/Manager/WebImages.aspx';</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

    }
}