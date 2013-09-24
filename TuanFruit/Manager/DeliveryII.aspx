<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="DeliveryII.aspx.cs" Inherits="TuanFruit.Manager.DeliveryII" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
        style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
        <tr>
            <td width="28%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>配送地址II ID</span></div>
            </td>
            <td width="28%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>配送地址II</span></div>
            </td>
             <td width="28%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>所属配送地址</span></div>
            </td>
            <td width="16%" height="25" bgcolor="#B7E895">
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
                   配送地址II&nbsp;<input name="dIIname" id="dIIname" type="text" style="border: solid 1px #cacaca;
                        width: 120px; height: 20px; line-height: 20px;" />&nbsp;&nbsp;<%=dsHTML%>&nbsp;&nbsp;<input type="button"
                            onclick="adddeliveryII()" value="添加" class="btn" /></div>
            </td>
        </tr>
    </table>
    <div id="editDeliveryII">
     <div class="tempclose">
            <a href="#" onclick="HideMsg()" title="关闭">× </a>
        </div>
        <div class="fccontent">
          配送地址&nbsp;<input id="editdIIname" type="text" style="border: solid 1px #cacaca; width: 120px; height: 20px; line-height: 20px;" />&nbsp;&nbsp;<%=edsHTML%>&nbsp;&nbsp;<input type="button" value="修改" onclick="editdeliveryII()" class="btn" /><input type="hidden" id="editdIIid" /></div>
    </div>
     <span id="boxs"></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightURL" runat="server">
<p>
        <span></span>你当前位置：产品管理 - 配送地址</p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
