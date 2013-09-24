var statecookie = new Array();
function itemselect(k) {
    var item1 = document.getElementById("l" + k + "content");
    statecookie[k] = getCookie("itemstate" + k);
    if (statecookie[k] == 0) {
        item1.style.display = "block";
        createcookie('itemstate' + k, '1');


    }
    else {
        item1.style.display = "none";
        createcookie('itemstate' + k, '0');
    }
}
function createcookie(name, value) {

    var cokkie = name + "=" + value;
    cokkie += ";path=/";
    var Days = 1;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    cokkie += ";expires=" + exp.toGMTString();
    document.cookie = cokkie;
}

function getCookie(objName) {//获取指定名称的cookie的值
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName) return unescape(temp[1]);
    }
}


function initstate() {
    for (var n = 1; n < 5; n++) {
        var item1 = document.getElementById("l" + n + "content");
        statecookie[n] = getCookie("itemstate" + n);
        if (getCookie("itemstate" + n) == 1) {
            item1.style.display = "block";

        }
        else {
            item1.style.display = "none";
            createcookie('itemstate' + n, '0');
        }

    }
}


if (document.all) {

    window.attachEvent('onload', initstate); //IE中

}

else {

    window.addEventListener('load', initstate, false); //firefox

}

//更改送货地址默认
function setisdefault(id) {
    var url = "/WebServices/userS.asmx/setisdefault";
    var parms = "{'addressid':'" + id + "'}";
    AjaxFunction(url, parms, "post", "josn", null, setisdefaultstate, null, null, false);

}
function setisdefaultstate(result) {
    if (result == "t") {
        boxs(1, "设置默认地址成功！");
    }
    else {
        boxs(1, "设置默认地址失败");
    }
}

//删除送货地址
function deladdress(id) {
    if (confirm('请您确定是否删除该送货地址')) {
        var url = "/WebServices/userS.asmx/deladdress";
        var parms = "{'addressid':'" + id + "'}";
        AjaxFunction(url, parms, "post", "josn", null, deladdressstate, null, null, false);
    }
    else {
        return;
    }

}
function deladdressstate(result) {
    if (result == "t") {
        boxs(1, "删除送货地址成功！");
    }
    else {
        boxs(1, "删除送货地址失败");
    }
}
