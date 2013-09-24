<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="TuanFruit.Manager.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
<p>
        <span></span>你当前位置：新闻管理 - 新闻列表</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
   <%=usertjHTML%><input id="uinfo" type="text" style="width: 180px; height: 20px;
                    border: solid 1px #cacaca" />&nbsp;<input type="button" onclick="searchbyuserinfo()"
                        value="搜索" class="btn" />&nbsp;Email或账号&nbsp;<%=atHTML%>&nbsp;<input type="button" onclick="searchbyaccountstype()"
                        value="搜索" class="btn" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <div id="newslist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
            style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
            <tr>
                <td width="14%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>注册时间</span></div>
                </td>
                <td width="16%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>注册邮箱</span></div>
                </td>
                <td width="10%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>会员账号</span></div>
                </td>
                 <td width="7%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>真实姓名</span></div>
                </td>
                 <td width="9%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>固定电话</span></div>
                </td>
                <td width="9%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>手机号码</span></div>
                </td>
                <td width="18%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>所在公司</span></div>
                </td>
                <td width="7%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>账号类型</span></div>
                </td>
                <td width="7%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>操作</span></div>
                </td>
            </tr>
            <%=userlistHTML%>
        </table>
    </div>
    <div class="digg">
        <%=pageHTML %>
    </div>
     <div id="editorderdiv">
            <div class="tempclose">
                <a href="#" onclick="HideMsg()" title="关闭">关闭</a>
            </div>
            <div class="fccontent" id="fccontent">
            </div>
        </div>
    <span id="boxs"></span>  
</asp:Content>

