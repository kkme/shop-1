<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="TuanFruit.Manager.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
<p>
        <span></span>你当前位置：产品管理 - 产品列表页</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
<input id="pinfo" type="text" style="width: 180px; height: 20px;
                    border: solid 1px #cacaca" />&nbsp;<input type="button" onclick="searchbyproductinfo()"
                        value="搜索" class="btn" />&nbsp;输入产品名称&nbsp;&nbsp;<%=bcHTML%>&nbsp;<input type="button" onclick="searchbybigcategory()"
                        value="搜索" class="btn" />&nbsp;&nbsp;<select id="pstate"><option value="0">销售中</option><option value="1">已下架</option></select>&nbsp;<input type="button" onclick="searchbypstate()"
                        value="搜索" class="btn" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
        style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
        <tr>
            <td width="25%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>产品图片</span></div>
            </td>
            <td width="35%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>产品名称</span></div>
            </td>
            <td width="10%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>产品价格</span></div>
            </td> 
            <td width="10%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>产品状态</span></div>
            </td>                     
            <td width="20%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>操作</span></div>
            </td>
        </tr>
        <%=productlistHTML%>
    </table>
    <div class="digg">
        <%=pageHTML%>
    </div> 
    <span id="boxs"></span>  
</asp:Content>
