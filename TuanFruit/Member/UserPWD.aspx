<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Member.Master" AutoEventWireup="true"
    CodeBehind="UserPWD.aspx.cs" Inherits="TuanFruit.Member.UserPWD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/user.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/comm.js" language="javascript" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="memberright">
        <div class="mt01">
            修改密码</div>
        <div class="mc">
            <div class="hy_table04 mt10" align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" height="25" align="left">
                            设置我的新密码。<input type="hidden" id="userid" value="<%=uidstr%>" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px; height: 25px" align="right" class="font_14_blue">
                            原始密码：
                        </td>
                        <td style="width: 100px; height: 25px" align="left">
                            <input id="txtoldpwd" onblur="checkoldeditpwd()" type="password" value="" size="15"
                                maxlength="15" style="border: solid 1px #efefef; width: 120px; height: 22px;
                                line-height: 22px" />
                        </td>
                        <td style="width: 180px; height: 25px" align="left" id="oldpwdnote">
                            请输入原始密码
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px; height: 25px" align="right" class="font_14_blue">
                            新置密码：
                        </td>
                        <td style="width: 100px; height: 25px" align="left">
                            <input name="txtnewpwd" id="txtnewpwd" type="password" onblur="checkeditnewpwd()"
                                size="15" maxlength="15" style="border: solid 1px #efefef; width: 120px; height: 22px;
                                line-height: 22px" />
                        </td>
                        <td style="width: 180px; height: 25px" align="left" id="newpwdnote">
                            请用5-15位字符或数字的密码
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px; height: 25px" align="right" class="font_14_blue">
                            确认新密码：
                        </td>
                        <td style="width: 100px; height: 25px" align="left">
                            <input name="txtrenewpwd" id="txtrenewpwd" type="password" onblur="checkreeditpwd()"
                                size="15" maxlength="15" style="border: solid 1px #efefef; width: 120px; height: 22px;
                                line-height: 22px" />
                        </td>
                        <td style="width: 180px; height: 25px" align="left" id="renewpwdnote">
                            请重新输入新密码
                        </td>
                    </tr>
                    <tr style="height: 40px; line-height: 40px">
                        <td style="width: 90px; padding-top: 10px;" align="right" class="font_14_blue">
                            &nbsp;
                        </td>
                        <td style="width: 100px; padding-top: 10px;" align="left" colspan="2">
                            <input type="button" onclick="editoldpwd()" value="修改密码" style="width: 100px; height: 28px;
                                cursor: pointer;" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <span id="boxs"></span>
</asp:Content>
