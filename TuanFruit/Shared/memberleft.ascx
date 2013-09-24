<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="memberleft.ascx.cs" Inherits="TuanFruit.Shared.memberleft" %>
<div class="memberleft">
    <div class="mt-left">
        会员管理平台</div>
    <div class="mc-left" align="center">
        <table width="100%" border="0">
            <tr>
                <td colspan="2" align="center">
                    <img src="/Files/HeaderImg/<%=headerimgHTML %>" alt="头像" width="70px" height="70px" />
                </td>
            </tr>
            <tr>
                <td width="40%" align="right" valign="middle" style="height:18px; line-height:18px; padding-top:10px;">
                    会员名：
                </td>
                <td width="60%" align="left" valign="middle" style="height:18px; line-height:18px;padding-top:10px;">
                     <%=accountHTML%>
                </td>
            </tr>
            <tr>
                <td align="right" valign="middle" style="height:18px; line-height:18px;">
                    等级：
                </td>
                <td align="left" valign="middle"  style="height:18px; line-height:18px;">
                    <%=atHTML %>
                </td>
            </tr>
        </table>
    </div>
    <div class="hy-left01" id="l1" onclick="itemselect(1)" style="cursor: pointer">
        <span class="hy-left01_icon"></span>基本资料</div>
    <div class="hy-left mb5" id="l1content">
        <ul>
            <li><a href="/UIndex" class="hy-left_icon">个人资料</a></li>
            <li><a href="/UHeaderImg" class="hy-left_icon">头像管理</a></li>
            <li><a href="/UEditPwd" class="hy-left_icon">修改密码</a></li>
        </ul>
    </div>

     <div class="hy-left01" id="l2" onclick="itemselect(2)" style="cursor: pointer">
        <span class="hy-left01_icon"></span>收货地址</div>
    <div class="hy-left mb5" id="l2content">
        <ul>
            <li><a href="/Address" class="hy-left_icon">收货地址</a></li>                       
        </ul>
    </div>

     <div class="hy-left01" id="l3" onclick="itemselect(3)" style="cursor: pointer">
        <span class="hy-left01_icon"></span>我的购物车</div>
    <div class="hy-left mb5" id="l3content">
        <ul>
            <li><a href="/OrderIndex" class="hy-left_icon" target="_blank">我的购物车</a></li>                  
        </ul>
    </div>

     <div class="hy-left01" id="l4" onclick="itemselect(4)" style="cursor: pointer">
        <span class="hy-left01_icon"></span>我的订单</div>
    <div class="hy-left mb5" id="l4content">
        <ul>
            <li><a href="/OList/0" class="hy-left_icon">进行中订单</a></li>   
            <li><a href="/OList/10" class="hy-left_icon">已完成订单</a></li>  
            <li><a href="/OList/44" class="hy-left_icon">待处理订单</a></li>             
        </ul>
    </div>

    
     <div class="hy-left01" id="memberquit"  style="cursor: pointer">
        <span class="hy-left01_icon"></span><a href="/Error/userunlogin.aspx">安全退出</a></div>   
</div>
