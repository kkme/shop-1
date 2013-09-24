<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Manager.Master" AutoEventWireup="true"
    CodeBehind="EditBigCategory.aspx.cs" Inherits="TuanFruit.Manager.EditBigCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <script type="text/javascript" src="/Scripts/imgreview.js"></script>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="15%" height="30" bgcolor="#cadee8">
                <div align="left">
                    <span>新闻图片</span></div>
            </td>
            <td width="85%" height="30" bgcolor="#e9f2f7">
                <div align="left">
                    <span>
                        <input name="newsimg" type="file" id="imgfile" runat="server" onchange="onUploadImgChange(this)" /></span><label id="imgnote" runat="server"></label></div>
            </td>
        </tr>
        <tr>
            <td width="15%" height="130" bgcolor="#cadee8">
                <div align="left">
                </div>
            </td>
            <td width="85%" height="130" bgcolor="#e9f2f7">
                <div id="preview_fake">
                    <img id="preview" onload="onPreviewLoad(this)" src="/Files/WebImages/<%=bigcategoryimgHTML %>" alt="" />
                    <img id="preview_size_fake" alt="" /><input type="hidden" runat="server" id="oimgname" />
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
                    <input name="bigcategoryname" id="bigcategoryname" type="text"  runat="server"
                        style="border: solid 1px #cacaca; width: 300px; height: 20px; line-height: 20px;
                        text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    <asp:Button runat="server" Text="修改大目录" OnClick="EditBigcategory" /></div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    &nbsp;
                </div>
            </td>
        </tr>
    </table>
    <input type="hidden" name="bigcategoryid" id="bigcategoryid"  runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightURL" runat="server">
    <p>
        <span></span>你当前位置：产品管理 - 产品大分类编辑</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
