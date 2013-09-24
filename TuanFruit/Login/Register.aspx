<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TuanFruit.Login.Register" %>
<%@ Register Src="/Shared/top.ascx" TagPrefix="UCTop" TagName="TopUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCFooter" TagName="FooterUC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>团水果网、会员注册中心</title>
    <link href="/Styles/main.css" type="text/css" rel="Stylesheet" />
    <script src="/Scripts/login.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/comm.js" language="javascript" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="mainC">
            <div class="mainbg">
                <UCTop:TopUC ID="mytop" runat="server"></UCTop:TopUC>               
                <div class="productmain">
                     <div id="regi-banner">
        <div id="regi-banner-c">
            <label>
                <span class="regititle1">填写账户信息</span> <span class="regititle2">以下均为必填</span></label>
        </div>
    </div>
    <div id="regi-content">
    <%var ran = new Random(); var rnum = ran.Next(1, 10); %>
        <div id="regi-content-left" class="fwtl">
            <table cellpadding="0" cellspacing="0" border="0">
                 <tr>
                    <td style="text-align: right; height: 50px; width:100px;">
                        会员账号：
                    </td>
                    <td>
                        <input id="account" name="account" type="text" maxlength="23" onblur="checkaccount()" style="width: 200px; height: 26px; line-height: 26px; border: solid 1px #ddd" />
                    </td>
                    <td style="height:50px">
                          <label id="accountnote"></label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; height: 50px; width:100px;">
                        注册邮箱：
                    </td>
                    <td>
                        <input id="email" name="email" type="text" maxlength="23" onblur="checkemail()" style="width: 200px; height: 26px; line-height: 26px; border: solid 1px #ddd" />
                    </td>
                    <td style="height:50px">
                          <label id="emailnote"></label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; height: 50px;width:100px;">
                        登录密码：
                    </td>
                    <td>
                        <input id="pwd" name="pwd" type="password" maxlength="23" onblur="checkpwd()" style="width: 200px; height: 26px; line-height: 26px; border: solid 1px #ddd" />
                    </td>
                    <td>
                     <label id="pwdnote"></label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; height: 50px;width:100px;">
                        确认密码：
                    </td>
                    <td>
                        <input id="repwd" name="repwd" type="password" maxlength="23" onblur="checkrepwd()" style="width: 200px; height: 26px; line-height: 26px; border: solid 1px #ddd" />
                    </td>
                    <td>
                        <label id="repwdnote"></label>
                    </td>
                </tr>               
                <tr>
                    <td style="text-align: right; height: 50px;width:100px;">
                        验证码：
                    </td>
                    <td>
                        <input id="validator" type="text" maxlength="10" style="width: 100px; height: 26px; line-height: 26px; border: solid 1px #ddd" />&nbsp;&nbsp;<label  id="validatorimg" ><img src="/WebHelper/Validator.aspx?vnum=5&rnum=<%=rnum%>" alt="点击获取新验证码" style="cursor:pointer" onclick="refreshValidator()" /></label>
                    </td>
                    <td>
                         &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; height: 50px;width:100px;">
                        &nbsp;
                    </td>
                    <td>
                         <input type="button" style="background:url(/Images/register.jpg) no-repeat 0 0; width:177px; height:31px; border:0; cursor:pointer" value="" onclick="register()"/>
                        
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; height: 50px;width:100px;">
                        &nbsp;
                    </td>
                    <td class="fwtl">
                        <a href="#">《水果团购网服务条例》</a>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <div id="regi-content-right">
            <div id="regi-content-right-c"> <%=indexzjHTML%>
        </div>
        <div class="clear"></div>
    </div>
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
