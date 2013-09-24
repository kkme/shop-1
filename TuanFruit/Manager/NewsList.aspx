<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="TuanFruit.Manager.NewsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
<p>
        <span></span>你当前位置：新闻管理 - 新闻列表</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <div id="newslist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
            style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
            <tr>
                <td width="20%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>添加时间</span></div>
                </td>
                <td width="30%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>资讯标题</span></div>
                </td>
                <td width="18%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>资讯来源</span></div>
                </td>
                <td width="10%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>资讯作者</span></div>
                </td>
                <td width="10%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>排名等级</span></div>
                </td>
                <td width="12%" height="25" bgcolor="#B7E895">
                    <div align="center">
                        <span>操作</span></div>
                </td>
            </tr>
            <%=newslistHTML%>
        </table>
    </div>
    <div class="digg">
        <%=pageHTML %>
    </div>
    <span id="boxs"></span>  
</asp:Content>
