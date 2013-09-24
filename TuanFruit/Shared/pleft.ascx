<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pleft.ascx.cs" Inherits="TuanFruit.Shared.pleft" %>
<div class="productleft">
    <div class="productcategory">
        <div class="productcategory_header">
            产品分类</div>
        <div class="productcategory_content">
            <%-- <h3>
                <span class="bcimg"></span>进口水果</h3>
            <ul>
                <li><span class="plist_ponit"></span><a href="">奇异果</a></li>
                <li><span class="plist_ponit"></span><a href="">奇异果</a></li>
                <li><span class="plist_ponit"></span><a href="">奇异果</a></li>
                <li><span class="plist_ponit"></span><a href="">奇异果</a></li>
                <li><span class="plist_ponit"></span><a href="">奇异果</a></li>
            </ul>--%>
            <%=categorysbHTML %>
        </div>
    </div>
    <div class="leftadvimg">
        <%-- <a href="">
            <img src="../Images/240X175shushi-CN1.jpg" alt="" /></a> <a href="">
                <img src="../Images/240X175shushi-CN1.jpg" alt="" /></a>--%>
        <%=img2HTML %>
    </div>
    <div class="viewhistory">
        <div class="productcategory_header">
            浏览记录</div>
        <div class="productcategory_content">
            <%--   <div class="view_li">
            <a href="" target="_blank" class="simg">
                <img src="../Images/240X175shushi-CN1.jpg" alt="" /></a><ul>
                    <li><a href="" title="" class="tl" target="_blank"></a></li>
                    <li><a href="" class="tl" target="_blank">￥：<span class="red">元</span></a></li><li><a
                        href="" class="tl" target="_blank">类别：</a></li></ul>
        </div>--%>
            <%=vhHTML%></div>
    </div>
</div>
