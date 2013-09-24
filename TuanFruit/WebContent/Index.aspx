<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TuanFruit.WebContent.Index" %>

<%@ Register Src="/Shared/top.ascx" TagPrefix="UCTop" TagName="TopUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCFooter" TagName="FooterUC" %>
<%@ Register Src="/Shared/pleft.ascx" TagPrefix="UCPLeft" TagName="PLeftUC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="keywords" content="上海网上超市,在线购物,送货上门,有机食品,田园时蔬,新鲜水果,肉类,海鲜,安心乳品,干点饮品,面包在线订购,有机婴儿产品,精选美酒美,容护肤,大厨熟食,晚餐" />
    <meta name="description" content="致力于为您和您的家人提供最优质的有机纯天然产品。我们的产品包括水果、蔬菜、奶制品、肉类、鱼类、有机蛋和新鲜面包，以及各种各样您所能想象得到的新鲜食品。甚至还有一些个人护理用品，所有这一切，现在只需轻按鼠标，所有晚上需要准备的食材都可送货上门。" />
    <title><%=ctitleHTML %></title>
    <link href="/Styles/main.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="mainC">
            <div class="mainbg">
                <UCTop:TopUC ID="mytop" runat="server"></UCTop:TopUC>
                <div class="advimg">
                    <a href="">
                        <img src="/Images/1030x88top-CN.jpg" alt="" /></a></div>
                <div class="productmain">
                    <UCPLeft:PLeftUC ID="mypleftuc" runat="server"></UCPLeft:PLeftUC>
                    <div class="productright">
                        <div class="product_urldh">
                            <ul>
                                <li><a href="/Default">首页</a></li><li>&gt;</li><li><a href="#"><%=ctitleHTML %></a></li></ul>
                        </div>
                        <div id="contentinfo">
                        <div class="contenttop">                 
                           </div>
                           <div class="contentmain">  
                           <%=contentHTML %>               
                           </div>
                           <div class="contentbottom"></div>
                        </div>
                    </div>
                </div>
                <UCFooter:FooterUC ID="myfooteruc" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
