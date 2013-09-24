using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Morrison.Models;
using System.Net;
using System.Text;

namespace Morrison.Helper
{
    public class admin
    {
        #region 检查账号是否存在

        /// <summary>
        /// 检查账号是否存在
        /// </summary>
        /// <param name="reginame"></param>
        /// <returns></returns>
        public static bool checkadminname(string adminname)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@adminname", SqlDbType.VarChar, 30);
            parms[0].Value = adminname;
            string sql = "SELECT adminid FROM SysAdmin where adminname = @adminname";

            SqlDataReader dr = null;
            string aid;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    aid = dr["adminid"].ToString();
                    if (aid != null && aid != "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception E)
            {
                return false;
            }
            finally
            { }          
        }

        #endregion

        #region 管理员登录

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="reginame"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool VLogin(string adminname, string pwd)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@adminname", SqlDbType.VarChar, 20);
            parms[0].Value = adminname;
            parms[1] = new SqlParameter("@pwd", SqlDbType.VarChar, 32);
            parms[1].Value = pwd;
            string sql = "SELECT adminid FROM SysAdmin where adminname = @adminname AND adminpwd=@pwd";            
            SqlDataReader dr = null;
            string aid;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    aid = dr["adminid"].ToString();
                    if (aid != null && aid != "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
              
            }
            catch (Exception E)
            {
                return false;
            }
            finally
            { }           
        }

        #endregion

        #region 添加新管理员

        /// <summary>
        /// 添加新管理员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool AddNewAdmin(admininfo data)
        {
            SqlParameter[] parms = new SqlParameter[5];
            parms[0] = new SqlParameter("@adminname", SqlDbType.VarChar, 20);
            parms[0].Value = data.adminname;
            parms[1] = new SqlParameter("@adminpwd", SqlDbType.VarChar, 50);
            parms[1].Value = data.adminpwd;
            parms[2] = new SqlParameter("@adddate", SqlDbType.DateTime);
            parms[2].Value = data.adddate;
            parms[3] = new SqlParameter("@updatedate", SqlDbType.DateTime);
            parms[3].Value = data.updatedate;
            parms[4] = new SqlParameter("@roleid",SqlDbType.Int);
            parms[4].Value = data.roleid;

            string sql = "INSERT INTO SysAdmin (adminname,adminpwd,adddate,updatedate,roleid) " +
                        "values (@adminname,@adminpwd,@adddate,@updatedate,@roleid)";

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

        #endregion

        #region 得到管理员

        /// <summary>
        /// 得到管理员ID
        /// </summary>
        /// <param name="adminname"></param>
        /// <returns></returns>
        public static int getAdminID(string adminname)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@adminname", SqlDbType.VarChar, 20);
            parms[0].Value = adminname;
            string sql = "select adminid FROM SysAdmin WHERE adminname=@adminname";
            SqlDataReader dr = null;
            int AdminID = 0;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    AdminID = TypeParse.DbObjToInt(dr["adminid"], 0);
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
            return AdminID;
        }

        public static int getadminamont()
        {
           
            string sql = "select count(*) as n  FROM SysAdmin";
            SqlDataReader dr = null;
            int n = 0;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql);
                if (dr.Read())
                {
                    n = TypeParse.DbObjToInt(dr["n"], 0);
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
            return n;
        }

        #endregion

        #region  得到管理员账号

        /// <summary>
        /// 得到管理员账号
        /// </summary>
        /// <param name="adminname"></param>
        /// <returns></returns>
        public static string getAdminName(int adminid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@adminid", SqlDbType.Int);
            parms[0].Value = adminid;
            string sql = "select adminname FROM SysAdmin WHERE adminid=@adminid";
            SqlDataReader dr = null;
            string adminname = "";
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    adminname = TypeParse.DbObjToString(dr["adminname"], "");
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
            return adminname;
        }

        #endregion

        #region 修改登录密码

        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool updatepwd(admininfo item)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@npwd", SqlDbType.VarChar, 50);
            parms[0].Value = item.adminpwd;
            parms[1] = new SqlParameter("@AdminID",SqlDbType.Int);
            parms[1].Value = item.adminid;

            string sql = "UPDATE SysAdmin SET adminpwd=@npwd WHERE adminid=@adminid";
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

        #endregion

        #region 登录账户的旧密码是否正确

        /// <summary>
        /// 登录账户的旧密码是否正确
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="oldpwd"></param>
        /// <returns></returns>
        public static bool CheckOldPwd(string adminname, string oldpwd)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@adminname", SqlDbType.VarChar, 20);
            parms[0].Value = adminname;
            parms[1] = new SqlParameter("@opwd", SqlDbType.VarChar, 32);
            parms[1].Value = oldpwd;
            string sql = "SELECT adminid FROM SysAdmin where adminname = @adminname AND adminpwd=@opwd ";
            SqlDataReader dr = null;
            string aid;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    aid = dr["adminid"].ToString();
                    if (aid != null && aid != "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception E)
            {
                return false;
            }
            finally
            { }          
        }

        #endregion

        #region 得到管理员信息列表

        /// <summary>
        /// 得到管理员信息列表
        /// </summary>
        /// <param name="pdata"></param>
        /// <returns></returns>
        public static List<admininfo> getAdminList()
        {
            List<admininfo> adminlist = new List<admininfo>();
            string sql = "SELECT adminid,adminname,roleid,adddate,updatedate FROM SysAdmin";

            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql).Tables[0];
                if (dt != null)
                {
                    foreach (DataRow reader in dt.Rows)
                    {
                        admininfo data = new admininfo();
                        data.adminid = TypeParse.DbObjToInt(reader["adminid"], 0);
                        data.adminname = TypeParse.DbObjToString(reader["adminname"], "");
                        data.adddate = TypeParse.DbObjToDateTime(reader["adddate"], DateTime.Now);
                        data.updatedate = TypeParse.DbObjToDateTime(reader["updatedate"], DateTime.Now);
                        adminlist.Add(data);
                    }
                }

                return adminlist;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
        }

        public static List<admininfo> getAdminListPage(pageinfo item)
        {            
            List<admininfo> adminlist = new List<admininfo>();   

            try
            {
                DataTable dt = pagehelper.getpagedt(item);
                if (dt != null)
                {
                    foreach (DataRow reader in dt.Rows)
                    {
                        admininfo data = new admininfo();
                        data.adminid = TypeParse.DbObjToInt(reader["adminid"], 0);
                        data.adminname = TypeParse.DbObjToString(reader["adminname"], "");
                        data.adddate = TypeParse.DbObjToDateTime(reader["adddate"], DateTime.Now);
                        data.updatedate = TypeParse.DbObjToDateTime(reader["updatedate"], DateTime.Now);
                        adminlist.Add(data);
                    }
                }

                return adminlist;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
        }

        #endregion

        #region 删除系统管理员

        /// <summary>
        /// 删除系统管理员
        /// </summary>
        /// <param name="adminid"></param>
        /// <returns></returns>
        public static bool delSysAdminyid(string adminid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@adminid",SqlDbType.Int);
            parms[0].Value = TypeParse.DbObjToInt(adminid, 0);

            string sql = "delete from SysAdmin where adminid=@adminid";
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

        #region 读取系统管理员信息

        /// <summary>
        /// 读取系统管理员信息
        /// </summary>
        /// <param name="adminid"></param>
        /// <returns></returns>
        public static admininfo getAdminInfo(int adminid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@adminid", SqlDbType.Int);
            parms[0].Value = adminid;

            admininfo data = new admininfo();
            string sql = "SELECT adminid,adminname,roleid,adddate,updatedate FROM SysAdmin WHERE  adminid=@adminid";

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (reader.Read())
                {
                    data.adminid = TypeParse.DbObjToInt(reader["adminid"], 0);
                    data.adminname = TypeParse.DbObjToString(reader["adminname"], "");
                    data.adddate = TypeParse.DbObjToDateTime(reader["adddate"], DateTime.Now);
                    data.updatedate = TypeParse.DbObjToDateTime(reader["updatedate"], DateTime.Now);
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
            { }
        }

        #endregion
    }
}