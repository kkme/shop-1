using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Morrison.Models;

namespace Morrison.Helper
{
    public class category
    {
        #region 添加大类别

        //添加大类别
        public static bool addbigcategory(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@bigcategory", SqlDbType.VarChar, 20);
            parms[0].Value = data.bigcategory;
            parms[1] = new SqlParameter("@bigcategoryimg", SqlDbType.VarChar,50);
            parms[1].Value = data.bigcategoryimg;  
            
            string sql = "insert into bigcategory (bigcategory,bigcategoryimg) values(@bigcategory,@bigcategoryimg)";
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

        #region 得到大类别列表

        //得到大类别列表
        public static List<categoryinfo> getbigcategory()
        {
            string sql = "select bigcategoryid,bigcategory,bigcategoryimg from bigcategory";
            List<categoryinfo> itlist = new List<categoryinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categoryinfo item = new categoryinfo();
                    item.bigcategoryid = TypeParse.DbObjToInt(dr["bigcategoryid"].ToString(), 0);
                    item.bigcategory = TypeParse.DbObjToString(dr["bigcategory"].ToString(), "");
                    item.bigcategoryimg = TypeParse.DbObjToString(dr["bigcategoryimg"].ToString(), "");  
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

        #region 根据大类别ID得到大类别信息

        //根据大类别ID得到大类别信息
        public static categoryinfo getbigcategoryinfo(int id)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@id",SqlDbType.Int);
            parms[0].Value = id;
            string sql = "select bigcategoryid,bigcategory,bigcategoryimg from bigcategory where bigcategoryid=@id";
            categoryinfo item = new categoryinfo();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    item.bigcategoryid = TypeParse.DbObjToInt(dr["bigcategoryid"].ToString(), 0);
                    item.bigcategory = TypeParse.DbObjToString(dr["bigcategory"].ToString(), "");
                    item.bigcategoryimg = TypeParse.DbObjToString(dr["bigcategoryimg"].ToString(), "");     
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

        #region 删除大类别

        //删除大类别
        public static bool delbigcategory(int id)
        {
            string sql = "delete from bigcategory where bigcategoryid=" + id;
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

        #region 编辑大类别

        //编辑大类别
        public static bool editbigcategory(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@bigcategory", SqlDbType.VarChar, 20);
            parms[0].Value = data.bigcategory;
            parms[1] = new SqlParameter("@bigcategoryimg", SqlDbType.VarChar,50);
            parms[1].Value = data.bigcategoryimg;
            parms[2] = new SqlParameter("@bigcategoryid",SqlDbType.Int);
            parms[2].Value = data.bigcategoryid;

            string sql = "update bigcategory set bigcategory=@bigcategory,bigcategoryimg=@bigcategoryimg where bigcategoryid=@bigcategoryid";
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

        #region 添加产品小类别

        //添加产品小类别
        public static bool addsmallcategory(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@smallcategory", SqlDbType.VarChar, 20);
            parms[0].Value = data.smallcategory;
            parms[1] = new SqlParameter("@bigcategoryid",SqlDbType.Int);
            parms[1].Value = data.bigcategoryid;

            string sql = "insert into smallcategory (smallcategory,bigcategoryid) values(@smallcategory,@bigcategoryid)";
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

        #region 得到产品小类别列表

        //得到产品小类别列表
        public static List<categoryinfo> getsmallcategory()
        {
            string sql = "select a.smallcategoryid,a.smallcategory,a.bigcategoryid,b.bigcategory from smallcategory a,bigcategory b where a.bigcategoryid=b.bigcategoryid";
            List<categoryinfo> itlist = new List<categoryinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categoryinfo item = new categoryinfo();
                    item.smallcategoryid = TypeParse.DbObjToInt(dr["smallcategoryid"].ToString(), 0);
                    item.smallcategory = TypeParse.DbObjToString(dr["smallcategory"].ToString(), "");
                    item.bigcategoryid = TypeParse.DbObjToInt(dr["bigcategoryid"].ToString(), 0);
                    item.bigcategory = TypeParse.DbObjToString(dr["bigcategory"].ToString(), "");
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

        #region 通过大分类得到产品小类别

        //通过大分类得到产品小类别
        public static List<categoryinfo> getsmallcategorybyid(int bigcategoryid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@bigcategoryid",SqlDbType.Int);
            parms[0].Value = bigcategoryid;

            string sql = "select a.smallcategoryid,a.smallcategory,a.bigcategoryid,b.bigcategory from smallcategory a,bigcategory b where a.bigcategoryid=b.bigcategoryid and b.bigcategoryid=@bigcategoryid";
            List<categoryinfo> itlist = new List<categoryinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categoryinfo item = new categoryinfo();
                    item.smallcategoryid = TypeParse.DbObjToInt(dr["smallcategoryid"].ToString(), 0);
                    item.smallcategory = TypeParse.DbObjToString(dr["smallcategory"].ToString(), "");
                    item.bigcategoryid = TypeParse.DbObjToInt(dr["bigcategoryid"].ToString(), 0);
                    item.bigcategory = TypeParse.DbObjToString(dr["bigcategory"].ToString(), "");
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

        #region 根据产品小类别ID得到类别信息

        //根据产品小类别ID得到类别信息
        public static categoryinfo getsmallcategoryinfo(int smallcategoryid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@smallcategoryid",SqlDbType.Int);
            parms[0].Value = smallcategoryid;

            string sql = "select a.smallcategoryid,a.smallcategory,a.bigcategoryid,b.bigcategory from smallcategory a,bigcategory b where a.bigcategoryid=b.bigcategoryid and a.smallcategoryid=@smallcategoryid";
            categoryinfo item = new categoryinfo();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    item.smallcategoryid = TypeParse.DbObjToInt(dr["smallcategoryid"].ToString(), 0);
                    item.smallcategory = TypeParse.DbObjToString(dr["smallcategory"].ToString(), "");
                    item.bigcategoryid = TypeParse.DbObjToInt(dr["bigcategoryid"].ToString(), 0);
                    item.bigcategory = TypeParse.DbObjToString(dr["bigcategory"].ToString(), "");
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

        #region 删除产品小类别

        //删除产品小类别
        public static bool delsmallcategory(int id)
        {
            string sql = "delete from smallcategory where smallcategoryid=" + id;
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

        #region 编辑产品小类别

        //编辑产品小类别
        public static bool editsmallcategory(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@smallcategory", SqlDbType.VarChar, 20);
            parms[0].Value = data.smallcategory;
            parms[1] = new SqlParameter("@bigcategoryid",SqlDbType.Int);
            parms[1].Value = data.bigcategoryid;
            parms[2] = new SqlParameter("@smallcategoryid",SqlDbType.Int);
            parms[2].Value = data.smallcategoryid;           

            string sql = "update smallcategory set smallcategory=@smallcategory,bigcategoryid=@bigcategoryid where smallcategoryid=@smallcategoryid";
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

        #region 推荐

        //添加推荐类型
        public static bool addtjtype(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@tjtype", SqlDbType.NVarChar, 20);
            parms[0].Value = data.tjtype;
            string sql = "insert into tjtype (tjtype) values(@tjtype)";
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

        //得到推荐类型列表
        public static List<categoryinfo> gettjtype()
        {
            string sql = "select tjtypeid,tjtype from tjtype";
            List<categoryinfo> itlist = new List<categoryinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categoryinfo item = new categoryinfo();
                    item.tjtypeid = TypeParse.DbObjToInt(dr["tjtypeid"].ToString(), 0);
                    item.tjtype = TypeParse.DbObjToString(dr["tjtype"].ToString(), "");
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

        //根据推荐类型ID得到推荐类型信息
        public static categoryinfo gettjtypeinfo(int id)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@id", SqlDbType.Int);
            parms[0].Value = id;
            string sql = "select tjtypeid,tjtype from tjtype where tjtypeid=@id";
            categoryinfo item = new categoryinfo();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    item.tjtypeid = TypeParse.DbObjToInt(dr["tjtypeid"].ToString(), 0);
                    item.tjtype = TypeParse.DbObjToString(dr["tjtype"].ToString(), "");
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

        //删除推荐类型
        public static bool deltjtype(int id)
        {
            string sql = "delete tjtype where tjtypeid=" + id;
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

        //编辑推荐类型
        public static bool edittjtype(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@tjtype", SqlDbType.NVarChar, 20);
            parms[0].Value = data.tjtype;
            parms[1] = new SqlParameter("@tjtypeid", SqlDbType.Int);
            parms[1].Value = data.tjtypeid;

            string sql = "update tjtype set tjtype=@tjtype where tjtypeid=@tjtypeid";
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

        #region 产地

        //添加产地
        public static bool addplace(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@place", SqlDbType.NVarChar, 20);
            parms[0].Value = data.place;
            string sql = "insert into place (place) values(@place)";
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

        //得到产地类型列表
        public static List<categoryinfo> getplace()
        {
            string sql = "select placeid,place from place";
            List<categoryinfo> itlist = new List<categoryinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categoryinfo item = new categoryinfo();
                    item.placeid = TypeParse.DbObjToInt(dr["placeid"].ToString(), 0);
                    item.place = TypeParse.DbObjToString(dr["place"].ToString(), "");
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

        //根据产地类型ID得到产地类型信息
        public static categoryinfo getplaceinfo(int id)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@id", SqlDbType.Int);
            parms[0].Value = id;
            string sql = "select placeid,place from place where placeid=@id";
            categoryinfo item = new categoryinfo();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    item.placeid = TypeParse.DbObjToInt(dr["placeid"].ToString(), 0);
                    item.place = TypeParse.DbObjToString(dr["place"].ToString(), "");
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

        //删除产地类型
        public static bool delplace(int id)
        {
            string sql = "delete place where placeid=" + id;
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

        //编辑产地类型
        public static bool editplace(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@place", SqlDbType.NVarChar, 20);
            parms[0].Value = data.place;
            parms[1] = new SqlParameter("@placeid", SqlDbType.Int);
            parms[1].Value = data.placeid;

            string sql = "update place set place=@place where placeid=@placeid";
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

        #region 配送地址I

        //添加配送地址I
        public static bool adddeliveryI(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@deliveryI", SqlDbType.NVarChar, 20);
            parms[0].Value = data.deliveryI;
            string sql = "insert into deliveryI (deliveryI) values(@deliveryI)";
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

        //得到配送地址I类型列表
        public static List<categoryinfo> getdeliveryI()
        {
            string sql = "select deliveryIid,deliveryI from deliveryI";
            List<categoryinfo> itlist = new List<categoryinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categoryinfo item = new categoryinfo();
                    item.deliveryIid = TypeParse.DbObjToInt(dr["deliveryIid"].ToString(), 0);
                    item.deliveryI = TypeParse.DbObjToString(dr["deliveryI"].ToString(), "");
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

        //根据配送地址I类型ID得到配送地址I类型信息
        public static categoryinfo getdeliveryIinfo(int id)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@id", SqlDbType.Int);
            parms[0].Value = id;
            string sql = "select deliveryIid,deliveryI from deliveryI where deliveryIid=@id";
            categoryinfo item = new categoryinfo();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    item.deliveryIid = TypeParse.DbObjToInt(dr["deliveryIid"].ToString(), 0);
                    item.deliveryI = TypeParse.DbObjToString(dr["deliveryI"].ToString(), "");
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

        //删除配送地址I类型
        public static bool deldeliveryI(int id)
        {
            string sql = "delete deliveryI where deliveryIid=" + id;
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

        //编辑配送地址I类型
        public static bool editdeliveryI(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@deliveryI", SqlDbType.NVarChar, 20);
            parms[0].Value = data.deliveryI;
            parms[1] = new SqlParameter("@deliveryIid", SqlDbType.Int);
            parms[1].Value = data.deliveryIid;

            string sql = "update deliveryI set deliveryI=@deliveryI where deliveryIid=@deliveryIid";
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

        #region 配送地址II

        //添加配送地址II
        public static bool adddeliveryII(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@deliveryII", SqlDbType.NVarChar, 20);
            parms[0].Value = data.deliveryII;
            parms[1] = new SqlParameter("@deliveryIid", SqlDbType.NVarChar, 20);
            parms[1].Value = data.deliveryIid;

            string sql = "insert into deliveryII (deliveryII,deliveryIid) values(@deliveryII,@deliveryIid)";
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

        //得到配送地址II类型列表
        public static List<categoryinfo> getdeliveryII()
        {
            string sql = "select a.deliveryIIid,a.deliveryII,b.deliveryI,b.deliveryIid from deliveryII a,deliveryI b where a.deliveryIid=b.deliveryIid";
            List<categoryinfo> itlist = new List<categoryinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categoryinfo item = new categoryinfo();
                    item.deliveryIIid = TypeParse.DbObjToInt(dr["deliveryIIid"].ToString(), 0);
                    item.deliveryII = TypeParse.DbObjToString(dr["deliveryII"].ToString(), "");
                    item.deliveryIid = TypeParse.DbObjToInt(dr["deliveryIid"].ToString(), 0);
                    item.deliveryI = TypeParse.DbObjToString(dr["deliveryI"].ToString(), "");
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

        //得到配送地址II类型列表通过Iid
        public static List<categoryinfo> getdeliveryIIbyID(int id)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@id", SqlDbType.Int);
            parms[0].Value = id;
            string sql = "select a.deliveryIIid,a.deliveryII,b.deliveryI,b.deliveryIid from deliveryII a,deliveryI b where a.deliveryIid=b.deliveryIid and a.deliveryIid=@id";
            List<categoryinfo> itlist = new List<categoryinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql,parms);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categoryinfo item = new categoryinfo();
                    item.deliveryIIid = TypeParse.DbObjToInt(dr["deliveryIIid"].ToString(), 0);
                    item.deliveryII = TypeParse.DbObjToString(dr["deliveryII"].ToString(), "");
                    item.deliveryIid = TypeParse.DbObjToInt(dr["deliveryIid"].ToString(), 0);
                    item.deliveryI = TypeParse.DbObjToString(dr["deliveryI"].ToString(), "");
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

        //根据配送地址II类型ID得到配送地址II类型信息
        public static categoryinfo getdeliveryIIinfo(int id)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@id", SqlDbType.Int);
            parms[0].Value = id;
            string sql = "select a.deliveryIIid,a.deliveryII,b.deliveryI,b.deliveryIid from deliveryII a,deliveryI b where a.deliveryIid=b.deliveryIid and a.deliveryIIid=@id";
            categoryinfo item = new categoryinfo();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    item.deliveryIIid = TypeParse.DbObjToInt(dr["deliveryIIid"].ToString(), 0);
                    item.deliveryII = TypeParse.DbObjToString(dr["deliveryII"].ToString(), "");
                    item.deliveryIid = TypeParse.DbObjToInt(dr["deliveryIid"].ToString(), 0);
                    item.deliveryI = TypeParse.DbObjToString(dr["deliveryI"].ToString(), "");
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

        //删除配送地址II类型
        public static bool deldeliveryII(int id)
        {
            string sql = "delete from deliveryII where deliveryIIid=" + id;
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

        //编辑配送地址II类型
        public static bool editdeliveryII(categoryinfo data)
        {
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@deliveryII", SqlDbType.NVarChar, 20);
            parms[0].Value = data.deliveryII;
            parms[1] = new SqlParameter("@deliveryIIid", SqlDbType.Int);
            parms[1].Value = data.deliveryIIid;
            parms[2] = new SqlParameter("@deliveryIid", SqlDbType.Int);
            parms[2].Value = data.deliveryIid;

            string sql = "update deliveryII set deliveryII=@deliveryII,deliveryIid=@deliveryIid where deliveryIIid=@deliveryIIid";
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