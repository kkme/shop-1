<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="TuanFruit.Product.ProductList" %>

<%@ Register Src="../Shared/top.ascx" TagPrefix="UCTop" TagName="TopUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCFooter" TagName="FooterUC" %>
<%@ Register Src="/Shared/pleft.ascx" TagPrefix="UCPLeft" TagName="PLeftUC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>水果、进口水果、有机食品、绿色食品，有机蔬菜、网络配送商城</title>
    <meta name="Keywords" content="水果，进口水果，国产水果，进口水果批发" />
    <meta name="Description" content="水果，进口水果，国产水果，进口水果批发" />
    <link href="/Styles/main.css" type="text/css" rel="Stylesheet" />
    <link href="../Styles/pagecss.css" type="text/css" rel="Stylesheet" />
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
                                <li><a href="/Default">首页</a></li><li>&gt;</li><li><a href="/PList">产品列表</a></li><li>
                                    &gt;</li><li><a href=""><%=ptypeHTML %></a></li></ul>
                        </div>
                        <div class="product_licontent">
                            <%--<div class="productlistli">
                                <a href="" class="plistimg">
                                    <img src="/Images/Organic_Black_Pi_5046fd4117767_200x150.jpg" /></a> <a href="" class="plisttitle">
                                        有机黑毛猪：带皮五花肉</a> <a href="" class="plistsite">
                                        规格:500g</a>  <a href="" class="plistprice"><span class="pricecss1">￥200</span><span
                                            class="pricecss2">￥80</span></a>
                            </div>--%>
                            <%=productlistHTML%>
                        </div>
                        <div class="digg2">
                            <%=pageHTML%>
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
