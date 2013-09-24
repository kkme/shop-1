using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morrison.Models
{
    public class orderinfo
    {
        //购物篮ID
        public string cartid
        {
            get;
            set;
        }
        //用户ID
        public string userid
        {
            get;
            set;
        }
        //产品ID
        public int productid
        {
            get;
            set;
        }

        //添加日期
        public DateTime adddate
        {
            get;
            set;
        }
        //购买数量
        public int buynum
        {
            get;
            set;
        }
        //购买统计数量
        public int tjbuynum
        {
            get;
            set;
        }

        //订单编号
        public string ordernumber
        {
            get;
            set;
        }

        //购物车状态：0为未生成订单 1为生成订单
        public int cartstate
        {
            get;
            set;
        }
      

        //产品名称
        public string productname
        {
            get;
            set;
        }

        //产品名称
        public string productcode
        {
            get;
            set;
        } 

        //vip价格
        public decimal vipprice
        {
            get;
            set;
        }


        //产品图片
        public string productimg
        {
            get;
            set;
        }

        //订单ID
        public string orderid { get; set; }

        //订单日期
        public DateTime orderdate { get; set; }

        //送货日期
        public DateTime deliverydate { get; set; }

        //订单总额
        public decimal allmoney { get; set; }

        //应付总额
        public decimal paymoney { get; set; }

        //订单状态 0为初始状态  10为已完成  44为待处理
        public string orderstatestr { get; set; }

        //订单状态id
        public int orderstate { get; set; }

        //送货地址ID
        public int addressid
        {
            get;
            set;
        }
        //配送区域I id
        public int deliveryIid
        {
            get;
            set;
        }
        //配送区域II id
        public int deliveryIIid
        {
            get;
            set;
        }
        //配送区域I 
        public string deliveryI
        {
            get;
            set;
        }
        //配送区域II 
        public string deliveryII
        {
            get;
            set;
        }
        //送货详细地址
        public string address
        {
            get;
            set;
        }
        //联系电话
        public string tel
        {
            get;
            set;
        }
        //联系手机
        public string mobile
        {
            get;
            set;
        }
        //联系人
        public string contact
        {
            get;
            set;
        }

        //订单备注
        public string ordernote { get; set; }
    }
}
