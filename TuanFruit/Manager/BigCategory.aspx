<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="BigCategory.aspx.cs" Inherits="TuanFruit.Manager.BigCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
        style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
        <tr>
            <td width="35%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>分类图片</span></div>
            </td>
            <td width="35%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>分类名称</span></div>
            </td>
            <td width="30%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>操作</span></div>
            </td>
        </tr>
        <%=bigcategorylistHTML%>
    </table>
    
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    大分类图片</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="imgfile" id="imgfile" runat="server" type="file" /><label id="imgnote" runat="server"></label>
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    大分类名称</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="bigcategoryname" id="bigcategoryname" runat="server" type="text" style="border: solid 1px #cacaca; width: 300px;
                        height: 20px; line-height: 20px; text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                   <asp:Button OnClick="AddBigCategory" runat="server" Text="添加大目录" /></div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    &nbsp;
                </div>
            </td>
        </tr>
    </table>   
     <span id="boxs"></span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightURL" runat="server">
<p>
        <span></span>你当前位置：产品管理 - 产品大分类</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
