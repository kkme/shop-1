using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Models;
using Morrison.Helper;
using System.Text;

namespace TuanFruit.Manager
{
    public partial class NewsList : System.Web.UI.Page
    {
        protected string newslistHTML;
        protected string pageHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                pdata.where = "news.ntid=newstype.ntid";
                pdata.recordcount = news.getnewscount();
                pdata.tablename = "news ,newstype";
                pdata.fieldlist = "news.newsid,news.newstitle,news.newswriter,news.newsfrom,news.newsnote,news.adddate,news.ntid,newstype.newstype,news.ninfo,news.istop,news.newsimg,news.userid";
                pdata.sorttype = 2;
                pdata.primarykey = "newsid";
                pdata.totalpagecount = (pdata.recordcount % pdata.pagesize == 0 ? pdata.recordcount / pdata.pagesize : pdata.recordcount / pdata.pagesize + 1);
                if (pdata.totalpagecount == 0)
                {
                    pdata.totalpagecount = 1;
                }

                List<newsinfo> newslist = news.getnews(pdata);

                StringBuilder sb = new StringBuilder();
                foreach (newsinfo item in newslist)
                {
                    string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" >{0}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\" style=\"padding:0 0 0 5px;\"><div align=\"left\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"left\" style=\"padding:0 0 0 5px;\">{2}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{3}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{4}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"/Manager/EditNews.aspx/?newsid={5}\" style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:delnews('{6}','{7}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                    sb.AppendFormat(template, item.adddate, comm.SubStr(item.newstitle, 17), item.newsfrom, item.newswriter, item.istop, item.newsid, item.newsid, pdata.curpageindex);
                }
                newslistHTML = sb.ToString();
                pageHTML = pagehelper.Pager(pdata.curpageindex, pdata.pagesize, pdata.recordcount, PageMode.Numeric, 5);
            }

        }
    }
}