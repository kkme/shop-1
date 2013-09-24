function changeproducttab(i, len, gyid) {
    for (var k = 0; k < len; k++) {
        if (k == i) {
            document.getElementById("gyC" + k).className = "on";
            var url = "/WebServices/ProductS.asmx/bandproducttab";
            var parms = "{'gyid':'" + gyid + "'}";
            createcookie('gyid', gyid);
            createcookie('tabnum', i);
            AjaxFunction(url, parms, "post", "josn", null, changeproducttabstate, null, null, false);
        }
        else {
            document.getElementById("gyC" + k).className = "normal";
        }
    }
}
function changeproducttabstate(result) {
    document.getElementById("product_left_bannerC").innerHTML = result;
}