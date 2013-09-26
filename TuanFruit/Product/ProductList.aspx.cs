using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;

namespace TuanFruit.Product
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected string productlistHTML;
        protected string pageHTML;
        protected string ptypeHTML="所有产品";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int page = 1;
                if (Request.QueryString["page"] != null)
                {
                    page = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                }
                pageinfo pdata = new pageinfo();
                pdata.curpageindex = page;
                pdata.pagesize = 20;
                if (RouteData.Values["bcid"] != null && RouteData.Values["bcid"].ToString() != "0")
                {
                    pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.bigcategoryid="+RouteData.Values["bcid"].ToString();
                    pdata.recordcount = product.getproductcountbycondition("product.bigcategoryid=" + RouteData.Values["bcid"].ToString());
                    categoryinfo data=category.getbigcategoryinfo(TypeParse.DbObjToInt(RouteData.Values["bcid"].ToString(),0));
                    ptypeHTML = data.bigcategory;
                }
                else if (RouteData.Values["scid"] != null && RouteData.Values["scid"].ToString() != "0")
                {
                    pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.smallcategoryid=" + RouteData.Values["scid"].ToString();
                    pdata.recordcount = product.getproductcountbycondition("product.smallcategoryid=" + RouteData.Values["scid"].ToString());
                    categoryinfo data = category.getsmallcategoryinfo(TypeParse.DbObjToInt(RouteData.Values["scid"].ToString(), 0));
                    ptypeHTML = data.smallcategory;
                }
                else if (RouteData.Values["placeid"] != null && RouteData.Values["placeid"].ToString() != "0")
                {
                    pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.placeid=" + RouteData.Values["placeid"].ToString();
                    pdata.recordcount = product.getproductcountbycondition("product.placeid=" + RouteData.Values["placeid"].ToString());
                    categoryinfo data = category.getplaceinfo(TypeParse.DbObjToInt(RouteData.Values["placeid"].ToString(), 0));
                    ptypeHTML ="水果产地:"+ data.place;
                }
                else if (RouteData.Values["price"] != null && RouteData.Values["price"].ToString() != "0")
                {
                    switch (RouteData.Values["price"].ToString())
                    {
                        case "1":
                            pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.vipprice>0 and product.vipprice<=50";
                            pdata.recordcount = product.getproductcountbycondition("product.vipprice>0 and product.vipprice<=50");
                            ptypeHTML = "价格0到50元水果";
                            break;
                        case "2":
                            pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.vipprice>50 and product.vipprice<=100";
                            pdata.recordcount = product.getproductcountbycondition("product.vipprice>50 and product.vipprice<=100");
                            ptypeHTML = "价格50到100元水果";
                            break;
                        case "3":
                            pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.vipprice>100 and product.vipprice<=200";
                            pdata.recordcount = product.getproductcountbycondition("product.vipprice>100 and product.vipprice<=200");
                            ptypeHTML = "价格100到200元水果";
                            break;
                        case "4":
                            pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.vipprice>200 and product.vipprice<=500";
                            pdata.recordcount = product.getproductcountbycondition("product.vipprice>200 and product.vipprice<=500");
                            ptypeHTML = "价格200到500元水果";
                            break;
                        case "5":
                            pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.vipprice>500";
                            pdata.recordcount = product.getproductcountbycondition("product.vipprice>500");
                            ptypeHTML = "价格500元以上水果";
                            break;
                        default:
                            pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid";
                            pdata.recordcount = product.getproductcount();                           
                            break;
                    }

                }
                else if (RouteData.Values["pname"] != null && RouteData.Values["pname"].ToString() != "")
                {
                    string pname=RouteData.Values["pname"].ToString();
                    pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and place.placeid=product.placeid and product.productname like'%" + RouteData.Values["pname"].ToString()+"%'";
                    pdata.recordcount = product.getproductcountbycondition("product.productname like '%" + RouteData.Values["pname"].ToString()+"%'");
                    categoryinfo data = category.getplaceinfo(TypeParse.DbObjToInt(RouteData.Values["placeid"].ToString(), 0));
                    ptypeHTML = "商品名称:" +pname ;
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
                    string template = "<div class=\"productlistli\"><a href=\"/PInfo/{0}.html\" class=\"plistimg\" title=\"{1}\" target=\"_blank\"><img src=\"/Files/Product/{2}\" /></a> <a href=\"/PInfo/{3}.html\" class=\"plisttitle\" title=\"{4}\"  target=\"_blank\">{5}</a> <a href=\"/PInfo/{6}.html\" class=\"plistsite\"  target=\"_blank\">规格:{7}</a>  <a href=\"/PInfo/{8}.html\" class=\"plistprice\"  target=\"_blank\"><span class=\"pricecss1\">￥{9}</span><span class=\"pricecss2\">￥{10}</span>{11}</a></div>";
                    sb.AppendFormat(template,item.productid,item.productname, item.productimg,item.productid, item.productname,comm.SubStr(item.productname,15),item.productid,item.punit,item.productid,item.productprice,item.vipprice,item.salestate == 1 ? "<span class=\"sstate\">已售完</span>" : "");
                }
                productlistHTML = sb.ToString();
                pageHTML = pagehelper.Pager(pdata.curpageindex, pdata.pagesize, pdata.recordcount, PageMode.Numeric, 5);
            }

        }
    }
}