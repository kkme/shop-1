using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Morrison.Models;

namespace Morrison.Helper
{
    public class webimages
    {
        #region 添加图片类别

        /// <summary>
        /// 添加图片类别
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool addimagestype(webimagesinfo data)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@imagestype", SqlDbType.VarChar, 20);
            parms[0].Value = data.imagestype;
            string sql = "insert into imagestype (imagestype) values(@imagestype)";
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

        #region 得到图片类别

        /// <summary>
        /// 得到图片类别
        /// </summary>
        /// <returns></returns>
        public static List<webimagesinfo> getimagestype()
        {
            string sql = "select itid,imagestype from imagestype";
            List<webimagesinfo> itlist = new List<webimagesinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    webimagesinfo item = new webimagesinfo();
                    item.itid = TypeParse.DbObjToInt(dr["itid"].ToString(), 0);
                    item.imagestype = TypeParse.DbObjToString(dr["imagestype"].ToString(), "");
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

        #region 删除图片类别

        /// <summary>
        /// 删除图片类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool delimagestype(int id)
        {
            string sql = "delete from imagestype where itid=" + id;
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

        #region 编辑图片类别

        /// <summary>
        /// 编辑图片类别
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool editimagestype(webimagesinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@imagestype", SqlDbType.VarChar, 20);
            parms[0].Value = data.imagestype;
            parms[1] = new SqlParameter("@itid",SqlDbType.Int);
            parms[1].Value = data.itid;
            string sql = "update imagestype set imagestype=@imagestype where itid=@itid";
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

        #region 添加广告图片

        /// <summary>
        /// 添加广告图片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool addwebimages(webimagesinfo data)
        {
            SqlParameter[] parms = new SqlParameter[5];
            parms[0] = new SqlParameter("@imginfo", SqlDbType.VarChar, 500);
            parms[0].Value = data.imginfo;
            parms[1] = new SqlParameter("@imgurl", SqlDbType.VarChar, 50);
            parms[1].Value = data.imgurl;
            parms[2] = new SqlParameter("@imgname", SqlDbType.VarChar, 50);
            parms[2].Value = data.imgname;
            parms[3] = new SqlParameter("@itid",SqlDbType.Int);
            parms[3].Value = data.itid;
            parms[4] = new SqlParameter("@imgcor", SqlDbType.VarChar, 50);
            parms[4].Value = data.imgcor;

            string sql = "insert into webimages (imginfo,imgurl,imgname,itid,imgcor) values(@imginfo,@imgurl,@imgname,@itid,@imgcor)";
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

        #region 得到广告图片

        /// <summary>
        /// 得到广告图片
        /// </summary>
        /// <param name="pdata"></param>
        /// <returns></returns>
        public static List<webimagesinfo> getwebimages(pageinfo pdata)
        { 
            List<webimagesinfo> webimageslist = new List<webimagesinfo>();            
            try
            {
                DataTable dt = pagehelper.getpagedt(pdata);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        webimagesinfo item = new webimagesinfo();
                        item.wiid = TypeParse.DbObjToInt(dr["wiid"].ToString(), 0);
                        item.imgurl = TypeParse.DbObjToString(dr["imgurl"].ToString(), "");
                        item.imginfo = TypeParse.DbObjToString(dr["imginfo"].ToString(), "");
                        item.imgname = TypeParse.DbObjToString(dr["imgname"].ToString(), "noimgs.jpg");
                        item.itid = TypeParse.DbObjToInt(dr["itid"].ToString(), 0);
                        item.imagestype = TypeParse.DbObjToString(dr["imagestype"].ToString(), "");
                        item.imgcor = TypeParse.DbObjToString(dr["imgcor"].ToString(), "");
                        webimageslist.Add(item);
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
            return webimageslist;
        }

        #endregion

        #region 编辑广告图片

        /// <summary>
        /// 编辑广告图片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool editwebimages(webimagesinfo data)
        {
            SqlParameter[] parms = new SqlParameter[6];
            parms[0] = new SqlParameter("@imgcor", SqlDbType.VarChar, 50);
            parms[0].Value = data.imgcor;
            parms[1] = new SqlParameter("@imgurl", SqlDbType.VarChar, 50);
            parms[1].Value = data.imgurl;
            parms[2] = new SqlParameter("@imginfo", SqlDbType.VarChar, 500);
            parms[2].Value = data.imginfo;
            parms[3] = new SqlParameter("@imgname", SqlDbType.VarChar, 50);
            parms[3].Value = data.imgname;
            parms[4] = new SqlParameter("@itid", SqlDbType.Int);
            parms[4].Value = data.itid;
            parms[5] = new SqlParameter("@wiid", SqlDbType.Int);
            parms[5].Value = data.wiid;           
           
            string sql = "update webimages set imgcor=@imgcor, imgurl=@imgurl,imginfo=@imginfo,imgname=@imgname,itid=@itid where wiid=@wiid";
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

        #region 删除广告图片

        /// <summary>
        /// 删除广告图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool delwebimages(int id)
        {
            string sql = "delete from webimages where wiid=" + id;
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

        #region 得到单个广告图片信息

        /// <summary>
        /// 得到单个广告图片信息
        /// </summary>
        /// <param name="wiid"></param>
        /// <returns></returns>
        public static webimagesinfo getwebimagesinfo(int wiid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@wiid", SqlDbType.Int);
            parms[0].Value = wiid;

            webimagesinfo item = new webimagesinfo();
            string sql = "select webimages.wiid,webimages.imgurl,webimages.imginfo,webimages.itid,webimages.imgname,webimages.imgcor,imagestype.imagestype from webimages,imagestype where webimages.itid=imagestype.itid and webimages.wiid=@wiid";

            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {

                    item.wiid = TypeParse.DbObjToInt(dr["wiid"].ToString(), 0);
                    item.imgurl = TypeParse.DbObjToString(dr["imgurl"].ToString(), "");
                    item.imginfo = TypeParse.DbObjToString(dr["imginfo"].ToString(), "");
                    item.imgname = TypeParse.DbObjToString(dr["imgname"].ToString(), "noimgs.jpg");
                    item.itid = TypeParse.DbObjToInt(dr["itid"].ToString(), 0);
                    item.imagestype = TypeParse.DbObjToString(dr["imagestype"].ToString(), "");
                    item.imgcor = TypeParse.DbObjToString(dr["imgcor"].ToString(), "");
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

        #region 根据图片类型名称得到单个广告图片信息

        /// <summary>
        /// 根据图片类型名称得到单个广告图片信息
        /// </summary>
        /// <param name="imagestype"></param>
        /// <returns></returns>
        public static webimagesinfo getwebimagesinfoOne(string imagestype)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@imagestype", SqlDbType.VarChar, 50);
            parms[0].Value = imagestype;

            webimagesinfo item = new webimagesinfo();
            string sql = "SELECT top 1 webimages.wiid,webimages.imgurl,webimages.imginfo,webimages.itid,webimages.imgname,imagestype.imagestype FROM webimages,imagestype WHERE imagestype.imagestype=@imagestype AND webimages.itid=imagestype.itid order by webimages.wiid DESC";

            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {

                    item.wiid = TypeParse.DbObjToInt(dr["wiid"].ToString(), 0);
                    item.imgurl = TypeParse.DbObjToString(dr["imgurl"].ToString(), "");
                    item.imginfo = TypeParse.DbObjToString(dr["imginfo"].ToString(), "");
                    item.imgname = TypeParse.DbObjToString(dr["imgname"].ToString(), "noimgs.jpg");
                    item.itid = TypeParse.DbObjToInt(dr["itid"].ToString(), 0);
                    item.imagestype = TypeParse.DbObjToString(dr["imagestype"].ToString(), "");
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

        #region 绑定页面的广告图片

        /// <summary>
        /// 绑定页面的广告图片
        /// </summary>
        /// <param name="n"></param>
        /// <param name="imagestype"></param>
        /// <returns></returns>
        public static List<webimagesinfo> bindwebimages(int n, string imagestype)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@imagestype", SqlDbType.VarChar, 50);
            parms[0].Value = imagestype;

            List<webimagesinfo> webimageslist = new List<webimagesinfo>();
            string sql = "SELECT top " + n + " webimages.wiid,webimages.imgurl,webimages.imginfo,webimages.itid,webimages.imgname,imagestype.imagestype FROM webimages,imagestype WHERE imagestype.imagestype=@imagestype AND webimages.itid=imagestype.itid order by webimages.wiid DESC";
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql, parms).Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        webimagesinfo item = new webimagesinfo();
                        item.wiid = TypeParse.DbObjToInt(dr["wiid"].ToString(), 0);
                        item.imgurl = TypeParse.DbObjToString(dr["imgurl"].ToString(), "");
                        item.imginfo = TypeParse.DbObjToString(dr["imginfo"].ToString(), "");
                        item.imgname = TypeParse.DbObjToString(dr["imgname"].ToString(), "noimgs.jpg");
                        item.itid = TypeParse.DbObjToInt(dr["itid"].ToString(), 0);
                        item.imagestype = TypeParse.DbObjToString(dr["imagestype"].ToString(), "");
                        webimageslist.Add(item);
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
            return webimageslist;
        }
        #endregion

        #region 得到网站图片的条数

        public static int getwebimagecount()
        {

            string sql = "select count(*) as n  FROM webimages";
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