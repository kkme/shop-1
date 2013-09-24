//检验验证码
function checkadminvalidator() {
    var validator = $("txtCodeOp").value;
    var yzmcode = getCookie("yzmcode");
    if (validator.toLocaleLowerCase() == yzmcode.toLocaleLowerCase()) {
        return true;
    }
    else {
        boxs(1, '您的验证码输入错误');
        return false;
    }
}

//刷新验证码
function refreshValidator() {
    var rnum = parseInt(Math.floor(Math.random() * 10));
    $("validatorimg").innerHTML = "<img src=\"/WebHelper/Validator.aspx?vnum=5&rnum=" + rnum + " \" alt=\"点击获取新验证码\" style=\"cursor:pointer;\" onclick=\"refreshValidator()\" />";
}

//检测账号是否合法
function checkadminaccount() {
    var strAccount = $("txtLoginName").value;
    if (strAccount.length > 4 && strAccount.length < 23) {
        return true;
    }
    else {
        boxs(1, '请输入有效的账号');
        return false;
    }
}

//检测密码是否合法
function checkadminpwd() {
    var strpwd = $("txtLoginPass").value;
    if (strpwd.length > 4 && strpwd.length < 23) {
        return true;
    }
    else {
        boxs(1, '密码请用5-22个字符或数字');
        return false;
    }
}

//用户登录
function adminlogin() {
    if (checkadminaccount()) {
        if (checkadminpwd()) {
            if (checkadminvalidator()) {
                var strPwd = document.getElementById("txtLoginPass").value;
                var strAdminname = document.getElementById("txtLoginName").value;
                var url = "/WebServices/ManagerS.asmx/adminlogin";
                var parms = "{'pwd':'" + strPwd + "','adminname':'" + strAdminname + "'}";
                AjaxFunction(url, parms, "post", "josn", null, adminloginstate, null, null, false);
            }
        }
    }
}

function adminloginstate(result) {
    if (result == "t") {
        location.href = "/Manager/Index.aspx";
    }
    else {
        boxs(1, "登录失败,请检查管理员账户和密码");
    }
}




var emailV;
//倒计时间隔
//var jg = 5;

//检测邮箱是否合法
function checkemail() {
    var strEmail = $("email").value;
    if (strEmail.search(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/) != -1) {
        var url = "/WebServices/userS.asmx/checkemail";
        var parms = "{'email':'" + strEmail + "'}";
        AjaxFunction(url, parms, "post", "josn", null, checkemailstate, null, null, false);
    }
    else {
        $("emailnote").className = "noteinfo2";
        $("emailnote").innerHTML = "× 请输入有效的邮箱格式";
        emailV = 0;
    }
}

function checkemailstate(result) {
    if (result == "t") {
        $("emailnote").className = "noteinfo";
        $("emailnote").innerHTML = "√ Email输入正确";
        emailV = 1;
    }
    else {
        $("emailnote").className = "noteinfo2";
        $("emailnote").innerHTML = "× 该邮箱已经被注册，请使用其他邮箱";
        emailV = 0;
    }
}

var accountV;
//检测账号是否合法
function checkaccount() {
    var strAccount = $("account").value;
    if (strAccount.length > 4 && strAccount.length < 23) {
        var url = "/WebServices/userS.asmx/checkaccount";
        var parms = "{'account':'" + strAccount + "'}";
        AjaxFunction(url, parms, "post", "josn", null, checkaccountstate, null, null, false);
    }
    else {
        $("accountnote").className = "noteinfo2";
        $("accountnote").innerHTML = "× 请输入有效的账号";
        accountV = 0;
    }
}

function checkaccountstate(result) {
    if (result == "t") {
        $("accountnote").className = "noteinfo";
        $("accountnote").innerHTML = "√ 账号输入正确";
        accountV = 1;
    }
    else {
        $("accountnote").className = "noteinfo2";
        $("accountnote").innerHTML = "× 该账号已经被注册，请使用其他账号";
        accountV = 0;
    }
}



//检测密码是否合法
function checkpwd() {
    var strpwd = $("pwd").value;
    if (strpwd.length > 4 && strpwd.length < 23) {
        $("pwdnote").className = "noteinfo";
        $("pwdnote").innerHTML = "√ 密码输入正确";
        return true;
    }
    else {
        $("pwdnote").className = "noteinfo2";
        $("pwdnote").innerHTML = "× 密码请用5-22个字符或数字";
        return false;
    }
}

//检测确认密码是否合法
function checkrepwd() {
    var strpwd = $("pwd").value;
    var strrepwd = $("repwd").value;
    if (strrepwd.length == 0) {
        $("repwdnote").className = "noteinfo2";
        $("repwdnote").innerHTML = "× 确认密码不能为空";
        return false;
    }
    else {
        if (strpwd != strrepwd) {
            $("repwdnote").className = "noteinfo2";
            $("repwdnote").innerHTML = "× 两次密码输入不一致";
            return false;
        }
        else {
            $("repwdnote").className = "noteinfo";
            $("repwdnote").innerHTML = "√ 两次密码输入一致";
            return true;
        }
    }
}

//检验验证码
function checkvalidator() {
    var validator = $("validator").value;
    var yzmcode = getCookie("yzmcode");
    if (validator.toLocaleLowerCase() == yzmcode.toLocaleLowerCase()) {
        $("validatornote").className = "noteinfo";
        $("validatornote").innerHTML = "√ 验证码输入正确";
        return true;
    }
    else {
        $("validatornote").className = "noteinfo2";
        $("validatornote").innerHTML = "× 验证码输入错误";
        return false;
    }
}


//刷新验证码

function refreshValidator1() {
    var rnum = parseInt(Math.floor(Math.random() * 10));
    $("validatorimg1").innerHTML = "<img src=\"/WebHelper/Validator.aspx?vnum=5&rnum=" + rnum + " \" alt=\"点击获取新验证码\" style=\"cursor:pointer;\" onclick=\"refreshValidator1()\" />";
}
function refreshValidator2() {
    var rnum = parseInt(Math.floor(Math.random() * 10));
    $("validatorimg2").innerHTML = "<img src=\"/WebHelper/Validator.aspx?vnum=5&rnum=" + rnum + " \" alt=\"点击获取新验证码\" style=\"cursor:pointer;\" onclick=\"refreshValidator2()\" />";
}


//注册新会员验证

function register() {
    var validator = $("validator").value;
    var yzmcode = getCookie("yzmcode");
    if (validator.toLocaleLowerCase() == yzmcode.toLocaleLowerCase()) {
        checkemail();
        if (checkpwd()) {
            if (checkrepwd()) {
                if (emailV) {
                    var uname = escape($("account").value);
                    var upwd = escape($("pwd").value);
                    var uemail = escape($("email").value);
                    var url = "/WebServices/userS.asmx/register";
                    var parms = "{'account':'" + uname + "','pwd':'" + upwd + "','email':'" + uemail + "'}";
                    AjaxFunction(url, parms, "post", "josn", null, registerstate, null, null, false);
                }
                else {
                    $("email").focus();
                    return false;
                }
            }
            else {
                boxs(1, '重复密码输入不正确，请重新输入');
                $("repwd").focus();
                return false;
            }
        }
        else {
            boxs(1, '密码输入不正确，请重新输入');
            $("pwd").focus();
            return false;
        }
    }
    else {
        boxs(1, '验证码输入不正确，请重新输入');
        $("validator").focus();
        return false;
    }
}

function registerstate(result) {
    if (result == "t") {
        location.href = "/UIndex";
    }
    else {
        boxs(1, "注册失败！");
    }
}

//用户登录
function login1() {
    var validator = $("validator1").value;
    var yzmcode = getCookie("yzmcode");
    if (validator.toLocaleLowerCase() == yzmcode.toLocaleLowerCase()) {
        if ($("email").value == "" || $("emailpwd").value == "") {
            boxs(1,'注册邮箱或密码不能为空');
            return false;
        }
        else {
            var uemail = escape(document.getElementById("email").value);
            var upwd = escape(document.getElementById("emailpwd").value);
            var url = "/WebServices/userS.asmx/emaillogin";
            var parms = "{'email':'" + uemail + "','pwd':'" + upwd + "'}";
            AjaxFunction(url, parms, "post", "josn", null, emailloginstate, null, null, false);
        }

    }
    else {
        boxs(1,'验证码输入不正确，请重新输入');
        $("validator1").focus();
        return false;
    }
}
function emailloginstate(result) {
    if (result != "f") {
        var relurl = document.getElementById("relurl").value;
        if (relurl != "" && relurl != null) {
            if (document.getElementById("remember2").checked) {
                var cokkie = "tfuid=" + result;
                cokkie += ";path=/";
                var Days = 7;
                var exp = new Date();
                exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
                cokkie += ";expires=" + exp.toGMTString();
                document.cookie = cokkie;
                location.href = relurl;
            }
            else {
                var cokkie = "tfuid=" + result;
                cokkie += ";path=/";
                document.cookie = cokkie;
                location.href = relurl;
            }
        }
        else {
            if (document.getElementById("remember2").checked) {
                var cokkie = "tfuid=" + result;
                cokkie += ";path=/";
                var Days = 7;
                var exp = new Date();
                exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
                cokkie += ";expires=" + exp.toGMTString();
                document.cookie = cokkie;
                location.href = "/UIndex";
            }
            else {
                var cokkie = "tfuid=" + result;
                cokkie += ";path=/";
                document.cookie = cokkie;
                location.href = "/UIndex";
            }
        }
    }
    else {
        boxs(1,'登录失败，注册邮箱或密码错误');
    }
}

//用户登录
function login2() {
    var validator = $("validator2").value;
    var yzmcode = getCookie("yzmcode");
    if (validator.toLocaleLowerCase() == yzmcode.toLocaleLowerCase()) {
        if ($("username").value == "" || $("usernamepwd").value == "") {
            boxs(1,'会员号或密码不能为空');
            return false;
        }
        else {
            var uname = escape(document.getElementById("username").value);
            var upwd = escape(document.getElementById("usernamepwd").value);
            var url = "/WebServices/userS.asmx/userlogin";
            var parms = "{'accounts':'" + uname + "','pwd':'" + upwd + "'}";
            AjaxFunction(url, parms, "post", "josn", null, userloginstate, null, null, false);
        }

    }
    else {
        boxs(1,'验证码输入不正确，请重新输入');
        $("validator2").focus();
        return false;
    }
}
function userloginstate(result) {
    if (result != "f") {
        var relurl = document.getElementById("relurl").value;
        if (relurl != "" && relurl != null) {
            if (document.getElementById("remember1").checked) {
                var cokkie = "tfuid=" + result;
                cokkie += ";path=/";
                var Days = 7;
                var exp = new Date();
                exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
                cokkie += ";expires=" + exp.toGMTString();
                document.cookie = cokkie;
                location.href = relurl;
            }
            else {
                var cokkie = "tfuid=" + result;
                cokkie += ";path=/";
                document.cookie = cokkie;
                location.href = relurl;
            }
        }
        else {
            if (document.getElementById("remember1").checked) {
                var cokkie = "tfuid=" + result;
                cokkie += ";path=/";
                var Days = 7;
                var exp = new Date();
                exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
                cokkie += ";expires=" + exp.toGMTString();
                document.cookie = cokkie;
                location.href = "/UIndex";
            }
            else {
                var cokkie = "tfuid=" + result;
                cokkie += ";path=/";
                document.cookie = cokkie;
                location.href = "/UIndex";
            }
        }
    }
    else {
        boxs(1,'登录失败，账号或密码错误');
    }
}


//登录界面-会员登录和邮箱登录切换
function changeloginitem(k) {
    if (k == 1) {
        document.getElementById("loginarea-header-l").className = "loginarea-header-l";
        document.getElementById("loginarea-header-r").className = "loginarea-header-r";
        document.getElementById("loginarea-main1").className = "loginarea-main1";
        document.getElementById("loginarea-main2").className = "loginarea-main2";
    }
    else {
        document.getElementById("loginarea-header-l").className = "loginarea-header-r";
        document.getElementById("loginarea-header-r").className = "loginarea-header-l";
        document.getElementById("loginarea-main1").className = "loginarea-main2";
        document.getElementById("loginarea-main2").className = "loginarea-main1";
    }
}


function rlogin() {
    var validator = $("rvalidator").value;
    var yzmcode = getCookie("yzmcode");
    if (validator.toLocaleLowerCase() == yzmcode.toLocaleLowerCase()) {
        if ($("remail").value == "" || $("rpwd").value == "") {
            boxs(1,'邮箱账号或密码不能为空');
            return false;
        }
        else {
            var strEmail = document.getElementById("remail").value;
            var strPwd = document.getElementById("rpwd").value;
            var url = "/WebServices/userS.asmx/userlogin";
            var parms = "{'email':'" + strEmail + "','pwd':'" + strPwd + "'}";
            AjaxFunction(url, parms, "post", "josn", null, rloginstate, null, null, false);
        }

    }
    else {
        boxs(1,'验证码输入不正确，请重新输入');
        $("rvalidator").focus();
        return false;
    }
}

function rloginstate(result) {
    if (result != "f") {
        var cokkie = "mywebuid=" + result;
        cokkie += ";path=/";
        var Days = 1;
        var exp = new Date();
        exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
        cokkie += ";expires=" + exp.toGMTString();
        document.cookie = cokkie;
        window.location.reload();
    }
    else {
        boxs(1,'登录失败，注册邮箱或密码错误');
    }
}

