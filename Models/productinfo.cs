using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Morrison.Models
{
    public class productinfo : pageinfo
    {
        //产品ID
        public int productid
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
        //产品编号
        public string productcode
        {
            get;
            set;
        }
        //会员价格
        public decimal vipprice
        {
            get;
            set;
        }
        //产品价格
        public decimal productprice
        {
            get;
            set;
        }
        //产品简介
        public string productbrief
        {
            get;
            set;
        }
        //产品介绍
        public string productintroduce
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
        //产品小类ID
        public int smallcategoryid
        {
            get;
            set;
        }
        //产品大类ID
        public int bigcategoryid
        {
            get;
            set;
        }
        //产品小类
        public string smallcategory
        {
            get;
            set;
        }
        //产品大类
        public string bigcategory
        {
            get;
            set;
        }   
        //产品产地ID
        public int placeid
        {
            get;
            set;
        }
        //产品产地
        public string place
        {
            get;
            set;
        }
        //产品品牌
        public string brand
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
        //修改日期
        public DateTime editdate
        {
            get;
            set;
        }
        //推荐类型ID
        public int tjtypeid
        {
            get;
            set;
        }
        //销售单位
        public string punit
        {
            get;
            set;
        }
        //销售状态 0为正常销售 1为缺货
        public int salestate
        {
            get;
            set;
        }

    }
}