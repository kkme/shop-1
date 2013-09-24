using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Morrison.Helper
{
    public class comm
    {
        /// <summary>
        /// 截断字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubStr(string str, int length)
        {
            if (str == null || length == 0)
            {
                return "";
            }
            else
            {

                if (str.Length < length + 1)
                {
                    return str;
                }
                else
                {
                    return str.Substring(0, length);
                }
            }
        }

        public static string SubStr2(string str, int length)
        {
            if (str == null || length == 0)
            {
                return "";
            }
            else
            {

                if (str.Length < length + 1)
                {
                    return str;
                }
                else
                {
                    return str.Substring(0, length)+"..";
                }
            }
        }

        /// <summary>
        /// 判断是否为整数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static bool isNumber(string strValue)
        {

            Regex regex = new Regex("^[0-9]*[1-9][0-9]*$");
            return regex.IsMatch(strValue.Trim());

        }





    }
}
