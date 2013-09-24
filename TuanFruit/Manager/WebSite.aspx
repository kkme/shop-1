<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="WebSite.aspx.cs" Inherits="TuanFruit.Manager.WebSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
 <p>
        <span></span>你当前位置：网站管理 - 网站内容管理</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
        style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
        <tr>
            <td height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>内容ID</span></div>
            </td>
            <td height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>内容类型</span></div>
            </td>
            <td height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>操作</span></div>
            </td>
        </tr>
        <%=websitelistHTML%>
    </table>
    <div class="digg">
        <%=websitepageHTML %>
    </div>   

    <script charset="utf-8" src="/kindeditor/kindeditor.js" type="text/javascript"></script>
    <script charset="utf-8" src="/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#editor_id', {
                resizeType: 2,
                uploadJson: '/kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: false,
                resizeMode: 0,
                width: '700px',
                resizeType: 1,
                items: ['source', 'undo', 'redo', 'fontname', 'fontsize', 'forecolor', 'hilitecolor', 'bold', 'justifyleft', 'justifycenter', 'justifyright', 'image', 'flash', 'media', 'insertfile', 'baidumap', 'pagebreak', 'textcolor', 'bgcolor']
            });
            K('input[name=addwebsite]').click(function (e) {
                var wsc = editor.html();
                addwebsite(wsc);
            });
        });        
    </script>

    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    内容类型</div>
            </td>
            <td width="80%" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <%=websitetypeHTML%>
                </div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="10px" bgcolor="cadee8">
                <div align="left">
                    内容详情</div>
            </td>
            <td width="80%" height="10px" bgcolor="e9f2f7">
                <div align="left">
                </div>
            </td>
        </tr>
        <tr>
            <td width="750px" height="520" bgcolor="cadee8" colspan="2">
                <div align="left">
                    <textarea name="websitecontent" id="editor_id" rows="3" cols="3" style="width: 750px; height: 500px;"></textarea></div>
            </td>
        </tr>
        <tr>
            <td width="20%" height="30" bgcolor="cadee8">
                <div align="left">
                    <input type="button" name="addwebsite" value="添加内容" /></div>
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
