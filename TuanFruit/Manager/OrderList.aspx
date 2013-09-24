<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="TuanFruit.Manager.OrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>团水果订单系统</title>
    <link href="/Styles/m_order.css" type="text/css" rel="Stylesheet" />
    <link href="/Styles/pagecss.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="/Scripts/comm.js"></script>
    <script type="text/javascript" src="/Scripts/MyDialog.js"></script>
    <script type="text/javascript" src="/Scripts/m_order.js"></script>
    <script src="/My97DatePicker/WdatePicker.js" charset="gb2312" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="searchDH">
            <p class="dh_p1">
                <a href="/OL/?type=1&n=1" id="id1" runat="server">今日配货明细</a><a href="/OL/?type=1&n=2"
                    id="id2" runat="server">今日配货订单</a><a href="/OL/?type=1&n=3" id="id3" runat="server">今日下单明细</a><a
                        href="/OL/?type=1&n=4" id="id4" runat="server">本月下单明细</a></p>
            <p class="dh_p1">
                <a href="/OL/?type=1&n=5" id="id5" runat="server">所有订单明细</a><a href="/OL/?type=1&n=6"
                    id="id6" runat="server">进行中订单</a><a href="/OL/?type=1&n=7" id="id7" runat="server">已完成订单</a><a
                        href="/OL/?type=1&n=8" id="id8" runat="server">待处理订单</a></p>
            <p class="dh_p2">
                <span class="fb">下单日期：</span>从<input type="text" class="dh_p2_txt" id="od1" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    readonly="readonly" />
                至<input type="text" class="dh_p2_txt" id="od2" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    readonly="readonly" />&nbsp;&nbsp;状态：<select id="ostateselect"><option value="1000">
                        不限</option>
                        <option value="0">进行中订单</option>
                        <option value="10">已完成订单</option>
                        <option value="44">待处理订单</option>
                    </select>&nbsp;&nbsp;大区:<%=d1sbHTML %>&nbsp;&nbsp;<label id="odIidlabel">小区:<select
                        id="odIIid"><option value="0">不限</option>
                    </select></label>&nbsp;&nbsp;<input type="button" value="生成数据" onclick="searchod()" /></p>
            <p class="dh_p2">
                <span class="fb">送货日期：</span>从<input type="text" class="dh_p2_txt" id="pod1" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    readonly="readonly" />
                至<input type="text" class="dh_p2_txt" id="pod2" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    readonly="readonly" />&nbsp;&nbsp;状态：<select id="postateselect"><option value="1000">不限</option>
                        <option value="0">进行中订单</option>
                        <option value="10">已完成订单</option>
                        <option value="44">待处理订单</option>
                    </select>&nbsp;&nbsp;大区:<%=podsbHTML %>&nbsp;&nbsp;<label id="podIidlabel">小区:<select id="podIIid"><option
                        value="0">不限</option>
                    </select></label>&nbsp;&nbsp;<input type="button" value="生成数据" onclick="searchpod()" /></p>
            <p class="dh_p2">
                <span class="fb">配货总量：</span>从<input type="text" class="dh_p2_txt" id="phod1" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    readonly="readonly" />
                至<input type="text" class="dh_p2_txt" id="phod2" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    readonly="readonly" />&nbsp;&nbsp;状态：<select id="phostateselect"><option value="1000">不限</option>
                        <option value="0">进行中订单</option>
                        <option value="10">已完成订单</option>
                        <option value="44">待处理订单</option>
                    </select>&nbsp;&nbsp;大区:<%=phodsbHTML %>&nbsp;&nbsp;<label id="phodIidlabel">小区:<select id="phodIIid"><option
                        value="0">不限</option>
                    </select></label>&nbsp;&nbsp;<input type="button" value="生成数据" onclick="searchphod()" /></p>
            <p class="dh_p3">
                <span class="fb">订单编号：</span><input type="text" class="dh_p3_txt" id="ordernumber" />&nbsp;&nbsp;<input
                    type="button" value="生成数据" onclick="searchbyordernumber()" />&nbsp;&nbsp;<span class="fb">收货人：</span><input
                        type="text" id="txtcontact" class="dh_p3_txt" />&nbsp;&nbsp;<input type="button"
                            value="生成数据" onclick="searchbycontact()" /></p>
        </div>
        <div class="dayin">
            <input type="button" value="打印数据" onclick="doPrint()" />
        </div>
        <div class="dayin_area" id="dayin_area">
            <%=dyHTML %>
            <%--  <h2>今日（2012-10-03）配货订单</h2>       
           <table width="100%" border="0" cellspacing="1" cellpadding="0" class="otb">
                            <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td colspan="6" style="padding-left: 10px;">
                                    订单编号：1234567890923456789856789&nbsp;&nbsp;下单日期：2012-10-01 12:12:12&nbsp;&nbsp;送货日期：2012-10-02
                                </td>                                                           
                            </tr> 
                             <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td colspan="6" style="padding-left: 10px;">
                                    收货人：吴孟圣&nbsp;&nbsp;手机号码：13761027508&nbsp;&nbsp;固定电话:021-23456789
                                </td>                                                           
                            </tr>  
                             <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td colspan="3" style="padding-left: 10px;">
                                    地址：上海市徐汇区虹梅路999弄601室（华美花苑）
                                </td>
                                <td colspan="2" align="center">
                                    产品总额：￥500.00元
                                </td>
                                <td align="center">
                                    应付总额：<span class="fb red">￥490.00元</span>
                                </td>                               
                            </tr>  
                             <tr style="height: 30px; line-height: 30px; background-color:#efefef">
                                <td style="padding-left: 10px;">
                                    序号
                                </td>
                                <td align="center">
                                    产品图片
                                </td>
                                <td align="center">
                                    产品名称
                                </td>  
                                <td align="center">
                                    购买数量
                                </td>  
                                <td align="center">
                                    产品单价
                                </td>
                                <td align="center">
                                    小计
                                </td>                                 
                            </tr>  
                             <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td style="padding-left: 10px;">
                                    1
                                </td>
                                <td align="center" class="oimg">
                                    <a href=""><img src="../Files/Product/634827953242189679.png" /></a>
                                </td>
                                <td align="center">
                                    新西兰猕猴桃、品质最高、盒装送礼佳品
                                </td>  
                                <td align="center">
                                    2
                                </td>  
                                <td align="center">
                                    198.00
                                </td>
                                <td align="center">
                                    396.00
                                </td>                                 
                            </tr>                
                              <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td style="padding-left: 10px;">
                                    1
                                </td>
                                <td align="center" class="oimg">
                                    <a href=""><img src="../Files/Product/634827953242189679.png" /></a>
                                </td>
                                <td align="center">
                                    新西兰猕猴桃、品质最高、盒装送礼佳品
                                </td>  
                                <td align="center">
                                    2
                                </td>  
                                <td align="center">
                                    198.00
                                </td>
                                <td align="center">
                                    396.00
                                </td>                                 
                            </tr>                                                
                        </table>
           <table width="100%" border="0" cellspacing="1" cellpadding="0" class="otb">
                            <tr style="height: 30px; line-height: 30px; background-color:#efefef">
                                <td  style="padding-left: 10px;">
                                    产品编号
                                </td>  
                                 <td  style="padding-left: 10px;">
                                    产品名称
                                </td> 
                                 <td  style="padding-left: 10px;">
                                    产品图片
                                </td> 
                                 <td  style="padding-left: 10px;">
                                    配货数量
                                </td> 
                                 <td  style="padding-left: 10px;">
                                    配货日期
                                </td>                                                         
                            </tr>  
                             <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td style="padding-left: 10px;">
                                    1
                                </td>
                                <td align="center" class="oimg">
                                    <a href=""><img src="../Files/Product/634827953242189679.png" /></a>
                                </td>
                                <td align="center">
                                    新西兰猕猴桃、品质最高、盒装送礼佳品
                                </td>  
                                <td align="center">
                                    90
                                </td>  
                                <td align="center">
                                    2012-10-03
                                </td>                                                               
                            </tr>  
                             <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td style="padding-left: 10px;">
                                    1098765434567876
                                </td>
                                <td align="center" class="oimg">
                                    <a href=""><img src="../Files/Product/634827953242189679.png" /></a>
                                </td>
                                <td align="center">
                                    新西兰猕猴桃、品质最高、盒装送礼佳品
                                </td>  
                                <td align="center">
                                    90
                                </td>  
                                <td align="center">
                                    2012-10-03
                                </td>                                                               
                            </tr>                          
                                                                            
                        </table>

           <h2>今日（2012-10-03）浦东配货订单</h2> 
           <table width="100%" border="0" cellspacing="1" cellpadding="0" class="otb">
                            <tr style="height: 30px; line-height: 30px; background-color:#efefef">
                                <td  style="padding-left: 10px;">
                                    产品编号
                                </td>  
                                 <td  style="padding-left: 10px;">
                                    产品名称
                                </td> 
                                 <td  style="padding-left: 10px;">
                                    产品图片
                                </td> 
                                 <td  style="padding-left: 10px;">
                                    配货数量
                                </td> 
                                 <td  style="padding-left: 10px;">
                                    配货日期
                                </td>                                                         
                            </tr>  
                             <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td style="padding-left: 10px;">
                                    1
                                </td>
                                <td align="center" class="oimg">
                                    <a href=""><img src="../Files/Product/634827953242189679.png" /></a>
                                </td>
                                <td align="center">
                                    新西兰猕猴桃、品质最高、盒装送礼佳品
                                </td>  
                                <td align="center">
                                    90
                                </td>  
                                <td align="center">
                                    2012-10-03
                                </td>                                                               
                            </tr>  
                             <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td style="padding-left: 10px;">
                                    1098765434567876
                                </td>
                                <td align="center" class="oimg">
                                    <a href=""><img src="../Files/Product/634827953242189679.png" /></a>
                                </td>
                                <td align="center">
                                    新西兰猕猴桃、品质最高、盒装送礼佳品
                                </td>  
                                <td align="center">
                                    90
                                </td>  
                                <td align="center">
                                    2012-10-03
                                </td>                                                               
                            </tr>                          
                                                                            
                        </table>
           <h2>今日（2012-10-03）浦西配货订单</h2> 
           <table width="100%" border="0" cellspacing="1" cellpadding="0" class="otb">
                            <tr style="height: 30px; line-height: 30px; background-color:#efefef">
                                <td  style="padding-left: 10px;">
                                    产品编号
                                </td>  
                                 <td  style="padding-left: 10px;">
                                    产品名称
                                </td> 
                                 <td  style="padding-left: 10px;">
                                    产品图片
                                </td> 
                                 <td  style="padding-left: 10px;">
                                    配货数量
                                </td> 
                                 <td  style="padding-left: 10px;">
                                    配货日期
                                </td>                                                         
                            </tr>  
                             <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td style="padding-left: 10px;">
                                    1
                                </td>
                                <td align="center" class="oimg">
                                    <a href=""><img src="../Files/Product/634827953242189679.png" /></a>
                                </td>
                                <td align="center">
                                    新西兰猕猴桃、品质最高、盒装送礼佳品
                                </td>  
                                <td align="center">
                                    90
                                </td>  
                                <td align="center">
                                    2012-10-03
                                </td>                                                               
                            </tr>  
                             <tr style="height: 30px; line-height: 30px; background-color:#fff">
                                <td style="padding-left: 10px;">
                                    1098765434567876
                                </td>
                                <td align="center" class="oimg">
                                    <a href=""><img src="../Files/Product/634827953242189679.png" /></a>
                                </td>
                                <td align="center">
                                    新西兰猕猴桃、品质最高、盒装送礼佳品
                                </td>  
                                <td align="center">
                                    90
                                </td>  
                                <td align="center">
                                    2012-10-03
                                </td>                                                               
                            </tr>                          
                                                                            
                        </table>--%>
        </div>
        <div class="digg2" id="digg2">
            <%=pageHTML%>
        </div>
        <div id="editorderdiv">
            <div class="tempclose">
                <a href="#" onclick="HideMsg()" title="关闭">关闭</a>
            </div>
            <div class="fccontent" id="fccontent">
            </div>
        </div>
        <span id="boxs"></span>
    </div>
    </form>
</body>
</html>
