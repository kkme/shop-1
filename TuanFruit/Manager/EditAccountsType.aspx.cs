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
    public partial class EditAccountsType : System.Web.UI.Page
    {     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["atid"] != null)
            {
                int bcid = TypeParse.DbObjToInt(Request.QueryString["atid"].ToString(), 0);
                userinfo data = user.getaccoutstypeinfo(bcid);               
                if (!Page.IsPostBack)
                {
                    accountstype.Value = data.accountstype.ToString();
                    atdiscount.Value = data.atdiscount.ToString("F2");
                    atid.Value = data.atid.ToString();
                }
            }
            else
            {
                Response.Redirect("/Manager/AccountsType.aspx");
            }           

        }
        protected void EditAccountsTypeInfo(object sender, EventArgs e)
        {
            try
            {
                userinfo data = new userinfo();
                data.accountstype = accountstype.Value.Trim();
                data.atdiscount = Convert.ToDecimal(TypeParse.DbObjToString(atdiscount.Value.Trim(), "1.00"));
                data.atid = TypeParse.DbObjToInt(atid.Value, 0);
                bool result = user.editaccountstype(data);
                if (result)
                {
                    Response.Write("<script>alert('编辑账号类型成功！');location.href='/Manager/AccountsType.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('编辑账号类型失败！');location.href='/Manager/AccountsType.aspx';</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}