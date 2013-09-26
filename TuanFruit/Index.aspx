<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TuanFruit.Index" %>

<%@ Register Src="/Shared/top.ascx" TagPrefix="UCTop" TagName="TopUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCFooter" TagName="FooterUC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>水果、进口水果、有机食品、绿色食品，有机蔬菜、网络配送商城</title>
    <meta name="Keywords" content="水果，进口水果，国产水果，进口水果批发" />
    <meta name="Description" content="水果，进口水果，国产水果，进口水果批发" />
    <link href="/Styles/main.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="/Scripts/jquery_002.js"></script>
    <script type="text/javascript" src="/Scripts/slideswitch.js"></script>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <!--[if IE 6]><script type="text/javascript" src="/js/lib/iepngfix_tilebg.js"></script><![endif]-->
    <!--[if IE]><script src="/js/lib/html5.js"></script><![endif]-->
    <script type="text/javascript">
		$(document).ready(function() { 
			$("a#inline").fancybox({
			'hideOnContentClick': true,
			});
		});
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="mainC">
            <div class="mainbg">
                <UCTop:TopUC ID="mytop" runat="server"></UCTop:TopUC>
                <div id="HD">
                    <div id="mainvisual">
                        <ul id="mvPanel">
                            <%=hd1HTML%>
                        </ul>
                        <ul id="mvThumbnail">
                            <%=hd2HTML%>
                        </ul>
                    </div>
                </div>
                <div id="Notice">
                    <div class="noticeli">
                       <%-- <a href=""><span class="n_point"></span>水果减肥酸酸甜甜瘦全身甜瘦全身</a> --%>
                       <%=ggHTML %>
                    </div>
                    <div class="categoryli">
                        <ul>
                            <li><span class="categoryli_t">目录</span><%--<a href="">新西兰水果</a>--%><%=mlHTML %></li>
                            <li><span class="categoryli_t">产地</span><%=cdHTML %></li>
                            <li><span class="categoryli_t">价格</span><a href="/PList/0/0/0/1">0-50元</a><a href="/PList/0/0/0/2">50-100元</a><a
                                href="/PList/0/0/0/3">100-200元</a><a href="/PList/0/0/0/4">200-500元</a><a href="/PList/0/0/0/5">500元以上</a></li>
                        </ul>
                    </div>
                </div>
                <div id="advimgli">
                  <%--  <a href="">
                        <img src="/Images/cn_delivery_time.jpg" /></a> --%>
                        <%=img4HTML %>
                </div>
               <%-- <div class="indexproductli">
                <h2>推荐商品</h2>
                   <div class="productli">
                      <a href="" class="pimg"><img src="/Images/Organic_Black_Pi_5046fd4117767_200x150.jpg" /></a>
                      <a href="" class="ptitle">有机黑毛猪：带皮五花肉</a>
                      <a href="" class="pprice"><span class="pricecss1">￥200</span><span class="pricecss2">￥80</span></a>
                   </div>        
                </div>--%>
                <%=pHTML%>
               
                <UCFooter:FooterUC ID="myfooteruc" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
