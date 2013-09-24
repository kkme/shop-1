using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;

namespace TuanFruit.Member
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected string orderlistHTML;
        protected string pageHTML;
        protected string orderh3HTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string uid = "";
                if (Request.Cookies["tfuid"] != null)
                {
                    uid = TypeParse.DbObjToString(Request.Cookies["tfuid"].Value, "");
                }
                else
                {
                    Response.Redirect("/UserLog");
                }     
                int page = 1;
                if (Request.QueryString["page"] != null)
                {
                    page = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                }
                pageinfo pdata = new pageinfo();
                pdata.curpageindex = page;
                pdata.pagesize = 10;
                if (RouteData.Values["orderstate"] != null)
                {
                    pdata.where = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid  and a.orderstate=" + RouteData.Values["orderstate"].ToString() + " and a.userid='" + uid + "'";
                    pdata.recordcount = order.getcountbycondition("userorder.orderstate=" + RouteData.Values["orderstate"].ToString()+"  and userorder.userid='"+uid+"'");
                    if (RouteData.Values["orderstate"].ToString() == "0")
                    {
                        orderh3HTML = "我的进行中的订单";
                    }
                    else if (RouteData.Values["orderstate"].ToString() == "10")
                    {
                        orderh3HTML = "我的已完成的订单";
                    }
                    else if (RouteData.Values["orderstate"].ToString() == "44")
                    {
                        orderh3HTML = "我的待处理的订单";
                    }
                    else
                    {
                        orderh3HTML = "我的订单";
                    }
                
                
                }
                else
                {
                    pdata.where = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid and  a.userid='" + uid + "'";
                    pdata.recordcount = order.getcountbycondition("userorder.userid='" + uid + "'");
                    orderh3HTML = "我的订单";
                }               
                pdata.tablename = "userorder a,deliveryI c,deliveryII d";
                pdata.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                pdata.sorttype = 2;
                pdata.primarykey = "orderid";
                pdata.totalpagecount = (pdata.recordcount % pdata.pagesize == 0 ? pdata.recordcount / pdata.pagesize : pdata.recordcount / pdata.pagesize + 1);
                if (pdata.totalpagecount == 0)
                {
                    pdata.totalpagecount = 1;
                }

                List<orderinfo> list = order.getorderlist(pdata);
                StringBuilder sb = new StringBuilder();
                foreach (orderinfo item in list)
                {
                    string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{6}</td><td colspan=\"2\" align=\"center\">产品总额：￥{7}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{8}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                    sb.AppendFormat(template,item.ordernumber,item.orderdate,item.deliverydate,item.contact,item.tel,item.mobile,item.address,item.allmoney.ToString("f2"),item.paymoney.ToString("f2"));
                    List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                    for (int k = 0; k < plist.Count;k++ )
                    {
                        string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                        sb.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                    }
                
                }
                sb.Append("</table>");
                orderlistHTML = sb.ToString();
                pageHTML = pagehelper.Pager(pdata.curpageindex, pdata.pagesize, pdata.recordcount, PageMode.Numeric, 5);
            }

        }
    }
}