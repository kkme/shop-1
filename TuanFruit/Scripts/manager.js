var statecookie = new Array();
function itemselect(k) {
    var item1 = document.getElementById("leftMenu" + k);
    var img1 = document.getElementById("sysimg" + k);
    statecookie[k] = getCookie("state" + k);
    if (statecookie[k] == 0) {
        item1.style.display = "block";
        img1.src = "/Images/arrBig.gif";
        createcookie('state' + k, '1');

    }
    else {
        item1.style.display = "none";
        img1.src = "/Images/arrBig1.gif";
        createcookie('state' + k, '0');
    }
}

function initstate() {
    for (var n = 1; n < 6; n++) {
        var item1 = document.getElementById("leftMenu" + n);
        statecookie[n] = getCookie("state" + n);
        if (getCookie("state" + n) == 1) {
            item1.style.display = "block";

        }
        else {
            item1.style.display = "none";
            createcookie('state' + n, '0');
        }

    }
}


if (document.all) {

    window.attachEvent('onload', initstate); //IE中

}

else {

    window.addEventListener('load', initstate, false); //firefox

}


var highlightcolor = '#DFF5D1';
//此处clickcolor只能用win系统颜色代码才能成功,如果用#xxxxxx的代码就不行,还没搞清楚为什么:(
var clickcolor = '#51b2f6';
function changeto() {
    source = event.srcElement;
    if (source.tagName == "TR" || source.tagName == "TABLE")
        return;
    while (source.tagName != "TD")
        source = source.parentElement;
    source = source.parentElement;
    cs = source.children;
    //alert(cs.length);
    if (cs[1].style.backgroundColor != highlightcolor && source.id != "nc")
        for (i = 0; i < cs.length; i++) {
        cs[i].style.backgroundColor = highlightcolor;
    }
}

function changeback() {
    cs = source.children;
    if (event.fromElement.contains(event.toElement) || source.contains(event.toElement) || source.id == "nc")
        return
    if (event.toElement != source)
    //source.style.backgroundColor=originalcolor
        for (i = 0; i < cs.length; i++) {
        cs[i].style.backgroundColor = "";
    }
}

//添加图片类别
function addimagestype() {
    var imagestype = escape($("itname").value);
    var url = "/WebServices/ManagerS.asmx/addimagestype";
    var parms = "{'simagestype':'" + imagestype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addimagestypestate, null, null, false);
}
function addimagestypestate(result) {
    if (result == "t") {
        boxs(1, "添加图片类别成功！");
    }
    else {
        boxs(1, "添加图片类别失败");
    }
}

//编辑图片类别
function edititname(itid, imagestype) {
    $("edititname").value = imagestype;
    $("edititid").value = itid;
    ShowPageDiv("editimagestype", 350, 200);
}

function editimagestype() {
    var itid = $("edititid").value;
    var imagestype = escape($("edititname").value);   
    var url = "/WebServices/ManagerS.asmx/editimagestype";
    var parms = "{'itid':'" + itid + "','simagestype':'" + imagestype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editimagestypestate, null, null, false);
}
function editimagestypestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑图片类别成功！");
    }
    else {
        boxs(1, "编辑图片类别失败");
    }
}

//删除图片类别
function delimagestype(itid) {
    var url = "/WebServices/ManagerS.asmx/delimagestype";
    var parms = "{'itid':'" + itid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delimagestypestate, null, null, false);

}
function delimagestypestate(result) {
    if (result == "t") {
        boxs(1, "删除图片类别成功！");
    }
    else {
        boxs(1, "删除图片类别失败");
    }
}

//添加内容类别
function addwebsitetype() {
    if ($("wtname").value.length > 0) {
        var websitetype = escape($("wtname").value);
        var url = "/WebServices/ManagerS.asmx/addwebsitetype";
        var parms = "{'swebsitetype':'" + websitetype + "'}";
        AjaxFunction(url, parms, "post", "josn", null, websitetypestate, null, null, false);
    }
    else {
        boxs(1, "内容类别不能为空！");
    }
}
function websitetypestate(result) {
    if (result == "t") {
        boxs(1, "添加内容类别成功！");
    }
    else {
        boxs(1, "添加内容类别失败");
    }
}

//编辑内容类别
function editwtname(wtid, websitetype) {
    $("editwtname").value = websitetype;
    $("editwtid").value = wtid;
    ShowPageDiv("editimagestype", 350, 200);
}

function editwebsitetype() {
    var wtid = $("editwtid").value;
    var websitetype = escape($("editwtname").value);
    var url = "/WebServices/ManagerS.asmx/editwebsitetype";
    var parms = "{'wtid':'" + wtid + "','swebsitetype':'" + websitetype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editwebsitetypestate, null, null, false);
}
function editwebsitetypestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑内容类别成功！");
    }
    else {
        boxs(1, "编辑内容类别失败");
    }
}

//删除内容类别
function delwebsitetype(wtid) {
    var url = "/WebServices/ManagerS.asmx/delwebsitetype";
        var parms = "{'wtid':'" + wtid + "'}";
        AjaxFunction(url, parms, "post", "josn", null, delwebsitetypestate, null, null, false);
   
}
function delwebsitetypestate(result) {
    if (result == "t") {
        boxs(1, "删除内容类别成功！");
    }
    else {
        boxs(1, "删除内容类别失败");
    }
}

//删除内容
function delwebsite(wsid) {
    var url = "/WebServices/ManagerS.asmx/delwebsite";
    var parms = "{'wsid':'" + wsid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delwebsitestate, null, null, false);

}
function delwebsitestate(result) {
    if (result == "t") {
        boxs(1, "删除内容成功！");
    }
    else {
        boxs(1, "删除内容失败");
    }
}


//添加新闻类别
function addnewstype() {
    var newstype = escape($("ntname").value);
    var url = "/WebServices/ManagerS.asmx/addnewstype";
    var parms = "{'s_newstype':'" + newstype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addnewstypestate, null, null, false);
}
function addnewstypestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "添加新闻类别成功！");
    }
    else {
        boxs(1, "添加新闻类别失败");
    }
}
//编辑新闻类别
function editntname(ntid, newstype) {
    $("editntname").value = newstype;
    $("editntid").value = ntid;
    ShowPageDiv("editnewstype", 350, 200);
}

function editnewstype() {
    var ntid = $("editntid").value;
    var newstype = escape($("editntname").value);
    var url = "/WebServices/ManagerS.asmx/editnewstype";
    var parms = "{'ntid':'" + ntid + "','s_newstype':'" + newstype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editnewstypestate, null, null, false);
}
function editnewstypestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑新闻类别成功！");
    }
    else {
        boxs(1, "编辑新闻类别失败");
    }
}

//删除新闻类别
function delnewstype(ntid) {
    var url = "/WebServices/ManagerS.asmx/delnewstype";
    var parms = "{'ntid':'" + ntid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delnewstypestate, null, null, false);

}
function delnewstypestate(result) {
    if (result == "t") {
        boxs(1, "删除新闻类别成功！");
    }
    else {
        boxs(1, "删除新闻类别失败");
    }
}

//删除新闻
function delnews(newsid,page) {
    var url = "/WebServices/ManagerS.asmx/delnews";
    var parms = "{'newsid':'" + newsid + "','page':'" + page + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delnewsstate, null, null, false);

}
function delnewsstate(result) {
    if (result != "f") {
        location.href = "/Manager/NewsList.aspx/?page=" + result;
    }
    else {
        boxs(1, "删除新闻失败");
    }
}

//添加网站内容
function addwebsite(wsc) {
    var index = document.getElementById("wtid").selectedIndex;
    var wtid = document.getElementById("wtid").options[index].value;
    var website = escape(wsc);
    var url = "/WebServices/ManagerS.asmx/addwebsite";
    var parms = "{'wtid':'" + wtid + "','s_website':'" + website + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addwebsitestate, null, null, false);
}
function addwebsitestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "添加网站内容成功！");
    }
    else {
        boxs(1, "添加网站内容失败");
    }
}
//编辑网站内容
function editwebsite(wsc) {  
    var wsid = document.getElementById("wsid").value;
    var website = escape(wsc);
    var url = "/WebServices/ManagerS.asmx/editwebsite";
    var parms = "{'s_website':'" + website + "','wsid':'" + wsid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editwebsitestate, null, null, false);
}
function editwebsitestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑网站内容成功！");
    }
    else {
        boxs(1, "编辑网站内容失败");
    }
}

//删除内容图片
function delwebimages(wiid,page) {
    var url = "/WebServices/ManagerS.asmx/delwebimages";
    var parms = "{'wiid':'" + wiid + "','page':'" + page + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delwebimagesstate, null, null, false);

}
function delwebimagesstate(result) {
    if (result != "f") {
        location.href = "/Manager/WebImages.aspx/?page=" + result;
    }
    else {
        boxs(1, "删除图片失败");
    }
}

//添加产品大类别
function addbigcategory() {
    var bigcategory = escape($("bcname").value);
    var url = "/WebServices/ManagerS.asmx/addbigcategory";
    var parms = "{'sbigcategory':'" + bigcategory + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addbigcategorystate, null, null, false);
}
function addbigcategorystate(result) {
    if (result == "t") {
        boxs(1, "添加产品大类别成功！");
    }
    else {
        boxs(1, "添加产品大类别失败");
    }
}

//编辑产品大类别
function editbcname(bcid, bigcategory) {
    $("editbcname").value = bigcategory;
    $("editbcid").value = bcid;
    ShowPageDiv("editimagestype", 350, 200);
}

function editbigcategory() {
    var bcid = $("editbcid").value;
    var bigcategory = escape($("editbcname").value);
    var url = "/WebServices/ManagerS.asmx/editbigcategory";
    var parms = "{'bcid':'" + bcid + "','sbigcategory':'" + bigcategory + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editbigcategorystate, null, null, false);
}
function editbigcategorystate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑产品大类别成功！");
    }
    else {
        boxs(1, "编辑产品大类别失败");
    }
}

//删除产品大类别
function delbigcategory(bcid) {
    var url = "/WebServices/ManagerS.asmx/delbigcategory";
    var parms = "{'bcid':'" + bcid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delbigcategorystate, null, null, false);

}
function delbigcategorystate(result) {
    if (result == "t") {
        boxs(1, "删除产品大类别成功！");
    }
    else {
        boxs(1, "删除产品大类别失败");
    }
}

//删除产品小类别
function delsmallcategory(scid) {
    var url = "/WebServices/ManagerS.asmx/delsmallcategory";
    var parms = "{'scid':'" + scid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delsmallcategorystate, null, null, false);

}
function delsmallcategorystate(result) {
    if (result == "t") {
        boxs(1, "删除产品小类别成功！");
    }
    else {
        boxs(1, "删除产品小类别失败");
    }
}

//删除产品
function delproduct(productid,page) {
    var url = "/WebServices/ManagerS.asmx/delproduct";
    var parms = "{'productid':'" + productid + "','page':'" + page + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delproductstate, null, null, false);

}
function delproductstate(result) {
    if (result != "f") {
        location.href = "/Manager/ProductList.aspx/?page=" + result;
    }
    else {
        boxs(1, "删除产品失败");
    }
}

//改变产品状态
function ChangeSalestate(productid,state,page) {
    var url = "/WebServices/ManagerS.asmx/ChangeSalestate";
    var parms = "{'productid':'" + productid + "','state':'" + state + "','page':'" + page + "'}";
    AjaxFunction(url, parms, "post", "josn", null, ChangeSalestatestate, null, null, false);

}
function ChangeSalestatestate(result) {
    if (result != "f") {
        location.href = "/Manager/ProductList.aspx/?page=" + result;
    }
    else {
        boxs(1, "改变产品状态失败");
    }
}


//添加推荐类型
function addtjtype() {
    var tjtype = escape($("tjname").value);
    var url = "/WebServices/ManagerS.asmx/addtjtype";
    var parms = "{'tjtype':'" + tjtype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addtjtypestate, null, null, false);

}
function addtjtypestate(result) {
    if (result != "f") {
        location.href = "/Manager/TJType.aspx";
    }
    else {
        boxs(1, "添加推荐类型失败");
    }
}
//编辑推荐类型
function edittjname(tjid, tjtype) {
    $("edittjname").value = tjtype;
    $("edittjid").value = tjid;
    ShowPageDiv("editnewstype", 350, 200);
}

function edittjtype() {
    var tjid = $("edittjid").value;
    var tjtype = escape($("edittjname").value);
    var url = "/WebServices/ManagerS.asmx/edittjtype";
    var parms = "{'tjid':'" + tjid + "','tjtype':'" + tjtype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, edittjtypestate, null, null, false);

}
function edittjtypestate(result) {
    if (result != "f") {
        location.href = "/Manager/TJType.aspx";
    }
    else {
        boxs(1, "编辑推荐类型失败");
    }
}

//删除推荐类型
function deltjtype(tjid) {
    var url = "/WebServices/ManagerS.asmx/deltjtype";
    var parms = "{'tjid':'" + tjid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, deltjtypestate, null, null, false);

}
function deltjtypestate(result) {
    if (result != "f") {
        location.href = "/Manager/TJType.aspx";
    }
    else {
        boxs(1, "删除推荐类型失败");
    }
}

//添加产地类型
function addplace() {
    var place = escape($("pname").value);
    var url = "/WebServices/ManagerS.asmx/addplace";
    var parms = "{'place':'" + place + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addplacestate, null, null, false);

}
function addplacestate(result) {
    if (result != "f") {
        location.href = "/Manager/place.aspx";
    }
    else {
        boxs(1, "添加产地失败");
    }
}
//编辑产地类型
function editpname(placeid, place) {
    $("editpname").value = place;
    $("editpid").value = placeid;
    ShowPageDiv("editnewstype", 350, 200);
}

function editplace() {
    var placeid = $("editpid").value;
    var place = escape($("editpname").value);
    var url = "/WebServices/ManagerS.asmx/editplace";
    var parms = "{'placeid':'" + placeid + "','place':'" + place + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editplacestate, null, null, false);

}
function editplacestate(result) {
    if (result != "f") {
        location.href = "/Manager/place.aspx";
    }
    else {
        boxs(1, "编辑产地失败");
    }
}

//删除产地类型
function delplace(placeid) {
    var url = "/WebServices/ManagerS.asmx/delplace";
    var parms = "{'placeid':'" + placeid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delplacestate, null, null, false);

}
function delplacestate(result) {
    if (result != "f") {
        location.href = "/Manager/place.aspx";
    }
    else {
        boxs(1, "删除产地失败");
    }
}

//添加配送地址I类型
function adddeliveryI() {
    var deliveryI = escape($("dIname").value);
    var url = "/WebServices/ManagerS.asmx/adddeliveryI";
    var parms = "{'deliveryI':'" + deliveryI + "'}";
    AjaxFunction(url, parms, "post", "josn", null, adddeliveryIstate, null, null, false);

}
function adddeliveryIstate(result) {
    if (result != "f") {
        location.href = "/Manager/deliveryI.aspx";
    }
    else {
        boxs(1, "添加配送地址I失败");
    }
}
//编辑配送地址I类型
function editdIname(deliveryIid, deliveryI) {
    $("editdIname").value = deliveryI;
    $("editdIid").value = deliveryIid;
    ShowPageDiv("editnewstype", 350, 200);
}

function editdeliveryI() {
    var deliveryIid = $("editdIid").value;
    var deliveryI = escape($("editdIname").value);
    var url = "/WebServices/ManagerS.asmx/editdeliveryI";
    var parms = "{'deliveryIid':'" + deliveryIid + "','deliveryI':'" + deliveryI + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editdeliveryIstate, null, null, false);

}
function editdeliveryIstate(result) {
    if (result != "f") {
        location.href = "/Manager/deliveryI.aspx";
    }
    else {
        boxs(1, "编辑配送地址I失败");
    }
}

//删除配送地址I类型
function deldeliveryI(deliveryIid) {
    var url = "/WebServices/ManagerS.asmx/deldeliveryI";
    var parms = "{'deliveryIid':'" + deliveryIid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, deldeliveryIstate, null, null, false);

}
function deldeliveryIstate(result) {
    if (result != "f") {
        location.href = "/Manager/deliveryI.aspx";
    }
    else {
        boxs(1, "删除配送地址I失败");
    }
}

//添加配送地址II类型
function adddeliveryII() {
    var deliveryII = escape($("dIIname").value);
    var i = document.getElementById("dsselect").selectedIndex;
    var deliveryIid = document.getElementById("dsselect").options[i].value;
    var url = "/WebServices/ManagerS.asmx/adddeliveryII";
    var parms = "{'deliveryII':'" + deliveryII + "','deliveryIid':'" + deliveryIid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, adddeliveryIIstate, null, null, false);

}
function adddeliveryIIstate(result) {
    if (result != "f") {
        location.href = "/Manager/deliveryII.aspx";
    }
    else {
        boxs(1, "添加配送地址II失败");
    }
}
//编辑配送地址II类型
function editdIIname(deliveryIIid, deliveryII,deliveryIid) {
    $("editdIIname").value = deliveryII;
    $("editdIIid").value = deliveryIIid;
     var n = document.getElementById("edsselect").options.length;    
     for (var i = 0; i < n; i++) {
         if (document.getElementById("edsselect").options[i].value == deliveryIid) {
             document.getElementById("edsselect").options[i].selected = true;
         }
     }
    ShowPageDiv("editDeliveryII", 350, 450);
}

function editdeliveryII() {
    var deliveryIIid = $("editdIIid").value;
    var deliveryII = escape($("editdIIname").value);
    var i = document.getElementById("edsselect").selectedIndex;
    var deliveryIid = document.getElementById("edsselect").options[i].value;
    var url = "/WebServices/ManagerS.asmx/editdeliveryII";
    var parms = "{'deliveryIIid':'" + deliveryIIid + "','deliveryII':'" + deliveryII + "','deliveryIid':'" + deliveryIid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editdeliveryIIstate, null, null, false);

}
function editdeliveryIIstate(result) {
    if (result != "f") {
        location.href = "/Manager/deliveryII.aspx";
    }
    else {
        boxs(1, "编辑配送地址II失败");
    }
}

//删除配送地址II类型
function deldeliveryII(deliveryIIid) {
    var url = "/WebServices/ManagerS.asmx/deldeliveryII";
    var parms = "{'deliveryIIid':'" + deliveryIIid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, deldeliveryIIstate, null, null, false);

}
function deldeliveryIIstate(result) {
    if (result != "f") {
        location.href = "/Manager/deliveryII.aspx";
    }
    else {
        boxs(1, "删除配送地址II失败");
    }
}

//删除账号类型
function delaccountstype(atid) {
    var url = "/WebServices/ManagerS.asmx/delaccountstype";
    var parms = "{'atid':'" + atid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delaccountstypestate, null, null, false);

}
function delaccountstypestate(result) {
    if (result != "f") {
        location.href = "/Manager/AccountsType.aspx";
    }
    else {
        boxs(1, "删除账号类型失败");
    }
}

//根据用户名称或EMAIL搜索用户
function searchbyuserinfo() {
    var uinfo = escape($("uinfo").value);
    window.location = ("/Manager/userlist.aspx/?uinfo=" + uinfo);
}
//根据用户类型搜索用户
function searchbyaccountstype() {
    var i = $("atselect").selectedIndex;
    var atid = $("atselect").options[i].value;
    window.location = ("/Manager/userlist.aspx/?atid=" + atid);
}

//删除用户
function deluser(userid,page) {
    var url = "/WebServices/ManagerS.asmx/deluser";
    var parms = "{'userid':'" + userid + "','page':'" + page + "'}";
    AjaxFunction(url, parms, "post", "josn", null, deluserstate, null, null, false);

}
function deluserstate(result) {
    if (result != "f") {
        location.href = "/Manager/userlist.aspx?page="+result;
    }
    else {
        boxs(1, "删除用户失败");
    }
}

//编辑用户
function edituser(userid) {
    var url = "/WebServices/ManagerS.asmx/bandedituser";
    var parms = "{'userid':'" + userid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, edituserinfostate, null, null, false);

}
function edituserinfostate(result) {
    if (result != "f") {
        document.getElementById("fccontent").innerHTML = result;
        ShowPageDiv("editorderdiv", 350, 220);
    }
    else {
        HideMsg();
    }
}

function edituserat(userid) {
    var i1 = $("eatselect").selectedIndex;
    var d1 = $("eatselect").options[i1].value;
    var url = "/WebServices/ManagerS.asmx/edituserinfo";
    var parms = "{'userid':'" + userid + "','atid':'" + d1 + "'}";
    AjaxFunction(url, parms, "post", "josn", null, edituseratstate, null, null, false);
}
function edituseratstate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1,"编辑账号类型成功！");
    }
    else {
        HideMsg();
        boxs(1, "编辑账号类型失败");
    }
}

//根据产品名称搜索产品
function searchbyproductinfo() {
    var pinfo = escape($("pinfo").value);
    window.location = ("/Manager/ProductList.aspx/?pinfo=" + pinfo);
}
//根据大目录搜索产品
function searchbybigcategory() {
    var i = $("bcselect").selectedIndex;
    var bcid = $("bcselect").options[i].value;
    window.location = ("/Manager/ProductList.aspx/?bcid=" + bcid);
}
//根据上架情况搜索产品
function searchbypstate() {
    var i = $("pstate").selectedIndex;
    var state = $("pstate").options[i].value;
    window.location = ("/Manager/ProductList.aspx/?state=" + state);
}