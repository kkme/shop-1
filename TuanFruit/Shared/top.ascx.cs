using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Morrison.Helper;
using Morrison.Models;

namespace TuanFruit.Views.Shared
{
    public partial class top : System.Web.UI.UserControl
    {
        protected string logoimgHTML;
        protected string topHTML;
        protected string cartHTML;
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

            //头部导航
            if (Request.Cookies["tfuid"] != null)
            {
                string uid = Request.Cookies["tfuid"].Value.ToString();
                userinfo data = user.getuserinfo(uid);
                topHTML = " 您好："+data.accounts+"<a href=\"/UIndex\">管理中心</a><a href=\"Error/userunlogin.aspx\">退出</a><a href=\"/OList\">我的订单</a><a href=\"Javascript:window.external.addFavorite('http://www.tuanfruit.com','团水果网')\">收藏</a>";
            }
            else
            {
                topHTML = " 欢迎您来到团水果商城！<a href=\"/UserLog\">登录</a><a href=\"/Reg\">注册</a><a href=\"Javascript:window.external.addFavorite('http://www.tuanfruit.com','团水果网')\">加入收藏</a>";
            }

            //购物车
            if (Request.Cookies["tfuid"] != null)
            {
                string uid = Request.Cookies["tfuid"].Value.ToString();
                int n = order.getcartcount(uid);
                cartHTML = "<span class=\"index_mycart\"><a href=\"/OrderIndex\" target=\"_blank\" style=\"color:#393939; text-decoration:none;height:25px; line-height:30px;\"><span class=\"cartimg\"></span>我的购物车（<span class=\"red\">" + n + "</span>）</a></span>";
            }
            else
            {
                cartHTML = "<span class=\"index_mycart\"><a href=\"/OrderIndex\" target=\"_blank\" style=\"color:#393939; text-decoration:none;height:25px; line-height:30px;\"><span class=\"cartimg\"></span>我的购物车</a></span>";
            }
        }
    }
}