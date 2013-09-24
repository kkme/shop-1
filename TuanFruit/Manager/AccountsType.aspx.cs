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
    public partial class AccountsType : System.Web.UI.Page
    {
        protected string atHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<userinfo> list = user.getaccountstype();
            StringBuilder sb = new StringBuilder();
            foreach (userinfo item in list)
            {
                string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\">{0}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\" style=\"padding:0 0 0 5px;\"><div align=\"center\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"/Manager/EditAccountsType.aspx/?atid={2}\" target=\"_blank\" style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:delaccountstype('{3}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                sb.AppendFormat(template, item.accountstype, item.atdiscount, item.atid, item.atid);
            }
            atHTML = sb.ToString();

        }
        protected void AddAccountsTypeInfo(object sender, EventArgs e)
        {
            try
            {
                userinfo data = new userinfo();
                data.accountstype = accountstype.Value.Trim();
                data.atdiscount = Convert.ToDecimal(TypeParse.DbObjToString(atdiscount.Value.Trim(), "1.00"));
                bool result = user.addaccountstype(data);
                if (result)
                {
                    Response.Write("<script>alert('添加账号类型成功！');location.href='/Manager/AccountsType.aspx';</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('添加账号类型失败！');location.href='/Manager/AccountsType.aspx';</script>");
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