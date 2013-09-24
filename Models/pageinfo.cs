using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Morrison.Models
{
    public class pageinfo
    {
        //当前页
        public int curpageindex
        {
            get;
            set;
        }
        //数据总数
        public int recordcount
        {
            get;
            set;
        }
        //页条数
        public int pagesize
        {
            get;
            set;
        }
        //总页数
        public int totalpagecount
        {
            get;
            set;
        }
        //字段
        public string fieldlist
        {
            get;
            set;
        }
        //表名称
        public string tablename
        {
            get;
            set;
        }
        //条件
        public string where
        {
            get;
            set;
        }
      
        //排序
        public string order
        {
            get;
            set;
        }
        //排序类型
        public int sorttype
        {
            get;
            set;
        }
        //主键
        public string primarykey
        {
            get;
            set;
        }
    }
}