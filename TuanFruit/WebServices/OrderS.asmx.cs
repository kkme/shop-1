using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Morrison.Models;
using Morrison.Helper;
using System.Text;

namespace TuanFruit.WebServices
{
    /// <summary>
    /// OrderS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class OrderS : System.Web.Services.WebService
    {

        #region 添加到购物车

        [WebMethod]
        public string addcart(string productid, string userid, string buynum)
        {
            int pid = TypeParse.DbObjToInt(productid, 0);
            int bnum = TypeParse.DbObjToInt(buynum, 1);
            productinfo item = product.getproductinfo(pid);

            bool cz = order.CheckCart(userid, pid);
            if (cz)
            {
                string jstr = "{'productid':'" + productid + "','userid':'" + userid + "','buynum':'" + buynum + "'}";
                return jstr;
            }
            else
            {
                orderinfo data = new orderinfo();
                data.productid = pid;
                data.vipprice = item.vipprice;
                data.userid = userid;
                data.buynum = bnum;
                data.adddate = DateTime.Now;
                bool result = order.AddCart(data);
                if (result)
                {
                    return "t";
                }
                else
                {
                    return "f";
                }
            }
        }

        #endregion

        #region 绑定配送区域二

        [WebMethod]
        public string bindd2select(string did)
        {
            int pid = TypeParse.DbObjToInt(did, 0);

            int intpID = TypeParse.DbObjToInt(did, 0);
            List<categoryinfo> list = category.getdeliveryIIbyID(intpID);
            StringBuilder d1sb = new StringBuilder();
            d1sb.Append("<select id=\"d2select\"  class=\"orderselect\">");
            foreach (categoryinfo item in list)
            {
                string template = "<option value=\"{0}\">{1}</option>";
                d1sb.AppendFormat(template, item.deliveryIIid, item.deliveryII);
            }
            d1sb.Append("</select>");
            string d1selectstr = d1sb.ToString();
            return d1selectstr;
        }

        #endregion

        #region 绑定配送区域二I

        [WebMethod]
        public string bindd2selectI(string did)
        {
            int pid = TypeParse.DbObjToInt(did, 0);

            int intpID = TypeParse.DbObjToInt(did, 0);
            List<categoryinfo> list = category.getdeliveryIIbyID(intpID);
            StringBuilder d1sb = new StringBuilder();
            d1sb.Append("<select id=\"odIIid\"  class=\"orderselect\"><option value=\"0\">不限</option>");
            foreach (categoryinfo item in list)
            {
                string template = "<option value=\"{0}\">{1}</option>";
                d1sb.AppendFormat(template, item.deliveryIIid, item.deliveryII);
            }
            d1sb.Append("</select>");
            string d1selectstr = d1sb.ToString();
            return d1selectstr;
        }

        #endregion

        #region 绑定配送区域二II

        [WebMethod]
        public string bindd2selectII(string did)
        {
            int pid = TypeParse.DbObjToInt(did, 0);

            int intpID = TypeParse.DbObjToInt(did, 0);
            List<categoryinfo> list = category.getdeliveryIIbyID(intpID);
            StringBuilder d1sb = new StringBuilder();
            d1sb.Append("<select id=\"podIIid\"  class=\"orderselect\"><option value=\"0\">不限</option>");
            foreach (categoryinfo item in list)
            {
                string template = "<option value=\"{0}\">{1}</option>";
                d1sb.AppendFormat(template, item.deliveryIIid, item.deliveryII);
            }
            d1sb.Append("</select>");
            string d1selectstr = d1sb.ToString();
            return d1selectstr;
        }

        #endregion

        #region 绑定配送区域二III

        [WebMethod]
        public string bindd2selectIII(string did)
        {
            int pid = TypeParse.DbObjToInt(did, 0);

            int intpID = TypeParse.DbObjToInt(did, 0);
            List<categoryinfo> list = category.getdeliveryIIbyID(intpID);
            StringBuilder d1sb = new StringBuilder();
            d1sb.Append("<select id=\"phodIIid\"  class=\"orderselect\"><option value=\"0\">不限</option>");
            foreach (categoryinfo item in list)
            {
                string template = "<option value=\"{0}\">{1}</option>";
                d1sb.AppendFormat(template, item.deliveryIIid, item.deliveryII);
            }
            d1sb.Append("</select>");
            string d1selectstr = d1sb.ToString();
            return d1selectstr;
        }

        #endregion

        #region 添加送货地址

        [WebMethod]
        public string addaddress(string contact, string userid, string saddress, string tel, string mobile, string p1id, string p2id)
        {
            int d1id = TypeParse.DbObjToInt(p1id, 0);
            int d2id = TypeParse.DbObjToInt(p2id, 0);

            addressinfo item = new addressinfo();
            item.contact = contact;
            item.address = saddress;
            item.tel = tel;
            item.mobile = mobile;
            item.deliveryIid = d1id;
            item.deliveryIIid = d2id;
            item.userid = userid;
            item.isdefault = 1;
            bool t = address.delisdefault();
            bool result = address.addaddress(item);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 绑定送货列表

        [WebMethod]
        public string selectaddress(string userid)
        {            
            List<addressinfo> list = address.getaddressinfobyuid(userid);
            StringBuilder sb = new StringBuilder();
            sb.Append("<h3>收货地址列表 <a href=\"javascript:refresh()\">[关闭]</a> <a href=\"javascript:addnewaddress()\">[添加新地址]</a></h3><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"ptb\"><tr class=\"ptr\"><td width=\"5%\">&nbsp;</td><td width=\"10%\" align=\"center\">联系人</td><td width=\"10%\" align=\"center\">手机号码</td><td width=\"10%\" align=\"center\">固定电话</td><td width=\"10%\" align=\"center\">配送大区</td><td width=\"10%\" align=\"center\">配送小区</td><td width=\"35%\" align=\"center\">详细地址</td><td width=\"10%\" align=\"center\">操作</td></tr>");
            foreach (addressinfo item in list)
            {
                string template = "<tr class=\"addresstr\"><td width=\"5%\" align=\"center\"><input type=\"radio\" name=\"cname\" value=\"{0}\" /></td><td width=\"10%\" align=\"center\">{1}</td><td width=\"10%\" align=\"center\">{2}</td><td width=\"10%\" align=\"center\">{3}</td><td width=\"10%\" align=\"center\">{4}</td><td width=\"10%\" align=\"center\">{5}</td><td width=\"35%\" align=\"center\">{6}</td><td width=\"10%\" align=\"center\"><a href=\"javascript:editaddress('{7}')\">编辑</a></td></tr>";
                sb.AppendFormat(template,item.addressid, item.contact,item.mobile,item.tel,item.deliveryI,item.deliveryII,item.address,item.addressid);
            }
            sb.Append("</table><p><input type=\"button\" value=\"选择地址\" onclick=\"selectindexaddress()\" class=\"orderbtn\" /></p>");
            string str = sb.ToString();
            return str;
        }

        #endregion

        #region 选择默认送货地址

        [WebMethod]
        public string selectindexaddress(string addressid)
        {
            int id=TypeParse.DbObjToInt(addressid,0);
            bool result = address.setisdefault(id);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 添加新的送货地址

        [WebMethod]
        public string addnewaddress()
        {
            //大区下拉菜单
            List<categoryinfo> d1list = category.getdeliveryI();
            string str;
            StringBuilder d1sb = new StringBuilder();
            d1sb.Append("<select id=\"d1select\" class=\"orderselect\"  onchange=\"changed1()\"><option value=\"0\">--请选择--</option>");
            foreach (categoryinfo pitem in d1list)
            {
                string template;

                template = "<option value=\"{0}\">{1}</option>";

                d1sb.AppendFormat(template, pitem.deliveryIid, pitem.deliveryI);
            }
            d1sb.Append("</select>");
            str = " <h3>添加新的收货地址  <a href=\"javascript:refresh()\">[关闭]</a> </h3><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"ordertb\"><tr><td class=\"tdleft\">收 货 人：</td><td><input type=\"text\" id=\"txtcontact\" class=\"ordertxt\" /></td></tr><tr><td class=\"tdleft\">配送大区：</td><td>";
            str += d1sb.ToString();
            str += "</td></tr><tr><td class=\"tdleft\"> 配送小区：</td><td><label id=\"d2selectlabel\"><select id=\"d2select\"  class=\"orderselect\"><option value=\"0\">--请选择--</option></select></label></td></tr><tr><td class=\"tdleft\">详细地址：</td><td><input type=\"text\" id=\"txtaddress\"  class=\"ordertxt w300\" />&nbsp;如:上海市XX区XX路XX弄XX号XX室</td></tr><tr><td class=\"tdleft\">手机号码：</td><td><input type=\"text\" id=\"txtmobile\" class=\"ordertxt\"/></td></tr><tr><td class=\"tdleft\">固定电话：</td><td><input type=\"text\" id=\"txttel\"  class=\"ordertxt\"/></td></tr></table><p><input type=\"button\" value=\"确认地址\" onclick=\"addaddress()\"  class=\"orderbtn\" /></p> ";
            return str;
        }

        #endregion

        #region 编辑送货地址

        [WebMethod]
        public string editaddress(string addressid)
        {
            int id = TypeParse.DbObjToInt(addressid, 0);
            addressinfo data = address.getaddressinfo(id);   

            //大区下拉菜单
            List<categoryinfo> d1list = category.getdeliveryI();
            string str;
            StringBuilder d1sb = new StringBuilder();
            d1sb.Append("<select id=\"d1select\" class=\"orderselect\"  onchange=\"changed1()\">");
            foreach (categoryinfo pitem in d1list)
            {
                string template;

                if (data.deliveryIid == pitem.deliveryIid)
                {
                    template = "<option value=\"{0}\" selected=\"selected\">{1}</option>";
                }
                else
                {
                    template = "<option value=\"{0}\">{1}</option>";
                }

                d1sb.AppendFormat(template, pitem.deliveryIid, pitem.deliveryI);
            }
            d1sb.Append("</select>");

            StringBuilder d2sb = new StringBuilder();
            List<categoryinfo> d2list = category.getdeliveryIIbyID(data.deliveryIid);
            d2sb.Append("<select id=\"d2select\" class=\"orderselect\">");
            foreach (categoryinfo pitem in d2list)
            {
                string template;

                if (data.deliveryIIid == pitem.deliveryIIid)
                {
                    template = "<option value=\"{0}\" selected=\"selected\">{1}</option>";
                }
                else
                {
                    template = "<option value=\"{0}\">{1}</option>";
                }

                d2sb.AppendFormat(template, pitem.deliveryIIid, pitem.deliveryII);
            }
            d2sb.Append("</select>");


            str = " <h3>添加新的收货地址  <a href=\"javascript:refresh()\">[关闭]</a> </h3><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"ordertb\"><tr><td class=\"tdleft\">收 货 人：</td><td><input type=\"text\" id=\"txtcontact\" value=\"{0}\" class=\"ordertxt\" /></td></tr><tr><td class=\"tdleft\">配送大区：</td><td>";
            str += d1sb.ToString();
            str += "</td></tr><tr><td class=\"tdleft\"> 配送小区：</td><td><label id=\"d2selectlabel\">";
            str+=d2sb.ToString();            
            str+="</label></td></tr><tr><td class=\"tdleft\">详细地址：</td><td><input type=\"text\" id=\"txtaddress\" value=\"{1}\"  class=\"ordertxt w300\" />&nbsp;如:上海市XX区XX路XX弄XX号XX室</td></tr><tr><td class=\"tdleft\">手机号码：</td><td><input type=\"text\" id=\"txtmobile\" value=\"{2}\" class=\"ordertxt\"/></td></tr><tr><td class=\"tdleft\">固定电话：</td><td><input type=\"text\" id=\"txttel\" value=\"{3}\" class=\"ordertxt\"/></td></tr></table><p><input type=\"button\" value=\"修改地址\" onclick=\"editaddressinfo('{4}')\"  class=\"orderbtn\" /></p> ";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(str, data.contact, data.address, data.mobile, data.tel,data.addressid);  
            
            return sb.ToString();
        }

        #endregion

        #region 编辑送货地址详情

        [WebMethod]
        public string editaddressinfo(string contact, string userid, string saddress, string tel, string mobile, string p1id, string p2id,string addressid)
        {
            int d1id = TypeParse.DbObjToInt(p1id, 0);
            int d2id = TypeParse.DbObjToInt(p2id, 0);
            int id = TypeParse.DbObjToInt(addressid, 0);

            addressinfo item = new addressinfo();
            item.contact = contact;
            item.address = saddress;
            item.tel = tel;
            item.mobile = mobile;
            item.deliveryIid = d1id;
            item.deliveryIIid = d2id;
            item.userid = userid;
            item.isdefault = 1;
            item.addressid = id;

            bool result = address.editaddress(item);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 绑定购物篮列表

        [WebMethod]
        public string bandcart()
        {
            string uid = "";
            StringBuilder rsb = new StringBuilder();
            if (HttpContext.Current.Request.Cookies["tfuid"] != null)
            {
                string userid = HttpContext.Current.Request.Cookies["tfuid"].Value.ToString();
                uid = userid;
            }
            List<orderinfo> cartlist = order.getcartlist(0, uid);
            StringBuilder sb = new StringBuilder();
            sb.Append("<h3>商品清单<a href=\"/PList\">[继续添加产品到购物车]</a></h3><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"ptb\"><tr class=\"ptr\"><td width=\"10%\">序号</td><td width=\"20%\" align=\"center\">商品图片</td><td width=\"40%\" align=\"center\">商品名称</td><td width=\"12%\" align=\"center\">商品价格</td><td width=\"8%\" align=\"left\">购买数量</td><td width=\"10%\" align=\"center\">操作</td></tr>");
            int ccount = cartlist.Count;
            for (int k = 0; k < ccount; k++)
            {
                string template = "<tr style=\"height: 60px;\"><td align=\"center\">{0}</td><td class=\"buyimg\"><a href=\"/PInfo/{1}.html\"><img src=\"/Files/Product/{2}\" alt=\"\" /></a></td><td><a href=\"/PInfo/{3}.html\" title=\"{4}\">{5}</a></td><td align=\"center\">{6}</td><td align=\"center\"><a href=\"javascript:changecartordernum('{7}','minus')\" class=\"minusbtn1\">&nbsp;</a><input type=\"text\" id=\"buynum\" class=\"numtxt1\" value=\"{8}\" readonly=\"readonly\" /><a href=\"javascript:changecartordernum('{9}','add')\" class=\"addbtn1\">&nbsp;</a></td><td align=\"center\"><a href=\"javascript:delcart('{10}')\">删除</a></td></tr>";

                sb.AppendFormat(template, k + 1, cartlist[k].productid, cartlist[k].productimg, cartlist[k].productid, cartlist[k].productname, cartlist[k].productname, cartlist[k].vipprice, cartlist[k].cartid, cartlist[k].buynum, cartlist[k].cartid, cartlist[k].cartid);
            }
            sb.Append(" </table></div>");   

            string pmoneyHMTL;
            string dmoneyHTML;
            string paymoneyHTML;

            if (ccount > 0)
            {
                userinfo udata = user.getuserinfo(uid);
                decimal udiscount = udata.atdiscount;
                string ac = (udiscount * 10).ToString("F1");
                string atype = udata.accountstype;
                decimal pmoney = order.getallprice(uid);
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
                paymoneyHTML = "0";
            }
           sb.Append("<input type=\"hidden\" id=\"hpmoney\" value=\""+pmoneyHMTL+"\"/><input type=\"hidden\" id=\"hdmoney\" value=\""+dmoneyHTML+"\"/><input type=\"hidden\" id=\"hpaymoney\" value=\""+paymoneyHTML+"\"/>");
           return sb.ToString();
        }

        #endregion

        #region 改变订单数量

        [WebMethod]
        public string changecartordernum(string cartid, string type)
        {
            bool result = order.changecartordernum(cartid, type);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 删除订单产品

        [WebMethod]
        public string delcart(string cartid)
        {
            bool result = order.delcart(cartid);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 生成订单

        [WebMethod]
        public string addorder(string ddate)
        {
            string uid = "";          
            int addressid; 
            if (HttpContext.Current.Request.Cookies["tfuid"] != null)
            {
                string userid = HttpContext.Current.Request.Cookies["tfuid"].Value.ToString();
                uid = userid;
            }
            //是否有默认收货地址
            List<addressinfo> alist = address.getaddressinfobyuid(uid);
            if (alist.Count < 1)
            {
                return "address_f";
            }
            else
            {                
                addressid = alist[0].addressid;
            }

            List<orderinfo> cartlist = order.getcartlist(0, uid);
            int ccount = cartlist.Count;          

            if (ccount > 0)
            {
                userinfo udata = user.getuserinfo(uid);
                decimal udiscount = udata.atdiscount;            
                decimal pmoney = order.getallprice(uid);
                decimal dmoney = pmoney - pmoney * udiscount;
                decimal paymoney = pmoney * udiscount;

                orderinfo odata = new orderinfo();
                odata.userid = uid;
                odata.address = alist[0].address;
                odata.contact = alist[0].contact;
                odata.tel = alist[0].tel;
                odata.mobile = alist[0].mobile;
                odata.deliveryIid = alist[0].deliveryIid;
                odata.deliveryIIid = alist[0].deliveryIIid;
                odata.allmoney = pmoney;
                odata.paymoney = paymoney;
                odata.orderdate = DateTime.Now;
                odata.ordernumber = order.getordernumber(uid);
                odata.orderstate = 0;
                DateTime dt;
                if (DateTime.Now.Hour >= 16)
                {
                   dt = DateTime.Now.AddDays(1);
                }
                else
                {
                    dt = DateTime.Now;
                }                
                odata.deliverydate = TypeParse.DbObjToDateTime(ddate, dt);
                bool r1 = order.addorder(odata);
                if (r1)
                {
                    bool r2 = order.changecartstate(odata.ordernumber, uid);
                    if (r2)
                    {
                        return "t";
                    }
                    else
                    {
                        return "f";
                    }
                }
                else
                {
                    return "f";
                }               
            }
            else
            {
                return "buynum_f";               
            }
          
        }

        #endregion

        #region 绑定修改订单

        [WebMethod]
        public string bandeditorder(string orderid)
        {
            orderinfo odata = order.getorderinfo(orderid);
            string str;

            //大区下拉菜单
            List<categoryinfo> d1list = category.getdeliveryI();            
            StringBuilder d1sb = new StringBuilder();
            d1sb.Append("<select id=\"d1select\" class=\"orderselect\"  onchange=\"changed1()\">");
            foreach (categoryinfo pitem in d1list)
            {
                string template;

                if (odata.deliveryIid == pitem.deliveryIid)
                {
                    template = "<option value=\"{0}\" selected=\"selected\">{1}</option>";
                }
                else
                {
                    template = "<option value=\"{0}\">{1}</option>";
                }

                d1sb.AppendFormat(template, pitem.deliveryIid, pitem.deliveryI);
            }
            d1sb.Append("</select>");

            //小区下拉菜单
            StringBuilder d2sb = new StringBuilder();
            List<categoryinfo> d2list = category.getdeliveryIIbyID(odata.deliveryIid);
            d2sb.Append("<select id=\"d2select\" class=\"orderselect\">");
            foreach (categoryinfo pitem in d2list)
            {
                string template;

                if (odata.deliveryIIid == pitem.deliveryIIid)
                {
                    template = "<option value=\"{0}\" selected=\"selected\">{1}</option>";
                }
                else
                {
                    template = "<option value=\"{0}\">{1}</option>";
                }

                d2sb.AppendFormat(template, pitem.deliveryIIid, pitem.deliveryII);
            }
            d2sb.Append("</select>");

            //送货日期
            string deliverydatestr = "<input type=\"text\" id=\"deliverydate\" onclick=\"WdatePicker({dateFmt:'yyyy-MM-dd'})\" value=\""+odata.deliverydate.ToString("yyyy-MM-dd")+"\" readonly=\"readonly\" style=\"width: 110px; height: 18px; border: solid 1px #cacaca;\" />";

            //订单状态
            string orderstatestr;
            if (odata.orderstate == 0)
            {
                orderstatestr = "<select id=\"orderstate\"><option value=\"0\">进行中</option><option value=\"10\">已完成</option><option value=\"44\">待处理</option></select>";
            }
            else if (odata.orderstate == 10)
            {
                orderstatestr = "<select id=\"orderstate\"><option value=\"0\">进行中</option><option value=\"10\" selected=\"selected\">已完成</option><option value=\"44\">待处理</option></select>";
            }
            else if (odata.orderstate == 44)
            {
                orderstatestr = "<select id=\"orderstate\"><option value=\"0\">进行中</option><option value=\"10\">已完成</option><option value=\"44\"  selected=\"selected\">待处理</option></select>";
            }
            else
            {
                orderstatestr = "<select id=\"orderstate\"><option value=\"0\">进行中</option><option value=\"10\">已完成</option><option value=\"44\">待处理</option></select>";
            }
            str = "<table width=\"100%\" cellpadding=\"0\" cellspace=\"0\" border=\"0\" class=\"editordertb\"><tr><td>收货人</td><td colspan=\"3\">" + odata.contact + "</td></tr><tr><td>详细地址</td><td  colspan=\"3\">" + odata.address + "</td></tr><tr><td>大区</td><td>" + d1sb.ToString() + "</td><td>小区</td><td><label id=\"d2selectlabel\">" + d2sb.ToString() + "</label></td></tr><tr><td>送货时间</td><td colspan=\"3\">" + deliverydatestr + "</td></tr><tr><td>订单状态</td><td colspan=\"3\">" + orderstatestr + "</td></tr><tr><td colspan=\"4\" align=\"right\"><input type=\"button\" onclick=\"editorderinfo('" + odata.orderid + "')\" value=\"修改订单\"/>&nbsp;&nbsp;<input type=\"button\" onclick=\"delorderinfo('" + odata.ordernumber + "')\"  value=\"删除订单\"/></td></tr></table>";
                       
            return str;       
        
        }

        #endregion

        #region 编辑订单详情

        [WebMethod]
        public string editorderinfo(string orderid, string d1, string d2, string deliverydate, string orderstate)
        {
            int d1id = TypeParse.DbObjToInt(d1, 0);
            int d2id = TypeParse.DbObjToInt(d2, 0);           
            int state = TypeParse.DbObjToInt(orderstate, 0);

            orderinfo data = new orderinfo();
            data.deliverydate = TypeParse.DbObjToDateTime(deliverydate, DateTime.Now);
            data.deliveryIid = d1id;
            data.deliveryIIid = d2id;
            data.orderstate = state;
            data.orderid = orderid;

            bool result = order.editorder(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 删除订单详情

        [WebMethod]
        public string delorderinfo(string ordernumber)
        {
            bool result = order.delcartandorder(ordernumber);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion        
    }
}
