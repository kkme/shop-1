<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="EditAdminPwd.aspx.cs" Inherits="TuanFruit.Manager.EditAdminPwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
  <p>
        <span></span>你当前位置：账号管理 - 系统管理员密码修改</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <%var adminid = Request.QueryString["adminid"].ToString(); %>
 <script type="text/javascript" src="/Scripts/admin.js"></script>
    <table border="0" cellpadding="0" cellspacing="1">
        <tr>
            <td height="30" bgcolor="white" colspan="2" style="padding-left: 5px; font-weight: bold;">
                <div align="left">
                    系统管理员密码修改
                </div>
            </td>
        </tr>
        <tr>
            <td width="150px" height="30" bgcolor="#cadee8" style="padding-left: 10px;">
                <div align="left">
                    <span>系统账号</span><input type="hidden" name="adminid" id="adminid" value="<%=adminid %>" /></div>
            </td>
            <td width="500px" height="30" bgcolor="#e9f2f7" style="padding-left: 10px;">
                <div align="left">
                    <span>
                        <input type="text" name="adminname" id="adminname" style="width: 200px; height: 20px;
                            line-height: 20px; border: solid 1px gray" value="<%=adminnameHTML %>"
                            readonly="readonly" /></span>
                    <label id="namenote">
                    </label>
                </div>
            </td>
        </tr>
        <tr>
            <td width="150px" height="30" bgcolor="#cadee8" style="padding-left: 10px;">
                <div align="left">
                    <span>登录密码</span></div>
            </td>
            <td width="500px" height="30" bgcolor="#e9f2f7" style="padding-left: 10px;">
                <div align="left">
                    <span>
                        <input type="password" name="pwd" onblur="checkpwd()" id="pwd" style="width: 200px;
                            height: 20px; line-height: 20px; border: solid 1px gray" /></span>
                    <label id="pwdnote">
                    </label>
                </div>
            </td>
        </tr>
        <tr>
            <td width="150px" height="30" bgcolor="#cadee8" style="padding-left: 10px;">
                <div align="left">
                    <span>重复密码</span></div>
            </td>
            <td width="500px" height="30" bgcolor="#e9f2f7" style="padding-left: 10px;">
                <div align="left">
                    <span>
                        <input type="password" name="repwd" onblur="checkrepwd()" id="repwd" style="width: 200px;
                            height: 20px; line-height: 20px; border: solid 1px gray" /></span>
                    <label id="repwdnote">
                    </label>
                </div>
            </td>
        </tr>
        <tr>
            <td height="50" bgcolor="white" colspan="2" style="padding: 0">
                <div align="left">
                    <input type="button" value="提交" onclick="resetpwd()" style="width: 60px; height: 20px;" />&nbsp;&nbsp;&nbsp;&nbsp;<input
                        type="reset" value="重填" style="width: 60px; height: 20px;" />
                </div>
            </td>
        </tr>
    </table>
     <span id="boxs"></span>   
</asp:Content>
