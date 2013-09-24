<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="EditNews.aspx.cs" Inherits="TuanFruit.Manager.EditNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
<p>
        <span></span>你当前位置：新闻管理 - 编辑新闻</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <% var newsinfo = newsinfoDATA as Morrison.Models.newsinfo; %>
     <script type="text/javascript" src="/Scripts/imgreview.js"></script>
    <script charset="utf-8" src="/kindeditor/kindeditor.js" type="text/javascript"></script>
    <script charset="utf-8" src="/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#MainContent_editor_id', {
                resizeType: 2,
                uploadJson: '/kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: false,
                resizeMode: 0,
                width: '700px',
                resizeType: 1,
                items: ['source', 'undo', 'redo', 'fontname', 'fontsize', 'forecolor', 'hilitecolor', 'bold', 'justifyleft', 'justifycenter', 'justifyright', 'image', 'flash', 'media', 'insertfile', 'baidumap', 'pagebreak', 'textcolor', 'bgcolor']
            });
        });
    </script>   
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="15%" height="30" bgcolor="#cadee8">
                <div align="left">
                    <span>新闻名称</span></div>
            </td>
            <td width="85%" height="30" bgcolor="#e9f2f7">
                <div align="left">
                    <span>
                        <input type="text" name="newstitle" id="newstitle" runat="server"
                            style="width: 400px; height: 20px; line-height: 20px; border: solid 1px #cacaca" /></span><input
                                id="snewsid" type="hidden" runat="server" /></div>
            </td>
        </tr>
        <tr>
            <td width="15%" height="30" bgcolor="#cadee8">
                <div align="left">
                    <span>新闻图片</span></div>
            </td>
            <td width="85%" height="30" bgcolor="#e9f2f7">
                <div align="left">
                    <span>
                        <input name="newsimg" id="newsimg" runat="server" type="file" onchange="onUploadImgChange(this)" /></span><label id="imgnote" runat="server"></label></div>
            </td>
        </tr>
        <tr>
            <td width="15%" height="130" bgcolor="#cadee8">
                <div align="left">
                </div>
            </td>
            <td width="85%" height="130" bgcolor="#e9f2f7">
                <div id="preview_fake">
                    <img id="preview" src="/Files/NewsImages/<%=newsinfo.newsimg %>" onload="onPreviewLoad(this)"
                        alt="" />
                    <img id="preview_size_fake" alt="" />
                    <input type="hidden" runat="server" id="oldnewsimg" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="15%" height="30" bgcolor="#cadee8">
                <div align="left">
                    <span>新闻类别</span></div>
            </td>
            <td width="85%" height="30" bgcolor="#e9f2f7">
                <div align="left">
                    <asp:DropDownList ID="ntid" runat="server"></asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td width="15%" height="30" bgcolor="#cadee8">
                <div align="left">
                    <span>新闻来源</span></div>
            </td>
            <td width="85%" height="30" bgcolor="#e9f2f7">
                <div align="left">
                    <span>
                        <input name="newsfrom" id="newsfrom" runat="server" type="text"
                            style="width: 150px; height: 20px; line-height: 20px; border: solid 1px #cacaca" /></span></div>
            </td>
        </tr>
        <tr>
            <td width="15%" height="30" bgcolor="#cadee8">
                <div align="left">
                    <span>新闻作者</span></div>
            </td>
            <td width="85%" height="30" bgcolor="#e9f2f7">
                <div align="left">
                    <span>
                        <input type="text" name="newswriter" id="newswriter" runat="server"
                            style="width: 150px; height: 20px; line-height: 20px; border: solid 1px #cacaca" /></span></div>
            </td>
        </tr>
        <tr>
            <td width="15%" height="30" bgcolor="#cadee8">
                <div align="left">
                    <span>排行等级</span></div>
            </td>
            <td width="85%" height="30" bgcolor="#e9f2f7">
                <div align="left">
                    <asp:DropDownList ID="istop" runat="server"></asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td width="15%" height="70" bgcolor="#cadee8">
                <div align="left">
                    <span>新闻简介</span></div>
            </td>
            <td width="85%" height="70" bgcolor="#e9f2f7">
                <div align="left">
                    <span>
                        <textarea name="newsnote" id="newsnote" rows="5" runat="server" cols="4" style="width: 400px; height: 60px;
                            border: solid 1px #cacaca"></textarea></span></div>
            </td>
        </tr>
        <tr>
            <td width="15%" height="410" bgcolor="#cadee8">
                <div align="left">
                    <span>新闻详情</span></div>
            </td>
            <td width="85%" height="410" bgcolor="#e9f2f7">
                <div align="left">
                    <textarea id="editor_id" name="ninfo" runat="server" rows="1" cols="1" style="width: 700px; height: 400px; visibility:hidden;"></textarea>
                </div>
            </td>
        </tr>
        <tr>
            <td height="50" bgcolor="white" colspan="2" style="padding: 0">
                <div align="left">
                <asp:Button Text="修改新闻" runat="server" OnClick="EditNewsInfo" />&nbsp;&nbsp;&nbsp;&nbsp;<input
                        type="reset" value="重填" style="width: 60px; height: 20px;" />
                </div>
            </td>
        </tr>
    </table>     
</asp:Content>
