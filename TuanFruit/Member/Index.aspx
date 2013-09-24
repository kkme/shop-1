<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Member.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="TuanFruit.Member.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/user.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/comm.js" language="javascript" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="memberright">
        <%var uinfo = UInfoDATA as Morrison.Models.userinfo; %>
        <div class="mt01">
            基本资料</div>
        <div class="mc">
            <div class="hy_table01_pad5 mt10">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="25" align="right" class="font_14_blue">
                            Email：
                        </td>
                        <td height="25" align="left">
                            <%=uinfo.email%><input type="hidden" runat="server" id="userid" />
                        </td>
                    </tr>
                    <tr>
                        <td width="12%" height="25" align="right" class="font_14_blue">
                            会员名：
                        </td>
                        <td width="88%" height="25" align="left">
                            <input name="txtaccounts" id="txtaccounts" runat="server" type="text" onblur="checkaccounts()"
                                maxlength="30" style="width: 200px; height: 22px; line-height: 22px; padding-left: 8px;
                                border: solid 1px #ddd" /><label id="accountsnote" runat="server"></label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mt01 mt10">
            详细资料</div>
        <div class="mc">
            <div class="hy_table04 mt10">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12%" height="25" align="right" class="font_14_blue">
                            真实姓名：
                        </td>
                        <td width="88%" height="25" align="left">
                            <input id="txttruename" type="text" runat="server" style="width: 200px; height: 22px;
                                line-height: 22px; padding-left: 8px; border: solid 1px #ddd" maxlength="30" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" class="font_14_blue">
                            手机号码：
                        </td>
                        <td height="25" align="left">
                            <input id="txtmobile" type="text" runat="server" style="width: 200px; height: 22px;
                                line-height: 22px; padding-left: 8px; border: solid 1px #ddd" maxlength="30" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" class="font_14_blue">
                            固定电话：
                        </td>
                        <td height="25" align="left">
                            <input id="txttel" type="text" runat="server" style="width: 200px; height: 22px;
                                line-height: 22px; padding-left: 8px; border: solid 1px #ddd" maxlength="30" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" class="font_14_blue">
                            QQ：
                        </td>
                        <td height="25" align="left">
                            <input id="txtqq" type="text" runat="server" style="width: 200px; height: 22px; line-height: 22px;
                                padding-left: 8px; border: solid 1px #ddd" maxlength="30" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" class="font_14_blue">
                            所在公司：
                        </td>
                        <td height="25" align="left">
                            <input id="txtcompany" type="text" runat="server" style="width: 200px; height: 22px;
                                line-height: 22px; padding-left: 8px; border: solid 1px #ddd" maxlength="30" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" class="font_14_blue">
                            联系地址：
                        </td>
                        <td height="25" align="left">
                            <input id="txtaddress" type="text" runat="server" style="width: 300px; height: 22px;
                                line-height: 22px; padding-left: 8px; border: solid 1px #ddd" maxlength="50" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" class="font_14_blue">
                            &nbsp;
                        </td>
                        <td height="25" align="left">
                            <asp:Button runat="server" OnClick="EditUserInfo" Width="100px" Height="28px" Text="更改资料" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
     <span id="boxs"></span>
</asp:Content>
