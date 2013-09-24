<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true"
    CodeBehind="EditWebImage.aspx.cs" Inherits="TuanFruit.Manager.EditWebImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
    <p>
        <span></span>你当前位置：网站管理 - 网站图片编辑</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="/Scripts/imgreview.js"></script>
    <% var webimagesinfo = webimagesinfoDATA as Morrison.Models.webimagesinfo; %>
    <%var wiid = Request.QueryString["wiid"].ToString(); %>
    <h3 class="hstyle">
        编辑网站广告图片</h3>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    上传图片</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="imgname" id="imgname" type="file" onchange="onUploadImgChange(this)" runat="server" /><label id="imgnote" runat="server"></label>
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                </div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="oimgname" id="oimgname" runat="server" type="hidden" />
                    <div id="preview_fake">
                        <img id="preview" onload="onPreviewLoad(this)" src="/Files/WebImages/<%=webimagesinfo.imgname %>"
                            alt="" />
                        <img id="preview_size_fake" alt="" />
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    网站导航</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="imgurl" id="imgurl" runat="server" type="text"
                        style="border: solid 1px #cacaca; width: 300px; height: 20px; line-height: 20px;
                        text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    图片介绍</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="imginfo" id="imginfo" runat="server" type="text" 
                        style="border: solid 1px #cacaca; width: 300px; height: 20px; line-height: 20px;
                        text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    所属公司</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="imgcor" id="imgcor" runat="server" type="text" 
                        style="border: solid 1px #cacaca; width: 300px; height: 20px; line-height: 20px;
                        text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    图片类型</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <asp:DropDownList ID="itID" runat="server"></asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                <asp:Button Text="修改图片" runat="server" OnClick="EditWebImages" />
                    </div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    &nbsp;
                </div>
            </td>
        </tr>
    </table>
    <input type="hidden" name="wiid" id="swiid" runat="server"  />
     <span id="boxs"></span>
</asp:Content>
