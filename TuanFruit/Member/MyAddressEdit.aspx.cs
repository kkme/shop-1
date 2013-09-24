using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;

namespace TuanFruit.Member
{
    public partial class MyAddressEdit : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["addressid"] != null)
            {
                int addressid = TypeParse.DbObjToInt(RouteData.Values["addressid"], 0);
                addressinfo data = address.getaddressinfo(addressid);               
                if (!Page.IsPostBack)
                {
                    txtaddress.Value = data.address;
                    txtcontact.Value = data.contact;
                    txtmobile.Value = data.mobile;
                    txttel.Value = data.tel;
                    hdaddressid.Value = data.addressid.ToString();

                    //配送区域I
                    List<categoryinfo> ntlist = category.getdeliveryI();
                    ddldeliveryIid.DataSource = ntlist;
                    ddldeliveryIid.DataTextField = "deliveryI";
                    ddldeliveryIid.DataValueField = "deliveryIid";
                    ddldeliveryIid.DataBind();
                    for (int i = 0; i < ddldeliveryIid.Items.Count; i++)
                    {
                        if (ddldeliveryIid.Items[i].Value == data.deliveryIid.ToString())
                        {
                            ddldeliveryIid.SelectedIndex = i;
                        }
                    }

                    //配送区域II
                    List<categoryinfo> ntlist2 = category.getdeliveryII();
                    ddldeliveryIIid.DataSource = ntlist2;
                    ddldeliveryIIid.DataTextField = "deliveryII";
                    ddldeliveryIIid.DataValueField = "deliveryIIid";
                    ddldeliveryIIid.DataBind();
                    for (int k = 0; k < ddldeliveryIIid.Items.Count; k++)
                    {
                        if (ddldeliveryIIid.Items[k].Value == data.deliveryIIid.ToString())
                        {
                            ddldeliveryIIid.SelectedIndex = k;
                        }
                    }  
                }
            }
        }

        protected void EditAddressInfo(object sender, EventArgs e)
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
                data.isdefault = 0;
                data.userid = uid;
                data.addressid = TypeParse.DbObjToInt(hdaddressid.Value, 0);

                bool result = address.editaddress(data);
                if (result)
                {
                    Response.Write("<script>alert('修改收货地址成功！');location.href='/Address';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('修改收货地址失败！');location.href='/Address';</script>");
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