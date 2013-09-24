using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;

namespace TuanFruit.Member
{
    public partial class MyAddress : System.Web.UI.Page
    {
        protected string AddressHTML;        
        protected void Page_Load(object sender, EventArgs e)
        {         
                
                string uid = "";
                if (Request.Cookies["tfuid"] != null)
                {
                    uid = TypeParse.DbObjToString(Request.Cookies["tfuid"].Value, "");
                }
                else
                {
                    Response.Redirect("/UserLog");
                }          
                List<addressinfo> list = address.getaddressinfobyuid(uid);
                StringBuilder sb = new StringBuilder();
                for(int i=0;i<list.Count;i++)
                {
                    string template = "<tr><td height=\"30\" bgcolor=\"#FFFFFF\"><div align=\"center\" >{0}</div></td><td height=\"30\" bgcolor=\"#FFFFFF\" style=\"padding:0 0 0 5px;\"><div align=\"center\">{1}</div></td><td height=\"30\" bgcolor=\"#FFFFFF\"><div align=\"left\" style=\"padding:0 0 0 5px;\">{2}</div></td><td height=\"30\" bgcolor=\"#FFFFFF\"><div align=\"center\">{3}</div></td><td height=\"30\" bgcolor=\"#FFFFFF\"><div align=\"center\">{4}</div></td><td height=\"30\" bgcolor=\"#FFFFFF\"><div align=\"center\">{5}</div></td><td height=\"30\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"javascript:setisdefault('{6}')\" style=\"color:blue;cursor:pointer;\">设置默认</a> | <a href=\"/EditAddress/{7}\" style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:deladdress('{8}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                    sb.AppendFormat(template, i + 1, list[i].contact, list[i].tel, list[i].mobile, list[i].address, list[i].isdefault == 1 ? "<span style=\"font-weight:bold\">是</span>" : "否", list[i].addressid, list[i].addressid, list[i].addressid);
                }
                AddressHTML = sb.ToString();

                if (!Page.IsPostBack)
                {

                    //配送区域I
                    List<categoryinfo> dIlist = category.getdeliveryI();
                    ddldeliveryIid.DataSource = dIlist;
                    ddldeliveryIid.DataTextField = "deliveryI";
                    ddldeliveryIid.DataValueField = "deliveryIid";
                    ddldeliveryIid.DataBind();

                    //配送区域II
                    List<categoryinfo> dIIlist = category.getdeliveryIIbyID(TypeParse.DbObjToInt(ddldeliveryIid.SelectedValue,0));
                    ddldeliveryIIid.DataSource = dIIlist;
                    ddldeliveryIIid.DataTextField = "deliveryII";
                    ddldeliveryIIid.DataValueField = "deliveryIIid";
                    ddldeliveryIIid.DataBind();
                }
           

        }
        protected void AddAddressInfo(object sender, EventArgs e)
        {
            string uid = "";
            if (Request.Cookies["tfuid"] != null)
            {
                uid = TypeParse.DbObjToString(Request.Cookies["tfuid"].Value, "");
            }
            else
            {
                Response.Redirect("/UserLog");
            }          
            if (txtaddress.Value.Length < 5 || txtcontact.Value.Length < 2)
            {
                lbladdressnote.InnerText = "请完整填写下面的选项";
                return;
            }
               
            try
            {               
                addressinfo data = new addressinfo();
                data.address = txtaddress.Value.Trim();
                data.contact = txtcontact.Value.Trim();
                data.mobile = txtmobile.Value.Trim();             
                data.tel = txttel.Value;
                data.deliveryIid = TypeParse.DbObjToInt(ddldeliveryIid.SelectedValue, 1);
                data.deliveryIIid = TypeParse.DbObjToInt(ddldeliveryIIid.SelectedValue, 1);
                data.isdefault =0;
                data.userid = uid;

                bool result = address.addaddress(data);
                if (result)
                {
                    Response.Write("<script>alert('添加收货地址成功！');location.href='/Address';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('添加收货地址失败！');location.href='/Address';</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void banddeliveryII(object sender, EventArgs e)
        {
            List<categoryinfo> sclist = category.getdeliveryIIbyID(TypeParse.DbObjToInt(ddldeliveryIid.SelectedValue, 0));
            ddldeliveryIIid.DataSource = sclist;
            ddldeliveryIIid.DataTextField = "deliveryII";
            ddldeliveryIIid.DataValueField = "deliveryIIid";
            ddldeliveryIIid.DataBind();
        }
    }
}