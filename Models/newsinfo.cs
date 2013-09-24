using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Morrison.Models
{
    public class newsinfo : pageinfo
    {
        /// <summary>
        /// 资讯类别ID
        /// </summary>
        public int ntid
        {
            get;
            set;
        }
        /// <summary>
        /// 资讯类别名称
        /// </summary>
        public string newstype
        {
            get;
            set;
        }
        /// <summary>
        /// 资讯ID
        /// </summary>
        public int newsid
        {
            get;
            set;
        }
        /// <summary>
        /// 资讯标题
        /// </summary>
        public string newstitle
        {
            get;
            set;
        }
        /// <summary>
        /// 资讯作者
        /// </summary>
        public string newswriter
        {
            get;
            set;
        }
        /// <summary>
        /// 资讯来源
        /// </summary>
        public string newsfrom
        {
            get;
            set;
        }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime adddate
        {
            get;
            set;
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public int istop
        {
            get;
            set;
        }
        /// <summary>
        /// 资讯简介
        /// </summary>
        public string newsnote
        {
            get;
            set;
        }
        /// <summary>
        /// 资讯内容
        /// </summary>
        public string ninfo
        {
            get;
            set;
        }
        /// <summary>
        /// 资讯图片
        /// </summary>
        public string newsimg
        {
            get;
            set;
        }
        public string userid
        {
            get;
            set;
        }
        public int newsstate
        {
            get;
            set;
        }
    }
}