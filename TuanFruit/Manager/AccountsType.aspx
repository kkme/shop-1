<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="AccountsType.aspx.cs" Inherits="TuanFruit.Manager.AccountsType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
        style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
        <tr>
            <td width="35%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>账号类型</span></div>
            </td>
            <td width="35%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>账号折扣</span></div>
            </td>
            <td width="30%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>操作</span></div>
            </td>
        </tr>
        <%=atHTML%>
    </table>
    
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    账号类型</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                     <input id="accountstype" runat="server" type="text" style="border: solid 1px #cacaca; width: 300px;
                        height: 20px; line-height: 20px; text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    账号折扣</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input id="atdiscount" runat="server" type="text" style="border: solid 1px #cacaca; width: 80px;
                        height: 20px; line-height: 20px; text-align: center;" />&nbsp;请填写折扣率，如0.90
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                  &nbsp; 
                  </div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                  <asp:Button ID="Button1" OnClick="AddAccountsTypeInfo" runat="server" Text="添加账号类型" />
                </div>
            </td>
        </tr>
    </table>   
     <span id="boxs"></span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightURL" runat="server">
<p>
        <span></span>你当前位置：账号管理 - 账号类型</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>

