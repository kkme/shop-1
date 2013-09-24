using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;

namespace TuanFruit.Manager
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected string orderlistHTML;
        protected string pageHTML;
        protected string dyHTML;
        protected string d1sbHTML;
        protected string podsbHTML;
        protected string phodsbHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Cookies["g_adminid"] != null)
                {

                    //大区下拉菜单
                    List<categoryinfo> d1list = category.getdeliveryI();
                    StringBuilder d1sb = new StringBuilder();
                    d1sb.Append("<select id=\"odIid\" class=\"orderselect\"  onchange=\"changeodI()\"><option value=\"0\">不限</option>");
                    foreach (categoryinfo pitem in d1list)
                    {
                        string template = "<option value=\"{0}\">{1}</option>";
                        d1sb.AppendFormat(template, pitem.deliveryIid, pitem.deliveryI);
                    }
                    d1sb.Append("</select>");
                    d1sbHTML = d1sb.ToString();

                    //大区下拉菜单
                    List<categoryinfo> podlist = category.getdeliveryI();
                    StringBuilder podsb = new StringBuilder();
                    podsb.Append("<select id=\"podIid\" class=\"orderselect\"  onchange=\"changepodI()\"><option value=\"0\">不限</option>");
                    foreach (categoryinfo pitem in podlist)
                    {
                        string template = "<option value=\"{0}\">{1}</option>";
                        podsb.AppendFormat(template, pitem.deliveryIid, pitem.deliveryI);
                    }
                    podsb.Append("</select>");
                    podsbHTML = podsb.ToString();

                    //大区下拉菜单
                    List<categoryinfo> phodlist = category.getdeliveryI();
                    StringBuilder phodsb = new StringBuilder();
                    phodsb.Append("<select id=\"phodIid\" class=\"orderselect\"  onchange=\"changephodI()\"><option value=\"0\">不限</option>");
                    foreach (categoryinfo pitem in phodlist)
                    {
                        string template = "<option value=\"{0}\">{1}</option>";
                        phodsb.AppendFormat(template, pitem.deliveryIid, pitem.deliveryI);
                    }
                    phodsb.Append("</select>");
                    phodsbHTML = phodsb.ToString();

                    if (Request.QueryString["type"] != null)
                    {
                        StringBuilder dysb = new StringBuilder();
                        string type = Request.QueryString["type"].ToString();
                        switch (type)
                        {
                            //第一列导航
                            case "1":
                                if (Request.QueryString["n"] != null)
                                {
                                    string n = Request.QueryString["n"].ToString();
                                    switch (n)
                                    {
                                        #region 第一列导航明细

                                        //今日配货总览
                                        case "1":
                                            List<orderinfo> list = order.getphlist(" and userorder.orderstate=0 and DateDiff(dd,userorder.deliverydate,GetDate())=0");
                                            dysb.Append(" <h2>今日（" + DateTime.Now.ToString("yyyy-MM-dd") + "）配货总览</h2>");
                                            dysb.Append(" <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td align=\"center\">产品编号</td><td align=\"center\">产品名称</td> <td align=\"center\">产品图片</td><td align=\"center\">配货数量</td><td align=\"center\">配货日期</td></tr>");
                                            foreach (orderinfo item in list)
                                            {
                                                string template = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td align=\"center\">{0}</td><td align=\"center\" class=\"oimg\"><img src=\"/Files/Product/{1}\" /></td><td align=\"center\">{2}</td><td align=\"center\"><span class=\"fb\">{3}</span></td><td align=\"center\">{4}</td></tr>";
                                                dysb.AppendFormat(template, item.productcode, item.productimg, item.productname, item.tjbuynum, DateTime.Now.ToString("yyyy-MM-dd"));
                                            }
                                            dysb.Append("</table>");

                                            List<categoryinfo> clist = category.getdeliveryI();
                                            foreach (categoryinfo citem in clist)
                                            {
                                                List<orderinfo> olist1 = order.getphlist(" and userorder.orderstate=0  and DateDiff(dd,userorder.deliverydate,GetDate())=0 and userorder.deliveryIid=" + citem.deliveryIid);
                                                dysb.Append(" <h2>今日（" + DateTime.Now.ToString("yyyy-MM-dd") + "）" + citem.deliveryI + "配货总览</h2>");
                                                dysb.Append(" <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td align=\"center\">产品编号</td><td align=\"center\">产品名称</td> <td align=\"center\">产品图片</td><td align=\"center\">配货数量</td><td align=\"center\">配货日期</td></tr>");
                                                foreach (orderinfo item in olist1)
                                                {
                                                    string template = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td align=\"center\">{0}</td><td align=\"center\" class=\"oimg\"><img src=\"/Files/Product/{1}\" /></td><td align=\"center\">{2}</td><td align=\"center\"><span class=\"fb\">{3}</span></td><td align=\"center\">{4}</td></tr>";
                                                    dysb.AppendFormat(template, item.productcode, item.productimg, item.productname, item.tjbuynum, DateTime.Now.ToString("yyyy-MM-dd"));
                                                }
                                                dysb.Append("</table>");
                                            }

                                            dyHTML = dysb.ToString();
                                            id1.Style.Value = "background:url(/Images/a.gif) no-repeat 0 -33px;color:White;";
                                            break;

                                        //今日配货订单
                                        case "2":
                                            int page = 1;
                                            if (Request.QueryString["page"] != null)
                                            {
                                                page = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                            }
                                            pageinfo pdata = new pageinfo();
                                            pdata.curpageindex = page;
                                            pdata.pagesize = 100000;
                                            pdata.where = " a.orderstate=0 and  a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid and DateDiff(dd,a.deliverydate,GetDate())=0";
                                            pdata.recordcount = order.getcountbycondition(" DateDiff(dd,userorder.deliverydate,GetDate())=0");
                                            pdata.tablename = "userorder a,deliveryI c,deliveryII d";
                                            pdata.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                            pdata.sorttype = 2;
                                            pdata.primarykey = "orderid";
                                            pdata.totalpagecount = (pdata.recordcount % pdata.pagesize == 0 ? pdata.recordcount / pdata.pagesize : pdata.recordcount / pdata.pagesize + 1);
                                            if (pdata.totalpagecount == 0)
                                            {
                                                pdata.totalpagecount = 1;
                                            }

                                            List<orderinfo> list2 = order.getorderlist(pdata);
                                            StringBuilder sb = new StringBuilder();
                                            sb.Append(" <h2>今日（" + DateTime.Now.ToString("yyyy-MM-dd") + "）配货订单</h2>");
                                            foreach (orderinfo item in list2)
                                            {
                                                string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{6}&nbsp;&nbsp;小区:{7}<span class=\"fr\"><a href=\"javascript:editorder('{8}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{9}</td><td colspan=\"2\" align=\"center\">产品总额：￥{10}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{11}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                                sb.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                                List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                                for (int k = 0; k < plist.Count; k++)
                                                {
                                                    string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                                    sb.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                                }

                                            }
                                            sb.Append("</table>");
                                            dyHTML = sb.ToString();
                                            id2.Style.Value = "background:url(/Images/a.gif) no-repeat 0 -33px;color:White;";
                                            break;

                                        //今日订单明细
                                        case "3":
                                            int page2 = 1;
                                            if (Request.QueryString["page"] != null)
                                            {
                                                page2 = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                            }
                                            pageinfo pdata2 = new pageinfo();
                                            pdata2.curpageindex = page2;
                                            pdata2.pagesize = 100000;
                                            pdata2.where = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid and DateDiff(dd,a.orderdate,GetDate())=0";
                                            pdata2.recordcount = order.getcountbycondition(" DateDiff(dd,userorder.orderdate,GetDate())=0");
                                            pdata2.tablename = "userorder a,deliveryI c,deliveryII d";
                                            pdata2.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                            pdata2.sorttype = 2;
                                            pdata2.primarykey = "orderid";
                                            pdata2.totalpagecount = (pdata2.recordcount % pdata2.pagesize == 0 ? pdata2.recordcount / pdata2.pagesize : pdata2.recordcount / pdata2.pagesize + 1);
                                            if (pdata2.totalpagecount == 0)
                                            {
                                                pdata2.totalpagecount = 1;
                                            }

                                            List<orderinfo> list3 = order.getorderlist(pdata2);
                                            StringBuilder sb3 = new StringBuilder();
                                            sb3.Append(" <h2>今日（" + DateTime.Now.ToString("yyyy-MM-dd") + "）订单明细</h2>");
                                            foreach (orderinfo item in list3)
                                            {
                                                string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{6}&nbsp;&nbsp;小区:{7}&nbsp;&nbsp;订单状态：{8}<span class=\"fr\"><a href=\"javascript:editorder('{9}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{10}</td><td colspan=\"2\" align=\"center\">产品总额：￥{11}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{12}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                                sb3.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderstatestr, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                                List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                                for (int k = 0; k < plist.Count; k++)
                                                {
                                                    string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                                    sb3.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                                }

                                            }
                                            sb3.Append("</table>");
                                            dyHTML = sb3.ToString();
                                            id3.Style.Value = "background:url(/Images/a.gif) no-repeat 0 -33px;color:White;";
                                            break;

                                        //本月订单明细
                                        case "4":
                                            int page4 = 1;
                                            if (Request.QueryString["page"] != null)
                                            {
                                                page4 = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                            }
                                            pageinfo pdata4 = new pageinfo();
                                            pdata4.curpageindex = page4;
                                            pdata4.pagesize = 10;
                                            pdata4.where = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid and DateDiff(Month,a.orderdate,GetDate())=0";
                                            pdata4.recordcount = order.getcountbycondition(" DateDiff(Month,userorder.orderdate,GetDate())=0");
                                            pdata4.tablename = "userorder a,deliveryI c,deliveryII d";
                                            pdata4.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                            pdata4.sorttype = 2;
                                            pdata4.primarykey = "orderid";
                                            pdata4.totalpagecount = (pdata4.recordcount % pdata4.pagesize == 0 ? pdata4.recordcount / pdata4.pagesize : pdata4.recordcount / pdata4.pagesize + 1);
                                            if (pdata4.totalpagecount == 0)
                                            {
                                                pdata4.totalpagecount = 1;
                                            }

                                            List<orderinfo> list4 = order.getorderlist(pdata4);
                                            StringBuilder sb4 = new StringBuilder();
                                            sb4.Append(" <h2>本月（" + DateTime.Now.ToString("yyyy-MM") + "）订单明细</h2>");
                                            foreach (orderinfo item in list4)
                                            {
                                                string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{6}&nbsp;&nbsp;小区:{7}&nbsp;&nbsp;订单状态：{8}<span class=\"fr\"><a href=\"javascript:editorder('{9}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{10}</td><td colspan=\"2\" align=\"center\">产品总额：￥{11}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{12}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                                sb4.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderstatestr, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                                List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                                for (int k = 0; k < plist.Count; k++)
                                                {
                                                    string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                                    sb4.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                                }

                                            }
                                            sb4.Append("</table>");
                                            dyHTML = sb4.ToString();
                                            pageHTML = pagehelper.Pager(pdata4.curpageindex, pdata4.pagesize, pdata4.recordcount, PageMode.Numeric, 5);
                                            id4.Style.Value = "background:url(/Images/a.gif) no-repeat 0 -33px;color:White;";
                                            break;

                                        //所有订单明细
                                        case "5":
                                            int page5 = 1;
                                            if (Request.QueryString["page"] != null)
                                            {
                                                page5 = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                            }
                                            pageinfo pdata5 = new pageinfo();
                                            pdata5.curpageindex = page5;
                                            pdata5.pagesize = 10;
                                            pdata5.where = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid";
                                            pdata5.recordcount = order.getcount();
                                            pdata5.tablename = "userorder a,deliveryI c,deliveryII d";
                                            pdata5.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                            pdata5.sorttype = 2;
                                            pdata5.primarykey = "orderid";
                                            pdata5.totalpagecount = (pdata5.recordcount % pdata5.pagesize == 0 ? pdata5.recordcount / pdata5.pagesize : pdata5.recordcount / pdata5.pagesize + 1);
                                            if (pdata5.totalpagecount == 0)
                                            {
                                                pdata5.totalpagecount = 1;
                                            }

                                            List<orderinfo> list5 = order.getorderlist(pdata5);
                                            StringBuilder sb5 = new StringBuilder();
                                            sb5.Append(" <h2>所有订单明细</h2>");
                                            foreach (orderinfo item in list5)
                                            {
                                                string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{6}&nbsp;&nbsp;小区:{7}&nbsp;&nbsp;订单状态：{8}<span class=\"fr\"><a href=\"javascript:editorder('{9}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{10}</td><td colspan=\"2\" align=\"center\">产品总额：￥{11}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{12}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                                sb5.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderstatestr, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                                List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                                for (int k = 0; k < plist.Count; k++)
                                                {
                                                    string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                                    sb5.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                                }

                                            }
                                            sb5.Append("</table>");
                                            dyHTML = sb5.ToString();
                                            pageHTML = pagehelper.Pager(pdata5.curpageindex, pdata5.pagesize, pdata5.recordcount, PageMode.Numeric, 5);
                                            id5.Style.Value = "background:url(/Images/a.gif) no-repeat 0 -33px;color:White;";
                                            break;

                                        //进行中订单
                                        case "6":
                                            int page6 = 1;
                                            if (Request.QueryString["page"] != null)
                                            {
                                                page6 = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                            }
                                            pageinfo pdata6 = new pageinfo();
                                            pdata6.curpageindex = page6;
                                            pdata6.pagesize = 10;
                                            pdata6.where = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid and a.orderstate=0";
                                            pdata6.recordcount = order.getcountbycondition("userorder.orderstate=0");
                                            pdata6.tablename = "userorder a,deliveryI c,deliveryII d";
                                            pdata6.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                            pdata6.sorttype = 2;
                                            pdata6.primarykey = "orderid";
                                            pdata6.totalpagecount = (pdata6.recordcount % pdata6.pagesize == 0 ? pdata6.recordcount / pdata6.pagesize : pdata6.recordcount / pdata6.pagesize + 1);
                                            if (pdata6.totalpagecount == 0)
                                            {
                                                pdata6.totalpagecount = 1;
                                            }

                                            List<orderinfo> list6 = order.getorderlist(pdata6);
                                            StringBuilder sb6 = new StringBuilder();
                                            sb6.Append(" <h2>进行中订单</h2>");
                                            foreach (orderinfo item in list6)
                                            {
                                                string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{6}&nbsp;&nbsp;小区:{7}&nbsp;&nbsp;订单状态：{8}<span class=\"fr\"><a href=\"javascript:editorder('{9}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{10}</td><td colspan=\"2\" align=\"center\">产品总额：￥{11}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{12}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                                sb6.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderstatestr, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                                List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                                for (int k = 0; k < plist.Count; k++)
                                                {
                                                    string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                                    sb6.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                                }

                                            }
                                            sb6.Append("</table>");
                                            dyHTML = sb6.ToString();
                                            pageHTML = pagehelper.Pager(pdata6.curpageindex, pdata6.pagesize, pdata6.recordcount, PageMode.Numeric, 5);
                                            id6.Style.Value = "background:url(/Images/a.gif) no-repeat 0 -33px;color:White;";
                                            break;

                                        //已完成订单
                                        case "7":
                                            int page7 = 1;
                                            if (Request.QueryString["page"] != null)
                                            {
                                                page7 = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                            }
                                            pageinfo pdata7 = new pageinfo();
                                            pdata7.curpageindex = page7;
                                            pdata7.pagesize = 10;
                                            pdata7.where = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid and a.orderstate=10";
                                            pdata7.recordcount = order.getcountbycondition("userorder.orderstate=10");
                                            pdata7.tablename = "userorder a,deliveryI c,deliveryII d";
                                            pdata7.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                            pdata7.sorttype = 2;
                                            pdata7.primarykey = "orderid";
                                            pdata7.totalpagecount = (pdata7.recordcount % pdata7.pagesize == 0 ? pdata7.recordcount / pdata7.pagesize : pdata7.recordcount / pdata7.pagesize + 1);
                                            if (pdata7.totalpagecount == 0)
                                            {
                                                pdata7.totalpagecount = 1;
                                            }

                                            List<orderinfo> list7 = order.getorderlist(pdata7);
                                            StringBuilder sb7 = new StringBuilder();
                                            sb7.Append(" <h2>已完成订单</h2>");
                                            foreach (orderinfo item in list7)
                                            {
                                                string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"7\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{7}&nbsp;&nbsp;小区:{7}&nbsp;&nbsp;订单状态：{8}<span class=\"fr\"><a href=\"javascript:editorder('{9}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{10}</td><td colspan=\"2\" align=\"center\">产品总额：￥{11}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{12}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                                sb7.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderstatestr, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                                List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                                for (int k = 0; k < plist.Count; k++)
                                                {
                                                    string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                                    sb7.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                                }

                                            }
                                            sb7.Append("</table>");
                                            dyHTML = sb7.ToString();
                                            pageHTML = pagehelper.Pager(pdata7.curpageindex, pdata7.pagesize, pdata7.recordcount, PageMode.Numeric, 5);
                                            id7.Style.Value = "background:url(/Images/a.gif) no-repeat 0 -33px;color:White;";
                                            break;

                                        //待处理订单
                                        case "8":
                                            int page8 = 1;
                                            if (Request.QueryString["page"] != null)
                                            {
                                                page8 = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                            }
                                            pageinfo pdata8 = new pageinfo();
                                            pdata8.curpageindex = page8;
                                            pdata8.pagesize = 100000;
                                            pdata8.where = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid and a.orderstate=44";
                                            pdata8.recordcount = order.getcountbycondition("userorder.orderstate=44");
                                            pdata8.tablename = "userorder a,deliveryI c,deliveryII d";
                                            pdata8.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                            pdata8.sorttype = 2;
                                            pdata8.primarykey = "orderid";
                                            pdata8.totalpagecount = (pdata8.recordcount % pdata8.pagesize == 0 ? pdata8.recordcount / pdata8.pagesize : pdata8.recordcount / pdata8.pagesize + 1);
                                            if (pdata8.totalpagecount == 0)
                                            {
                                                pdata8.totalpagecount = 1;
                                            }

                                            List<orderinfo> list8 = order.getorderlist(pdata8);
                                            StringBuilder sb8 = new StringBuilder();
                                            sb8.Append(" <h2>待处理订单</h2>");
                                            foreach (orderinfo item in list8)
                                            {
                                                string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"8\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{8}&nbsp;&nbsp;小区:{7}&nbsp;&nbsp;订单状态：{8}<span class=\"fr\"><a href=\"javascript:editorder('{9}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{10}</td><td colspan=\"2\" align=\"center\">产品总额：￥{11}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{12}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                                sb8.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderstatestr, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                                List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                                for (int k = 0; k < plist.Count; k++)
                                                {
                                                    string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                                    sb8.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                                }

                                            }
                                            sb8.Append("</table>");
                                            dyHTML = sb8.ToString();
                                            pageHTML = pagehelper.Pager(pdata8.curpageindex, pdata8.pagesize, pdata8.recordcount, PageMode.Numeric, 5);
                                            id8.Style.Value = "background:url(/Images/a.gif) no-repeat 0 -33px;color:White;";
                                            break;
                                        default:
                                            break;

                                        #endregion
                                    }
                                }
                                break;

                            //第二列搜索 搜索订单
                            case "2":
                                int page_2 = 1;
                                if (Request.QueryString["page"] != null)
                                {
                                    page_2 = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                }
                                pageinfo pdata_2 = new pageinfo();
                                pdata_2.curpageindex = page_2;
                                pdata_2.pagesize = 100000;
                                string searctxt="";
                                string conditionstr1 = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid ";
                                string conditionstr="";
                                if (Request.QueryString["od1"] != null && Request.QueryString["od1"] != "" && Request.QueryString["od2"] != null && Request.QueryString["od2"] != "")
                                {
                                    DateTime od1date=TypeParse.DbObjToDateTime(Request.QueryString["od1"].ToString()+" 00:00:00",DateTime.Now);
                                    DateTime od2date = TypeParse.DbObjToDateTime(Request.QueryString["od2"].ToString() + " 23:59:59", DateTime.Now);
                                    conditionstr += " and a.orderdate>='"+od1date+"' and a.orderdate<='"+od2date+"'";
                                    searctxt += "开始日期：" + od1date.ToString() + ",结束日期：" + od2date.ToString();
                                }
                                if (Request.QueryString["ostateid"] != null && Request.QueryString["ostateid"] != "" && Request.QueryString["ostateid"] != "1000")
                                {
                                    int state = TypeParse.DbObjToInt(Request.QueryString["ostateid"], 0);
                                    conditionstr += " and a.orderstate=" + state;
                                    if (state == 0)
                                    {
                                        searctxt += "进行中订单";
                                    }
                                    if (state == 10)
                                    {
                                        searctxt += "已完成订单";
                                    }
                                    if (state == 44)
                                    {
                                        searctxt += "待处理订单";
                                    }
                                }
                                if (Request.QueryString["odIid"] != null && Request.QueryString["odIid"] != "" && Request.QueryString["odIid"] != "0")
                                {
                                    int odIid = TypeParse.DbObjToInt(Request.QueryString["odIid"], 0);
                                    conditionstr += " and a.deliveryIid=" + odIid;
                                    categoryinfo citem = category.getdeliveryIinfo(odIid);
                                    searctxt += "大区：" + citem.deliveryI;
                                }
                                if (Request.QueryString["odIIid"] != null && Request.QueryString["odIIid"] != "" && Request.QueryString["odIIid"] != "0")
                                {
                                    int odIIid = TypeParse.DbObjToInt(Request.QueryString["odIIid"], 0);
                                    conditionstr += " and a.deliveryIIid=" + odIIid;
                                    categoryinfo citem = category.getdeliveryIIinfo(odIIid);
                                    searctxt += "小区：" + citem.deliveryII;
                                }


                                pdata_2.where = conditionstr1 + conditionstr;                                   
                                pdata_2.recordcount = order.getcountbycondition("");
                                pdata_2.tablename = "userorder a,deliveryI c,deliveryII d";
                                pdata_2.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                pdata_2.sorttype = 2;
                                pdata_2.primarykey = "orderid";
                                pdata_2.totalpagecount = (pdata_2.recordcount % pdata_2.pagesize == 0 ? pdata_2.recordcount / pdata_2.pagesize : pdata_2.recordcount / pdata_2.pagesize + 1);
                                if (pdata_2.totalpagecount == 0)
                                {
                                    pdata_2.totalpagecount = 1;
                                }

                                List<orderinfo> list_2 = order.getorderlist(pdata_2);
                                StringBuilder sb_2 = new StringBuilder();
                                sb_2.Append(" <h2>下单日期查询:("+searctxt+")</h2>");
                                foreach (orderinfo item in list_2)
                                {
                                    string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{6}&nbsp;&nbsp;小区:{7}&nbsp;&nbsp;订单状态：{8}<span class=\"fr\"><a href=\"javascript:editorder('{9}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{10}</td><td colspan=\"2\" align=\"center\">产品总额：￥{11}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{12}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                    sb_2.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderstatestr, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                    List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                    for (int k = 0; k < plist.Count; k++)
                                    {
                                        string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                        sb_2.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                    }

                                }
                                sb_2.Append("</table>");
                                dyHTML = sb_2.ToString();
                                break;

                            //第三列搜索 搜索订单-配货日期
                            case "3":
                                int page_3 = 1;
                                if (Request.QueryString["page"] != null)
                                {
                                    page_3 = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                }
                                pageinfo pdata_3 = new pageinfo();
                                pdata_3.curpageindex = page_3;
                                pdata_3.pagesize = 100000;
                                string searctxt_3 = "";
                                string conditionstr1_3 = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid ";
                                string conditionstr_3 = "";
                                if (Request.QueryString["pod1"] != null && Request.QueryString["pod1"] != "" && Request.QueryString["pod2"] != null && Request.QueryString["pod2"] != "")
                                {
                                    DateTime od1date = TypeParse.DbObjToDateTime(Request.QueryString["pod1"].ToString() + " 00:00:00", DateTime.Now);
                                    DateTime od2date = TypeParse.DbObjToDateTime(Request.QueryString["pod2"].ToString() + " 23:59:59", DateTime.Now);
                                    conditionstr_3 += " and a.deliverydate>='" + od1date + "' and a.deliverydate<='" + od2date+"'";
                                    searctxt_3 += "开始日期：" + od1date.ToString() + ",结束日期：" + od2date.ToString();
                                }
                                if (Request.QueryString["postateid"] != null && Request.QueryString["postateid"] != "" && Request.QueryString["postateid"] != "1000")
                                {
                                    int state = TypeParse.DbObjToInt(Request.QueryString["postateid"], 0);
                                    conditionstr_3 += " and a.orderstate=" + state;
                                    if (state == 0)
                                    {
                                        searctxt_3 += "进行中订单";
                                    }
                                    if (state == 10)
                                    {
                                        searctxt_3 += "已完成订单";
                                    }
                                    if (state == 44)
                                    {
                                        searctxt_3 += "待处理订单";
                                    }
                                }
                                if (Request.QueryString["podIid"] != null && Request.QueryString["podIid"] != "" && Request.QueryString["podIid"] != "0")
                                {
                                    int odIid = TypeParse.DbObjToInt(Request.QueryString["podIid"], 0);
                                    conditionstr_3 += " and a.deliveryIid=" + odIid;
                                    categoryinfo citem = category.getdeliveryIinfo(odIid);
                                    searctxt_3 += "大区：" + citem.deliveryI;
                                }
                                if (Request.QueryString["podIIid"] != null && Request.QueryString["podIIid"] != "" && Request.QueryString["podIIid"] != "0")
                                {
                                    int odIIid = TypeParse.DbObjToInt(Request.QueryString["podIIid"], 0);
                                    conditionstr_3 += " and a.deliveryIIid=" + odIIid;
                                    categoryinfo citem = category.getdeliveryIIinfo(odIIid);
                                    searctxt_3 += "小区：" + citem.deliveryII;
                                }


                                pdata_3.where = conditionstr1_3 + conditionstr_3;
                                pdata_3.recordcount = order.getcountbycondition("");
                                pdata_3.tablename = "userorder a,deliveryI c,deliveryII d";
                                pdata_3.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                pdata_3.sorttype = 2;
                                pdata_3.primarykey = "orderid";
                                pdata_3.totalpagecount = (pdata_3.recordcount % pdata_3.pagesize == 0 ? pdata_3.recordcount / pdata_3.pagesize : pdata_3.recordcount / pdata_3.pagesize + 1);
                                if (pdata_3.totalpagecount == 0)
                                {
                                    pdata_3.totalpagecount = 1;
                                }

                                List<orderinfo> list_3 = order.getorderlist(pdata_3);
                                StringBuilder sb_3 = new StringBuilder();
                                sb_3.Append(" <h2>送货日期查询:(" + searctxt_3 + ")</h2>");
                                foreach (orderinfo item in list_3)
                                {
                                    string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{6}&nbsp;&nbsp;小区:{7}&nbsp;&nbsp;订单状态：{8}<span class=\"fr\"><a href=\"javascript:editorder('{9}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{10}</td><td colspan=\"2\" align=\"center\">产品总额：￥{11}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{12}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                    sb_3.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderstatestr, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                    List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                    for (int k = 0; k < plist.Count; k++)
                                    {
                                        string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                        sb_3.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                    }

                                }
                                sb_3.Append("</table>");
                                dyHTML = sb_3.ToString();
                                break;

                            //第三列搜索  配货总量
                            case "8":
                                 string searctxt_8="";
                                 string conditionstr_8 = " and userorder.orderstate=0  ";
                                 if (Request.QueryString["phod1"] != null && Request.QueryString["phod1"] != "" && Request.QueryString["phod2"] != null && Request.QueryString["phod2"] != "")
                                {
                                    DateTime od1date=TypeParse.DbObjToDateTime(Request.QueryString["od1"].ToString()+" 00:00:00",DateTime.Now);
                                    DateTime od2date = TypeParse.DbObjToDateTime(Request.QueryString["od2"].ToString() + " 23:59:59", DateTime.Now);
                                    conditionstr_8 += " and userorder.orderdate>='" + od1date + "' and userorder.orderdate<='" + od2date+"'";
                                    searctxt_8 += "开始日期：" + od1date.ToString() + ",结束日期：" + od2date.ToString();
                                }
                                 if (Request.QueryString["phostateid"] != null && Request.QueryString["phostateid"] != "" && Request.QueryString["phostateid"] != "1000")
                                {
                                    int state = TypeParse.DbObjToInt(Request.QueryString["phostateid"], 0);
                                    conditionstr_8 += " and userorder.orderstate=" + state;
                                    if (state == 0)
                                    {
                                        searctxt_8 += "进行中订单";
                                    }
                                    if (state == 10)
                                    {
                                        searctxt_8 += "已完成订单";
                                    }
                                    if (state == 44)
                                    {
                                        searctxt_8 += "待处理订单";
                                    }
                                }
                                 if (Request.QueryString["phodIid"] != null && Request.QueryString["phodIid"] != "" && Request.QueryString["phodIid"] != "0")
                                {
                                    int odIid = TypeParse.DbObjToInt(Request.QueryString["phodIid"], 0);
                                    conditionstr_8 += " and userorder.deliveryIid=" + odIid;
                                    categoryinfo citem = category.getdeliveryIinfo(odIid);
                                    searctxt_8 += "大区：" + citem.deliveryI;
                                }
                                 if (Request.QueryString["phodIIid"] != null && Request.QueryString["phodIIid"] != "" && Request.QueryString["phodIIid"] != "0")
                                {
                                    int odIIid = TypeParse.DbObjToInt(Request.QueryString["phodIIid"], 0);
                                    conditionstr_8 += " and userorder.deliveryIIid=" + odIIid;
                                    categoryinfo citem = category.getdeliveryIIinfo(odIIid);
                                    searctxt_8 += "小区：" + citem.deliveryII;
                                }


                                List<orderinfo> polist = order.getphlist(conditionstr_8);
                                dysb.Append(" <h2>配货总量：(" + searctxt_8 + ")</h2>");
                                dysb.Append(" <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td align=\"center\">产品编号</td><td align=\"center\">产品名称</td> <td align=\"center\">产品图片</td><td align=\"center\">配货数量</td></tr>");
                                foreach (orderinfo item in polist)
                                {
                                    string template = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td align=\"center\">{0}</td><td align=\"center\" class=\"oimg\"><img src=\"/Files/Product/{1}\" /></td><td align=\"center\">{2}</td><td align=\"center\"><span class=\"fb\">{3}</span></td></tr>";
                                    dysb.AppendFormat(template, item.productcode, item.productimg, item.productname, item.tjbuynum);
                                }
                                dysb.Append("</table>");                              

                                dyHTML = dysb.ToString();                               
                                break;

                            //根据订单号搜索
                            case "4":
                                int page_4 = 1;
                                if (Request.QueryString["page"] != null)
                                {
                                    page_4 = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                }
                                pageinfo pdata_4 = new pageinfo();
                                pdata_4.curpageindex = page_4;
                                pdata_4.pagesize = 100000;
                                string ordernumber = "";
                                if (Request.QueryString["ordernumber"] != null)
                                {
                                    ordernumber =HttpUtility.UrlDecode(Request.QueryString["ordernumber"].ToString());
                                }

                                pdata_4.where = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid and a.ordernumber='" + ordernumber + "'";
                                pdata_4.recordcount = order.getcountbycondition("userorder.ordernumber='" + ordernumber + "'");
                                pdata_4.tablename = "userorder a,deliveryI c,deliveryII d";
                                pdata_4.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                pdata_4.sorttype = 2;
                                pdata_4.primarykey = "orderid";
                                pdata_4.totalpagecount = (pdata_4.recordcount % pdata_4.pagesize == 0 ? pdata_4.recordcount / pdata_4.pagesize : pdata_4.recordcount / pdata_4.pagesize + 1);
                                if (pdata_4.totalpagecount == 0)
                                {
                                    pdata_4.totalpagecount = 1;
                                }

                                List<orderinfo> list_4 = order.getorderlist(pdata_4);
                                StringBuilder sb_4 = new StringBuilder();
                                sb_4.Append(" <h2>订单编号：（" + ordernumber + "）查询订单结果</h2>");
                                foreach (orderinfo item in list_4)
                                {
                                    string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{6}&nbsp;&nbsp;小区:{7}&nbsp;&nbsp;订单状态：{8}<span class=\"fr\"><a href=\"javascript:editorder('{9}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{10}</td><td colspan=\"2\" align=\"center\">产品总额：￥{11}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{12}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                    sb_4.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderstatestr, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                    List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                    for (int k = 0; k < plist.Count; k++)
                                    {
                                        string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                        sb_4.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                    }

                                }
                                sb_4.Append("</table>");
                                dyHTML = sb_4.ToString();
                                break;

                            //根据订单号搜索
                            case "5":
                                int page_5 = 1;
                                if (Request.QueryString["page"] != null)
                                {
                                    page_5 = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                                }
                                pageinfo pdata_5 = new pageinfo();
                                pdata_5.curpageindex = page_5;
                                pdata_5.pagesize = 100000;
                                string contact = "";
                                if (Request.QueryString["contact"] != null)
                                {
                                    contact = HttpUtility.UrlDecode(Request.QueryString["contact"].ToString());
                                }

                                pdata_5.where = "a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid and a.contact like '%" + contact + "%'";
                                pdata_5.recordcount = order.getcountbycondition("userorder.ordernumber like '%" + contact + "%'");
                                pdata_5.tablename = "userorder a,deliveryI c,deliveryII d";
                                pdata_5.fieldlist = "a.orderid,a.orderstate,a.ordernumber,a.orderdate,a.deliverydate,a.allmoney,a.paymoney,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII";
                                pdata_5.sorttype = 2;
                                pdata_5.primarykey = "orderid";
                                pdata_5.totalpagecount = (pdata_5.recordcount % pdata_5.pagesize == 0 ? pdata_5.recordcount / pdata_5.pagesize : pdata_5.recordcount / pdata_5.pagesize + 1);
                                if (pdata_5.totalpagecount == 0)
                                {
                                    pdata_5.totalpagecount = 1;
                                }

                                List<orderinfo> list_5 = order.getorderlist(pdata_5);
                                StringBuilder sb_5 = new StringBuilder();
                                sb_5.Append(" <h2>收货人：（" + contact + "）查询订单结果</h2>");
                                foreach (orderinfo item in list_5)
                                {
                                    string template = " <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"otb\"><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\"><span class=\"fb\">订单编号：{0}</span>&nbsp;&nbsp;下单日期：{1}&nbsp;&nbsp;送货日期：{2}</td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"6\" style=\"padding-left: 10px;\">收货人：{3}&nbsp;&nbsp;手机号码：{4}&nbsp;&nbsp;固定电话:{5}&nbsp;&nbsp;大区:{6}&nbsp;&nbsp;小区:{7}&nbsp;&nbsp;订单状态：{8}<span class=\"fr\"><a href=\"javascript:editorder('{9}')\" class=\"cb mr5\">编辑</a></span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td colspan=\"3\" style=\"padding-left: 10px;\">地址：{10}</td><td colspan=\"2\" align=\"center\">产品总额：￥{11}元</td><td align=\"center\">应付总额：<span class=\"fb red\">￥{12}元</span></td></tr><tr style=\"height: 30px; line-height: 30px; background-color:#efefef\"><td style=\"padding-left: 10px;\">序号</td><td align=\"center\">产品图片</td><td align=\"center\">产品名称</td><td align=\"center\">购买数量</td><td align=\"center\">产品单价 </td><td align=\"center\">小计</td></tr> ";
                                    sb_5.AppendFormat(template, item.ordernumber, item.orderdate, item.deliverydate.ToString("yyyy-MM-dd"), item.contact, item.mobile, item.tel, item.deliveryI, item.deliveryII, item.orderstatestr, item.orderid, item.address, item.allmoney.ToString("f2"), item.paymoney.ToString("f2"));
                                    List<orderinfo> plist = order.getcartlistbyordernumber(item.ordernumber);
                                    for (int k = 0; k < plist.Count; k++)
                                    {
                                        string ptemplate = "<tr style=\"height: 30px; line-height: 30px; background-color:#fff\"><td style=\"padding-left: 10px;\">{0}</td><td align=\"center\" class=\"oimg\"><a href=\"/PInfo/{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a></td><td align=\"center\">{3}</td><td align=\"center\">{4}</td><td align=\"center\">{5}</td><td align=\"center\">{6}</td></tr>";
                                        sb_5.AppendFormat(ptemplate, k + 1, plist[k].productid, plist[k].productimg, plist[k].productname, plist[k].buynum, plist[k].vipprice.ToString("f2"), (plist[k].vipprice * plist[k].buynum).ToString("f2"));
                                    }

                                }
                                sb_5.Append("</table>");
                                dyHTML = sb_5.ToString();
                                break;

                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Response.Redirect("/Log");
                }
               
            }

        }
    }
}