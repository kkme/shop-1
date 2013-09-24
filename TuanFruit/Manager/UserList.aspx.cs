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
    public partial class UserList : System.Web.UI.Page
    {
        protected string userlistHTML;
        protected string pageHTML;
        protected string usertjHTML;
        protected string atHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int allcount = user.getusernumbydate(0);
                int yearcount = user.getusernumbydate(1);
                int monthcount = user.getusernumbydate(2);
                int daycount = user.getusernumbydate(3);
                usertjHTML = "总会员：<span class=\"red\">" + allcount + "</span>个&nbsp;今年注册<span class=\"red\">" + yearcount + "</span>个&nbsp;本月注册<span class=\"red\">" + monthcount + "</span>个&nbsp;今日注册<span  class=\"red\">" + daycount + "</span>个&nbsp;";

                //账号类型
                List<userinfo> alist = user.getaccountstype();
                StringBuilder aselectsb = new StringBuilder();
                aselectsb.Append("<select id=\"atselect\" style=\"width:100px; border:solid 1px #cacaca; height:20px;z-index:100;\">");
                foreach (userinfo item in alist)
                {
                    string template = "<option value=\"{0}\">{1}</option>";
                    aselectsb.AppendFormat(template, item.atid, item.accountstype);
                }
                aselectsb.Append("</select>");
                atHTML = aselectsb.ToString();
                
                
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
                if (Request.QueryString["uinfo"] != null)
                {
                    string uinfo = HttpUtility.UrlDecode(Request.QueryString["uinfo"].ToString());
                    pdata.where = "userinfo.atid=accountstype.atid and ( userinfo.accounts like'%"+uinfo+"%' or userinfo.email like '%"+uinfo+"%')";
                }
                else if (Request.QueryString["atid"] != null)
                {
                    pdata.where = "userinfo.atid=accountstype.atid and userinfo.atid="+Request.QueryString["atid"].ToString();
                }
                else
                {
                    pdata.where = "userinfo.atid=accountstype.atid";
                }
                pdata.recordcount = allcount;
                pdata.tablename = "userinfo,accountstype";
                pdata.fieldlist = "userinfo.userid,userinfo.accounts,userinfo.email,userinfo.tel,userinfo.truename,userinfo.qq,userinfo.atid,userinfo.headerimg,userinfo.address,userinfo.mobile,userinfo.company,userinfo.adddate,accountstype.accountstype";
                pdata.sorttype = 2;
                pdata.primarykey = "userid";
                pdata.totalpagecount = (pdata.recordcount % pdata.pagesize == 0 ? pdata.recordcount / pdata.pagesize : pdata.recordcount / pdata.pagesize + 1);
                if (pdata.totalpagecount == 0)
                {
                    pdata.totalpagecount = 1;
                }

                List<userinfo> userlist = user.getUserList(pdata);

                StringBuilder sb = new StringBuilder();
                foreach (userinfo item in userlist)
                {
                    string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" >{0}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{2}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{3}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{4}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{5}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"left\" style=\"padding:0 0 0 2px;\">{6}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{7}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"javascript:edituser('{8}')\" style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:deluser('{9}','{10}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                    sb.AppendFormat(template, item.adddate, item.email, item.accounts, item.truename, item.tel, item.mobile, item.company, item.accountstype, item.userid,item.userid, pdata.curpageindex);
                }
                userlistHTML = sb.ToString();
                pageHTML = pagehelper.Pager(pdata.curpageindex, pdata.pagesize, pdata.recordcount, PageMode.Numeric, 5);
            }

        }
    }
}