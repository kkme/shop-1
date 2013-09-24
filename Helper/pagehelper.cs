using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Routing;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Morrison.Models;

namespace Morrison.Helper
{
    public class pagehelper
    {
        #region 分页

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="htmlAttributes">分页头标签属性</param>
        /// <param name="className">分页样式</param>
        /// <param name="mode">分页模式</param>
        /// <returns></returns>
        public static string Pager(int currentPageIndex, int pageSize, int recordCount, PageMode mode, int show)
        {
            string builder;
            builder = GetNormalPage(currentPageIndex, pageSize, recordCount, mode, show);
            return builder;
        }

        #endregion

        #region 获取分页

        /// <summary>
        /// 获取普通分页
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        private static string GetNormalPage(int currentPageIndex, int pageSize, int recordCount, PageMode mode, int show)
        {
            int pageCount = (recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1);
            StringBuilder url = new StringBuilder();
            url.Append(HttpContext.Current.Request.Url.AbsolutePath + "?page={0}");
            NameValueCollection collection = HttpContext.Current.Request.QueryString;
            string[] keys = collection.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].ToLower() != "page")
                    url.AppendFormat("&{0}={1}", keys[i], collection[keys[i]]);
            }
            if (pageCount < 2)
            {
                return "";
            }
            if (currentPageIndex > pageCount)
            {
                currentPageIndex = pageCount;
            }
            StringBuilder sb = new StringBuilder();
            if (currentPageIndex == 1)
            {
                sb.Append("<span><a href=\"#\">&lt;&lt;</a></span>");
            }
            if (currentPageIndex != 1)
            {
                string url1 = string.Format(url.ToString(), 1);
                sb.AppendFormat("<span><a href={0}>&lt;&lt;</a></span>", url1);
            }
            if (currentPageIndex > 1)
            {
                string url1 = string.Format(url.ToString(), currentPageIndex - 1);
                sb.AppendFormat("<span><a href={0}>&lt;</a></span>", url1);
            }

            if (mode == PageMode.Numeric)
                sb.Append(GetNumericPage(currentPageIndex, show, recordCount, pageCount, url.ToString()));
            if (currentPageIndex < pageCount)
            {
                string url1 = string.Format(url.ToString(), currentPageIndex + 1);
                sb.AppendFormat("<span><a href={0}>&gt;</a></span>", url1);
            }


            if (currentPageIndex == pageCount)
            {
                sb.Append("<span><a href=\"#\">&gt;&gt;</a></span>");
            }
            else
            {
                string url1 = string.Format(url.ToString(), pageCount);
                sb.AppendFormat("<span><a href={0}>&gt;&gt;</a></span>", url1);
            }
            return sb.ToString();
        }

        #endregion

        #region 获取数字分页

        /// <summary>
        /// 获取数字分页
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <param name="url"></param>
        /// <returns></returns>    
        private static string GetNumericPage(int page, int show, int recordCount, int total, string url)
        {
            if (total == 1)
            {
                return "";
            }
            var sb = new StringBuilder();

            if (page > (show + 1))
            {
                sb.AppendFormat("<span><a href=\"{0}\" title=\"前" + (show + 1) + "页\">{1}</a></span>", string.Format(url, page - (show + 1)), "..");

            }
            for (var i = page - show; i <= page + show; i++)
            {
                if (i == page)
                {
                    sb.AppendFormat("<span class=\"current\">{0}</span>", i);
                }
                else
                {
                    if (i > 0 & i <= total)
                    {
                        sb.AppendFormat("<span><a href=\"{0}\">{1}</a></span>", string.Format(url, i), i);
                    }
                }
            }
            if (page < (total - (show)))
            {
                sb.AppendFormat("<span><a href=\"{0}\" title=\"后" + (show + 1) + "页\">{1}</a></span>", string.Format(url, page + (show + 1)), "..");
            }


            return sb.ToString();
        }

        #endregion

        #region 得到分页数据

        public static DataTable getpagedt(pageinfo pdata)
        {
            SqlParameter[] parms = new SqlParameter[8];
            parms[0] = new SqlParameter("@pagesize", SqlDbType.Int);
            parms[0].Value = pdata.pagesize;
            parms[1] = new SqlParameter("@fieldlist", SqlDbType.VarChar, 2000);
            parms[1].Value = pdata.fieldlist;
            parms[2] = new SqlParameter("@tablename", SqlDbType.VarChar, 500);
            parms[2].Value = pdata.tablename;
            parms[3] = new SqlParameter("@where", SqlDbType.VarChar, 500);
            parms[3].Value = pdata.where;
            parms[4] = new SqlParameter("@sorttype", SqlDbType.Int);
            parms[4].Value = pdata.sorttype;
            parms[5] = new SqlParameter("@order", SqlDbType.VarChar, 200);
            parms[5].Value = pdata.order;
            parms[6] = new SqlParameter("@primarykey", SqlDbType.VarChar, 50);
            parms[6].Value = pdata.primarykey;
            parms[7] = new SqlParameter("@pageindex", SqlDbType.Int);
            parms[7].Value = pdata.curpageindex;


            StringBuilder sql = new StringBuilder();
            string new_where2;
            string new_where1;
            string new_order;           

            if (pdata.where == null || pdata.where == "")
            {
                new_where2 = " where ";
                new_where1 = "";
            }
            else
            {
                new_where2 = " where " + pdata.where + " and ";
                new_where1 = " where " + pdata.where;
            }

            if (pdata.sorttype == 1)
            {
                new_order = " order by " + pdata.primarykey + " asc";
            }
            else if (pdata.sorttype == 2)
            {
                new_order = " order by " + pdata.primarykey + " desc";
            }
            else if (pdata.sorttype == 3)
            {
                new_order = " order by " + pdata.order;
            }
            else
            {
                new_order = " order by " + pdata.primarykey + " desc";
            }

            if (pdata.curpageindex < 1)
            {
                pdata.curpageindex = 1;
            }
            if (pdata.curpageindex > pdata.totalpagecount)
            {
                pdata.curpageindex = pdata.totalpagecount;
            }
            if (pdata.curpageindex == 1)
            {
                sql.Append("select top " + pdata.pagesize + " " + pdata.fieldlist + " from " + pdata.tablename + " " + new_where1 + " " + new_order);
            }
            else
            {
                if (pdata.sorttype == 1)
                {
                    sql.Append("SELECT TOP " + pdata.pagesize + " " + pdata.fieldlist + " FROM " + pdata.tablename + " " + new_where2 + " " + pdata.primarykey + " > " + " (SELECT MAX(" + pdata.primarykey + " ) FROM (SELECT TOP " + pdata.pagesize * (pdata.curpageindex - 1) + " " + pdata.primarykey + " " + " FROM " + pdata.tablename + " " + new_where1 + " " + new_order + " ) AS TMP) " + new_order);
                }
                if (pdata.sorttype == 2)
                {
                    sql.Append("SELECT TOP " + pdata.pagesize + " " + pdata.fieldlist + " FROM " + pdata.tablename + " " + new_where2 + " " + pdata.primarykey + " < " + " (SELECT MIN(" + pdata.primarykey + " ) FROM (SELECT TOP " + pdata.pagesize * (pdata.curpageindex - 1) + " " + pdata.primarykey + " " + " FROM " + pdata.tablename + " " + new_where1 + " " + new_order + " ) AS TMP) " + new_order);

                }
                if (pdata.sorttype == 3)
                {
                    sql.Append("SELECT TOP " + pdata.pagesize + " " + pdata.fieldlist + " FROM " + pdata.tablename + " " + new_where2 + " " + pdata.primarykey + " NOT IN (SELECT TOP " + pdata.pagesize * (pdata.curpageindex - 1) + " " + pdata.primarykey + " FROM " + pdata.tablename + " " + new_where1 + " " + new_order + ")" + new_order);
                }
            }
            DataTable dt = new DataTable();

            try
            {
                dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql.ToString()).Tables[0];
                return dt;
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

    #region 分页模式

    /// <summary>
    /// 分页模式
    /// </summary>
    public enum PageMode
    {
        /// <summary>
        /// 普通分页模式
        /// </summary>
        Normal,
        /// <summary>
        /// 普通分页加数字分页
        /// </summary>
        Numeric
    }

    #endregion
}