<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="EditSmallCategory.aspx.cs" Inherits="TuanFruit.Manager.EditSmallCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
 <p>
        <span></span>你当前位置：产品管理 - 产品小类别编辑</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="hstyle">
        编辑小产品类别</h3>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    产品大分类</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                   <asp:DropDownList ID="bcID" runat="server"></asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    产品小分类</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="smallcategory" id="smallcategory" runat="server" type="text" 
                        style="border: solid 1px #cacaca; width: 300px; height: 20px; line-height: 20px;
                        text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left"><asp:Button runat="server" OnClick="EditSmallCategoryInfo" Text="编辑小类" />
                    </div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    &nbsp;
                </div>
            </td>
        </tr>
    </table>
    <input type="hidden" name="smallcategoryid" id="smallcategoryid" runat="server"/>   
</asp:Content>
