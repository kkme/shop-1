//编辑订单
function editorder(orderid) {
    var url = "/WebServices/OrderS.asmx/bandeditorder";
    var parms = "{'orderid':'" + orderid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editorderstate, null, null, false);
   
}
function editorderstate(result) {
    if (result != "f") {
        document.getElementById("fccontent").innerHTML = result;
        ShowPageDiv("editorderdiv", 350, 240);
    }
    else {
        HideMsg();
    }
}

//编辑订单信息
function editorderinfo(orderid) {
    var i1 = $("d1select").selectedIndex;
    var d1 = $("d1select").options[i1].value;
    var i2 = $("d2select").selectedIndex;
    var d2 = $("d2select").options[i2].value;
    var ddate = document.getElementById('deliverydate').value.replace(/-/g, "/");
    var ddatebj = document.getElementById('deliverydate').value.replace(/-/g, "/") + " 23:59:59";
    var ddate1 = new Date(ddatebj);
    var ddate2 = new Date();

//    if (Date.parse(ddate1) - Date.parse(ddate2) < 0) {
//        alert("送货日期选择有误");
//        return;
//    }
    var deliverydate = ddate;
    var s1 = $("orderstate").selectedIndex;
    var state1 = $("orderstate").options[s1].value;

    var url = "/WebServices/OrderS.asmx/editorderinfo";
    var parms = "{'orderid':'" + orderid + "','d1':'" + d1 + "','d2':'" + d2 + "','deliverydate':'" + deliverydate + "','orderstate':'" + state1 + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editorderinfostate, null, null, false);
}
function editorderinfostate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑订单成功！");
    }
    else {
        boxs(1, "编辑订单失败");
    }
}

//删除订单信息
function delorderinfo(ordernumber) {

    var url = "/WebServices/OrderS.asmx/delorderinfo";
    var parms = "{'ordernumber':'" + ordernumber + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delorderinfostate, null, null, false);
}
function delorderinfostate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "删除订单成功！");
    }
    else {
        boxs(1, "删除订单失败");
    }
}

//绑定配送区域二的下拉菜单
function changed1() {
    var index = $("d1select").selectedIndex;
    var pid = $("d1select").options[index].value;
    var url = "/WebServices/OrderS.asmx/bindd2select";
    var parms = "{'did':'" + pid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, changed1state, null, null, false);
}
function changed1state(result) {
    $("d2selectlabel").innerHTML = result;
}

//通过订单号搜索订单
function searchbyordernumber() {
    var ordernum =escape(document.getElementById("ordernumber").value);
    location.href = "/OL?type=4&ordernumber=" + ordernum;
}

//通过收货人搜索订单
function searchbycontact() {
    var contact = escape(document.getElementById("txtcontact").value);
    location.href = "/OL?type=5&contact=" + contact;
}

//绑定配送区域二的下拉菜单
function changeodI() {
    var index = $("odIid").selectedIndex;
    var pid = $("odIid").options[index].value;
    var url = "/WebServices/OrderS.asmx/bindd2selectI";
    var parms = "{'did':'" + pid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, changeodIstate, null, null, false);
}
function changeodIstate(result) {
    $("odIidlabel").innerHTML = result;
}
//绑定配送区域二的下拉菜单II
function changepodI() {
    var index = $("podIid").selectedIndex;
    var pid = $("podIid").options[index].value;
    var url = "/WebServices/OrderS.asmx/bindd2selectII";
    var parms = "{'did':'" + pid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, changepodIstate, null, null, false);
}
function changepodIstate(result) {
    $("podIidlabel").innerHTML = result;
}

//绑定配送区域二的下拉菜单II
function changephodI() {
    var index = $("phodIid").selectedIndex;
    var pid = $("phodIid").options[index].value;
    var url = "/WebServices/OrderS.asmx/bindd2selectIII";
    var parms = "{'did':'" + pid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, changephodIstate, null, null, false);
}
function changephodIstate(result) {
    $("phodIidlabel").innerHTML = result;
}
//高级搜索订单
function searchod() {
    var od1 = document.getElementById("od1").value;
    var od2 = document.getElementById("od2").value;
    var i1 = $("ostateselect").selectedIndex;
    var state = $("ostateselect").options[i1].value;
    var i2 = $("odIid").selectedIndex;
    var odIid = $("odIid").options[i2].value;
    var i3 = $("odIIid").selectedIndex;
    var odIIid = $("odIIid").options[i3].value;
    location.href = "/OL?type=2&od1=" + od1 + "&od2=" + od2 + "&ostateid=" + state + "&odIid=" + odIid + "&odIIid=" + odIIid;
}
//高级搜索订单II-配货日期
function searchpod() {
    var od1 = document.getElementById("pod1").value;
    var od2 = document.getElementById("pod2").value;
    var i1 = $("postateselect").selectedIndex;
    var state = $("postateselect").options[i1].value;
    var i2 = $("podIid").selectedIndex;
    var odIid = $("podIid").options[i2].value;
    var i3 = $("podIIid").selectedIndex;
    var odIIid = $("podIIid").options[i3].value;
    location.href = "/OL?type=3&pod1=" + od1 + "&pod2=" + od2 + "&postateid=" + state + "&podIid=" + odIid + "&podIIid=" + odIIid;
}

//高级搜索订单II-配货总量
function searchphod() {
    var od1 = document.getElementById("phod1").value;
    var od2 = document.getElementById("phod2").value;
    var i1 = $("phostateselect").selectedIndex;
    var state = $("phostateselect").options[i1].value;
    var i2 = $("phodIid").selectedIndex;
    var odIid = $("phodIid").options[i2].value;
    var i3 = $("phodIIid").selectedIndex;
    var odIIid = $("phodIIid").options[i3].value;
    location.href = "/OL?type=8&phod1=" + od1 + "&phod2=" + od2 + "&phostateid=" + state + "&phodIid=" + odIid + "&phodIIid=" + odIIid;
}

function doPrint() {
    var str = '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN"><html><head>';
    str += '<meta http-equiv="Content-Type" content="text/html; charset=gbk" />';
    str += '<title></title>';
    str += '<link rel="stylesheet" type="text/css" href="/Styles/m_order.css" />';
    str += '<link rel="stylesheet" type="text/css" href="/Styles/pagecss.css" />';
    str += '</head>';
    str += '<body onload="window.print()">' + document.getElementById("dayin_area").innerHTML + '</body></html>';
    document.write(str);
    document.close();
}
