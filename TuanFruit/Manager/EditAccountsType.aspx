<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Manager.Master" AutoEventWireup="true"
    CodeBehind="EditAccountsType.aspx.cs" Inherits="TuanFruit.Manager.EditAccountsType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    账号类型</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input id="accountstype" runat="server" type="text" style="border: solid 1px #cacaca;
                        width: 300px; height: 20px; line-height: 20px; text-align: left;" />
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
                    <input id="atdiscount" runat="server" type="text" style="border: solid 1px #cacaca;
                        width: 80px; height: 20px; line-height: 20px; text-align: center;" />&nbsp;请填写折扣率，如0.90
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    <asp:Button ID="Button1" OnClick="EditAccountsTypeInfo" runat="server" Text="编辑账号类型" /></div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    &nbsp;
                </div>
            </td>
        </tr>
    </table>
    <input type="hidden" runat="server" id="atid" />
    <span id="boxs"></span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightURL" runat="server">
    <p>
        <span></span>你当前位置：账号管理 - 编辑账号类型</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
