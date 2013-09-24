var nameV = 0;
//检测账号是否合法
function checkadminname() {
    var strAdmin = $("adminname").value;
    if (strAdmin.length > 4 && strAdmin.length < 23) {
        var url = "/WebServices/ManagerS.asmx/checkadminname";
        var parms = "{'adminname':'" + strAdmin + "'}";
        AjaxFunction(url, parms, "post", "josn", null, checkadminnamestate, null, null, false);
    }
    else {
        $("namenote").className = "red";
        $("namenote").innerHTML = "× 请输入有效的登录账号";       
        nameV = 0;
    }
}

function checkadminnamestate(result) {
    if (result == "t") {
        $("namenote").className = "green";
        $("namenote").innerHTML = "√ 账号输入正确";
        nameV = 1;
    }
    else {
        $("namenote").className = "red";
        $("namenote").innerHTML = "× 该账号已经被注册，请使用其他账号";
        nameV = 0;
    }
}


//检测密码是否合法
function checkpwd() {
    var strpwd = $("pwd").value;
    if (strpwd.length > 4 && strpwd.length < 23) {
        $("pwdnote").className = "green";
        $("pwdnote").innerHTML = "√ 密码输入正确";
        return true;
    }
    else {
        $("pwdnote").className = "red";
        $("pwdnote").innerHTML = "× 密码请用5-22个字符或数字";
        return false;
    }
}

//检测确认密码是否合法
function checkrepwd() {
    var strpwd = $("pwd").value;
    var strrepwd = $("repwd").value;
    if (strrepwd.length == 0) {
        $("repwdnote").className = "red";
        $("repwdnote").innerHTML = "× 确认密码不能为空";
        return false;
    }
    else {
        if (strpwd != strrepwd) {
            $("repwdnote").className = "red";
            $("repwdnote").innerHTML = "× 两次密码输入不一致";
            return false;
        }
        else {
            $("repwdnote").className = "green";
            $("repwdnote").innerHTML = "√ 两次密码输入一致";
            return true;
        }
    }
}

//注册新会员验证

function addnewadmin() {
    checkadminname();
    if (checkpwd()) {
        if (checkrepwd()) {
            if (nameV) {
                var strPwd = document.getElementById("pwd").value;
                var strAdminname = document.getElementById("adminname").value;
                var url = "/WebServices/ManagerS.asmx/addadmin";
                var parms = "{'pwd':'" + strPwd + "','adminname':'" + strAdminname + "'}";
                AjaxFunction(url, parms, "post", "josn", null, addnewadminstate, null, null, false);
            }
            else {
                $("adminname").focus();
                return false;
            }
        }
        else {
            boxs(1,'重复密码输入不正确，请重新输入');
            $("repwd").focus();
            return false;
        }
    }
    else {
        boxs(1,'密码输入不正确，请重新输入');
        $("pwd").focus();
        return false;
    }
}
function addnewadminstate(result) {
    if (result == "t") {
        boxs(1, "添加管理员账户成功！");
    }
    else {
        boxs(1, "添加管理员账户失败");
    }
}

//修改密码

function resetpwd() {
    
    if (checkpwd()) {
        if (checkrepwd()) {
            var strPwd = document.getElementById("pwd").value;
            var strAdminId = document.getElementById("adminid").value;
            var url = "/WebServices/ManagerS.asmx/editadminpwd";
            var parms = "{'newpwd':'" + strPwd + "','adminid':'" + strAdminId + "'}";
            AjaxFunction(url, parms, "post", "josn", null, resetpwdstate, null, null, false);
        }
        else {
            boxs(1,'重复密码输入不正确，请重新输入');
            $("repwd").focus();
            return false;
        }
    }
    else {
        boxs(1,'密码输入不正确，请重新输入');
        $("pwd").focus();
        return false;
    }
}
function resetpwdstate(result) {
    if (result == "t") {
        boxs(1, "修改管理员密码成功！");
    }
    else {
        boxs(1, "修改管理员密码失败");
    }
}

//删除管理员

function deladmin(adminid) {
    var url = "/WebServices/ManagerS.asmx/deladmin";
    var parms = "{'adminid':'" + adminid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, deladminstate, null, null, false);
}

function deladminstate(result) {
    if (result == "t") {
        boxs(1, "删除管理员成功！");
    }
    else {
        boxs(1, "删除管理员失败");
    }
}








