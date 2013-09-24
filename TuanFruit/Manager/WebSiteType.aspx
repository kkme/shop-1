<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="WebSiteType.aspx.cs" Inherits="TuanFruit.Manager.WebSiteType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
 <p>
        <span></span>你当前位置：网站管理 - 网站内容类别管理</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
        style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
        <tr>
            <td width="40%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>类型ID</span></div>
            </td>
            <td width="40%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>内容类型</span></div>
            </td>
            <td width="20%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>操作</span></div>
            </td>
        </tr>
        <%=websitetypeHTML%>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    <span>内容类型</span></div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    类型名称&nbsp;<input name="wtname" id="wtname" type="text" style="border: solid 1px #cacaca;
                        width: 120px; height: 20px; line-height: 20px;" />&nbsp;&nbsp;<input type="button"
                            onclick="addwebsitetype()" value="添加" class="btn" /></div>
            </td>
        </tr>
    </table>
    <div id="editimagestype">
     <div class="tempclose">
            <a href="#" onclick="HideMsg()" title="关闭">× </a>
        </div>
        <div class="fccontent">
          类型名称&nbsp;<input id="editwtname" type="text" style="border: solid 1px #cacaca; width: 120px; height: 20px; line-height: 20px;" />&nbsp;<input type="button" value="修改" onclick="editwebsitetype()" class="btn" /><input type="hidden" id="editwtid" /></div>
    </div>
     <span id="boxs"></span>  
</asp:Content>
