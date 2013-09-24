<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top.ascx.cs" Inherits="TuanFruit.Views.Shared.top" %>
<div id="top">
<script src="/Scripts/search.js" language="javascript" type="text/javascript"></script>
    <div id="topleft">
        <%=logoimgHTML%></div>
    <div id="topright">
        <div class="welcomearea">
          <%=topHTML %>
        </div>
        <div class="searcharea">
           <input type="text" class="searchinput" id="searchpname" value="请输入商品名称" onclick="clicksearch()" onblur="blursearch()"/><a href="javascript:searchproduct()" class="searcha">搜索</a>
        </div>
    </div>
    <div id="banner">
       <div class="banner_l"></div>
       <div class="banner_url">
        <a href="/Default">首页</a><a href="/PList">商品列表</a><a href="/PList/1">进口水果</a><a href="/PList/2">进口食品</a><a href="/PList/3">国产水果</a><a href="/PList/4">国产食品</a><a href="/PList/5">节日礼包</a><%=cartHTML%>
       </div>
       <div class="banner_r"></div>
    </div>
</div>
