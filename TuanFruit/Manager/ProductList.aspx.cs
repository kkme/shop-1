using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Models;
using Morrison.Helper;
using System.Text;

namespace TuanFruit.Manager
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected string productlistHTML;        
        protected string pageHTML;
        protected string bcHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //大目录
                List<categoryinfo> alist = category.getbigcategory();
                StringBuilder aselectsb = new StringBuilder();
                aselectsb.Append("<select id=\"bcselect\" style=\"width:100px; border:solid 1px #cacaca; height:20px;z-index:100;\">");
                foreach (categoryinfo item in alist)
                {
                    string template = "<option value=\"{0}\">{1}</option>";
                    aselectsb.AppendFormat(template, item.bigcategoryid, item.bigcategory);
                }
                aselectsb.Append("</select>");
                bcHTML = aselectsb.ToString();

                int page = 1;
                if (Request.QueryString["page"] != null)
                {
                    page = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                }
                pageinfo pdata = new pageinfo();
                pdata.curpageindex = page;
                pdata.pagesize = 20;
                if (Request.QueryString["pinfo"] != null)
                {
                    string pname = HttpUtility.UrlDecode(Request.QueryString["pinfo"].ToString());
                    pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.productname like'%"+pname+"%'";
                    pdata.recordcount = product.getproductcountbycondition(" product.productname like '%"+pname+"%'");
                }
                else if (Request.QueryString["bcid"] != null)
                {
                    int bcid = TypeParse.DbObjToInt(Request.QueryString["bcid"].ToString(), 0);
                    pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.bigcategoryid=" +bcid;
                    pdata.recordcount = product.getproductcountbycondition(" product.bigcategoryid=" + bcid);
                }
                else if (Request.QueryString["state"] != null)
                {
                    int state = TypeParse.DbObjToInt(Request.QueryString["state"].ToString(), 0);
                    pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.salestate=" + state;
                    pdata.recordcount = product.getproductcountbycondition(" product.salestate=" + state);
                }
                else
                {
                    pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid";
                    pdata.recordcount = product.getproductcount();
                }
                    
                pdata.tablename = "smallcategory,product,bigcategory,place";
                pdata.fieldlist = "product.productid,product.productname,product.productprice,product.productcode,product.productbrief,product.productintroduce,product.vipprice,product.productimg,product.smallcategoryid,product.bigcategoryid,product.brand,product.punit,product.adddate,product.editdate,product.salestate,product.placeid,smallcategory.smallcategory,bigcategory.bigcategory,place.place";
                pdata.sorttype = 2;
                pdata.primarykey = "productid";
                pdata.totalpagecount = (pdata.recordcount % pdata.pagesize == 0 ? pdata.recordcount / pdata.pagesize : pdata.recordcount / pdata.pagesize + 1);
                if (pdata.totalpagecount == 0)
                {
                    pdata.totalpagecount = 1;
                }

                List<productinfo> list = product.getproduct(pdata);
                StringBuilder sb = new StringBuilder();
                foreach (productinfo item in list)
                {
                    string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" style=\"padding:5px 0;\"><img src=\"/Files/product/{0}\" style=\"width:120px;height:100px;\"/></div></td><td height=\"20\" bgcolor=\"#FFFFFF\" style=\"padding:0 0 0 5px;\"><div align=\"left\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" style=\"padding:0 0 0 5px;\">{2}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" style=\"padding:0 0 0 5px;\">{3}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"javascript:ChangeSalestate('{4}','{5}','{6}')\" style=\"color:blue;cursor:pointer;\">{7}</a> | <a href=\"/Manager/EditProduct.aspx/?productid={8}\" style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:delproduct('{9}','{10}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                    sb.AppendFormat(template, item.productimg, item.productname, item.vipprice, item.salestate == 0 ? "<span style=\"color:green\">销售中</span>" : "<span style=\"color:red\">已下架</span>", item.productid, item.salestate == 0 ? "1" : "0", pdata.curpageindex, item.salestate == 1 ? "上架" : "下架", item.productid, item.productid, pdata.curpageindex);
                }
                productlistHTML = sb.ToString();
                pageHTML = pagehelper.Pager(pdata.curpageindex, pdata.pagesize, pdata.recordcount, PageMode.Numeric, 5);
            }

        }
    }
}