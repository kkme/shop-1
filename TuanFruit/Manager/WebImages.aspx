<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true"
    CodeBehind="WebImages.aspx.cs" Inherits="TuanFruit.Manager.WebImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
    <p>
        <span></span>你当前位置：网站管理 - 网站图片管理</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="/Scripts/imgreview.js"></script>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
        style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
        <tr>
            <td width="20%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>图片</span></div>
            </td>
            <td width="25%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>图片导航</span></div>
            </td>
            <td width="15%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>图片说明</span></div>
            </td>
            <td width="15%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>图片类型</span></div>
            </td>
            <td width="15%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>操作</span></div>
            </td>
        </tr>
        <%=imageslistHTML%>
    </table>
    <div class="digg">
        <%=pageHTML %>
    </div>  
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="160px" style="padding-right: 10px" height="30" bgcolor="cadee8">
                <div align="right">
                    产品图片</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="imgfile" id="imgfile" runat="server" type="file" onchange="onUploadImgChange(this)" /><label id="imgnote" runat="server"></label>
                </div>
            </td>
        </tr>
          <tr>
            <td width="160px" height="130" bgcolor="#cadee8">
                <div align="left">
                </div>
            </td>
            <td width="610px" height="130" bgcolor="#e9f2f7">
                <div id="preview_fake">
                    <img id="preview" onload="onPreviewLoad(this)" src="/Images/noimg.jpg" alt="" />
                    <img id="preview_size_fake" alt="" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="right">
                    网站导航</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="imgurl" id="imgurl" runat="server" type="text" style="border: solid 1px #cacaca; width: 300px;
                        height: 20px; line-height: 20px; text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="right">
                    图片介绍</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="imginfo" id="imginfo" runat="server" type="text" style="border: solid 1px #cacaca; width: 300px;
                        height: 20px; line-height: 20px; text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="right">
                    所属公司</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="imgcor" id="imgcor" runat="server" type="text" style="border: solid 1px #cacaca; width: 300px;
                        height: 20px; line-height: 20px; text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="right">
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
                    <asp:Button Text="添加图片" runat="server" OnClick="AddWebImages" /></div>
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
