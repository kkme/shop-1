using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Morrison.Models
{
    public class webimagesinfo : pageinfo
    {
        /// <summary>
        /// 图片类型ID
        /// </summary>
        public int itid
        {
            get;
            set;
        }
        /// <summary>
        /// 图片类型
        /// </summary>
        public string imagestype
        {
            get;
            set;
        }
        /// <summary>
        /// 图片介绍
        /// </summary>
        public string imginfo
        {
            get;
            set;
        }
        /// <summary>
        /// 图片导航
        /// </summary>
        public string imgurl
        {
            get;
            set;
        }
        /// <summary>
        /// 图片ID
        /// </summary>
        public int wiid
        {
            get;
            set;
        }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string imgname
        {
            get;
            set;
        }
        /// <summary>
        /// 所属公司
        /// </summary>
        public string imgcor
        {
            get;
            set;
        }
    }
}