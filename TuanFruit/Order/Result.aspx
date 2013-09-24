<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="TuanFruit.Order.Result" %>
<%@ Register Src="/Shared/top.ascx" TagPrefix="UCTop" TagName="TopUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCFooter" TagName="FooterUC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>恭喜您，订单已成功</title>
    <link href="/Styles/main.css" type="text/css" rel="Stylesheet" />
    <script src="/My97DatePicker/WdatePicker.js" charset="gb2312" type="text/javascript"></script>
     <script src="/Scripts/order.js" type="text/javascript" language="javascript"></script>
     <script src="/Scripts/comm.js" type="text/javascript" language="javascript"></script>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <div id="ordermain">
        <div id="ordermainC">
          <div class="ordertop">
             <%=logoimgHTML%><img src="../Images/orderlc.jpg" alt="" />
          </div>
            <div id="orderheader">
                订单已提交成功</div>
            <div id="ordercontent">
                  <p class="resultimg"><img src="/Images/ordersuc.jpg" alt="" /></p>                
                  <p class="resultnote">提示：您的订单在处理中，发货后会显示承运人的联系方式，如有必要，可以联系我们。</p>
                  <p class="resulta">现在您可以：<a href="/OList">查看订单</a><a href="/PList">继续购物</a><a href="/Default">返回首页</a></p>
            </div>
            <div id="footer" style="width: 888px">
                <p>
                    <a href="/Default">首页</a><a href="/WS/1.html">关于我们</a><a href="/WS/3.html">联系我们</a><a href="/PList">产品展示</a></p>
                <p>
                    Copyright 2012-<%=DateTime.Now.Year %>
                    水果网 版权所有 沪ICP备10215492号</p>
            </div>
        </div>
    </div>
     <span id="boxs"></span>
    </form>
</body>
</html>
