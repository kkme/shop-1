using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Morrison.Models;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Morrison.Helper
{
    public class user
    {
        /// <summary>
        /// 检测邮箱是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool checkemail(string email)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            parms[0].Value = email;
            string sql = "if(EXISTS(SELECT [userid] FROM userinfo where [email] = @email or [accounts]=@email)) " +
                         "select 1 " +
                         "else " +
                         "select 0";

            int result = 0;
            try
            {
                result = TypeParse.DbObjToInt(SqlHelper.ExecuteScalar(SqlHelper.connectionstring, CommandType.Text, sql, parms), 0);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        /// <summary>
        /// 昵称是否存在
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static bool checkaccounts(string accounts, string uid)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@accounts", SqlDbType.NVarChar, 50);
            parms[0].Value = accounts;
            parms[1] = new SqlParameter("@uid", SqlDbType.NVarChar, 50);
            parms[1].Value = uid;
            string sql = "if(EXISTS(SELECT [userid] FROM userinfo where ([accounts] = @accounts or [email]=@accounts) and [userid] <> @uid)) " +
                         "select 1 " +
                         "else " +
                         "select 0";

            int result = 0;
            try
            {
                result = TypeParse.DbObjToInt(SqlHelper.ExecuteScalar(SqlHelper.connectionstring, CommandType.Text, sql, parms), 0);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        /// <summary>
        /// 昵称是否存在
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static bool checkaccount(string accounts)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@accounts", SqlDbType.NVarChar, 50);
            parms[0].Value = accounts;

            string sql = "if(EXISTS(SELECT [userid] FROM userinfo where [accounts] = @accounts or [email]=@accounts )) " +
                         "select 1 " +
                         "else " +
                         "select 0";

            int result = 0;
            try
            {
                result = TypeParse.DbObjToInt(SqlHelper.ExecuteScalar(SqlHelper.connectionstring, CommandType.Text, sql, parms), 0);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
            return result > 0;
        }


        /// <summary>
        /// 检查旧密码输入是否正确
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool checkpwd(userinfo item)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@pwd", SqlDbType.NVarChar, 50);
            parms[0].Value = item.MD5pwd;
            parms[1] = new SqlParameter("@uid", SqlDbType.NVarChar, 50);
            parms[1].Value = item.userid;
            string sql = "if(EXISTS(SELECT [userid] FROM userinfo where [pwd] = @pwd and [userid] = @uid)) " +
                         "select 1 " +
                         "else " +
                         "select 0";

            int result = 0;
            try
            {
                result = TypeParse.DbObjToInt(SqlHelper.ExecuteScalar(SqlHelper.connectionstring, CommandType.Text, sql, parms), 0);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        public static bool rlogin(userinfo item)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@pwd", SqlDbType.NVarChar, 50);
            parms[0].Value = item.MD5pwd;
            parms[1] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            parms[1].Value = item.email;
            string sql = "if(EXISTS(SELECT [userid] FROM userinfo where [pwd] = @pwd and [email] = @email)) " +
                         "select 1 " +
                         "else " +
                         "select 0";

            int result = 0;
            try
            {
                result = TypeParse.DbObjToInt(SqlHelper.ExecuteScalar(SqlHelper.connectionstring, CommandType.Text, sql, parms), 0);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool adduser(userinfo data)
        {
            SqlParameter[] parms = new SqlParameter[8];
            parms[0] = new SqlParameter("@id", SqlDbType.VarChar, 20);
            parms[0].Direction = ParameterDirection.Output;
            parms[1] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            parms[1].Value = data.email;
            parms[2] = new SqlParameter("@pwd", SqlDbType.Char, 50);
            parms[2].Value = data.MD5pwd;
            parms[3] = new SqlParameter("@adddate", SqlDbType.DateTime);
            parms[3].Value = data.adddate;
            parms[4] = new SqlParameter("@accounts", SqlDbType.VarChar, 50);
            parms[4].Value = data.accounts;
            parms[5] = new SqlParameter("@headerimg", SqlDbType.VarChar, 50);
            parms[5].Value = data.headerimg;
            parms[6] = new SqlParameter("@atid", SqlDbType.Int);
            parms[6].Value = data.atid;

            string sql = "exec dbo.www_getno 'userinfo',10,@id output " +
                        "insert into userinfo (userid,pwd,email,adddate,accounts,headerimg,atid) " +
                        "values (@id,@pwd,@email,@adddate,@accounts,@headerimg,@atid) ";
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                data.userid = TypeParse.DbObjToString(parms[0].Value, "");
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        /// <summary>
        /// 通过邮箱得到aid
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string getuidbyemail(userinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            parms[0].Value = data.email;
            parms[1] = new SqlParameter("@pwd", SqlDbType.NVarChar, 50);
            parms[1].Value = data.MD5pwd;
            string sql = "SELECT [userid] FROM userinfo where [email] = @email and [pwd]=@pwd ";
            string uid = "";
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    uid = TypeParse.DbObjToString(dr["userid"].ToString(), "");
                    dr.Close();
                    dr.Dispose();
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
            return uid;
        }

        public static string getemailbyid(string userid)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar, 50);
            parms[0].Value = userid;

            string sql = "SELECT [email] FROM userinfo where [userid] = @userid";
            string email = "";
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    email = TypeParse.DbObjToString(dr["email"].ToString(), "");
                    dr.Close();
                    dr.Dispose();
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
            return email;
        }

        /// <summary>
        /// 用户名用户登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool usernamelogin(userinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@username", SqlDbType.NVarChar, 20);
            parms[0].Value = data.accounts;
            parms[1] = new SqlParameter("@pwd", SqlDbType.NVarChar, 50);
            parms[1].Value = data.MD5pwd;
            string sql = "if(EXISTS(SELECT userid FROM userinfo where accounts = @username and pwd=@pwd)) " +
                         "select 1 " +
                         "else " +
                         "select 0";


            int result = 0;
            try
            {
                result = TypeParse.DbObjToInt(SqlHelper.ExecuteScalar(SqlHelper.connectionstring, CommandType.Text, sql, parms), 0);
            }
            catch (Exception E)
            {
                Console.Write(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        /// <summary>
        /// 邮箱用户登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool emaillogin(userinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@email", SqlDbType.NVarChar, 20);
            parms[0].Value = data.email;
            parms[1] = new SqlParameter("@pwd", SqlDbType.NVarChar, 50);
            parms[1].Value = data.MD5pwd;
            string sql = "if(EXISTS(SELECT userid FROM userinfo where email = @email and pwd=@pwd)) " +
                         "select 1 " +
                         "else " +
                         "select 0";


            int result = 0;
            try
            {
                result = TypeParse.DbObjToInt(SqlHelper.ExecuteScalar(SqlHelper.connectionstring, CommandType.Text, sql, parms), 0);
            }
            catch (Exception E)
            {
                Console.Write(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        //通过用户名得到aid
        public static string getuseridbyusername(userinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@username", SqlDbType.NVarChar, 20);
            parms[0].Value = data.accounts;
            parms[1] = new SqlParameter("@pwd", SqlDbType.NVarChar, 50);
            parms[1].Value = data.MD5pwd;
            string sql = "SELECT [userid] FROM userinfo where [accounts] = @username and [pwd]=@pwd ";
            string uid = "";
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    uid = TypeParse.DbObjToString(dr["userid"].ToString(), "");
                    dr.Close();
                    dr.Dispose();
                }
            }
            catch (Exception E)
            {
                Console.Write(E.Message);
            }
            finally
            { }
            return uid;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="address"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool sendEmail(string address, string subject, string body)
        {
            SmtpClient sc = new SmtpClient();
            sc.Host = "smtp.gmail.com";
            sc.UseDefaultCredentials = true;
            sc.EnableSsl = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.Credentials = new NetworkCredential("jiajulu@gmail.com", "33409249");
            MailMessage mms = new MailMessage();
            mms.Subject = subject;
            mms.Body = body;
            mms.IsBodyHtml = true;
            mms.BodyEncoding = Encoding.UTF8;
            mms.From = new MailAddress("jiajulu@gmail.com");
            mms.To.Add(address);
            try
            {
                sc.Send(mms);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 得到用户信息列表
        /// </summary>
        /// <param name="pdata"></param>
        /// <returns></returns>
        public static List<userinfo> getUserList(pageinfo pdata)
        {
            List<userinfo> userlist = new List<userinfo>();  
            try
            {
                DataTable dt = pagehelper.getpagedt(pdata);
                if (dt != null)
                {
                    foreach (DataRow reader in dt.Rows)
                    {
                        userinfo data = new userinfo();
                        data.userid = TypeParse.DbObjToString(reader["userid"], "");
                        data.email = TypeParse.DbObjToString(reader["email"], "");
                        data.accounts = TypeParse.DbObjToString(reader["accounts"], "");

                        data.tel = TypeParse.DbObjToString(reader["tel"], "");
                        data.mobile = TypeParse.DbObjToString(reader["mobile"], "");

                        data.headerimg = TypeParse.DbObjToString(reader["headerimg"], "noimg.jpg");
                        data.atid = TypeParse.DbObjToInt(reader["atid"], 1);
                        data.accountstype = TypeParse.DbObjToString(reader["accountstype"], "");
                        data.truename = TypeParse.DbObjToString(reader["truename"], "");
                        data.qq = TypeParse.DbObjToString(reader["qq"], "");

                        data.company = TypeParse.DbObjToString(reader["company"], "");
                        data.address = TypeParse.DbObjToString(reader["address"], "");
                        data.adddate = TypeParse.DbObjToDateTime(reader["adddate"], DateTime.Now);
                        userlist.Add(data);
                    }
                }               
                return userlist;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static bool deluserbyid(string userid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar);
            parms[0].Value = userid;

            string sql = "delete from userinfo  where userid=@userid";
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
            return result > 0;
        }

        /// <summary>
        /// 读取注册人数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int getusernumbydate(int n)
        {
            string sql = "";
            switch (n)
            {
                case 0:
                    sql = "select count(*) as count from userinfo ";
                    break;
                case 1:
                    sql = "select count(*)  as count from userinfo where   YEAR(adddate)= YEAR('" + DateTime.Now + "')";
                    break;
                case 2:
                    sql = "select count(*)  as count from userinfo where    YEAR(adddate)= YEAR('" + DateTime.Now + "') and MONTH(adddate)= MONTH('" + DateTime.Now + "')";
                    break;
                case 3:
                    sql = "select count(*)  as count from userinfo where   YEAR(adddate)= YEAR('" + DateTime.Now + "') and MONTH(adddate)= MONTH('" + DateTime.Now + "')and DAY(adddate)= DAY('" + DateTime.Now + "') ";
                    break;
                default:
                    sql = "select count(*)  as count from userinfo";
                    break;
            }
            int count = 0;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql);
                if (dr.Read())
                {
                    count = Int32.Parse(dr["count"].ToString());
                    dr.Close();
                    dr.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
            return count;
        }

        /// <summary>
        /// 根据AID读取用户信息
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static userinfo getuserinfo(string userid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar, 50);
            parms[0].Value = userid;

            string sql = "SELECT userinfo.userid,userinfo.email,userinfo.accounts,userinfo.pwd,userinfo.tel,userinfo.mobile,userinfo.headerimg,userinfo.qq,userinfo.company,userinfo.address,userinfo.truename,userinfo.adddate,userinfo.atid,accountstype.atdiscount,accountstype.accountstype FROM userinfo,accountstype WHERE accountstype.atid=userinfo.atid and userinfo.[userid]=@userid";
            SqlDataReader reader = null;
            try
            {
                userinfo data = new userinfo();
                reader = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (reader.Read())
                {
                    data.userid = TypeParse.DbObjToString(reader["userid"], "");
                    data.email = TypeParse.DbObjToString(reader["email"], "");
                    data.adddate = TypeParse.DbObjToDateTime(reader["adddate"], DateTime.Now);
                    data.tel = TypeParse.DbObjToString(reader["tel"], "");
                    data.mobile = TypeParse.DbObjToString(reader["mobile"], "");
                    data.headerimg = TypeParse.DbObjToString(reader["headerimg"], "noimg.jpg");
                    data.truename = TypeParse.DbObjToString(reader["truename"], "");
                    data.qq = TypeParse.DbObjToString(reader["qq"], "");
                    data.company = TypeParse.DbObjToString(reader["company"], "");
                    data.accounts = TypeParse.DbObjToString(reader["accounts"], "");
                    data.address = TypeParse.DbObjToString(reader["address"], "");
                    data.atid = TypeParse.DbObjToInt(reader["atid"], 1);
                    data.accountstype = TypeParse.DbObjToString(reader["accountstype"], "");
                    data.atdiscount = Decimal.Parse(TypeParse.DbObjToString(reader["atdiscount"], "1.00"));
                    reader.Close();
                    reader.Dispose();

                }
                return data;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            {

            }
        }

        /// <summary>
        /// 修改普通用户资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool updateUserInfo(userinfo data)
        {
            SqlParameter[] parms = new SqlParameter[16];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar, 40);
            parms[0].Value = data.userid;
            parms[1] = new SqlParameter("@tel", SqlDbType.VarChar, 50);
            parms[1].Value = data.tel;
            parms[2] = new SqlParameter("@mobile", SqlDbType.VarChar, 50);
            parms[2].Value = data.mobile;
            parms[3] = new SqlParameter("@truename", SqlDbType.VarChar, 50);
            parms[3].Value = data.truename;
            parms[4] = new SqlParameter("@qq", SqlDbType.VarChar, 50);
            parms[4].Value = data.qq;
            parms[5] = new SqlParameter("@company", SqlDbType.VarChar, 50);
            parms[5].Value = data.company;
            parms[6] = new SqlParameter("@accounts", SqlDbType.VarChar, 50);
            parms[6].Value = data.accounts;
            parms[7] = new SqlParameter("@address", SqlDbType.VarChar, 50);
            parms[7].Value = data.address;

            string sql = "update userinfo set accounts=@accounts,tel=@tel,mobile=@mobile,truename=@truename,qq=@qq,company=@company,address=@address where [userid]=@userid";
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        /// <summary>
        /// 改变用户账号类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool updateuserat(userinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar, 40);
            parms[0].Value = data.userid;
            parms[1] = new SqlParameter("@atid", SqlDbType.Int);
            parms[1].Value = data.atid;           

            string sql = "update userinfo set atid=@atid where [userid]=@userid";
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool changePwd(userinfo item)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar, 40);
            parms[0].Value = item.userid;
            parms[1] = new SqlParameter("@pwd", SqlDbType.NVarChar, 50);
            parms[1].Value = item.MD5pwd;
            string sql = "update userinfo set pwd=@pwd where userid=@userid";
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
            }
            catch (Exception E)
            {
                Console.Write(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        /// <summary>
        /// 改变头像
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool changeHeaderImg(userinfo item)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar, 40);
            parms[0].Value = item.userid;
            parms[1] = new SqlParameter("@headerimg", SqlDbType.NVarChar, 60);
            parms[1].Value = item.headerimg;
            string sql = "update userinfo set headerimg=@headerimg where userid=@userid";
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
            }
            catch (Exception E)
            {
                Console.Write(E.Message);
            }
            finally
            { }
            return result > 0;
        }

        #region 账号类型

        //添加账号类型
        public static bool addaccountstype(userinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@accountstype", SqlDbType.NVarChar, 20);
            parms[0].Value = data.accountstype;
            parms[1] = new SqlParameter("@atdiscount", SqlDbType.Decimal);
            parms[1].Value = data.atdiscount;

            string sql = "insert into accountstype (accountstype,atdiscount) values(@accountstype,@atdiscount)";
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
            return result > 0;
        }

        //得到账号类型列表
        public static List<userinfo> getaccountstype()
        {
            string sql = "select atid,accountstype,atdiscount from accountstype";
            List<userinfo> itlist = new List<userinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    userinfo item = new userinfo();
                    item.atid = TypeParse.DbObjToInt(dr["atid"].ToString(), 0);
                    item.accountstype = TypeParse.DbObjToString(dr["accountstype"].ToString(), "");
                    item.atdiscount = Convert.ToDecimal(TypeParse.DbObjToString(dr["atdiscount"].ToString(), "1.00"));
                    itlist.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
            return itlist;
        }

        //根据账号类型ID得到账号类型信息
        public static userinfo getaccoutstypeinfo(int id)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@id", SqlDbType.Int);
            parms[0].Value = id;
            string sql = "select atid,accountstype,atdiscount from accountstype where atid=@id";
            userinfo item = new userinfo();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    item.atid = TypeParse.DbObjToInt(dr["atid"].ToString(), 0);
                    item.accountstype = TypeParse.DbObjToString(dr["accountstype"].ToString(), "");
                    item.atdiscount = Convert.ToDecimal(TypeParse.DbObjToString(dr["atdiscount"].ToString(), "1.00"));
                    dr.Close();
                    dr.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
            return item;
        }

        //删除账号类型
        public static bool delaccountstype(int id)
        {
            string sql = "delete from accountstype where atid=" + id;
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

        //编辑账号类型
        public static bool editaccountstype(userinfo data)
        {
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@accountstype", SqlDbType.NVarChar, 20);
            parms[0].Value = data.accountstype;
            parms[1] = new SqlParameter("@atdiscount", SqlDbType.Decimal);
            parms[1].Value = data.atdiscount;
            parms[2] = new SqlParameter("@atid", SqlDbType.Int);
            parms[2].Value = data.atid;

            string sql = "update accountstype set accountstype=@accountstype,atdiscount=@atdiscount where atid=@atid";
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
            return result > 0;
        }

        #endregion

    }
}
