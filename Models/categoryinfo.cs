using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Morrison.Models
{
    public class categoryinfo
    {
        //大目录ID
        public int bigcategoryid
        {
            get;
            set;
        }
        //大目录
        public string bigcategory
        {
            get;
            set;
        }
        //大目录图片
        public string bigcategoryimg
        {
            get;
            set;
        } 
        //小目录ID
        public int smallcategoryid
        {
            get;
            set;
        }
        //小目录
        public string smallcategory
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
        //推荐类型
        public string tjtype
        {
            get;
            set;
        }
        //产地ID
        public int placeid
        {
            get;
            set;
        }
        //产地
        public string place
        {
            get;
            set;
        }
        //配送地址I ID
        public int deliveryIid
        {
            get;
            set;
        }
        //配送地址I
        public string deliveryI
        {
            get;
            set;
        }
        //配送地址II ID
        public int deliveryIIid
        {
            get;
            set;
        }
        //配送地址II
        public string deliveryII
        {
            get;
            set;
        }

    }
}