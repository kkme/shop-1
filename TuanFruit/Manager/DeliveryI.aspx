<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="DeliveryI.aspx.cs" Inherits="TuanFruit.Manager.DeliveryI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
        style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
        <tr>
            <td width="40%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>配送地址ID</span></div>
            </td>
            <td width="40%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>配送地址</span></div>
            </td>
            <td width="20%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>操作</span></div>
            </td>
        </tr>
        <%=deliveryHTML%>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    <span>配送地址</span></div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                   配送地址&nbsp;<input name="dIname" id="dIname" type="text" style="border: solid 1px #cacaca;
                        width: 120px; height: 20px; line-height: 20px;" />&nbsp;&nbsp;<input type="button"
                            onclick="adddeliveryI()" value="添加" class="btn" /></div>
            </td>
        </tr>
    </table>
    <div id="editnewstype">
     <div class="tempclose">
            <a href="#" onclick="HideMsg()" title="关闭">× </a>
        </div>
        <div class="fccontent">
          配送地址&nbsp;<input id="editdIname" type="text" style="border: solid 1px #cacaca; width: 120px; height: 20px; line-height: 20px;" />&nbsp;<input type="button" value="修改" onclick="editdeliveryI()" class="btn" /><input type="hidden" id="editdIid" /></div>
    </div>
     <span id="boxs"></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightURL" runat="server">
<p>
        <span></span>你当前位置：产品管理 - 配送地址</p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
