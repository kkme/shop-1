//减少购买数量
function minusbuynum() {
    var buynum;
    var curnum = parseInt(document.getElementById("buynum").value);
    if (curnum == 1) {
        return;
    }
    else {
        buynum = curnum - 1;
    }
    document.getElementById("buynum").value = buynum;
}
//增加购买数量
function addbuynum() {
    var buynum;
    var curnum =parseInt(document.getElementById("buynum").value);
    buynum = curnum + 1;
    document.getElementById("buynum").value = buynum;
}

//添加到购物篮
function addcart(state) {
    if (state == '1') {
        boxs(1, "对不起，该产品已经售完，可以联系客服");
    }
    else {
        var NameOfCookie = "tfuid";
        var productid = document.getElementById("pid").value;
        var c = document.cookie.indexOf(NameOfCookie + "=");
        if (c != -1) {
            var userid = getCookie("tfuid");
            var buynum = document.getElementById("buynum").value;
            var url = "/WebServices/OrderS.asmx/addcart";
            var parms = "{'productid':'" + productid + "','userid':'" + userid + "','buynum':'" + buynum + "'}";
            AjaxFunction(url, parms, "post", "josn", null, addcartstate, null, null, false);
        }
        else {
            location.href = "/UserLog?relurl=/PInfo/" + productid + ".html";
        }
    }
}
function addcartstate(result) {
    if (result != "f") {
        location.href = "/OrderIndex";
    }
    else {
        boxs(1, "添加到购物车失败，请您重新添加！");
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

//添加收货地址
function addaddress() {
    var contact = document.getElementById("txtcontact").value;
    var saddress = document.getElementById("txtaddress").value;
    var tel = document.getElementById("txttel").value;
    var mobile = document.getElementById("txtmobile").value;
    var index = $("d1select").selectedIndex;
    var p1id = $("d1select").options[index].value;
    var index2 = $("d2select").selectedIndex;
    var p2id = $("d2select").options[index2].value;
    var userid = document.getElementById("uid").value;

    if (contact.length < 1) {
        alert("请您填写收货人真实姓名");
        document.getElementById("txtcontact").focus();
        return;
    }

    if (saddress.length < 3) {
        alert("请您填写收货人详细地址");
        document.getElementById("txtaddress").focus();
        return;
    }
    if (tel.length < 8&&mobile.length<11) {
        alert("电话或手机号码要填一个");
        document.getElementById("txtmobile").focus();
        return;
    }
    if (p1id=="0") {
        alert("请选择配送区域");       
        return;
    }

    var url = "/WebServices/OrderS.asmx/addaddress";
    var parms = "{'contact':'" + contact + "','saddress':'" + saddress + "','tel':'" + tel + "','mobile':'" + mobile + "','p1id':'" + p1id + "','p2id':'" + p2id + "','userid':'" + userid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addaddressstate, null, null, false);
}
function addaddressstate(result) {
    if (result != "f") {
        refresh();
    }
    else {
        boxs(1, "添加收货信息失败");
    }
}

//选择收货地址
function selectaddress() {
    var uid = $("uid").value;
    var url = "/WebServices/OrderS.asmx/selectaddress";
    var parms = "{'userid':'" + uid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, selectaddressstate, null, null, false);
}
function selectaddressstate(result) {
    if (result != "f") {
        $("orderaddress1").innerHTML = result;
    }
    else {
        boxs(1, "选择收货信息失败");
    }
}

//选择默认收货地址
function selectindexaddress() {
    var addressid = GetRadioValue("cname");
    if (addressid == "noselectvalue") {
        alert("请选择一个送货地址");
        return;
    }
    var url = "/WebServices/OrderS.asmx/selectindexaddress";
    var parms = "{'addressid':'" + addressid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, selectindexaddressstate, null, null, false);

}
function selectindexaddressstate(result) {
    if (result != "f") {
        refresh();
    }
    else {
        boxs(1, "选择收货地址失败");
    }
}

//添加一个新的收货地址
function addnewaddress() {
    var url = "/WebServices/OrderS.asmx/addnewaddress";    
    AjaxFunction(url, null, "post", "josn", null, addnewaddressstate, null, null, false);
}
function addnewaddressstate(result) {
    if (result != "f") {
        $("orderaddress1").innerHTML = result;
    }
    else {
        boxs(1, "添加新的收货信息失败");
    }
}

//编辑一个新的收货地址
function editaddress(addressid) {
    var url = "/WebServices/OrderS.asmx/editaddress";
     var parms = "{'addressid':'" + addressid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editaddressstate, null, null, false);
}
function editaddressstate(result) {
    if (result != "f") {
        $("orderaddress1").innerHTML = result;
    }
    else {
        boxs(1, "编辑新的收货信息失败");
    }
}

//编辑收货地址
function editaddressinfo(addressid) {
    var contact = document.getElementById("txtcontact").value;
    var saddress = document.getElementById("txtaddress").value;
    var tel = document.getElementById("txttel").value;
    var mobile = document.getElementById("txtmobile").value;
    var index = $("d1select").selectedIndex;
    var p1id = $("d1select").options[index].value;
    var index2 = $("d2select").selectedIndex;
    var p2id = $("d2select").options[index2].value;
    var userid = document.getElementById("uid").value;

    if (contact.length < 1) {
        alert("请您填写收货人真实姓名");
        document.getElementById("txtcontact").focus();
        return;
    }

    if (saddress.length < 3) {
        alert("请您填写收货人详细地址");
        document.getElementById("txtaddress").focus();
        return;
    }
    if (tel.length < 8 && mobile.length < 11) {
        alert("电话或手机号码要填一个");
        document.getElementById("txtmobile").focus();
        return;
    }
    if (p1id == "0") {
        alert("请选择配送区域");
        return;
    }

    var url = "/WebServices/OrderS.asmx/editaddressinfo";
    var parms = "{'contact':'" + contact + "','saddress':'" + saddress + "','tel':'" + tel + "','mobile':'" + mobile + "','p1id':'" + p1id + "','p2id':'" + p2id + "','userid':'" + userid + "','addressid':'" + addressid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editaddressinfostate, null, null, false);
}
function editaddressinfostate(result) {
    if (result != "f") {
        refresh();
    }
    else {
        boxs(1, "编辑收货信息失败");
    }
}

//绑定订单产品
function bandcart() {
    var url = "/WebServices/OrderS.asmx/bandcart";
    AjaxFunction(url, null, "post", "josn", null, bandcartstate, null, null, false);
}

function bandcartstate(result) {   
    document.getElementById("orderproduct").innerHTML = result;
    document.getElementById("pmoney").innerHTML = document.getElementById("hpmoney").value;
    document.getElementById("dmoney").innerHTML =  document.getElementById("hdmoney").value;
    document.getElementById("paymoney").innerHTML = document.getElementById("hpaymoney").value;
}

//改变购物车产品数目
function changecartordernum(cartid, type) {
    var url = "/WebServices/OrderS.asmx/changecartordernum";
    var parms = "{'cartid':'" + cartid + "','type':'" + type + "'}";
    AjaxFunction(url, parms, "post", "josn", null, changecartordernumstate, null, null, false);
}

function changecartordernumstate(result) {
    if (result == "t") {
        bandcart();
    }
    else {
    }
}

//删除购物车产品
function delcart(cartid) {
    var url = "/WebServices/OrderS.asmx/delcart";
    var parms = "{'cartid':'" + cartid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delcartstate, null, null, false);
}

function delcartstate(result) {
    if (result == "t") {
        bandcart();
    }
    else {
    }
}

//生成订单
function addorder() {
    var ddate = document.getElementById('deliverydate').value.replace(/-/g, "/");
    var ddatebj = document.getElementById('deliverydate').value.replace(/-/g, "/") + " 23:59:59";
    var d1 = new Date(ddatebj);
    var d2 = new Date();

    if (Date.parse(d1) - Date.parse(d2) < 0) {
        alert("收货日期选择有误");
        return;
    }
    var url = "/WebServices/OrderS.asmx/addorder";
    var parms = "{'ddate':'" + ddate + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addorderstate, null, null, false);
}
function addorderstate(result) {
    if (result == "f") {
        boxs(1, "生成订单失败");
    }
    else if (result == "address_f") {
        boxs(1, "请添加收货地址");
    }
    else if (result == "buynum_f") {
        boxs(1, "购物车没有产品");
    }
    else if (result == "t") {
        location.href = "/OrderResult";
    }
    else {
        boxs(1, "生成订单失败");
    }
}


