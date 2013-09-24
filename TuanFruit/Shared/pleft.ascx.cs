using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;

namespace TuanFruit.Shared
{
    public partial class pleft : System.Web.UI.UserControl
    {
        protected string categorysbHTML;
        protected string img2HTML;
        protected string vhHTML="暂无记录";
        protected void Page_Load(object sender, EventArgs e)
        {
            //产品类别
            List<categoryinfo> bigcategorylist = category.getbigcategory();
            StringBuilder categorysb = new StringBuilder();
            int bint = bigcategorylist.Count;
            for (int i = 0; i < bint; i++)
            {
                string btem = " <h3><span class=\"bcimg\"></span><a href=\"/PList/{0}\">{1}</a></h3><ul>";
                categorysb.AppendFormat(btem, bigcategorylist[i].bigcategoryid, bigcategorylist[i].bigcategory);
                List<categoryinfo> smallcategorylist = category.getsmallcategorybyid(bigcategorylist[i].bigcategoryid);
                foreach (categoryinfo item1 in smallcategorylist)
                {
                    string template = "<li><span class=\"plist_ponit\"></span><a href=\"/PList/0/{0}\">{1}</a></li>";
                    categorysb.AppendFormat(template, item1.smallcategoryid, item1.smallcategory);
                }
                categorysb.Append("</ul>");
            }
            categorysbHTML = categorysb.ToString();

            //两个广告图片
            List<webimagesinfo> img4list = webimages.bindwebimages(2, "首页4图片");
            StringBuilder img4sb = new StringBuilder();
            for (int k = 0; k < img4list.Count; k++)
            {
                string template;
                template = "<a href=\"{0}\"><img src=\"/Files/WebImages/{1}\" /></a>";

                img4sb.AppendFormat(template, img4list[k].imgurl, img4list[k].imgname);
            }
            img2HTML = img4sb.ToString();

            //绑定浏览记录
            if (Request.Cookies["tfviewhistory"] != null)
            {
                string vhc = Request.Cookies["tfviewhistory"].Value.ToString();
                StringBuilder vhsb = new StringBuilder();
                List<productinfo> vhlist = product.bindproductlistvh(10, vhc);
                for (int m = vhlist.Count - 1; m >=0; m--)
                {
                    string template = "<div class=\"view_li\"><a href=\"/PInfo/{0}.html\" target=\"_blanm\" class=\"simg\"><img src=\"/Files/Product/{1}\" alt=\"{2}\" /></a><ul><li><a href=\"/PInfo/{3}.html\" title=\"{4}\" class=\"tl\" target=\"_blanm\">{5}</a></li><li><a href=\"/PInfo/{6}.html\" class=\"tl\" target=\"_blanm\">￥：<span class=\"red\">{7}元</span></a></li><li><a  href=\"/PInfo/{8}.html\" class=\"tl\" target=\"_blanm\">类别：{9}</a></li></ul></div>";
                    vhsb.AppendFormat(template, vhlist[m].productid, vhlist[m].productimg, vhlist[m].productname, vhlist[m].productid, vhlist[m].productname, comm.SubStr(vhlist[m].productname, 10), vhlist[m].productid, vhlist[m].productprice, vhlist[m].productid, vhlist[m].smallcategory);

                }
                vhHTML = vhsb.ToString();
            }

        }
    }
}