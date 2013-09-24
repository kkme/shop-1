<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="left.ascx.cs" Inherits="TuanFruit.Views.Shared.left" %>
<div id="manager_left">
    <div class="sys" style="cursor: pointer" onclick="itemselect(1)">
        <img src="/Images/arrBig1.gif" id="sysimg1" width="11" height="11" alt="" />
        账号管理</div>
    <div id="leftMenu1" class="leftMenu">
        <ul>
          <li><a href="/Manager/Index.aspx"><span></span> 系统管理员</a></li>  
           <li><a href="/Manager/AccountsType.aspx"><span></span> 账号类型</a></li>  
           <li><a href="/Manager/UserList.aspx"><span></span> 会员列表</a></li>       
        </ul>
    </div>
    <div class="sys" style="cursor: pointer" onclick="itemselect(2)">
        <img src="/Images/arrBig1.gif" id="sysimg2" width="11" height="11" alt="" />
        网站管理</div>
    <div id="leftMenu2" class="leftMenu">
        <ul>
            <li><a href="/Manager/WebSiteType.aspx"><span></span> 内容类别</a></li>           
            <li><a href="/Manager/WebSite.aspx"><span></span> 网站内容</a></li>
            <li><a href="/Manager/ImagesType.aspx"><span></span> 图片类型</a></li>
            <li><a href="/Manager/WebImages.aspx"><span></span> 网站图片</a></li>
        </ul>
    </div>
     <div class="sys" style="cursor: pointer" onclick="itemselect(3)">
        <img src="/Images/arrBig1.gif" id="sysimg3" width="11" height="11" alt="" />
        新闻管理</div>
    <div id="leftMenu3" class="leftMenu">
        <ul>           
            <li><a href="/Manager/NewsType.aspx"><span></span> 新闻类别</a></li>   
            <li><a href="/Manager/AddNews.aspx"><span></span> 新闻发布</a></li>   
            <li><a href="/Manager/NewsList.aspx"><span></span> 新闻列表</a></li>            
        </ul>
    </div>
    <div class="sys" style="cursor: pointer" onclick="itemselect(4)">
        <img src="/Images/arrBig1.gif" id="sysimg4" width="11" height="11" alt="" />
        产品管理</div>
    <div id="leftMenu4" class="leftMenu">
        <ul>           
            <li><a href="/Manager/BigCategory.aspx"><span></span> 产品大类</a></li>
            <li><a href="/Manager/SmallCategory.aspx"><span></span> 产品小类</a></li>  
            <li><a href="/Manager/TJType.aspx"><span></span> 推荐类型</a></li>  
            <li><a href="/Manager/Place.aspx"><span></span> 产品产地</a></li>            
            <li><a href="/Manager/AddProduct.aspx"><span></span> 产品发布</a></li>
            <li><a href="/Manager/ProductList.aspx"><span></span> 产品列表</a></li>
        </ul>
    </div>
     <div class="sys" style="cursor: pointer" onclick="itemselect(5)">
        <img src="/Images/arrBig1.gif" id="sysimg5" width="11" height="11" alt="" />
        订单管理</div>
    <div id="leftMenu5" class="leftMenu">
        <ul>           
            <li><a href="/OL" target="_blank"><span></span> 订单管理</a></li>          
        </ul>
    </div>
    
</div>