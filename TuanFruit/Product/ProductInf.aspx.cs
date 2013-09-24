using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Models;
using Morrison.Helper;
using System.Text;

namespace TuanFruit.Product
{
    public partial class ProductInf : System.Web.UI.Page
    {
        protected productinfo pDATA;
        protected string pTitleHTML;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["productid"] != null&&RouteData.Values["productid"].ToString()!="0")
            {
                int nid =TypeParse.DbObjToInt(RouteData.Values["productid"].ToString(),0);
                productinfo item = product.getproductinfo(nid);
                pTitleHTML = item.productname;
                pDATA = item;

                //添加浏览历史

                if (Request.Cookies["tfviewhistory"] != null)
                {
                    string vhstr = Request.Cookies["tfviewhistory"].Value.ToString();
                    string[] vh = vhstr.Split(',');
                    int q = 0;
                    for (int p = 0; p < vh.Length; p++)
                    {
                        if (nid.ToString() == vh[p])
                        {
                            q = 1;
                        }
                    }
                    if (q == 0)
                    {
                        vhstr += "," + nid;
                        Response.Cookies["tfviewhistory"].Value = vhstr;
                        Response.Cookies["tfviewhistory"].Expires = DateTime.Now.AddDays(30);
                    }

                }
                else
                {
                    HttpCookie vcookie = new HttpCookie("tfviewhistory");
                    vcookie.Expires = DateTime.Now.AddDays(30);
                    vcookie.Value = nid.ToString();
                    Response.Cookies.Add(vcookie);
                }
              
            }
            else
            {
                Response.Redirect("/PList");
            }     

        }
    }
}