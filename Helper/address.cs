using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Morrison.Models;
using System.Net;
using System.Text;

namespace Morrison.Helper
{
   public class address
    {
        #region 添加送货地址

        /// <summary>
        /// 添加送货地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool addaddress(addressinfo data)
        {
            SqlParameter[] parms = new SqlParameter[8];
            parms[0] = new SqlParameter("@address", SqlDbType.VarChar, 50);
            parms[0].Value = data.address;            
            parms[1] = new SqlParameter("@contact", SqlDbType.VarChar, 10);
            parms[1].Value = data.contact;
            parms[2] = new SqlParameter("@mobile", SqlDbType.VarChar, 30);
            parms[2].Value = data.mobile;
            parms[3] = new SqlParameter("@tel",SqlDbType.VarChar, 30);
            parms[3].Value = data.tel;
            parms[4] = new SqlParameter("@userid", SqlDbType.VarChar, 50);
            parms[4].Value = data.userid;
            parms[5] = new SqlParameter("@deliveryIid", SqlDbType.Int);
            parms[5].Value = data.deliveryIid;
            parms[6] = new SqlParameter("@deliveryIIid", SqlDbType.Int);
            parms[6].Value = data.deliveryIIid;
            parms[7] = new SqlParameter("@isdefault", SqlDbType.Int);
            parms[7].Value = data.isdefault;

            string sql = "insert into address (address,contact,mobile,tel,userid,deliveryIid,deliveryIIid,isdefault) values(@address,@contact,@mobile,@tel,@userid,@deliveryIid,@deliveryIIid,@isdefault)";
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

        #endregion

        #region 得到送货地址

        /// <summary>
        /// 得到送货地址
        /// </summary>
        /// <param name="pdata"></param>
        /// <returns></returns>
        public static List<addressinfo> getaddress(pageinfo pdata)
        {
            List<addressinfo> list = new List<addressinfo>();
            try
            {
                DataTable dt = pagehelper.getpagedt(pdata);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        addressinfo item = new addressinfo();
                        item.addressid = TypeParse.DbObjToInt(dr["addressid"].ToString(), 0);
                        item.address = TypeParse.DbObjToString(dr["address"].ToString(), "");                       
                        item.contact = TypeParse.DbObjToString(dr["contact"].ToString(), "");
                        item.mobile = TypeParse.DbObjToString(dr["mobile"].ToString(), "");
                        item.tel = TypeParse.DbObjToString(dr["tel"].ToString(), "");
                        item.userid = TypeParse.DbObjToString(dr["userid"].ToString(), "");
                        item.deliveryIid = TypeParse.DbObjToInt(dr["deliveryIid"].ToString(), 0);
                        item.deliveryIIid = TypeParse.DbObjToInt(dr["deliveryIIid"].ToString(), 0);
                        item.isdefault = TypeParse.DbObjToInt(dr["isdefault"].ToString(), 0);                       
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
            return list;
        }

        #endregion

        #region 编辑送货地址

        /// <summary>
        /// 编辑送货地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool editaddress(addressinfo data)
        {
            SqlParameter[] parms = new SqlParameter[8];
            parms[0] = new SqlParameter("@address", SqlDbType.VarChar, 50);
            parms[0].Value = data.address;
            parms[1] = new SqlParameter("@contact", SqlDbType.VarChar, 10);
            parms[1].Value = data.contact;
            parms[2] = new SqlParameter("@mobile", SqlDbType.VarChar, 30);
            parms[2].Value = data.mobile;
            parms[3] = new SqlParameter("@tel", SqlDbType.VarChar, 30);
            parms[3].Value = data.tel;
            parms[4] = new SqlParameter("@userid", SqlDbType.VarChar, 50);
            parms[4].Value = data.userid;
            parms[5] = new SqlParameter("@deliveryIid", SqlDbType.Int);
            parms[5].Value = data.deliveryIid;
            parms[6] = new SqlParameter("@deliveryIIid", SqlDbType.Int);
            parms[6].Value = data.deliveryIIid;           
            parms[7] = new SqlParameter("@addressid", SqlDbType.Int);
            parms[7].Value = data.addressid;

            string sql = "update address set address=@address,contact=@contact,mobile=@mobile,tel=@tel,userid=@userid,deliveryIid=@deliveryIid,deliveryIIid=@deliveryIIid where addressid=@addressid";
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

        #endregion

        #region 删除送货地址

        /// <summary>
        /// 删除送货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool deladdress(int id)
        {
            string sql = "delete from address where addressid=" + id;
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

        #endregion

        #region 编辑默认地址

        /// <summary>
        /// 编辑默认地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool setisdefault(int id)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@id", SqlDbType.Int);
            parms[0].Value = id;
            string sql = "update address set isdefault=1 where addressid=@id";
            bool result1;
            int result2 = 0;
            try
            {
                result1 = delisdefault();
                if (result1)
                {
                    result2 = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);                    
                }
                return result2 > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

       /// <summary>
       /// 清除所以默认
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public static bool delisdefault()
        {
            string sql = "update address set isdefault=0";
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

        #endregion

        #region 得到单个送货地址信息

        /// <summary>
        /// 得到单个送货地址信息
        /// </summary>
        /// <param name="wiid"></param>
        /// <returns></returns>
        public static addressinfo getaddressinfo(int addressid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@addressid", SqlDbType.Int);
            parms[0].Value = addressid;

            addressinfo item = new addressinfo();
            string sql = "select a.addressid,a.address,a.contact,a.mobile,a.tel,a.userid,a.deliveryIid,a.deliveryIIid,a.isdefault,b.deliveryI,c.deliveryII from address a ,deliveryI b ,deliveryII c  where a.deliveryIid=b.deliveryIid and a.deliveryIIid=c.deliveryIIid and addressid=@addressid";

            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    item.addressid = TypeParse.DbObjToInt(dr["addressid"].ToString(), 0);
                    item.address = TypeParse.DbObjToString(dr["address"].ToString(), "");
                    item.contact = TypeParse.DbObjToString(dr["contact"].ToString(), "");
                    item.mobile = TypeParse.DbObjToString(dr["mobile"].ToString(), "");
                    item.tel = TypeParse.DbObjToString(dr["tel"].ToString(), "");
                    item.userid = TypeParse.DbObjToString(dr["userid"].ToString(), "");
                    item.deliveryIid = TypeParse.DbObjToInt(dr["deliveryIid"].ToString(), 0);
                    item.deliveryIIid = TypeParse.DbObjToInt(dr["deliveryIIid"].ToString(), 0);
                    item.isdefault = TypeParse.DbObjToInt(dr["isdefault"].ToString(), 0);     
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

        public static addressinfo getindexaddressinfo(string  userid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar,50);
            parms[0].Value = userid;

            addressinfo item = new addressinfo();
            string sql = "select a.addressid,a.address,a.contact,a.mobile,a.tel,a.userid,a.deliveryIid,a.deliveryIIid,a.isdefault,b.deliveryI,c.deliveryII from address a ,deliveryI b ,deliveryII c  where a.deliveryIid=b.deliveryIid and a.deliveryIIid=c.deliveryIIid and a.userid=@userid and a.isdefault=1";

            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    item.addressid = TypeParse.DbObjToInt(dr["addressid"].ToString(), 0);
                    item.address = TypeParse.DbObjToString(dr["address"].ToString(), "");
                    item.contact = TypeParse.DbObjToString(dr["contact"].ToString(), "");
                    item.mobile = TypeParse.DbObjToString(dr["mobile"].ToString(), "");
                    item.tel = TypeParse.DbObjToString(dr["tel"].ToString(), "");
                    item.userid = TypeParse.DbObjToString(dr["userid"].ToString(), "");
                    item.deliveryIid = TypeParse.DbObjToInt(dr["deliveryIid"].ToString(), 0);
                    item.deliveryIIid = TypeParse.DbObjToInt(dr["deliveryIIid"].ToString(), 0);
                    item.deliveryI = TypeParse.DbObjToString(dr["deliveryI"].ToString(), "");
                    item.deliveryII = TypeParse.DbObjToString(dr["deliveryII"].ToString(), "");
                    item.isdefault = TypeParse.DbObjToInt(dr["isdefault"].ToString(), 0);
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

        #endregion      

        #region 得到某个人送货地址

        public static List<addressinfo> getaddressinfobyuid(string userid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar, 50);
            parms[0].Value = userid;
          
            string sql = "select a.addressid,a.address,a.contact,a.mobile,a.tel,a.userid,a.deliveryIid,a.deliveryIIid,a.isdefault,b.deliveryI,c.deliveryII from address a ,deliveryI b ,deliveryII c  where a.deliveryIid=b.deliveryIid and a.deliveryIIid=c.deliveryIIid and userid=@userid order by a.isdefault desc";

            List<addressinfo> list = new List<addressinfo>();
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql, parms).Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        addressinfo item = new addressinfo();
                        item.addressid = TypeParse.DbObjToInt(dr["addressid"].ToString(), 0);
                        item.address = TypeParse.DbObjToString(dr["address"].ToString(), "");
                        item.contact = TypeParse.DbObjToString(dr["contact"].ToString(), "");
                        item.mobile = TypeParse.DbObjToString(dr["mobile"].ToString(), "");
                        item.tel = TypeParse.DbObjToString(dr["tel"].ToString(), "");
                        item.userid = TypeParse.DbObjToString(dr["userid"].ToString(), "");
                        item.deliveryIid = TypeParse.DbObjToInt(dr["deliveryIid"].ToString(), 0);
                        item.deliveryIIid = TypeParse.DbObjToInt(dr["deliveryIIid"].ToString(), 0);
                        item.isdefault = TypeParse.DbObjToInt(dr["isdefault"].ToString(), 0);
                        item.deliveryI = TypeParse.DbObjToString(dr["deliveryI"].ToString(), "");
                        item.deliveryII = TypeParse.DbObjToString(dr["deliveryII"].ToString(), "");
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
            return list;
        }

        #endregion
    }
}
