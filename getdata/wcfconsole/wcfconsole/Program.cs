using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wcfconsole.ServiceReference1;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Data;

namespace wcfconsole
{
    class Program
    {
        static void Main(string[] args)
        {

            DataServiceClient client = new DataServiceClient();

            if (client.GetWebPredict().Length > 0)
            {
                string webData = client.GetWebData();
                //string aaaa=webData.Replace("//","");

                string jsonString = DecryptAES(webData, "qjkHuIy9D/9i=", "Mi9l/+7Zujhy12se6Yjy111A");
                


               
                Console.Write(jsonString);
                //Console.ReadKey();
               

                //string webPredict = client.GetWebPredict();
                //JsonValue value3 = JsonValue.Parse(webPredict)["Table"];
  
               // Console.Write(webPredict);
               
               // Console.ReadKey();
                //string webAlert = client.GetWebAlert();
                //Console.Write(webAlert);

                client.Close();
            }  
        }
        /// <summary>
        /// 使用AES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密字符串</param>
        /// <param name="decryptKey">解密密匙</param>
        /// <param name="salt">盐</param>
        /// <returns>解密结果，解谜失败则返回源串</returns>
        public static string DecryptAES(string decryptString, string decryptKey, string salt)
        {
            AesManaged aes = null;
            System.IO.MemoryStream ms = null;
            CryptoStream cs = null;

            string str = null;

            try
            {
                Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(decryptKey, Encoding.UTF8.GetBytes(salt));

                aes = new AesManaged();
                aes.Key = rfc2898.GetBytes(aes.KeySize / 8);
                aes.IV = rfc2898.GetBytes(aes.BlockSize / 8);

                ms = new System.IO.MemoryStream();
                cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);

                byte[] data = Convert.FromBase64String(decryptString);
                cs.Write(data, 0, data.Length);
                cs.FlushFinalBlock();

                str = Encoding.UTF8.GetString(ms.ToArray(), 0, ms.ToArray().Length);
            }
            catch
            {
                str = decryptString;
            }
            finally
            {
                if (cs != null)
                    cs.Close();

                if (ms != null)
                    ms.Close();

                if (aes != null)
                    aes.Clear();
            }

            return str;
        }

    }
}
