using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Morrison.Models;
using System.Data;
using System.Data.SqlClient;

namespace Morrison.Helper
{
    public class order
    {
        #region 添加到购物车

        public static bool AddCart(orderinfo item)
        {
            SqlParameter[] parms = new SqlParameter[7];
            parms[0] = new SqlParameter("@id", SqlDbType.VarChar, 20);
            parms[0].Direction = ParameterDirection.Output;
            parms[1] = new SqlParameter("@productid", SqlDbType.NVarChar,50);
            parms[1].Value = item.productid;           
            parms[2] = new SqlParameter("@userid", SqlDbType.NVarChar, 50);
            parms[2].Value = item.userid;           
            parms[3] = new SqlParameter("adddate", SqlDbType.DateTime);
            parms[3].Value = item.adddate;
            parms[4] = new SqlParameter("@vipprice", SqlDbType.Decimal);
            parms[4].Value = item.vipprice;
            parms[5] = new SqlParameter("@buynum", SqlDbType.Int);
            parms[5].Value =item.buynum;
            parms[6] = new SqlParameter("@cartstate", SqlDbType.Int);
            parms[6].Value = item.cartstate;

            string sql = "exec dbo.www_getno 'usercart',10,@id output " +
                         "Insert into usercart(cartid,productid,userid,adddate,vipprice,buynum,cartstate) VALUES (@id,@productid,@userid,@adddate,@vipprice,@buynum,@cartstate)";
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
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

        #region 检查购物车产品是否重复

        public static bool CheckCart(string userid, int productid)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar,50);
            parms[0].Value = userid;
            parms[1] = new SqlParameter("@productid", SqlDbType.Int);
            parms[1].Value = productid;
            string sql = "if(EXISTS(SELECT [cartid] FROM usercart where [userid] = @userid and [productid] =@productid and cartstate=0)) " +
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

        #endregion

        #region 得到购物车产品

        //根据购物车状态得到购物车产品
        public static List<orderinfo> getcartlist(int state, string userid)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@state", SqlDbType.Int);
            parms[0].Value = state;
            parms[1] = new SqlParameter("@userid", SqlDbType.NVarChar,50);
            parms[1].Value = userid;

            string sql;
            List<orderinfo> list = new List<orderinfo>();            
                sql = "select a.cartid,a.vipprice,a.userid,a.productid,a.cartstate,a.adddate,a.buynum,b.productimg,b.productname  from usercart a,product b where a.userid=@userid and a.productid=b.productid and a.cartstate=@state";
                        try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql, parms).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    orderinfo item = new orderinfo();
                    item.cartid = TypeParse.DbObjToString(dr["cartid"].ToString(), "0");
                    item.productid = TypeParse.DbObjToInt(dr["productid"].ToString(), 0);
                    item.productname = TypeParse.DbObjToString(dr["productname"].ToString(), "");
                    item.cartstate = TypeParse.DbObjToInt(dr["cartstate"].ToString(), 0);
                    item.vipprice =Decimal.Parse(TypeParse.DbObjToString(dr["vipprice"].ToString(),"0.00"));                    
                    item.productimg = TypeParse.DbObjToString(dr["productimg"].ToString(), "");
                    item.buynum = TypeParse.DbObjToInt(dr["buynum"].ToString(), 1);
                    list.Add(item);
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

        #region 得到购物车产品个数

        public static int getcartcount(string uid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar, 50);
            parms[0].Value = uid;

            string sql = "select count(*) as n  FROM usercart where cartstate=0 and userid=@userid";
            SqlDataReader dr = null;
            int n = 0;
            try
            {
                dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql,parms);
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

        #region 得到购物车产品价值

        //得到购物车产品总价值
        public static decimal getallprice(string userid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@userid", SqlDbType.NVarChar,50);
            parms[0].Value = userid;

            decimal amountfee = 0.00M;
            string sql = "select sum(vipprice*buynum) as countfee from usercart where userid=@userid and cartstate=0";
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    amountfee = Decimal.Parse(TypeParse.DbObjToString(dr["countfee"].ToString(), "0.00"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
            return amountfee;
        }

        #endregion             

        #region 改变购物车产品数量

        //改变购物车产品状态
        public static bool changecartordernum(string cartid, string type)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@cartid", SqlDbType.NVarChar,50);
            parms[0].Value = cartid;

            int ordernum = getcartordernum(cartid);
            string sql;
            if (type == "minus")
            {
                if (ordernum <= 1)
                {
                    sql = "update usercart set buynum=buynum where cartid=@cartid";
                }
                else
                {
                    sql = "update usercart set buynum=buynum-1 where cartid=@cartid";
                }
            }
            else if (type == "add")
            {
                sql = "update usercart set buynum=buynum+1 where cartid=@cartid";
            }
            else
            {
                sql = "update usercart set buynum=buynum where cartid=@cartid";
            }
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                return result > 0;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
        }

        public static int getcartordernum(string cartid)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@cartid", SqlDbType.NVarChar,50);
            parms[0].Value = cartid;


            string sql = "select buynum from usercart where cartid=@cartid";
            int ordernum = 1;
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {
                    ordernum = TypeParse.DbObjToInt(dr["buynum"].ToString(), 1);
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
            return ordernum;
        }

        #endregion

        #region 删除购物车产品

        //删除购物车产品
        public static bool delcart(string cartid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@cartid", SqlDbType.NVarChar, 50);
            parms[0].Value = cartid;           
            string sql = "delete from usercart where cartid=@cartid";               
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                return result > 0;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
        }
       
        #endregion

        #region 改变购物车订单状态和订单号

        //改变购物车订单状态和订单号
        public static bool changecartstate(string ordernumber,string userid)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@ordernumber", SqlDbType.NVarChar, 50);
            parms[0].Value = ordernumber;
            parms[1] = new SqlParameter("@userid", SqlDbType.NVarChar, 50);
            parms[1].Value = userid;

            string sql;
            sql = "update usercart set ordernumber=@ordernumber,cartstate=1 where cartstate=0 and userid=@userid";

            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                return result > 0;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
        }


        #endregion

        #region 得到订单列表

        public static List<orderinfo> getcartlistbyordernumber(string ordernumber)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@ordernumber", SqlDbType.NVarChar, 50);
            parms[0].Value = ordernumber;


            List<orderinfo> list = new List<orderinfo>();
            string sql = "select a.cartid,a.buynum,a.ordernumber,a.vipprice,a.userid, b.productname,b.productimg,b.productcode  from usercart a,product b where a.ordernumber=@ordernumber and a.productid=b.productid";

            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql, parms).Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        orderinfo item = new orderinfo();
                        item.cartid = TypeParse.DbObjToString(dr["cartid"].ToString(), "0");
                        item.buynum = TypeParse.DbObjToInt(dr["buynum"].ToString(), 0);
                        item.ordernumber = TypeParse.DbObjToString(dr["ordernumber"].ToString(), "");
                        item.vipprice =Decimal.Parse(TypeParse.DbObjToString(dr["vipprice"].ToString(), "0.00"));
                        item.userid = TypeParse.DbObjToString(dr["userid"].ToString(), "0");
                        item.productname = TypeParse.DbObjToString(dr["productname"].ToString(), "");
                        item.productcode = TypeParse.DbObjToString(dr["productcode"].ToString(), "");                       
                        item.productimg = TypeParse.DbObjToString(dr["productimg"].ToString(), "");
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

        #region 生成订单

        /// <summary>
        /// 生成订单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool addorder(orderinfo data)
        {
            SqlParameter[] parms = new SqlParameter[14];
            parms[0] = new SqlParameter("@id", SqlDbType.VarChar, 20);
            parms[0].Direction = ParameterDirection.Output;
            parms[1] = new SqlParameter("@ordernumber", SqlDbType.NVarChar, 50);
            parms[1].Value = data.ordernumber;
            parms[2] = new SqlParameter("@orderdate", SqlDbType.DateTime);
            parms[2].Value = data.orderdate;
            parms[3] = new SqlParameter("@deliverydate", SqlDbType.DateTime);
            parms[3].Value = data.deliverydate;
            parms[4] = new SqlParameter("@allmoney", SqlDbType.Decimal);
            parms[4].Value = data.allmoney;
            parms[5] = new SqlParameter("@paymoney", SqlDbType.Decimal);
            parms[5].Value = data.paymoney;
            parms[6] = new SqlParameter("@orderstate", SqlDbType.Int);
            parms[6].Value = data.orderstate;
            parms[7] = new SqlParameter("@userid", SqlDbType.NVarChar,50);
            parms[7].Value = data.userid;
            parms[8] = new SqlParameter("@address", SqlDbType.VarChar, 50);
            parms[8].Value = data.address;
            parms[9] = new SqlParameter("@contact", SqlDbType.VarChar, 10);
            parms[9].Value = data.contact;
            parms[10] = new SqlParameter("@mobile", SqlDbType.VarChar, 30);
            parms[10].Value = data.mobile;
            parms[11] = new SqlParameter("@tel", SqlDbType.VarChar, 30);
            parms[11].Value = data.tel;            
            parms[12] = new SqlParameter("@deliveryIid", SqlDbType.Int);
            parms[12].Value = data.deliveryIid;
            parms[13] = new SqlParameter("@deliveryIIid", SqlDbType.Int);
            parms[13].Value = data.deliveryIIid;


            string sql = "exec dbo.www_getno 'userorder',10,@id output " +
                         "insert into [userorder] (orderid,ordernumber,orderdate,deliverydate,allmoney,paymoney,orderstate,userid,address,contact,mobile,tel,deliveryIid,deliveryIIid) values(@id,@ordernumber,@orderdate,@deliverydate,@allmoney,@paymoney,@orderstate,@userid,@address,@contact,@mobile,@tel,@deliveryIid,@deliveryIIid)";
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

        #region  得到订单列表

        /// <summary>
        /// 得到订单列表
        /// </summary>
        /// <param name="pdata"></param>
        /// <returns></returns>
        public static List<orderinfo> getorderlist(pageinfo pdata)
        {
            List<orderinfo> list = new List<orderinfo>();
            try
            {
                DataTable dt = pagehelper.getpagedt(pdata);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        orderinfo item = new orderinfo();
                        item.orderid = TypeParse.DbObjToString(dr["orderid"].ToString(),"0");
                        item.tel = TypeParse.DbObjToString(dr["tel"].ToString(), "");
                        item.mobile = TypeParse.DbObjToString(dr["mobile"].ToString(), "");
                        item.address = TypeParse.DbObjToString(dr["address"].ToString(), "");
                        item.contact = TypeParse.DbObjToString(dr["contact"].ToString(), "");
                        item.allmoney =Decimal.Parse(TypeParse.DbObjToString(dr["allmoney"].ToString(), "0.00"));
                        item.paymoney =Decimal.Parse(TypeParse.DbObjToString(dr["paymoney"].ToString(), "0.00"));
                        item.orderstate = TypeParse.DbObjToInt(dr["orderstate"].ToString(), 0);                       
                        item.orderdate = TypeParse.DbObjToDateTime(dr["orderdate"].ToString(), DateTime.Now);
                        item.deliverydate = TypeParse.DbObjToDateTime(dr["deliverydate"].ToString(), DateTime.Now);
                        item.ordernumber = TypeParse.DbObjToString(dr["ordernumber"].ToString(), "");
                        item.deliveryI = TypeParse.DbObjToString(dr["deliveryI"].ToString(), "");
                        item.deliveryII = TypeParse.DbObjToString(dr["deliveryII"].ToString(), "");
                        switch (item.orderstate)
                        {
                            case 0:
                                item.orderstatestr = "进行中";
                                break;
                            case 10:                              
                                  item.orderstatestr = "已完成";                              
                                break;
                            case 44:
                                item.orderstatestr = "待处理";
                                break;
                            default:
                                item.orderstatestr = "进行中";
                                break;
                        }
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

        #region  得到配货列表

        public static List<orderinfo> getphlist(string condition)
        {
            List<orderinfo> list = new List<orderinfo>();
            string sql = "select sum(usercart.buynum) as n,product.productcode,product.productimg,product.productname from usercart,userorder,product where usercart.ordernumber=userorder.ordernumber and usercart.productid=product.productid "+condition+" group by usercart.productid,product.productcode,product.productname,product.productimg";

            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.connectionstring, CommandType.Text, sql).Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        orderinfo item = new orderinfo();                        
                        item.tjbuynum = TypeParse.DbObjToInt(dr["n"].ToString(), 0);                      
                        item.productname = TypeParse.DbObjToString(dr["productname"].ToString(), "");
                        item.productcode = TypeParse.DbObjToString(dr["productcode"].ToString(), "");
                        item.productimg = TypeParse.DbObjToString(dr["productimg"].ToString(), "");
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

        #region 得到单个订单信息

        /// <summary>
        /// 得到单个订单信息
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public static orderinfo getorderinfo(string orderid)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@orderid", SqlDbType.NVarChar,50);
            parms[0].Value = orderid;

            orderinfo item = new orderinfo();
            string sql = "select a.orderid,a.ordernumber,a.allmoney,a.paymoney,a.deliveryIid,a.deliveryIIid,a.orderdate,a.deliverydate,a.orderstate,a.contact,a.tel,a.mobile,a.address,c.deliveryI,d.deliveryII from [userorder] a,deliveryI c,deliveryII d where  a.deliveryIid=c.deliveryIid and a.deliveryIIid=d.deliveryIIid and orderid=@orderid";

            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                if (dr.Read())
                {

                    item.orderid = TypeParse.DbObjToString(dr["orderid"].ToString(), "0");
                    item.tel = TypeParse.DbObjToString(dr["tel"].ToString(), "");
                    item.ordernumber = TypeParse.DbObjToString(dr["ordernumber"].ToString(), "");
                    item.mobile = TypeParse.DbObjToString(dr["mobile"].ToString(), "");
                    item.address = TypeParse.DbObjToString(dr["address"].ToString(), "");
                    item.contact = TypeParse.DbObjToString(dr["contact"].ToString(), "");
                    item.allmoney = Decimal.Parse(TypeParse.DbObjToString(dr["allmoney"].ToString(), "0.00"));
                    item.paymoney = Decimal.Parse(TypeParse.DbObjToString(dr["paymoney"].ToString(), "0.00"));
                    item.orderstate = TypeParse.DbObjToInt(dr["orderstate"].ToString(), 0);
                    item.orderdate = TypeParse.DbObjToDateTime(dr["orderdate"].ToString(), DateTime.Now);
                    item.deliverydate = TypeParse.DbObjToDateTime(dr["deliverydate"].ToString(), DateTime.Now);
                    item.ordernumber = TypeParse.DbObjToString(dr["ordernumber"].ToString(), "");
                    item.deliveryI = TypeParse.DbObjToString(dr["deliveryI"].ToString(), "");
                    item.deliveryII = TypeParse.DbObjToString(dr["deliveryII"].ToString(), "");
                    item.deliveryIid = TypeParse.DbObjToInt(dr["deliveryIid"].ToString(), 0);
                    item.deliveryIIid = TypeParse.DbObjToInt(dr["deliveryIIid"].ToString(), 0);
                    switch (item.orderstate)
                    {
                        case 0:
                            item.orderstatestr = "进行中";
                            break;
                        case 10:
                            item.orderstatestr = "已完成";
                            break;
                        case 44:
                            item.orderstatestr = "待处理";
                            break;
                        default:
                            item.orderstatestr = "进行中";
                            break;
                    }
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

        #region 取消订单

        //取消订单
        public static bool delcartandorder(string ordernumber)
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@ordernumber", SqlDbType.NVarChar, 50);
            parms[0].Value = ordernumber;

            string sql = "delete [userorder]  where ordernumber=@ordernumber " +
                         "delete [usercart] where ordernumber=@ordernumber";
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                return result > 0;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
        }

        #endregion

        #region 改变订单产品状态 
        
        //改变订单流程状态
        public static bool changeorderstatebylevel(string ordernumber, int state)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@ordernumber", SqlDbType.NVarChar, 50);
            parms[0].Value = ordernumber;
            parms[1] = new SqlParameter("@state", SqlDbType.Int);
            parms[1].Value = state;

            string sql = "update [userorder] set orderstate=@state where ordernumber=@ordernumber ";                        
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.connectionstring, CommandType.Text, sql, parms);
                return result > 0;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
            finally
            { }
        }

        #endregion

        #region 得到订单号码

        public static string getordernumber(string uid)
        {
            string ordernumber = uid + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            return ordernumber;
        }

        #endregion

        #region 得到订单的条数

        public static int getcount()
        {

            string sql = "select count(*) as n  FROM userorder";
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

        public static int getcountbycondition(string where)
        {

            string sql = "select count(*) as n  FROM userorder where " + where;
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

        #region 编辑订单

        /// <summary>
        ///编辑订单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool editorder(orderinfo data)
        {
            SqlParameter[] parms = new SqlParameter[5];
            parms[0] = new SqlParameter("@id", SqlDbType.VarChar, 20);
            parms[0].Value = data.orderid;           
            parms[1] = new SqlParameter("@deliverydate", SqlDbType.DateTime);
            parms[1].Value = data.deliverydate;          
            parms[2] = new SqlParameter("@orderstate", SqlDbType.Int);
            parms[2].Value = data.orderstate;           
            parms[3] = new SqlParameter("@deliveryIid", SqlDbType.Int);
            parms[3].Value = data.deliveryIid;
            parms[4] = new SqlParameter("@deliveryIIid", SqlDbType.Int);
            parms[4].Value = data.deliveryIIid;

            string sql = "update [userorder] set deliverydate=@deliverydate,orderstate=@orderstate,deliveryIid=@deliveryIid,deliveryIIid=@deliveryIIid where orderid=@id";
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

    }
}
