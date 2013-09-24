using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Morrison.Models;

namespace Morrison.Helper
{
    public class news
    {
        #region 添加资讯类别

        /// <summary>
        /// 添加资讯类别
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool addnewstype(newsinfo data)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@newstype", SqlDbType.VarChar, 20);
            parms[0].Value = data.newstype;
            string sql = "insert into newstype (newstype) values(@newstype)";
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

        #region 得到资讯类别

        /// <summary>
        /// 得到资讯类别
        /// </summary>
        /// <returns></returns>
        public static List<newsinfo> getnewstype()
        {
            string sql = "select ntid,newstype from newstype";
            List<newsinfo> ntlist = new List<newsinfo>();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    newsinfo item = new newsinfo();
                    item.ntid = TypeParse.DbObjToInt(dr["ntid"].ToString(), 0);
                    item.newstype = TypeParse.DbObjToString(dr["newstype"].ToString(), "");
                    ntlist.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
            return ntlist;
        }

        #endregion

        #region 删除资讯类别

        /// <summary>
        /// 删除资讯类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool delnewstype(int id)
        {
            string sql = "delete from newstype where ntid=" + id;
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

        #region 编辑资讯类别

        /// <summary>
        /// 编辑资讯类别
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool editnewstype(newsinfo data)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@newstype", SqlDbType.VarChar, 20);
            parms[0].Value = data.newstype;
            parms[1] = new SqlParameter("@ntid",SqlDbType.Int);
            parms[1].Value = data.ntid;
            string sql = "update newstype set newstype=@newstype where ntid=@ntid";
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

        #region 添加资讯

        /// <summary>
        /// 添加资讯
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool addnews(newsinfo data)
        {
            SqlParameter[] parms = new SqlParameter[10];
            parms[0] = new SqlParameter("@userid",SqlDbType.Int);
            parms[0].Value = data.userid;
            parms[1] = new SqlParameter("@newstitle", SqlDbType.VarChar, 20);
            parms[1].Value = data.newstitle;
            parms[2] = new SqlParameter("@newsfrom", SqlDbType.VarChar, 20);
            parms[2].Value = data.newsfrom;
            parms[3] = new SqlParameter("@newswriter", SqlDbType.VarChar, 50);
            parms[3].Value = data.newswriter;
            parms[4] = new SqlParameter("@adddate",SqlDbType.DateTime);
            parms[4].Value = data.adddate;
            parms[5] = new SqlParameter("@istop",SqlDbType.Int);
            parms[5].Value = data.istop;
            parms[6] = new SqlParameter("@ntid",SqlDbType.Int);
            parms[6].Value = data.ntid;
            parms[7] = new SqlParameter("@newsnote", SqlDbType.VarChar, 50);
            parms[7].Value = data.newsnote;
            parms[8] = new SqlParameter("@ninfo", SqlDbType.Text);
            parms[8].Value = data.ninfo;
            parms[9] = new SqlParameter("@newsimg", SqlDbType.VarChar, 50);
            parms[9].Value = data.newsimg;



            string sql = "insert into news (userid ,newstitle,newsfrom ,newswriter ,adddate ,istop ,ntid,newsnote,ninfo,newsimg) " +
                        "values (@userid,@newstitle,@newsfrom ,@newswriter ,@adddate ,@istop ,@ntid,@newsnote,@ninfo,@newsimg)";

            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);               

            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
                //Console.Write(E.Message);
            }
            finally
            { }
            return result > 0;
        }


        #endregion

        #region 得到资讯列表

        /// <summary>
        /// 得到资讯列表
        /// </summary>
        /// <param name="pdata"></param>
        /// <returns></returns>
        public static List<newsinfo> getnews(pageinfo pdata)
        {           

            List<newsinfo> newslist = new List<newsinfo>();           
            try
            {
                DataTable dt = pagehelper.getpagedt(pdata);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        newsinfo item = new newsinfo();
                        item.newsid = TypeParse.DbObjToInt(dr["newsid"].ToString(), 0);
                        item.newstitle = TypeParse.DbObjToString(dr["newstitle"].ToString(), "");
                        item.newswriter = TypeParse.DbObjToString(dr["newswriter"].ToString(), "");
                        item.ntid = TypeParse.DbObjToInt(dr["ntid"].ToString(), 1);
                        item.istop = TypeParse.DbObjToInt(dr["istop"].ToString(), 0);
                        item.newsfrom = TypeParse.DbObjToString(dr["newsfrom"].ToString(), "");
                        item.newsnote = TypeParse.DbObjToString(dr["newsnote"].ToString(), "");
                        item.ninfo = TypeParse.DbObjToString(dr["ninfo"].ToString(), "");
                        item.newstype = TypeParse.DbObjToString(dr["newstype"].ToString(), "");
                        item.adddate = TypeParse.DbObjToDateTime(dr["adddate"].ToString(), DateTime.Now);
                        item.newsimg = TypeParse.DbObjToString(dr["newsimg"].ToString(), "noimg.jpg");
                        item.userid = TypeParse.DbObjToString(dr["userid"].ToString(), "");
                        newslist.Add(item);
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
            return newslist;
        }

        #endregion

        #region 根据ID读取资讯信息

        /// <summary>
        /// 根据ID读取资讯信息
        /// </summary>
        /// <param name="newsid"></param>
        /// <returns></returns>
        public static newsinfo getnewsinfo(string newsid)
        {
            string sql = "select news.newsid,news.newstitle,news.newswriter,news.newsfrom,news.newsnote,news.adddate,news.ntid,newstype.newstype,news.ninfo,news.istop,news.newsimg,news.userid from news,newstype where news.ntid=newstype.ntid and news.newsid=" + newsid + "";
            newsinfo item = new newsinfo();
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql);
                if (dr.Read())
                {                    
                    item.newsid = TypeParse.DbObjToInt(dr["newsid"].ToString(), 0);
                    item.newstitle = TypeParse.DbObjToString(dr["newstitle"].ToString(), "");
                    item.newswriter = TypeParse.DbObjToString(dr["newswriter"].ToString(), "");
                    item.ntid = TypeParse.DbObjToInt(dr["ntid"].ToString(), 1);
                    item.istop = TypeParse.DbObjToInt(dr["istop"].ToString(), 0);
                    item.newsfrom = TypeParse.DbObjToString(dr["newsfrom"].ToString(), "");
                    item.newsnote = TypeParse.DbObjToString(dr["newsnote"].ToString(), "");
                    item.ninfo = TypeParse.DbObjToString(dr["ninfo"].ToString(), "");
                    item.newstype = TypeParse.DbObjToString(dr["newstype"].ToString(), "");
                    item.adddate = TypeParse.DbObjToDateTime(dr["adddate"].ToString(), DateTime.Now);
                    item.newsimg = TypeParse.DbObjToString(dr["newsimg"].ToString(), "noimg.jpg");
                    item.userid = TypeParse.DbObjToString(dr["userid"].ToString(), "");                   
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

        #region 修改资讯信息

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool editnewsinfo(newsinfo data)
        {
            SqlParameter[] parms = new SqlParameter[9];           
            parms[0] = new SqlParameter("@newstitle", SqlDbType.VarChar, 100);
            parms[0].Value = data.newstitle;
            parms[1] = new SqlParameter("@ninfo", SqlDbType.Text);
            parms[1].Value = data.ninfo;
            parms[2] = new SqlParameter("@istop",SqlDbType.Int);
            parms[2].Value = data.istop;
            parms[3] = new SqlParameter("@newswriter", SqlDbType.VarChar, 20);
            parms[3].Value = data.newswriter;
            parms[4] = new SqlParameter("@newsfrom", SqlDbType.VarChar, 50);
            parms[4].Value = data.newsfrom;
            parms[5] = new SqlParameter("@newsnote", SqlDbType.VarChar, 500);
            parms[5].Value = data.newsnote;           
            parms[6] = new SqlParameter("@ntid",SqlDbType.Int);
            parms[6].Value = data.ntid;
            parms[7] = new SqlParameter("@newsimg", SqlDbType.VarChar, 50);
            parms[7].Value = data.newsimg;
            parms[8] = new SqlParameter("@newsid",SqlDbType.Int);
            parms[8].Value = data.newsid;

            string sql = "update news set newstitle=@newstitle,ninfo=@ninfo,istop=@istop,newswriter=@newswriter,newsfrom=@newsfrom,newsnote=@newsnote,ntid=@ntid,newsimg=@newsimg where newsid=@newsid";
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

        #region 删除资讯

        /// <summary>
        /// 删除资讯
        /// </summary>
        /// <param name="newsid"></param>
        /// <returns></returns>
        public static bool delnews(string newsid)
        {
            string sql = "delete from news where newsid=" + newsid;
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

        #region 绑定页面资讯列表

        /// <summary>
        /// 绑定页面资讯列表
        /// </summary>
        /// <param name="n"></param>
        /// <param name="newstype"></param>
        /// <returns></returns>
        public static List<newsinfo> bindnewslist(int n, string newstype)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@newstype", SqlDbType.VarChar, 50);
            parms[0].Value = newstype;

            List<newsinfo> newslist = new List<newsinfo>();
            string sql = "SELECT TOP " + n + " news.newsid,news.newstitle,news.newswriter,news.newsfrom,news.newsnote,news.adddate,news.ntid,newstype.newstype,news.ninfo,news.istop,news.newsimg FROM news,newstype WHERE news.ntid=newstype.ntid AND newstype.newstype=@newstype ORDER BY news.istop desc,news.adddate desc";

            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql, parms).Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        newsinfo item = new newsinfo();
                        item.newsid = TypeParse.DbObjToInt(dr["newsid"].ToString(),0);
                        item.newstitle = TypeParse.DbObjToString(dr["newstitle"].ToString(), "");
                        item.newswriter = TypeParse.DbObjToString(dr["newswriter"].ToString(), "");
                        item.ntid = TypeParse.DbObjToInt(dr["ntid"].ToString(), 1);
                        item.istop = TypeParse.DbObjToInt(dr["istop"].ToString(), 0);
                        item.newsfrom = TypeParse.DbObjToString(dr["newsfrom"].ToString(), "");
                        item.newsnote = TypeParse.DbObjToString(dr["newsnote"].ToString(), "");
                        item.ninfo = TypeParse.DbObjToString(dr["ninfo"].ToString(), "");
                        item.newstype = TypeParse.DbObjToString(dr["newstype"].ToString(), "");
                        item.adddate = TypeParse.DbObjToDateTime(dr["adddate"].ToString(), DateTime.Now);
                        item.newsimg = TypeParse.DbObjToString(dr["newsimg"].ToString(), "noimg.jpg");
                        newslist.Add(item);
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
            return newslist;
        }


        #endregion      

        #region 得到新闻的条数

        public static int getnewscount()
        {

            string sql = "select count(*) as n  FROM news";
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

        public static int getnewscountbycondition(string where)
        {

            string sql = "select count(*) as n  FROM news where " + where;
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