<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="TuanFruit.Login.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>管理员登录</title>
    <link href="../Styles/layout.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/login.js"></script>
     <script type="text/javascript" src="../Scripts/comm.js"></script>
    <style type="text/css">
    <!--
    body {
	    background-image: url(../Images/loginBg.jpg);
	    font-family:"宋体";
    }
    -->
    </style>
</head>
<body>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <object classid="clsid:52A05F4B-9F0C-4752-BB78-9B6DFD2DE9D5" id="HdwCode" width="0"
        height="0" codebase="http://www.123pk.net/download/HdwCode.cab#version=1,1,0,0">
        <param name="_Version" value="65536">
        <param name="_ExtentX" value="2646">
        <param name="_ExtentY" value="1323">
        <param name="_StockProps" value="0">
    </object>
     <form id="form1" runat="server">   
    <table width="705" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="705" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="125">
                            &nbsp;
                        </td>
                        <td width="581">
                            <img src="/Images/loginLogo.jpg" width="360" height="75" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="">
                <img src="../Images/login01.png" width="705" height="50" style="margin:0; padding:0; border:0;overflow:hidden; float:left;" />
            </td>
        </tr>
        <tr>
            <td background="../Images/login02.png" width="705" height="235">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="301" height="33">
                            &nbsp;
                        </td>
                        <td width="73" height="33" class="f14" align="right">
                            帐 号：
                        </td>
                        <td width="331" height="33">
                            <input name="txtLoginName"  id="txtLoginName" type="text" style="font-size:14px" class="text" onblur="checkadminaccount()" />
                        </td>
                    </tr>
                    <tr>
                        <td width="301" height="33">
                            &nbsp;
                        </td>
                        <td height="33" class="f14" align="right">
                            密 码：
                        </td>
                        <td height="33">
                            <input name="txtLoginPass" id="txtLoginPass" type="password" class="text"  onblur="checkadminpwd()" />
                        </td>
                    </tr>
                    <tr>
                        <td width="301" height="33">
                            &nbsp;
                        </td>
                        <td height="33" class="f14" align="right">
                            验证码：
                        </td>
                        <td height="33">
                            <input name="txtCodeOp" id="txtCodeOp" type="text" class="text" onblur="checkadminvalidator()" />
                        </td>
                    </tr>
                    <tr>
                        <td width="301" height="30">
                            &nbsp;
                        </td>
                        <td height="30">
                            &nbsp;
                        </td>
                        <td height="30" class="hui6">
                            验证码请按下图中的数字填写
                        </td>
                    </tr>
                    <tr>
                        <td width="301" height="30">
                            &nbsp;
                        </td>
                        <td height="30">
                            &nbsp;
                        </td>
                        <td height="30">
                          <label id="validatorimg"> <img src="/WebHelper/Validator.aspx?vnum=5&rnum=8" alt="验证码" style="border: 0; cursor: pointer;
                                margin: 0; padding: 0; float: left;" /> </label>                              
                        </td>
                    </tr>
                    <tr>
                        <td width="301" height="30">
                            &nbsp;
                        </td>
                        <td height="30">
                            &nbsp;
                        </td>
                        <td height="30" class="lan">
                            <a href="javascript:refreshValidator()" class="l">看不清楚？ 换一个</a>
                        </td>
                    </tr>
                    <tr>
                        <td width="301" height="30">
                            &nbsp;
                        </td>
                        <td height="30">
                            &nbsp;
                        </td>
                        <td height="30">      
                        <input type="button" value=""  style="width:86px; height:34px; border:0; cursor:pointer; background:url(../Images/loginBtn.jpg) no-repeat 0 0;" onclick="adminlogin()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="705" height="54" align="center" background="../Images/login03.png" style="color: #115287;">
                CopyRight <%=DateTime.Now.Year %> 团水果网站
            </td>
        </tr>
        <tr>
            <td>
                <img src="/Images/login04.png" width="705" height="46" />
            </td>
        </tr>
        <tr>
            <td>
                <img src="/Images/login05.png" width="705" height="53" />
            </td>
        </tr>
    </table>
    <span id="boxs"></span>
    </form>
</body>
</html>
