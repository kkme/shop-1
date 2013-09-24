using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace TuanFruit
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }

        //URL重写
        void RegisterRoutes(RouteCollection routes)
        {
            //网站首页
            routes.MapPageRoute("Default",
                "Default",
                "~/Index.aspx", false,
                new RouteValueDictionary { });
            //订单确认首页
            routes.MapPageRoute("OrderIndex",
                "OrderIndex",
                "~/Order/Index.aspx", false,
                new RouteValueDictionary { });
            //订单结果页面
            routes.MapPageRoute("OrderResult",
                "OrderResult",
                "~/Order/Result.aspx", false,
                new RouteValueDictionary { });
            //管理员登录
            routes.MapPageRoute("loginurl",
                "Log/{adminid}/{adminname}",
                "~/Login/AdminLogin.aspx", false,
                new RouteValueDictionary { { "adminid", "0" }, { "adminname", "admin" } });
            //会员登录
            routes.MapPageRoute("userlogin",
                "UserLog",
                "~/Login/UserLogin.aspx", false,
                new RouteValueDictionary { });
            //会员注册
            routes.MapPageRoute("userreg",
                "Reg/{userid}/{username}",
                "~/Login/Register.aspx", false,
                new RouteValueDictionary { { "userid", "0" }, { "username", "user" } });
            //会员管理首页
            routes.MapPageRoute("MemberIndex",
                "UIndex/{userid}/{username}",
                "~/Member/Index.aspx", false,
                new RouteValueDictionary { { "userid", "0" }, { "username", "user" } });
            //会员密码修改
            routes.MapPageRoute("UEditPwd",
                "UEditPwd/{userid}/{username}",
                "~/Member/UserPWD.aspx", false,
                new RouteValueDictionary { { "userid", "0" }, { "username", "user" } });
            //会员头像修改
            routes.MapPageRoute("UEditHeaderImg",
                "UHeaderImg/{userid}/{username}",
                "~/Member/HeaderImg.aspx", false,
                new RouteValueDictionary { { "userid", "0" }, { "username", "user" } });
            //会员收货地址
            routes.MapPageRoute("Address",
                "Address/{userid}/{username}",
                "~/Member/MyAddress.aspx", false,
                new RouteValueDictionary { { "userid", "0" }, { "username", "user" } });
            //编辑会员收货地址
            routes.MapPageRoute("EditAddress",
                "EditAddress/{addressid}/{address}",
                "~/Member/MyAddressEdit.aspx", false,
                new RouteValueDictionary { { "addressid", "0" }, { "address", "" } });
            //产品列表
            routes.MapPageRoute("PList",
              "PList/{bcid}/{scid}/{placeid}/{price}/{pname}",
              "~/Product/ProductList.aspx", false,
              new RouteValueDictionary { { "bcid", "0" }, { "scid", "0" }, { "placeid", "0" }, { "price", "0" }, { "pname", "" } });
            //产品详情
            routes.MapPageRoute("PInfo",
              "PInfo/{productid}.html",
              "~/Product/ProductInf.aspx", false,
              new RouteValueDictionary { { "productid", "0" }});
            ////资讯列表
            //routes.MapPageRoute("newslisturl",
            //  "NewsShow/{category}/{name}",
            //  "~/News/Index.aspx", false,
            //  new RouteValueDictionary { { "category", "book" }, { "name", "aspnet" } });
            //资讯详情
            routes.MapPageRoute("NInfo",
              "NInfo/{newsid}.html",
              "~/News/Index.aspx", false,
              new RouteValueDictionary { { "newsid", "0" } });
            //网站内容
            routes.MapPageRoute("contenturl",
              "WS/{contenttype}.html",
              "~/WebContent/Index.aspx", false,
              new RouteValueDictionary { { "contenttype", "1" }, { "name", "aspnet" } });

            //会员订单
            routes.MapPageRoute("OList",
              "OList/{orderstate}",
              "~/Member/OrderList.aspx", false,
              new RouteValueDictionary { { "orderstate", "0" } });

            //管理员订单管理
            routes.MapPageRoute("OL",
                "OL",
                "~/Manager/OrderList.aspx", false,
                new RouteValueDictionary { });
        }

    }
}
