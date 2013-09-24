<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Member.Master" AutoEventWireup="true" CodeBehind="HeaderImg.aspx.cs" Inherits="TuanFruit.Member.HeaderImg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="/Scripts/user.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/comm.js" language="javascript" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="memberright">       
       <div class="mt01">
            上传图像</div>
        <div class="mc">
            <div class="hy_table04 mt10" align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="88%" height="25" align="left">
                            设置我的新头像,请选择一个新照片进行上传编辑。
                        </td>
                    </tr>
                    <tr>
                        <td width="88%" height="25" align="left">
                            <div id="preview_fake">
                                <img id="preview" onload="onPreviewLoad(this)" src="/Files/HeaderImg/<%= headerimgHTML %>" width="80"
                                    height="80" alt="" />
                                <img id="preview_size_fake" alt="" /><input type="hidden" runat="server" id="oimgname" value="" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="88%" height="25" align="left">
                            <input id="headerimg" type="file" runat="server" onchange="onUploadImgChange(this)" />                            
                            <asp:Button runat="server" CssClass="font_14_w" Text="上传头像" OnClick="EditHeaderImg" /><label id="imgnote" runat="server"></label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="left">
                            提示：图片格式为jpg、gif，建议宽度200像素、高度200像素。<br />
                            头像保存后，您可能需要刷新一下本页面(按F5键)，才能查看最新的头像效果。
                        </td>
                    </tr>
                </table>
                <input type="hidden" name="oldheaderimg" value=" " />
            </div>
        </div>
    </div>
     <span id="boxs"></span>
</asp:Content>
