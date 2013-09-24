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
    public class websitetype
    {
        #region 添加网站内容类别

        //添加网站内容类别
        public static bool addwebsitetype(websitetypeinfo data)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@websitetype", SqlDbType.VarChar);
            parms[0].Value = data.websitetype;
            string sql = "insert into websitetype (websitetype) values(@websitetype)";
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

        #region 得到网站内容类别列表

        //得到网站内容类别列表
        public static List<websitetypeinfo> getwebsitetype()
        {
            string sql = "select wtid,websitetype from websitetype";
            List<websitetypeinfo> itlist = new List<websitetypeinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    websitetypeinfo item = new websitetypeinfo();
                    item.wtid = TypeParse.DbObjToInt(dr["wtid"].ToString(), 0);
                    item.websitetype = TypeParse.DbObjToString(dr["websitetype"].ToString(), "");
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

        #endregion

        #region 删除网站内容类别

        //删除网站内容类别
        public static bool delwebsitetype(int id)
        {
            string sql = "delete from websitetype where wtid=" + id;
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

        #region 编辑网站内容类别

        //编辑网站内容类别
        public static bool editwebsitetype(websitetypeinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@websitetype", SqlDbType.VarChar, 20);
            parms[0].Value = data.websitetype;
            parms[1] = new SqlParameter("@wtid",SqlDbType.Int);
            parms[1].Value = data.wtid;
            string sql = "update websitetype set websitetype=@websitetype where wtid=@wtid";
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

        #region 添加网站内容

        //添加网站内容
        public static bool addwebsite(websitetypeinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@wtid",SqlDbType.Int);
            parms[0].Value = data.wtid;
            parms[1] = new SqlParameter("@websitecontent", SqlDbType.Text);
            parms[1].Value = data.websitecontent;

            string sql = "insert into website (wtid,websitecontent) values(@wtid,@websitecontent)";
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

        #region 得到网站内容列表

        //得到网站内容列表
        public static List<websitetypeinfo> getwebsite(pageinfo pdata)
        {            

            List<websitetypeinfo> list = new List<websitetypeinfo>();           
            try
            {
                DataTable dt = pagehelper.getpagedt(pdata);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        websitetypeinfo item = new websitetypeinfo();
                        item.wsid = TypeParse.DbObjToInt(dr["wsid"].ToString(), 0);
                        item.wtid = TypeParse.DbObjToInt(dr["wtid"].ToString(), 0);
                        item.websitetype = TypeParse.DbObjToString(dr["websitetype"].ToString(), "");
                        item.websitecontent = TypeParse.DbObjToString(dr["websitecontent"].ToString(), "");
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

        #region 编辑网站内容

        //编辑网站内容
        public static bool editwebsite(websitetypeinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@websitecontent", SqlDbType.Text);
            parms[0].Value = data.websitecontent;
            parms[1] = new SqlParameter("@wsid",SqlDbType.Int);
            parms[1].Value = data.wsid;          

            string sql = "update website set websitecontent=@websitecontent where wsid=@wsid";
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

        #region 删除网站内容

        //删除网站内容
        public static bool delwebsite(int id)
        {
            string sql = "delete from website where wsid=" + id;
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

        #region 得到网站内容信息

        //得到网站内容信息
        public static websitetypeinfo getwebsiteinfo(int wsid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@wsid",SqlDbType.Int);
            parms[0].Value = wsid;

            websitetypeinfo item = new websitetypeinfo();
            string sql = "select website.wsid,website.websitecontent,websitetype.websitetype,website.wtid from website,websitetype where website.wtid=websitetype.wtid AND wsid=@wsid";

            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {

                    item.wsid = TypeParse.DbObjToInt(dr["wsid"].ToString(), 0);
                    item.wtid = TypeParse.DbObjToInt(dr["wtid"].ToString(), 0);
                    item.websitecontent = TypeParse.DbObjToString(dr["websitecontent"].ToString(), "");
                    item.websitetype = TypeParse.DbObjToString(dr["websitetype"].ToString(), "");
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

        #region 得到网站内容信息通过信息类别

        //得到网站内容信息通过信息类别
        public static websitetypeinfo getwebsiteinfobytype(string type)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            parms[0].Value = type;

            websitetypeinfo item = new websitetypeinfo();
            string sql = "select website.wsid,website.websitecontent, websitetype.websitetype from website,websitetype where website.wtid=websitetype.wtid AND websitetype.websitetype like'%" + type + "%'";

            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {

                    item.wsid = TypeParse.DbObjToInt(dr["wsid"].ToString(), 0);
                    item.websitecontent = TypeParse.DbObjToString(dr["websitecontent"].ToString(), "");
                    item.websitetype = TypeParse.DbObjToString(dr["websitetype"].ToString(), "");
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

        #region 得到网站内容的条数

        public static int getwebsitecount()
        {

            string sql = "select count(*) as n  FROM website";
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
    }
}