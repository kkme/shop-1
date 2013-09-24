//遮罩层
var maskObj = null;
//遮罩层上的内容
var tempdiv = null;
//遮照层的宽和高
var sWidth, sHeight;
//内容层的宽和高
var cWidth, cHeight, cTop = 0;

//窗体大小发生变化时改变遮照层的大小
window.onresize = function() {
    changelocation();
}

function changelocation() {
    sWidth = document.documentElement.offsetWidth;
    sHeight = document.body.scrollHeight; //13; 

    if (sHeight < window.screen.availHeight)
        sHeight = window.screen.availHeight - 20;

    cTop = document.documentElement.scrollTop +
    document.documentElement.clientHeight / 2 - 100;
    if (!maskObj || !tempdiv) return;
    maskObj.style.width = sWidth + "px";
    maskObj.style.height = sHeight + "px";
    tempdiv.style.left = (sWidth - cWidth) / 2 + "px";
    tempdiv.style.top = cTop + "px";
}


//创建遮罩层
function AlertMsg(pagediv) {
    pagediv.style.display = "block";
    cWidth = pagediv.clientWidth;
    cHeight = pagediv.clientHeight;
    changelocation();

    if (maskObj == null) {
        //创建遮罩背景
        maskObj = document.createElement("div");
        maskObj.setAttribute('id', 'BigDiv');
        maskObj.style.position = "absolute";
        maskObj.style.top = "0";
        maskObj.style.left = "0";
        maskObj.style.background = "#777";
        maskObj.style.filter = "Alpha(opacity=80);";
        maskObj.style.opacity = "0.8";
        maskObj.style.width = sWidth + "px";
        maskObj.style.height = sHeight + "px";
        maskObj.style.zIndex = "10000";
        document.body.appendChild(maskObj);
    }
    else
        maskObj.style.display = "block";

    if (tempdiv == null) {
        tempdiv = document.createElement("div");
        tempdiv.setAttribute('id', 'addImage');
        tempdiv.style.left = (sWidth - cWidth) / 2 + "px"; //650
        tempdiv.style.top = cTop + "px"; //409
        tempdiv.style.width = cWidth + "px"; //"655px";
        tempdiv.style.height = cHeight + "px"; //"347px";
        tempdiv.style.position = "absolute";
        tempdiv.style.filter = "Alpha(opacity=100);";
        tempdiv.style.opacity = "1";
        tempdiv.style.backgroundColor = "#fff";
        tempdiv.style.zIndex = "10001";
        tempdiv.style.textAlign = "center";
        document.body.appendChild(tempdiv);
    }
    else
        tempdiv.style.width = cWidth + "px"; //"655px";
    tempdiv.style.height = cHeight + "px"; //"347px";
    tempdiv.style.display = "block";

    if (pagediv)
        tempdiv.appendChild(pagediv);
}

function ShowPageDiv(divid, width, height) {
    AlertMsg($(divid));
}

/*********************** www专用 ***********************/
//文字提示框
function ShowTextDialog(textinfo) {
    cWidth = 384;
    cHeight = 144;
    AlertMsg();
    tempdiv.innerHTML = "<dl><dt><img src=\"images/a1.gif\" width=\"71\" height=\"80\" /></dt>" + "<dd><div id=\"showyminfo\">" + textinfo + "</div><br />" + "<img src=\"images/a3.jpg\" width=\"86px\" height=\"29px\" style=\"cursor:hand\" onclick=\"HideMsg();\" /></dd>" + "</dl></div>";
}
//进度框
function ShowProgress() {
    cWidth = 384;
    cHeight = 144;
    AlertMsg();
    tempdiv.innerHTML = "<dl><dt></dt><dd><img src=\"images/05043119.gif\" /><br />正在加载，请耐心等候....</dd></dl>";
}
/*******************************************************/

//隐藏
function HideMsg() {
    if (tempdiv) {
        tempdiv.style.display = "none";
        if (tempdiv.childNodes.length > 0) {
            tempdiv.childNodes[0].style.display = "none";
            document.body.appendChild(tempdiv.childNodes[0]);
            tempdiv.innerHTML = "";
        }
    }
    if (maskObj) maskObj.style.display = "none";
}