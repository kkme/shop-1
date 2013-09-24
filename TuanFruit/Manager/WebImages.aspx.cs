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
    public partial class WebImages : System.Web.UI.Page
    {
        protected string imageslistHTML;
        protected string imagestypeHTML;
        protected string pageHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<webimagesinfo> itlist = webimages.getimagestype();
                itID.DataSource = itlist;
                itID.DataTextField = "imagestype";
                itID.DataValueField = "itid";
                itID.DataBind();

                pageinfo pdata = new pageinfo();
                int page;
                if (Request.QueryString["page"] != null)
                {
                    page = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                }
                else
                {
                    page = 1;
                }

                pdata.curpageindex = page;
                pdata.pagesize = 10;
                pdata.where = "webimages.itid=imagestype.itid";
                pdata.recordcount = webimages.getwebimagecount();
                pdata.tablename = "webimages ,imagestype";
                pdata.fieldlist = "webimages.wiid,webimages.imgurl,webimages.imginfo,webimages.itid,webimages.imgname,webimages.imgcor,imagestype.imagestype";
                pdata.sorttype = 2;
                pdata.primarykey = "wiid";
                pdata.totalpagecount = (pdata.recordcount % pdata.pagesize == 0 ? pdata.recordcount / pdata.pagesize : pdata.recordcount / pdata.pagesize + 1);
                if (pdata.totalpagecount == 0)
                {
                    pdata.totalpagecount = 1;
                }

                List<webimagesinfo> imageslist = webimages.getwebimages(pdata);
                StringBuilder imgsb = new StringBuilder();
                foreach (webimagesinfo item in imageslist)
                {
                    string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" style=\"padding:5px 0;\"><img src=\"/Files/WebImages/{0}\" style=\"width:120px;height:100px;\"/></div></td><td height=\"20\" bgcolor=\"#FFFFFF\" style=\"padding:0 0 0 5px;\"><div align=\"left\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"left\" style=\"padding:0 0 0 5px;\">{2}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{3}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"/Manager/EditWebImage.aspx/?wiid={4}\"  style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:delwebimages('{5}','{6}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                    imgsb.AppendFormat(template, item.imgname, item.imgurl, item.imginfo, item.imagestype, item.wiid, item.wiid, pdata.curpageindex);
                }
                imageslistHTML = imgsb.ToString();

                pageHTML = pagehelper.Pager(pdata.curpageindex, pdata.pagesize, pdata.recordcount, PageMode.Numeric, 5);
            }
        }

        //上传图片并写入数据库
        protected void AddWebImages(object sender, EventArgs e)
        {
            string s_imginfo = imginfo.Value.Trim();
            string s_imgcor = imgcor.Value.Trim();
            string s_imgurl = imgurl.Value.Trim();
            int s_itid =TypeParse.DbObjToInt(itID.SelectedValue,0);

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
                webimagesinfo item = new webimagesinfo();
                item.imgcor = s_imgcor;
                item.imginfo = s_imginfo;
                item.imgname = pictureName;
                item.imgurl = s_imgurl;
                item.itid = s_itid;
                bool result = webimages.addwebimages(item);
                if (result)
                {
                    Response.Write("<script>alert('上传图片成功！');location.href='/Manager/WebImages.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('上传图片失败！');location.href='/Manager/WebImages.aspx';</script>");
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