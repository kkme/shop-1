
var accountsV;

//检测昵称是否合法
function checkaccounts() {
    var strAccounts = document.getElementById("MainContent_txtaccounts").value;
    var uid = document.getElementById("MainContent_userid").value;
    if (strAccounts.length > 4 && strAccounts.length < 23) {
        var url = "/WebServices/userS.asmx/checkaccounts";
        var parms = "{'accounts':'" + strAccounts + "','userid':'" + uid + "'}";
        AjaxFunction(url, parms, "post", "josn", null, checkaccountsstate, null, null, false);
    }
    else {
        boxs(1,'不好意思，你输入的昵称不合规范，请输入长度在5到23之间');
        accountsV = 0;
    }
}

function checkaccountsstate(result) {
    if (result == "t") {
        boxs(1, '不好意思，改昵称已被注册，请选择其他昵称');
        accountsV = 0;

    }
    else {
        accountsV = 1;
    }
}

function AccountsIsV(uid) {
    checkaccounts(uid);
    if (accountsV == 1) {
        return true;
    }
    else {
        return false;
    }
}

//检查输入的密码是否正确
function checkoldeditpwd() {
    var stroldpwd = $("txtoldpwd").value;
    var uid = $("userid").value;
    if (stroldpwd.length > 4 && stroldpwd.length < 16) {
        var url = "/WebServices/userS.asmx/checkeditpwd";
        var parms = "{'pwd':'" + stroldpwd + "','userid':'" + uid + "'}";
        AjaxFunction(url, parms, "post", "josn", null, checkeditpwdstate, null, null, false);
    }
    else {
        document.getElementById('oldpwdnote').innerHTML = "× 密码请输入长度在5到15之间";
        document.getElementById('oldpwdnote').className = "red";
        return false;
    }

}

function checkeditpwdstate(result) {
    if (result == "t") {
        document.getElementById('oldpwdnote').innerHTML = "√ 密码输入正确";
        document.getElementById('oldpwdnote').className = "green";
        return true;
    }
    else {
        document.getElementById('oldpwdnote').innerHTML = "× 旧密码输入不正确";
        document.getElementById('oldpwdnote').className = "red";
        return false;
    }
}



function checkeditnewpwd() {

    if ((document.getElementById('txtnewpwd').value.length < 4) || (document.getElementById('txtnewpwd').value.length > 12)) {
        document.getElementById('newpwdnote').innerHTML = "× 请用5-12位字符的密码，以确保账号安全";
        document.getElementById('newpwdnote').className = "red";
        return false;

    }
    else {
        document.getElementById('newpwdnote').innerHTML = "√ 密码输入正确";
        document.getElementById('newpwdnote').className = "green";
        return true;
    }
}

function checkreeditpwd() {

    if ((document.getElementById('txtrenewpwd').value == document.getElementById('txtnewpwd').value) && (document.getElementById('txtrenewpwd').value != "")) {
        document.getElementById('renewpwdnote').innerHTML = "√ 密码确认正确";
        document.getElementById('renewpwdnote').className = "green";
        return true;
    }
    else {
        document.getElementById('renewpwdnote').innerHTML = "× 两次输入不一致";
        document.getElementById('renewpwdnote').className = "red";
        return false;
    }
}

//修改密码
function editoldpwd() {
    if (checkoldeditpwd) {
        if (checkeditnewpwd) {
            if (checkreeditpwd) {
                var url = "/WebServices/userS.asmx/editpwd";
                var npwd = document.getElementById('txtnewpwd').value;
                var uid = document.getElementById('userid').value
                var parms = "{'pwd':'" + npwd + "','userid':'" + uid + "'}";
                AjaxFunction(url, parms, "post", "josn", null, editoldpwdstate, null, null, false);
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }

    }
    else {
        return false;
    }
}
function editoldpwdstate(result) {
    if (result == "t") {
        boxs(1, '密码修改成功！');
       
    }
    else {
        boxs(1, '密码修改失败！');     
    }
}