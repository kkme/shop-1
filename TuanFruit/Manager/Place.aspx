﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="Place.aspx.cs" Inherits="TuanFruit.Manager.Place" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
        style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
        <tr>
            <td width="40%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>产地ID</span></div>
            </td>
            <td width="40%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>产地</span></div>
            </td>
            <td width="20%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>操作</span></div>
            </td>
        </tr>
        <%=placeHTML%>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    <span>产地</span></div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                   产地名称&nbsp;<input name="pname" id="pname" type="text" style="border: solid 1px #cacaca;
                        width: 120px; height: 20px; line-height: 20px;" />&nbsp;&nbsp;<input type="button"
                            onclick="addplace()" value="添加" class="btn" /></div>
            </td>
        </tr>
    </table>
    <div id="editnewstype">
     <div class="tempclose">
            <a href="#" onclick="HideMsg()" title="关闭">× </a>
        </div>
        <div class="fccontent">
          产地名称&nbsp;<input id="editpname" type="text" style="border: solid 1px #cacaca; width: 120px; height: 20px; line-height: 20px;" />&nbsp;<input type="button" value="修改" onclick="editplace()" class="btn" /><input type="hidden" id="editpid" /></div>
    </div>
     <span id="boxs"></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightURL" runat="server">
<p>
        <span></span>你当前位置：产品管理 - 产地管理</p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
