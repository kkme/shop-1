using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Security.Cryptography;

namespace Morrison.Helper
{
    /// <summary>
    /// 在应用程序中定义用于单向加密文本的方法
    /// </summary>
    public class TextEncrypt
    {
        #region 隐藏构造方法
        private TextEncrypt()
        { }
        #endregion

        #region DSA 加密

        /// <summary>
        /// DSA 加密
        /// </summary>
        /// <param name="password">要加密的字符串</param>
        /// <returns>等效于此实例经过 DSA 加密密文</returns>
        public static string DSAEncryptPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            DSACryptoServiceProvider ServiceProvider = new DSACryptoServiceProvider();
            string NewPassword = BitConverter.ToString(ServiceProvider.SignData(Encoding.UTF8.GetBytes(password)));
            ServiceProvider.Clear();
            return NewPassword.Replace("-", null);
        }

        #endregion

        #region MD5 加密

        /// <summary>
        /// MD5 加密 
        /// </summary>
        /// <param name="password">要加密的字符串</param>
        /// <returns>等效于此实例经过 MD5 加密密文</returns>
        public static string EncryptPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            return MD5EncryptPassword(password);
        }

        /// <summary>
        /// MD5 加密 
        /// </summary>
        /// <param name="password">要加密的字符串</param>
        /// <returns>等效于此实例经过 MD5 加密密文</returns>
        public static string MD5EncryptPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            return MD5EncryptPassword(password, MD5ResultMode.Strong);
        }

        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="password">要加密的字符串</param>
        /// <param name="mode">加密强度</param>
        /// <returns>等效于此实例经过 MD5 加密密文</returns>
        public static string MD5EncryptPassword(string password, MD5ResultMode mode)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            MD5CryptoServiceProvider ServiceProvider = new MD5CryptoServiceProvider();
            string NewPassword = BitConverter.ToString(ServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(password)));
            ServiceProvider.Clear();
            if (mode != MD5ResultMode.Strong)
            {
                return NewPassword.Replace("-", null).Substring(8, 0x10);
            }
            return NewPassword.Replace("-", null);
        }

        #endregion

        #region SHA1 加密

        /// <summary>
        /// SHA1 加密
        /// </summary>
        /// <param name="password">要加密的字符串</param>
        /// <returns>等效于此实例经过 SHA1 加密</returns>
        public static string SHA1EncryptPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            SHA1CryptoServiceProvider ServiceProvider = new SHA1CryptoServiceProvider();
            string NewPassword = BitConverter.ToString(ServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(password)));
            ServiceProvider.Clear();
            return NewPassword.Replace("-", null);
        }

        /// <summary>
        /// SHA256 加密
        /// </summary>
        /// <param name="password">要加密的字符串</param>
        /// <returns>等效此实例经过 SHA256 加密密文</returns>
        public static string SHA256(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            SHA256Managed managed = new SHA256Managed();
            return Convert.ToBase64String(managed.ComputeHash(bytes));
        }

        #endregion

        #region Base64编解码

        /// <summary>
        /// Base64 编码
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Base64Encode(string message)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(message));
        }

        /// <summary>
        /// Base64 解码
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Base64Decode(string message)
        {
            byte[] bytes = Convert.FromBase64String(message);
            return Encoding.UTF8.GetString(bytes);
        }

        #endregion
    }

    /// <summary>
    /// MD5 加密的强度模式 
    /// </summary>
    public enum MD5ResultMode : byte
    {
        /// <summary>
        /// 强密码模式 
        /// </summary>
        Strong = 0,

        /// <summary>
        /// 弱密码模式 
        /// </summary>
        Weak = 1
    }
}