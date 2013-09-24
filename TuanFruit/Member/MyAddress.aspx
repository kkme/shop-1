<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Member.Master" AutoEventWireup="true"
    CodeBehind="MyAddress.aspx.cs" Inherits="TuanFruit.Member.MyAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/user.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/comm.js" language="javascript" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="memberright">
        <div class="memberright">
            <div class="mt01">
                送货地址</div>
            <div class="mc">
                <div class="hy_table01 mt10">
                    <div class="hy_table01_bg-f3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr style="height: 30px; line-height: 30px; background-color:#efefef">
                                <td width="5%" style="padding-left: 10px;">
                                    编号
                                </td>
                                <td width="10%" align="center">
                                    收货人
                                </td>
                                <td width="12%" align="center">
                                    电话
                                </td>
                                <td width="12%" align="center">
                                    手机
                                </td>
                                <td width="31%" align="center">
                                    联系地址
                                </td>
                                <td width="10%" align="center">
                                    默认地址
                                </td>
                                <td width="20%" align="center">
                                    操作
                                </td>
                            </tr>
                            <%=AddressHTML%>
                        </table>
                    </div>
                </div>
            </div>
            <div class="mt01 mt15">
                添加配送地址</div>
            <div class="mc">
                <div class="hy_table04 mt10">
                    <label id="lbladdressnote" runat="server" style="margin: 10px 0 10px 10px; float:left; font-size: 14px;
                        color: Red;">
                    </label>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12%" height="25" align="right" class="font_14_blue">
                                收货人姓名：
                            </td>
                            <td width="88%" height="25" align="left">
                                <input id="txtcontact" type="text" runat="server" style="width: 200px; height: 22px;
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
                                配送大区：
                            </td>
                            <td height="25" align="left">
                                <asp:DropDownList ID="ddldeliveryIid" OnTextChanged="banddeliveryII" AutoPostBack="true"
                                    runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" align="right" class="font_14_blue">
                                配送小区：
                            </td>
                            <td height="25" align="left">
                                <asp:DropDownList ID="ddldeliveryIIid" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" align="right" class="font_14_blue">
                                详细地址：
                            </td>
                            <td height="25" align="left">
                                <input id="txtaddress" type="text" runat="server" style="width: 300px; height: 22px;
                                    line-height: 22px; padding-left: 8px; border: solid 1px #ddd" maxlength="50" />
                                &nbsp;&nbsp;格式如：上海市XX区XX弄XX号XX室
                            </td>
                        </tr>                      
                        <tr>
                            <td height="25" align="right" class="font_14_blue">
                                &nbsp;
                            </td>
                            <td height="25" align="left">
                                <asp:Button ID="Button1" runat="server" OnClick="AddAddressInfo" Width="100px" Height="28px"
                                    Text="添加地址" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <span id="boxs"></span>
</asp:Content>
