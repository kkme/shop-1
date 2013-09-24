using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace Morrison.Helper
{
    /// <summary>
    /// 类型转换工具类
    /// </summary>
    public class TypeParse
    {
        /// <summary>
        /// 字符串转整型
        /// </summary>
        /// <param name="strvalue">要转换的值</param>
        /// <param name="defaultvalue">默认值</param>
        /// <returns>int</returns>
        public static int StrToInt(string strvalue, int defValue)
        {
            if (strvalue == null || strvalue.Split('-').Length > 10)
                return defValue;
            else
            {
                if (Regex.IsMatch(strvalue, @"^([-]|\d)(\d*)$"))
                    return Convert.ToInt32(strvalue);
                else
                    return defValue;
            }
        }

        /// <summary>
        /// 字符串转浮点型
        /// </summary>
        /// <param name="strvalue">要转换的值</param>
        /// <param name="defValue">默认值</param>
        /// <returns>float</returns>
        public static float StrToFloat(string strvalue, float defValue)
        {
            if (strvalue == null || strvalue.Split('-').Length > 10)
                return defValue;
            else
            {
                if (Regex.IsMatch(strvalue, @"^([-]|\d)[\d]*(\.\d*)?$"))
                    return Convert.ToSingle(strvalue);
                else
                    return defValue;
            }
        }

        /// <summary>
        /// 对象转整型
        /// </summary>
        /// <param name="dbobjvalue">要转换的值</param>
        /// <param name="defaultvalue">默认值</param>
        /// <returns>int</returns>
        public static int DbObjToInt(object dbobjvalue, int defValue)
        {
            if (dbobjvalue == System.DBNull.Value || dbobjvalue == null) return defValue;
            return StrToInt(dbobjvalue.ToString(), defValue);
        }

        /// <summary>
        /// 对象转浮点型
        /// </summary>
        /// <param name="dbobjvalue">要转换的值</param>
        /// <param name="defaultvalue">默认值</param>
        /// <returns>float</returns>
        public static float DbObjToFloat(object dbobjvalue, float defValue)
        {
            if (dbobjvalue == System.DBNull.Value || dbobjvalue == null) return defValue;
            return StrToFloat(dbobjvalue.ToString(), defValue);
        }

        /// <summary>
        /// 对象转字符串
        /// </summary>
        /// <param name="dbobjvalue">要转换的值</param>
        /// <param name="defaultvalue">默认值</param>
        /// <returns>string</returns>
        public static string DbObjToString(object dbobjvalue, string defValue)
        {
            if (dbobjvalue == System.DBNull.Value || dbobjvalue == null)
                return defValue;
            else
                return dbobjvalue.ToString().Trim();
        }

        /// <summary>
        /// 对象转Bool
        /// </summary>
        /// <param name="dbobjvalue">要转换的值</param>
        /// <param name="defaultvalue">默认值</param>
        /// <returns>bool</returns>
        public static bool DbObjToBool(object dbobjvalue, bool defValue)
        {
            if (dbobjvalue == System.DBNull.Value || dbobjvalue == null)
                return defValue;
            else
                return Convert.ToBoolean(dbobjvalue);
        }

        /// <summary>
        /// 对象装DateTime
        /// </summary>
        /// <param name="dbobjvalue"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static DateTime DbObjToDateTime(object dbobjvalue, DateTime defValue)
        {
            if (dbobjvalue == System.DBNull.Value || dbobjvalue == null || dbobjvalue.Equals(""))
                return defValue;
            else
                return DateTime.Parse(dbobjvalue.ToString());
        }
    }
}