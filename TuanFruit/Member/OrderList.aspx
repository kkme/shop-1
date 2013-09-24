<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Member.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="TuanFruit.Member.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/user.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/comm.js" language="javascript" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="memberright">
        <div class="memberright">
            <div class="mt01">
                <%=orderh3HTML%></div>
            <div class="mc">
                <div class="hy_table01 mt10">
                    <%--<div class="hy_table01_bg-f3">
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
                       
                    </div>--%>
                    <%=orderlistHTML %>
                     <div class="digg2">
                            <%=pageHTML%>
                        </div>
                </div>
            </div>           
        </div>
    </div>
    <span id="boxs"></span>
</asp:Content>

