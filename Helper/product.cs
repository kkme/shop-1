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
    public class product
    {
        #region 添加产品

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool addproduct(productinfo data)
        {
            SqlParameter[] parms = new SqlParameter[16];
            parms[0] = new SqlParameter("@productname", SqlDbType.VarChar, 50);
            parms[0].Value = data.productname;
            parms[1] = new SqlParameter("@productprice", SqlDbType.Decimal);
            parms[1].Value = data.productprice;
            parms[2] = new SqlParameter("@productcode", SqlDbType.VarChar, 50);
            parms[2].Value = data.productcode;
            parms[3] = new SqlParameter("@productbrief", SqlDbType.VarChar, 500);
            parms[3].Value = data.productbrief;
            parms[4] = new SqlParameter("@productintroduce", SqlDbType.Text);
            parms[4].Value = data.productintroduce;
            parms[5] = new SqlParameter("@vipprice", SqlDbType.Decimal);
            parms[5].Value = data.vipprice;
            parms[6] = new SqlParameter("@productimg", SqlDbType.VarChar, 50);
            parms[6].Value = data.productimg;
            parms[7] = new SqlParameter("@smallcategoryid", SqlDbType.Int);
            parms[7].Value = data.smallcategoryid;
            parms[8] = new SqlParameter("@bigcategoryid", SqlDbType.Int);
            parms[8].Value = data.bigcategoryid;
            parms[9] = new SqlParameter("@placeid", SqlDbType.Int);
            parms[9].Value = data.placeid;
            parms[10] = new SqlParameter("@brand", SqlDbType.VarChar, 50);
            parms[10].Value = data.brand;
            parms[11] = new SqlParameter("@tjtypeid", SqlDbType.Int);
            parms[11].Value = data.tjtypeid;
            parms[12] = new SqlParameter("@salestate", SqlDbType.Int);
            parms[12].Value = data.salestate;
            parms[13] = new SqlParameter("@punit", SqlDbType.VarChar, 50);
            parms[13].Value = data.punit;
            parms[14] = new SqlParameter("@adddate", SqlDbType.DateTime);
            parms[14].Value = data.adddate;
            parms[15] = new SqlParameter("@editdate", SqlDbType.DateTime);
            parms[15].Value = data.editdate;

            string sql = "insert into product (productname,productprice,productcode,productbrief,productintroduce,vipprice,productimg,smallcategoryid,bigcategoryid,brand,punit,adddate,editdate,salestate,placeid,tjtypeid) values(@productname,@productprice,@productcode,@productbrief,@productintroduce,@vipprice,@productimg,@smallcategoryid,@bigcategoryid,@brand,@punit,@adddate,@editdate,@salestate,@placeid,@tjtypeid)";
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

        #region 得到产品

        /// <summary>
        /// 得到产品
        /// </summary>
        /// <param name="pdata"></param>
        /// <returns></returns>
        public static List<productinfo> getproduct(pageinfo pdata)
        {
            List<productinfo> list = new List<productinfo>();
            try
            {
                DataTable dt = pagehelper.getpagedt(pdata);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        productinfo item = new productinfo();
                        item.productid = TypeParse.DbObjToInt(dr["productid"].ToString(), 0);
                        item.productname = TypeParse.DbObjToString(dr["productname"].ToString(), "");
                        item.vipprice =Convert.ToDecimal(TypeParse.DbObjToString(dr["vipprice"].ToString(),"100.00"));
                        item.productprice = Convert.ToDecimal(TypeParse.DbObjToString(dr["productprice"].ToString(), "100.00"));
                        item.productcode = TypeParse.DbObjToString(dr["productcode"].ToString(), "");
                        item.productbrief = TypeParse.DbObjToString(dr["productbrief"].ToString(), "");
                        item.productintroduce = TypeParse.DbObjToString(dr["productintroduce"].ToString(), "");
                        item.productimg = TypeParse.DbObjToString(dr["productimg"].ToString(), "");
                        item.smallcategoryid = TypeParse.DbObjToInt(dr["smallcategoryid"].ToString(), 0);
                        item.bigcategoryid = TypeParse.DbObjToInt(dr["bigcategoryid"].ToString(), 0);
                        item.smallcategory = TypeParse.DbObjToString(dr["smallcategory"].ToString(), "");
                        item.bigcategory = TypeParse.DbObjToString(dr["bigcategory"].ToString(), "");
                        item.brand = TypeParse.DbObjToString(dr["brand"].ToString(), "");
                        item.punit = TypeParse.DbObjToString(dr["punit"].ToString(), "");
                        item.adddate = TypeParse.DbObjToDateTime(dr["adddate"], DateTime.Now);
                        item.editdate = TypeParse.DbObjToDateTime(dr["editdate"], DateTime.Now);
                        item.salestate = TypeParse.DbObjToInt(dr["salestate"].ToString(), 0);
                        item.placeid = TypeParse.DbObjToInt(dr["placeid"].ToString(), 0);
                        item.place = TypeParse.DbObjToString(dr["place"].ToString(), "");                        
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

        #region 编辑产品

        /// <summary>
        /// 编辑产品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool editproduct(productinfo data)
        {
            SqlParameter[] parms = new SqlParameter[16];
            parms[0] = new SqlParameter("@productname", SqlDbType.VarChar, 50);
            parms[0].Value = data.productname;
            parms[1] = new SqlParameter("@productprice", SqlDbType.Decimal);
            parms[1].Value = data.productprice;
            parms[2] = new SqlParameter("@productcode", SqlDbType.VarChar, 50);
            parms[2].Value = data.productcode;
            parms[3] = new SqlParameter("@productbrief", SqlDbType.VarChar, 500);
            parms[3].Value = data.productbrief;
            parms[4] = new SqlParameter("@productintroduce", SqlDbType.Text);
            parms[4].Value = data.productintroduce;
            parms[5] = new SqlParameter("@vipprice", SqlDbType.Decimal);
            parms[5].Value = data.vipprice;
            parms[6] = new SqlParameter("@productimg", SqlDbType.VarChar, 50);
            parms[6].Value = data.productimg;
            parms[7] = new SqlParameter("@smallcategoryid", SqlDbType.Int);
            parms[7].Value = data.smallcategoryid;
            parms[8] = new SqlParameter("@bigcategoryid", SqlDbType.Int);
            parms[8].Value = data.bigcategoryid;
            parms[9] = new SqlParameter("@placeid", SqlDbType.Int);
            parms[9].Value = data.placeid;
            parms[10] = new SqlParameter("@brand", SqlDbType.VarChar, 50);
            parms[10].Value = data.brand;
            parms[11] = new SqlParameter("@tjtypeid", SqlDbType.Int);
            parms[11].Value = data.tjtypeid;
            parms[12] = new SqlParameter("@salestate", SqlDbType.Int);
            parms[12].Value = data.salestate;
            parms[13] = new SqlParameter("@punit", SqlDbType.VarChar, 50);
            parms[13].Value = data.punit;           
            parms[14] = new SqlParameter("@editdate", SqlDbType.DateTime);
            parms[14].Value = data.editdate;
            parms[15] = new SqlParameter("@productid", SqlDbType.Int);
            parms[15].Value = data.productid;

            string sql = "update product set productname=@productname,productprice=@productprice,productcode=@productcode,productbrief=@productbrief,productintroduce=@productintroduce,vipprice=@vipprice,productimg=@productimg ,smallcategoryid=@smallcategoryid,bigcategoryid=@bigcategoryid,brand=@brand,placeid=@placeid,punit=@punit,editdate=@editdate where productid=@productid";
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
        /// 更改产品销售状态
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="salestate"></param>
        /// <returns></returns>
        public static bool editsalestate(int productid,int salestate)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@productid", SqlDbType.Int);
            parms[0].Value = productid;
            parms[1] = new SqlParameter("@salestate", SqlDbType.Int);
            parms[1].Value = salestate;         

            string sql = "update product set salestate=@salestate where productid=@productid";
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

        #region 删除产品

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool delproduct(int id)
        {
            string sql = "delete from product where productid=" + id;
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

        #region 得到单个产品信息

        /// <summary>
        /// 得到单个产品信息
        /// </summary>
        /// <param name="wiid"></param>
        /// <returns></returns>
        public static productinfo getproductinfo(int productid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@productid", SqlDbType.Int);
            parms[0].Value = productid;

            productinfo item = new productinfo();
            string sql = "select a.productid,a.productname,a.productprice,a.productcode,a.productbrief,a.productintroduce,a.vipprice,a.productimg,a.smallcategoryid,a.bigcategoryid,a.brand,a.punit,a.placeid,a.adddate,a.editdate,a.salestate,a.tjtypeid,b.bigcategory,c.smallcategory,d.place from product a ,bigcategory b ,smallcategory c ,place d where a.smallcategoryid=c.smallcategoryid and b.bigcategoryid=c.bigcategoryid and a.placeid=d.placeid and productid=@productid";

            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    item.productid = TypeParse.DbObjToInt(dr["productid"].ToString(), 0);
                    item.productname = TypeParse.DbObjToString(dr["productname"].ToString(), "");
                    item.vipprice = Convert.ToDecimal(TypeParse.DbObjToString(dr["vipprice"].ToString(), "100.00"));
                    item.productprice = Convert.ToDecimal(TypeParse.DbObjToString(dr["productprice"].ToString(), "100.00"));
                    item.productcode = TypeParse.DbObjToString(dr["productcode"].ToString(), "");
                    item.productbrief = TypeParse.DbObjToString(dr["productbrief"].ToString(), "");
                    item.productintroduce = TypeParse.DbObjToString(dr["productintroduce"].ToString(), "");
                    item.productimg = TypeParse.DbObjToString(dr["productimg"].ToString(), "");
                    item.smallcategoryid = TypeParse.DbObjToInt(dr["smallcategoryid"].ToString(), 0);
                    item.bigcategoryid = TypeParse.DbObjToInt(dr["bigcategoryid"].ToString(), 0);                   
                    item.bigcategory = TypeParse.DbObjToString(dr["bigcategory"].ToString(), "");
                    item.smallcategory = TypeParse.DbObjToString(dr["smallcategory"].ToString(), "");
                    item.brand = TypeParse.DbObjToString(dr["brand"].ToString(), "");
                    item.punit = TypeParse.DbObjToString(dr["punit"].ToString(), "");
                    item.adddate = TypeParse.DbObjToDateTime(dr["adddate"], DateTime.Now);
                    item.editdate = TypeParse.DbObjToDateTime(dr["editdate"], DateTime.Now);
                    item.salestate = TypeParse.DbObjToInt(dr["salestate"].ToString(), 0);
                    item.placeid = TypeParse.DbObjToInt(dr["placeid"].ToString(), 0);
                    item.place = TypeParse.DbObjToString(dr["place"].ToString(), "");
                    item.tjtypeid = TypeParse.DbObjToInt(dr["tjtypeid"].ToString(), 0);
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

        #region 得到产品的条数

        public static int getproductcount()
        {

            string sql = "select count(*) as n  FROM product";
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

        public static int getproductcountbycondition(string where)
        {

            string sql = "select count(*) as n  FROM product where " + where;
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

        #region 得到n个产品

        public static List<productinfo> bindproductlist(int n)
        {
            List<productinfo> list = new List<productinfo>();
            string sql = "SELECT TOP " + n + " a.productid,a.productname,a.productprice,a.productcode,a.productbrief,a.productintroduce,a.vipprice,a.productimg,a.smallcategoryid,a.bigcategoryid,a.brand,a.punit,a.placeid,a.adddate,a.editdate,a.salestate,a.tjtypeid,b.bigcategory,c.smallcategory,d.place from product a ,bigcategory b ,smallcategory c ,place d where a.smallcategoryid=c.smallcategoryid and b.bigcategoryid=c.bigcategoryid and a.placeid=d.placeid ORDER BY a.editdate desc,a.productid desc";

            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql).Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        productinfo item = new productinfo();
                        item.productid = TypeParse.DbObjToInt(dr["productid"].ToString(), 0);
                        item.productname = TypeParse.DbObjToString(dr["productname"].ToString(), "");
                        item.vipprice = Convert.ToDecimal(TypeParse.DbObjToString(dr["vipprice"].ToString(), "100.00"));
                        item.productprice = Convert.ToDecimal(TypeParse.DbObjToString(dr["productprice"].ToString(), "100.00"));
                        item.productcode = TypeParse.DbObjToString(dr["productcode"].ToString(), "");
                        item.productbrief = TypeParse.DbObjToString(dr["productbrief"].ToString(), "");
                        item.productintroduce = TypeParse.DbObjToString(dr["productintroduce"].ToString(), "");
                        item.productimg = TypeParse.DbObjToString(dr["productimg"].ToString(), "");
                        item.smallcategoryid = TypeParse.DbObjToInt(dr["smallcategoryid"].ToString(), 0);
                        item.bigcategoryid = TypeParse.DbObjToInt(dr["bigcategoryid"].ToString(), 0);
                        item.brand = TypeParse.DbObjToString(dr["brand"].ToString(), "");
                        item.punit = TypeParse.DbObjToString(dr["punit"].ToString(), "");
                        item.adddate = TypeParse.DbObjToDateTime(dr["adddate"], DateTime.Now);
                        item.editdate = TypeParse.DbObjToDateTime(dr["editdate"], DateTime.Now);
                        item.salestate = TypeParse.DbObjToInt(dr["salestate"].ToString(), 0);
                        item.placeid = TypeParse.DbObjToInt(dr["placeid"].ToString(), 0);
                        item.place = TypeParse.DbObjToString(dr["place"].ToString(), "");
                        item.tjtypeid = TypeParse.DbObjToInt(dr["tjtypeid"].ToString(), 0);
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

        //绑定推荐产品
        public static List<productinfo> bindproductlistbytj(int n,int tjtypeid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@tjtypeid", SqlDbType.Int);
            parms[0].Value = tjtypeid;

            List<productinfo> list = new List<productinfo>();
            string sql = "SELECT TOP " + n + " a.productid,a.productname,a.productprice,a.productcode,a.productbrief,a.productintroduce,a.vipprice,a.productimg,a.smallcategoryid,a.bigcategoryid,a.brand,a.punit,a.placeid,a.adddate,a.editdate,a.salestate,a.tjtypeid,b.bigcategory,c.smallcategory,d.place from product a ,bigcategory b ,smallcategory c ,place d where a.smallcategoryid=c.smallcategoryid and b.bigcategoryid=c.bigcategoryid and a.placeid=d.placeid and a.tjtypeid=@tjtypeid ORDER BY a.editdate desc,a.productid desc";

            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql,parms).Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        productinfo item = new productinfo();
                        item.productid = TypeParse.DbObjToInt(dr["productid"].ToString(), 0);
                        item.productname = TypeParse.DbObjToString(dr["productname"].ToString(), "");
                        item.vipprice = Convert.ToDecimal(TypeParse.DbObjToString(dr["vipprice"].ToString(), "100.00"));
                        item.productprice = Convert.ToDecimal(TypeParse.DbObjToString(dr["productprice"].ToString(), "100.00"));
                        item.productcode = TypeParse.DbObjToString(dr["productcode"].ToString(), "");
                        item.productbrief = TypeParse.DbObjToString(dr["productbrief"].ToString(), "");
                        item.productintroduce = TypeParse.DbObjToString(dr["productintroduce"].ToString(), "");
                        item.productimg = TypeParse.DbObjToString(dr["productimg"].ToString(), "");
                        item.smallcategoryid = TypeParse.DbObjToInt(dr["smallcategoryid"].ToString(), 0);
                        item.bigcategoryid = TypeParse.DbObjToInt(dr["bigcategoryid"].ToString(), 0);
                        item.brand = TypeParse.DbObjToString(dr["brand"].ToString(), "");
                        item.punit = TypeParse.DbObjToString(dr["punit"].ToString(), "");
                        item.adddate = TypeParse.DbObjToDateTime(dr["adddate"], DateTime.Now);
                        item.editdate = TypeParse.DbObjToDateTime(dr["editdate"], DateTime.Now);
                        item.salestate = TypeParse.DbObjToInt(dr["salestate"].ToString(), 0);
                        item.placeid = TypeParse.DbObjToInt(dr["placeid"].ToString(), 0);
                        item.place = TypeParse.DbObjToString(dr["place"].ToString(), "");
                        item.tjtypeid = TypeParse.DbObjToInt(dr["tjtypeid"].ToString(), 0);
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

        //绑定浏览记录
        public static List<productinfo> bindproductlistvh(int n, string pidstr)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@pidstr", SqlDbType.NVarChar,500);
            parms[0].Value = pidstr;

            List<productinfo> list = new List<productinfo>();
            string sql = "SELECT TOP " + n + " a.productid,a.productname,a.productprice,a.productcode,a.productbrief,a.productintroduce,a.vipprice,a.productimg,a.smallcategoryid,a.bigcategoryid,a.brand,a.punit,a.placeid,a.adddate,a.editdate,a.salestate,a.tjtypeid,b.bigcategory,c.smallcategory,d.place from product a ,bigcategory b ,smallcategory c ,place d where a.smallcategoryid=c.smallcategoryid and b.bigcategoryid=c.bigcategoryid and a.placeid=d.placeid  and a.productid in (" + pidstr + ")";

            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql,parms).Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        productinfo item = new productinfo();
                        item.productid = TypeParse.DbObjToInt(dr["productid"].ToString(), 0);
                        item.productname = TypeParse.DbObjToString(dr["productname"].ToString(), "");
                        item.vipprice = Convert.ToDecimal(TypeParse.DbObjToString(dr["vipprice"].ToString(), "100.00"));
                        item.productprice = Convert.ToDecimal(TypeParse.DbObjToString(dr["productprice"].ToString(), "100.00"));
                        item.productcode = TypeParse.DbObjToString(dr["productcode"].ToString(), "");
                        item.productbrief = TypeParse.DbObjToString(dr["productbrief"].ToString(), "");
                        item.productintroduce = TypeParse.DbObjToString(dr["productintroduce"].ToString(), "");
                        item.productimg = TypeParse.DbObjToString(dr["productimg"].ToString(), "");
                        item.smallcategoryid = TypeParse.DbObjToInt(dr["smallcategoryid"].ToString(), 0);
                        item.smallcategory = TypeParse.DbObjToString(dr["smallcategory"].ToString(), "");
                        item.bigcategoryid = TypeParse.DbObjToInt(dr["bigcategoryid"].ToString(), 0);
                        item.brand = TypeParse.DbObjToString(dr["brand"].ToString(), "");
                        item.punit = TypeParse.DbObjToString(dr["punit"].ToString(), "");
                        item.adddate = TypeParse.DbObjToDateTime(dr["adddate"], DateTime.Now);
                        item.editdate = TypeParse.DbObjToDateTime(dr["editdate"], DateTime.Now);
                        item.salestate = TypeParse.DbObjToInt(dr["salestate"].ToString(), 0);
                        item.placeid = TypeParse.DbObjToInt(dr["placeid"].ToString(), 0);
                        item.place = TypeParse.DbObjToString(dr["place"].ToString(), "");
                        item.tjtypeid = TypeParse.DbObjToInt(dr["tjtypeid"].ToString(), 0);
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