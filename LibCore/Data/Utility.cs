using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace LibCore.Data
{
    public class Utility
    {
        #region GenerateRandomCode
        /// <summary>
        /// Randoms the code by lenght.
        /// </summary>
        /// <param name="lenght">The lenght.</param>
        /// <returns>String</returns>
        public static string RandomCodeByLenght(int lenght)
        {
            Random random = new Random();
            const string _chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] buffer = new char[lenght];
            for (int i = 0; i < lenght; i++)
            {
                buffer[i] = _chars[random.Next(_chars.Length)];
            }
            return new string(buffer);
        }
        #endregion

        #region CookiesControl
        /// <summary>
        /// Saves the cookie.
        /// </summary>
        /// <param name="_cookieName">Name of the cookie.</param>
        /// <param name="_value">The value.</param>
        /// <param name="_expires">The expires.</param>
        public static void SaveCookie(string _cookieName, string _value, int _expires)
        {
            var _cookies = new HttpCookie(_cookieName) { Value = EncryptASE(_value), Expires = DateTime.Now.AddDays(_expires) };
            _cookies.HttpOnly = true;// cookie not available in js
            HttpContext.Current.Response.Cookies.Add(_cookies);//Save userID to cookie when remember checked.
        }

        /// <summary>
        /// Clears the cookie.
        /// </summary>
        /// <param name="_cookieName">Name of the cookie.</param>
        public static void ClearCookie(string _cookieName) 
        {
            var _cookies = new HttpCookie(_cookieName) { Expires = DateTime.Now.AddDays(-365) };
            HttpContext.Current.Response.Cookies.Add(_cookies);
        }
        #endregion

        #region ASE256 Encrypt
        private static string AesIV = ConfigurationManager.AppSettings["AesIV"];
        private static string AesKey = ConfigurationManager.AppSettings["AesKey"];

        /// <summary>
        /// Encrypts the ASE.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>string</returns>
        public static string EncryptASE(string text)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.IV = Convert.FromBase64String(AesIV);
                aes.Key = Convert.FromBase64String(AesKey);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Convert string to byte array
                byte[] src = Encoding.Unicode.GetBytes(text);

                // encryption
                using (ICryptoTransform encrypt = aes.CreateEncryptor())
                {
                    byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                    // Convert byte array to Base64 strings
                    return Convert.ToBase64String(dest);
                }
            }
            catch (Exception ex)
            {
                return text;
            }
        }

        /// <summary>
        /// Decrypts the ASE.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string DecryptASE(string text)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.IV = Convert.FromBase64String(AesIV);
                aes.Key = Convert.FromBase64String(AesKey);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Convert Base64 strings to byte array
                byte[] src = System.Convert.FromBase64String(text);


                // decryption
                using (ICryptoTransform decrypt = aes.CreateDecryptor())
                {
                    byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                    return Encoding.Unicode.GetString(dest);
                }
            }
            catch
            {
                return text;

            }
        }

        public static Stream EncryptFile(Stream inputStream)
        {
            var algorithm = new RijndaelManaged { KeySize = 256, BlockSize = 128 };
            var key = new Rfc2898DeriveBytes(AesIV, Encoding.ASCII.GetBytes(AesKey));

            algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
            algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

            try
            {
                return new CryptoStream(inputStream, algorithm.CreateEncryptor(), CryptoStreamMode.Read);
            }
            catch
            {
                return inputStream;
            }
        }

        public static Stream DecryptFile(Stream inputStream)
        {
            var algorithm = new RijndaelManaged { KeySize = 256, BlockSize = 128 };
            var key = new Rfc2898DeriveBytes(AesIV, Encoding.ASCII.GetBytes(AesKey));

            algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
            algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

            try
            {
                return new CryptoStream(inputStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read);
            }
            catch
            {
                return inputStream;
            }
        }
        #endregion
    }
}
