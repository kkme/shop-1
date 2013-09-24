<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="TuanFruit.Login.UserLogin" %>

<%@ Register Src="/Shared/top.ascx" TagPrefix="UCTop" TagName="TopUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCFooter" TagName="FooterUC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="keywords" content="上海网上超市,在线购物,送货上门,有机食品,田园时蔬,新鲜水果,肉类,海鲜,安心乳品,干点饮品,面包在线订购,有机婴儿产品,精选美酒美,容护肤,大厨熟食,晚餐" />
    <meta name="description" content="致力于为您和您的家人提供最优质的有机纯天然产品。我们的产品包括水果、蔬菜、奶制品、肉类、鱼类、有机蛋和新鲜面包，以及各种各样您所能想象得到的新鲜食品。甚至还有一些个人护理用品，所有这一切，现在只需轻按鼠标，所有晚上需要准备的食材都可送货上门。" />
    <title>团水果网会员登录系统</title>
    <link href="/Styles/main.css" type="text/css" rel="Stylesheet" />
    <script src="/Scripts/login.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/comm.js" language="javascript" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="mainC">
            <div class="mainbg">
                <%var relurl = ""; if (Request.QueryString["relurl"] != null) { relurl = Request.QueryString["relurl"].ToString(); }; %>
                <UCTop:TopUC ID="mytop" runat="server"></UCTop:TopUC>
                <div id="loginmain">
                    <div id="loginmain-left">
                        <%=indexzjHTML%>
                    </div>
                    <div id="loginmain-right">
                        <div id="loginarea">
                            <div id="loginarea-header">
                                <div class="loginarea-header-l" id="loginarea-header-r" onclick="changeloginitem(2)">
                                    会员号登录</div>
                                <div class="loginarea-header-r" id="loginarea-header-l" onclick="changeloginitem(1)">
                                    邮箱号登录</div>
                                <div class="clear">
                                </div>
                            </div>
                            <div id="loginarea-main">
                                <%var ran = new Random(); var rnum = ran.Next(1, 10); %>
                                <div class="loginarea-main1" id="loginarea-main2">
                                    <table>
                                        <tr>
                                            <td style="width: 70px">
                                                会员名
                                            </td>
                                            <td>
                                                <input name="username" id="username" maxlength="23" type="text" style="width: 200px;
                                                    height: 25px; line-height: 25px; border: solid 1px #cacaca" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                密&nbsp;&nbsp;码
                                            </td>
                                            <td>
                                                <input name="usernamepwd" id="usernamepwd" type="password" maxlength="23" style="width: 200px;
                                                    height: 25px; line-height: 25px; border: solid 1px #cacaca" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                验证码
                                            </td>
                                            <td>
                                                <input id="validator2" type="text" maxlength="10" style="width: 100px; height: 26px;
                                                    line-height: 26px; border: solid 1px #cacaca" />&nbsp;&nbsp;<label id="validatorimg2"
                                                        style="padding-top: 10px"><img src="/WebHelper/Validator.aspx?vnum=5&rnum=<%=rnum%>"
                                                            alt="点击获取新验证码" style="cursor: pointer" onclick="refreshValidator2()" /></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <input type="checkbox" id="remember1" />&nbsp;&nbsp;两周内免登录
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <input type="button" value="" onclick="login2()" style="background: url(/Images/login.jpg) no-repeat 0 0;
                                                    border: 0; width: 88px; height: 28px; cursor: pointer;" />&nbsp;&nbsp;<a href="/Reg" class="tn cblue">注册新用户</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="loginarea-main2" id="loginarea-main1">
                                    <input type="hidden" value="<%=relurl %>" id="relurl" />
                                    <table>
                                        <tr>
                                            <td style="width: 70px">
                                                邮箱名
                                            </td>
                                            <td>
                                                <input name="email" id="email" maxlength="50" type="text" style="width: 200px; height: 25px;
                                                    line-height: 25px; border: solid 1px #cacaca" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                密&nbsp;&nbsp;码
                                            </td>
                                            <td>
                                                <input name="emailpwd" id="emailpwd" maxlength="23" type="password" style="width: 200px;
                                                    height: 25px; line-height: 25px; border: solid 1px #cacaca" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                验证码
                                            </td>
                                            <td>
                                                <input id="validator1" type="text" maxlength="10" style="width: 100px; height: 26px;
                                                    line-height: 26px; border: solid 1px #cacaca" />&nbsp;&nbsp;<label id="validatorimg1"><img
                                                        src="/WebHelper/Validator.aspx?vnum=5&rnum=<%=rnum%>" alt="点击获取新验证码" style="cursor: pointer"
                                                        onclick="refreshValidator1()" /></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <input type="checkbox" id="remember2" />&nbsp;&nbsp;两周内免登录
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <input type="button" value="" onclick="login1()" style="background: url(/Images/login.jpg) no-repeat 0 0;
                                                    border: 0; width: 88px; height: 28px; cursor: pointer;" />&nbsp;&nbsp;<a href="/Reg" class="tn cblue">注册新用户</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <UCFooter:FooterUC ID="myfooteruc" runat="server" />
            </div>
        </div>
    </div>
      <span id="boxs"></span>
    </form>
</body>
</html>
