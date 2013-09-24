function clicksearch() {
    if (document.getElementById("searchpname").value == "请输入商品名称") {
        document.getElementById("searchpname").value = "";
    }
}
function blursearch() {
    if (document.getElementById("searchpname").value == "") {
        document.getElementById("searchpname").value = "请输入商品名称";
    }
}
function searchproduct() {
    if (document.getElementById("searchpname").value == "请输入商品名称") {
        location.href = "/PList";
    }
    else {
        var stxt = document.getElementById("searchpname").value;
        location.href = "/PList/0/0/0/0/"+stxt;
    }
}