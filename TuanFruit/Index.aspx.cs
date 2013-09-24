using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Models;
using Morrison.Helper;
using System.Text;

namespace TuanFruit
{
    public partial class Index : System.Web.UI.Page
    {
        protected string hd1HTML;
        protected string hd2HTML;
        protected string pHTML;
        protected string ggHTML;
        protected string mlHTML;
        protected string cdHTML;
        protected string img4HTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //幻灯大图片绑定
                List<webimagesinfo> webimageslist = webimages.bindwebimages(5, "幻灯大图");
                StringBuilder webimagessb = new StringBuilder();
                int bimgn = webimageslist.Count;
                for (int k = 0; k < bimgn; k++)
                {
                    string template;
                    if (k == 1)
                    {
                        template = "<li style=\"display: list-item;\" class=\"b active\"><a href=\"{0}\"><img src=\"./Files/WebImages/{1}\" alt=\"\" height=\"300\" width=\"995\"></a></li>";

                    }
                    else
                    {
                        template = "<li style=\"display: none;\" class=\"b\"><a href=\"{0}\"><img src=\"./Files/WebImages/{1}\" alt=\"\" height=\"300\" width=\"995\"></a></li>";
                    }
                    webimagessb.AppendFormat(template, webimageslist[k].imgurl, webimageslist[k].imgname);
                }
                hd1HTML = webimagessb.ToString();

                //幻灯小图片绑定
                List<webimagesinfo> webimageslist2 = webimages.bindwebimages(5, "幻灯小图");
                StringBuilder webimagessb2 = new StringBuilder();
                int simgn = webimageslist2.Count;
                for (int k = 0; k < simgn; k++)
                {
                    string template;
                    if (k == 1)
                    {
                        template = " <li class=\"active\"><a href=\"./{0}\" rel=\"{1}\"><img src=\"./Files/WebImages/{2}\" alt=\"\" height=\"30\" width=\"30\"></a></li>";
                    }
                    else
                    {
                        template = " <li class=\"\"><a href=\"./{0}\" rel=\"{1}\"><img src=\"./Files/WebImages/{2}\" alt=\"\" height=\"30\" width=\"30\"></a></li>";
                    }
                    webimagessb2.AppendFormat(template, webimageslist2[k].imgurl, k, webimageslist2[k].imgname);
                }
                hd2HTML = webimagessb2.ToString();

                //首页产品--网站公告
                List<newsinfo> gglist = news.bindnewslist(4,"网站公告");
                StringBuilder ggsb = new StringBuilder();
                for (int i = 0; i < gglist.Count; i++)
                {

                    string template = " <a href=\"./NInfo/{0}.html\" target=\"_blank\" title=\"{1}\"><span class=\"n_point\"></span>{2}</a>";
                    ggsb.AppendFormat(template, gglist[i].newsid,gglist[i].newstitle,comm.SubStr(gglist[i].newstitle,15));
                }
                ggHTML = ggsb.ToString();

                //首页产品--目录
                List<categoryinfo> mllist = category.getbigcategory();
                StringBuilder mlsb = new StringBuilder();
                for (int i = 0; i < mllist.Count; i++)
                {

                    string template = "<a href=\"./PList/{0}\">{1}</a>";
                    mlsb.AppendFormat(template, mllist[i].bigcategoryid, mllist[i].bigcategory);
                }
                mlHTML = mlsb.ToString();

                //首页产品--产地
                List<categoryinfo> cdlist = category.getplace();
                StringBuilder cdsb = new StringBuilder();
                for (int i = 0; i < cdlist.Count; i++)
                {

                    string template = "<a href=\"./PList/0/0/{0}\">{1}</a>";
                    cdsb.AppendFormat(template, cdlist[i].placeid, cdlist[i].place);
                }
                cdHTML = cdsb.ToString();

                //首页四个广告图片
                List<webimagesinfo> img4list = webimages.bindwebimages(4, "首页4图片");
                StringBuilder img4sb = new StringBuilder();
                for (int k = 0; k < img4list.Count; k++)
                {
                    string template;
                    template = "<a href=\"./{0}\"><img src=\"./Files/WebImages/{1}\" /></a>";

                        img4sb.AppendFormat(template, img4list[k].imgurl, img4list[k].imgname);
                }
                img4HTML = img4sb.ToString();

                //产品
                List<categoryinfo> clist = category.gettjtype();
                StringBuilder psb = new StringBuilder();
                int nint = clist.Count;
                for (int i = 0; i < nint; i++)
                {
                    string btem = "<div class=\"indexproductli\"><h2>{0}</h2>";
                    psb.AppendFormat(btem, clist[i].tjtype);
                    List<productinfo> list1 = product.bindproductlistbytj(4,clist[i].tjtypeid);

                    foreach (productinfo item1 in list1)
                    {
                        string template = "<div class=\"productli\"><a href=\"./PInfo/{0}.html\" class=\"pimg\" target=\"_blank\"><img src=\"./Files/Product/{1}\" /></a><a href=\"./PInfo/{2}.html\" class=\"ptitle\" title=\"{3}\"  target=\"_blank\">{4}</a><a href=\"./PInfo/{5}.html\" class=\"pprice\"  target=\"_blank\"><span class=\"pricecss1\">￥{6}</span><span class=\"pricecss2\">￥{7}</span>{8}</a></div>";
                        psb.AppendFormat(template, item1.productid, item1.productimg, item1.productid, item1.productname, comm.SubStr(item1.productname, 13), item1.productid, item1.productprice, item1.vipprice, item1.salestate == 1 ? "<span class=\"sstate\">已售完</span>" : "");
                    }
                    psb.Append("</div>");
                }
                pHTML = psb.ToString();
              
            }

        }
    }
}