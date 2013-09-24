using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Morrison.Models;
using Morrison.Helper;

namespace TuanFruit.Manager
{
    public partial class DeliveryII : System.Web.UI.Page
    {
        protected string deliveryHTML;
        protected string dsHTML;
        protected string edsHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<categoryinfo> ntlist = category.getdeliveryII();
            foreach (categoryinfo item in ntlist)
            {
                string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{0}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{2}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"javascript:editdIIname('{3}','{4}','{5}')\"  style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:deldeliveryII('{6}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                sb.AppendFormat(template, item.deliveryIIid, item.deliveryII,item.deliveryI, item.deliveryIIid, item.deliveryII,item.deliveryIid, item.deliveryIIid);
            }
            deliveryHTML = sb.ToString();

            //所属配送地址下拉菜单
            List<categoryinfo> dslist = category.getdeliveryI();
            StringBuilder ntselectsb = new StringBuilder();
            ntselectsb.Append("<select id=\"dsselect\"  name=\"dsselect\" style=\"width:120px; border:solid 1px #cacaca; height:20px;z-index:100;\">");
            foreach (categoryinfo item in dslist)
            {
                string template = "<option value=\"{0}\">{1}</option>";
                ntselectsb.AppendFormat(template, item.deliveryIid, item.deliveryI);
            }
            ntselectsb.Append("</select>");
            dsHTML = ntselectsb.ToString();

            List<categoryinfo> edslist = category.getdeliveryI();
            StringBuilder entselectsb = new StringBuilder();
            entselectsb.Append("<select id=\"edsselect\"  name=\"edsselect\" style=\"width:120px; border:solid 1px #cacaca; height:20px;z-index:100;\">");
            foreach (categoryinfo item in edslist)
            {
                string template = "<option value=\"{0}\">{1}</option>";
                entselectsb.AppendFormat(template, item.deliveryIid, item.deliveryI);
            }
            entselectsb.Append("</select>");
            edsHTML = entselectsb.ToString();
        }
    }
}