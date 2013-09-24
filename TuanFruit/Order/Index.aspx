<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TuanFruit.Order.Index" %>

<%@ Register Src="/Shared/top.ascx" TagPrefix="UCTop" TagName="TopUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCFooter" TagName="FooterUC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商品订单确定页面</title>
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
             <%=logoimgHTML%><img src="/Images/orderlc.jpg" alt="" /><input type="hidden" id="uid" value="<%=uidValue %>" />
          </div>
            <div id="orderheader">
                填写订单核对信息</div>
            <div id="ordercontent">
                <div id="orderaddress">
                    <div id="orderaddress1" class="orderaddress1">
                    <%=addressHTML %>
                       <%-- <h3>
                            收货人信息 <a href="">[修改信息]</a></h3>
                        <table cellpadding="0" cellspacing="0" border="0" class="ordertb">
                            <tr>
                                <td class="tdleft">
                                    收 货 人：
                                </td>
                                <td>
                                    吴孟圣
                                </td>
                            </tr>
                            <tr>
                                <td class="tdleft">
                                    配送大区：
                                </td>
                                <td>
                                    上海浦西
                                </td>
                            </tr>
                            <tr>
                                <td class="tdleft">
                                    配送小区：
                                </td>
                                <td>
                                    港汇片区
                                </td>
                            </tr>
                            <tr>
                                <td class="tdleft">
                                    详细地址：
                                </td>
                                <td>
                                    上海市徐汇区虹梅路999弄601室
                                </td>
                            </tr>
                            <tr>
                                <td class="tdleft">
                                    手机号码：
                                </td>
                                <td>
                                    13761027508
                                </td>
                            </tr>
                            <tr>
                                <td class="tdleft">
                                    固定电话：
                                </td>
                                <td>
                                    021-89898989
                                </td>
                            </tr>
                        </table>--%>
                    </div>
                  <%--   <div id="orderaddress2" class="orderaddress1">
                        <h3>
                            收货地址列表 <a href="">[关闭]</a></h3> 
                             <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ptb">
                        <tr class="ptr">
                            <td width="5%">
                                &nbsp;
                            </td>
                            <td width="10%" align="center">
                                联系人
                            </td>
                            <td width="10%" align="center">
                                手机号码
                            </td>
                            <td width="10%" align="center">
                                固定电话
                            </td>
                            <td width="10%" align="center">
                                配送大区
                            </td>
                            <td width="10%" align="center">
                                配送小区
                            </td>
                            <td width="35%" align="center">
                                详细地址
                            </td>
                            <td width="10%" align="center">
                                操作
                            </td>
                        </tr>
                        <tr class="addresstr">
                            <td width="5%" align="center">
                                <input type="checkbox" name="cname" />
                            </td>
                            <td width="10%" align="center">
                                吴孟圣
                            </td>
                            <td width="10%" align="center">
                                13761027508
                            </td>
                            <td width="10%" align="center">
                                021-98786787
                            </td>
                            <td width="10%" align="center">
                                上海浦西
                            </td>
                            <td width="10%" align="center">
                                万体馆
                            </td>
                            <td width="35%" align="center">
                                上海市虹梅路999弄34号601室
                            </td>
                            <td width="10%" align="center">
                                <a href="">编辑</a>  <a href="">删除</a>
                            </td>
                        </tr>
                        <tr class="addresstr">
                            <td width="5%">
                                <input type="checkbox" name="cname" />
                            </td>
                            <td width="10%" align="center">
                                吴孟圣
                            </td>
                            <td width="10%" align="center">
                                13761027508
                            </td>
                            <td width="10%" align="center">
                                021-98786787
                            </td>
                            <td width="10%" align="center">
                                上海浦西
                            </td>
                            <td width="10%" align="center">
                                万体馆
                            </td>
                            <td width="15%" align="center">
                                上海市虹梅路999弄34号601室
                            </td>
                            <td width="10%" align="center">
                                <a href="">编辑</a>  <a href="">删除</a>
                            </td>
                        </tr>
                    </table>     
                    <p><input type="button" value="选择地址" class="orderbtn" /></p>                  
                    </div>
                     <div id="orderaddress3" class="orderaddress1">
                        <h3>
                            修改收货地址 <a href="">[关闭]</a></h3>
                        <table cellpadding="0" cellspacing="0" border="0" class="ordertb">
                            <tr>
                                <td class="tdleft">
                                    收 货 人：
                                </td>
                                <td>
                                    <input type="text" class="ordertxt" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdleft">
                                    配送大区：
                                </td>
                                <td>
                                    <select  class="orderselect" onchange=""><option value="0">上海浦东</option><option value="0">上海浦西</option></select>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdleft">
                                    配送小区：
                                </td>
                                <td>
                                     <select  class="orderselect"><option value="0">港汇</option><option value="0">陆家嘴</option></select>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdleft">
                                    详细地址：
                                </td>
                                <td>
                                     <input type="text"  class="ordertxt" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdleft">
                                    手机号码：
                                </td>
                                <td>
                                     <input type="text"  class="ordertxt"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdleft">
                                    固定电话：
                                </td>
                                <td>
                                    <input type="text"  class="ordertxt"/>
                                </td>
                            </tr>
                        </table>
                         <p><input type="button" value="确认地址"  class="orderbtn" /></p> 
                    </div>--%>
                </div>
                <div id="orderdeliverydate">
                    <h3>
                        收货日期
                    </h3>
                    <p>
                        上海配送区域内，下午4点前下订单，默认当天送货，下午4点后下订单，默认第二天送货。</p>
                    <p>
                        送货日期：<input type="text" id="deliverydate" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" value="<%=deliverydateValue %>"
                            readonly="readonly" style="width: 110px; height: 18px; border: solid 1px #cacaca;" /></p>
                </div>
                <div id="orderproduct">
                    <h3>
                        商品清单<a href="/PList">[继续添加产品到购物车]</a>
                    </h3>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ptb">
                        <tr class="ptr">
                            <td width="10%">
                                序号
                            </td>
                            <td width="20%" align="center">
                                商品图片
                            </td>
                            <td width="40%" align="center">
                                商品名称
                            </td>
                            <td width="12%" align="center">
                                商品价格
                            </td>
                            <td width="8%" align="left">
                                购买数量
                            </td>
                            <td width="10%" align="center">
                                操作
                            </td>
                        </tr>
                       <%-- <tr style="height: 60px;">
                            <td align="center">
                                100029
                            </td>
                            <td class="buyimg">
                                <a href="">
                                    <img src="../Files/Product/634827953242189679.png" alt="" /></a>
                            </td>
                            <td>
                                <a href="">美国进口猕猴桃，500G 促销300元，售完为止</a>
                            </td>
                            <td align="center">
                                102.00
                            </td>
                            <td align="center">
                                <a href="javascript:minusordernum()" class="minusbtn1">&nbsp;</a><input type="text" id="buynum" class="numtxt1" value="1" readonly="readonly" /><a href="javascript:addordernum()" class="addbtn1">&nbsp;</a>
                            </td>
                            <td align="center">
                                <a href="">删除</a>
                            </td>
                        </tr>       --%>    
                        <%=cartlistHTML %>            
                    </table>
                </div>
                <div id="ordermoney">
                    <h3>
                        结算信息</h3>
                        <p class="pallmoney">商品总额：￥<label id="pmoney"><%=pmoneyHMTL %></label></p>
                        <p class="pdiscount"><label id="dmoney"><%=dmoneyHTML %></label></p>
                        <p class="realmoney">应付金额：￥<span class="red fs16 fb"><label id="paymoney"><%=paymoneyHTML %></label></span></p>
                </div>
                <div id="adddd">
                    <a href="javascript:addorder()"><img src="/Images/adddd.jpg" alt="" /></a>
                </div>
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
