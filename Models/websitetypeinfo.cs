using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Morrison.Models
{
    public class websitetypeinfo : pageinfo
    {
        //网站内容类型ID
        public int wtid
        {
            get;
            set;
        }
        //网站内容ID
        public int wsid
        {
            get;
            set;
        }
        //网站内容类型
        public string websitetype
        {
            get;
            set;
        }
        //网站内容
        public string websitecontent
        {
            get;
            set;
        }
    }
}