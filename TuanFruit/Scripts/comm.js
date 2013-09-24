function $(id) {
    return document.getElementById(id);
}

var ajaxObj;
var btype = getOs();
function getOs() {
    if (navigator.userAgent.indexOf("MSIE") > 0) {
        return "MSIE";       //IE浏览器
    }
    if (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) {
        return "Firefox";     //Firefox浏览器
    }
    if (isSafari = navigator.userAgent.indexOf("Safari") > 0) {
        return "Safari";      //Safan浏览器
    }
    if (isCamino = navigator.userAgent.indexOf("Camino") > 0) {
        return "Camino";   //Camino浏览器
    }
    if (isMozilla = navigator.userAgent.indexOf("Gecko/") > 0) {
        return "Gecko";    //Gecko浏览器
    }
}

function get_request() {
    http_request = "";
    //开始初始化XMLHttpRequest 对象
    if (window.XMLHttpRequest) { //Mozilla 浏览器
        http_request = new XMLHttpRequest();
        if (http_request.overrideMimeType) {//设置MiME 类别        
            http_request.overrideMimeType("text/xml");
        }
    } else if (window.ActiveXObject) { // IE 浏览器
        try {
            http_request = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                http_request = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) { }
        }
    }
    if (!http_request) { // 异常，创建对象实例失败
        window.alert("不能创建XMLHttpRequest 对象实例.");
        return false;
    }
    return http_request;
}

//公用Ajax函数(url:调用的WebService路径； parms:WebService参数； committype:申请方式Post或Get； beforsendMethod:调用WebService前执行的回调函数；
//             sucMethod:操作成功执行的回调函数； failMethod:操作失败后执行的回调函数； completeMethod:全部操作完成后执行的回调函数)
function AjaxFunction(url, parms, committype, ajaxtype, beforsendMethod, sucMethod, failMethod, completeMethod, yb) {
    ajaxObj = get_request();
    ajaxObj.open(committype, url, yb);

    var requesttype;
    switch (ajaxtype) {
        case "text":
            requesttype = "application/x-www-form-urlencoded";
            break;
        case "josn":
            requesttype = "application/json;utf-8";
            break;
    }
    ajaxObj.setRequestHeader("Content-Type", requesttype);
    if (beforsendMethod) beforsendMethod();
    ajaxObj.send(parms);

    if ((ajaxObj.readyState == 4 || btype == "Firefox")) {
        if (ajaxObj.status == 200) {
            var result;
            switch (ajaxtype) {
                //JOSN模式解析 
                case "josn":
                    eval("objresult=" + ajaxObj.responseText);
                    result = objresult.d;
                    break;
                //正常文本模式解析   
                case "text":
                    result = ajaxObj.responseText;
                    break;
            }
            if (sucMethod) sucMethod(result);
        }
        else {
            if (failMethod)
                failMethod(ajaxObj.status + "," + ajaxObj.responseText);
            else
                defaultfail(ajaxObj.responseText);
        }
        if (completeMethod) completeMethod();
    }
}
function defaultfail(resulst) {
    alert(resulst);
}

//获取指定名称的cookie的值
function getCookie(objName) {
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName) return unescape(temp[1]);
    }
}
//创建一个cookie
function createcookie(name, value) {

    var cokkie = name + "=" + value;
    cokkie += ";path=/";
//    var Days = 1;
//    var exp = new Date();
//    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
//    cokkie += ";expires=" + exp.toGMTString();
    document.cookie = cokkie;
}

function boxs(v, content) {
    window.scrollTo(0, 0);
    var bo = document.getElementsByTagName('body')[0];
    var ht = document.getElementsByTagName('html')[0];
    var boht = document.getElementById('boxs');
    boht.innerHTML = '';
    bo.style.height = 'auto';
    bo.style.overflow = 'auto';
    ht.style.height = 'auto';
    if (v == 1) {
        bo.style.height = '100%';
        bo.style.overflow = 'hidden';
        ht.style.height = '100%';
        boht.innerHTML = '<div id="bg"></div><div id="info"><div id="center"><strong>信息提示</strong><p>' + content + '<br><a href="javascript:refresh()"> <img src="/images/confirm.gif" border="0"> </a></p></div></div>';
    }
}

//刷新
function refresh() {
    window.location.reload();
}

//取radio选中的值
function GetRadioValue(RadioName) {
    var obj;
    var dvalue = "noselectvalue";
    obj = document.getElementsByName(RadioName);
    if (obj != null) {
        var i;
        for (i = 0; i < obj.length; i++) {
            if (obj[i].checked) {
                dvalue = obj[i].value;
                return dvalue;
            }
        }
    }
    return dvalue;
}





        
















