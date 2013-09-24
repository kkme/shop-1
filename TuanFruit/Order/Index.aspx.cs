using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;

namespace TuanFruit.Order
{
    public partial class Index : System.Web.UI.Page
    {
        protected string logoimgHTML;
        protected string addressHTML;
        protected string uidValue;
        protected string deliverydateValue;
        protected string cartlistHTML;
        protected string pmoneyHMTL;
        protected string dmoneyHTML;
        protected string paymoneyHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            //图片绑定
            List<webimagesinfo> webimageslist = webimages.bindwebimages(1, "企业LOGO");
            StringBuilder webimagessb = new StringBuilder();
            foreach (webimagesinfo item in webimageslist)
            {
                string template = "<a href=\"{0}\" target=\"_blank\"><img src=\"/Files/WebImages/{1}\" alt=\"\" target=\"_blank\"/></a>";
                webimagessb.AppendFormat(template, item.imgurl, item.imgname);
            }
            logoimgHTML = webimagessb.ToString();


            if (Request.Cookies["tfuid"] != null)
            {
                string userid = Request.Cookies["tfuid"].Value.ToString();
                uidValue = userid;
                userinfo item = user.getuserinfo(userid);
                List<addressinfo> alist = address.getaddressinfobyuid(userid);
                if (alist.Count < 1)
                {
                    //大区下拉菜单
                    List<categoryinfo> d1list = category.getdeliveryI();
                    StringBuilder d1sb = new StringBuilder();
                    d1sb.Append("<select id=\"d1select\" class=\"orderselect\"  onchange=\"changed1()\"><option value=\"0\">--请选择--</option>");
                    foreach (categoryinfo pitem in d1list)
                    {
                        string template;

                        template = "<option value=\"{0}\">{1}</option>";

                        d1sb.AppendFormat(template, pitem.deliveryIid, pitem.deliveryI);
                    }
                    d1sb.Append("</select>");
                    addressHTML = " <h3>添加收货人信息</h3><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"ordertb\"><tr><td class=\"tdleft\">收 货 人：</td><td><input type=\"text\" id=\"txtcontact\" class=\"ordertxt\" /></td></tr><tr><td class=\"tdleft\">配送大区：</td><td>";
                    addressHTML += d1sb.ToString();
                    addressHTML += "</td></tr><tr><td class=\"tdleft\"> 配送小区：</td><td><label id=\"d2selectlabel\"><select id=\"d2select\"  class=\"orderselect\"><option value=\"0\">--请选择--</option></select></label></td></tr><tr><td class=\"tdleft\">详细地址：</td><td><input type=\"text\" id=\"txtaddress\"  class=\"ordertxt w300\" />&nbsp;如:上海市XX区XX路XX弄XX号XX室</td></tr><tr><td class=\"tdleft\">手机号码：</td><td><input type=\"text\" id=\"txtmobile\" class=\"ordertxt\"/></td></tr><tr><td class=\"tdleft\">固定电话：</td><td><input type=\"text\" id=\"txttel\"  class=\"ordertxt\"/></td></tr></table><p><input type=\"button\" value=\"确认地址\" onclick=\"addaddress()\"  class=\"orderbtn\" /></p> ";
                }
                else
                {
                    addressinfo data = address.getindexaddressinfo(userid);
                    StringBuilder asb = new StringBuilder();
                    string template = " <h3>收货人信息 <a href=\"javascript:selectaddress()\">[修改信息]</a></h3><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"ordertb\"><tr><td class=\"tdleft\">收 货 人：</td><td>{0}</td></tr><tr><td class=\"tdleft\">配送大区：</td><td>{1}</td></tr><tr><td class=\"tdleft\">配送小区：</td><td>{2}</td></tr> <tr><td class=\"tdleft\">详细地址：</td><td>{3}</td></tr><tr><td class=\"tdleft\">手机号码： </td><td>{4}</td></tr><tr><td class=\"tdleft\"> 固定电话： </td><td>{5}</td></tr></table>";
                    asb.AppendFormat(template, data.contact, data.deliveryI, data.deliveryII, data.address, data.mobile, data.tel);
                    addressHTML = asb.ToString();
                }

                if (DateTime.Now.Hour >= 16)
                {
                    deliverydateValue = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                }
                else
                {
                    deliverydateValue = DateTime.Now.ToString("yyyy-MM-dd");
                }

                List<orderinfo> cartlist = order.getcartlist(0, userid);
                int ccount = cartlist.Count;
                StringBuilder csb = new StringBuilder();
                for (int k = 0; k < ccount; k++)
                {
                    string template = "<tr style=\"height: 60px;\"><td align=\"center\">{0}</td><td class=\"buyimg\"><a href=\"/PInfo/{1}.html\"><img src=\"/Files/Product/{2}\" alt=\"\" /></a></td><td><a href=\"/PInfo/{3}.html\" title=\"{4}\">{5}</a></td><td align=\"center\">{6}</td><td align=\"center\"><a href=\"javascript:changecartordernum('{7}','minus')\" class=\"minusbtn1\">&nbsp;</a><input type=\"text\" id=\"buynum\" class=\"numtxt1\" value=\"{8}\" readonly=\"readonly\" /><a href=\"javascript:changecartordernum('{9}','add')\" class=\"addbtn1\">&nbsp;</a></td><td align=\"center\"><a href=\"javascript:delcart('{10}')\">删除</a></td></tr>";

                    csb.AppendFormat(template, k + 1, cartlist[k].productid, cartlist[k].productimg, cartlist[k].productid, cartlist[k].productname, cartlist[k].productname, cartlist[k].vipprice, cartlist[k].cartid, cartlist[k].buynum, cartlist[k].cartid, cartlist[k].cartid);
                }
                cartlistHTML =csb.ToString();

                if (ccount > 0)
                {
                    userinfo udata = user.getuserinfo(userid);
                    decimal udiscount = udata.atdiscount;
                    string ac = (udiscount * 10).ToString("F1");
                    string atype = udata.accountstype;
                    decimal pmoney = order.getallprice(userid);
                    decimal dmoney = pmoney - pmoney * udiscount;
                    decimal paymoney = pmoney * udiscount;
                    pmoneyHMTL = pmoney.ToString("F2");
                    dmoneyHTML = atype + ac + "折，优惠：￥" + dmoney.ToString("F2");
                    paymoneyHTML = paymoney.ToString("F2");
                }
                else
                {
                    pmoneyHMTL = "0";
                    dmoneyHTML = "优惠：0";
                    paymoneyHTML ="0";
                }
                 

            }
            else
            {
                Response.Redirect("/UserLog?relurl=/PList");
            }

        }
    }
}