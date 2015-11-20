using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcf_client.ServiceReference1;
using System.ServiceModel.Channels;
using System.Xml;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Security.Cryptography;

namespace wcf_client
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //System.ServiceModel.Channels.CustomBinding binding = new System.ServiceModel.Channels.CustomBinding();
           // binding.MaxReceivedMessageSize = 2147483647;

            DataServiceClient client = new DataServiceClient();

            if (client.GetWebPredict().Length>0)
            {
                string body = client.GetWebData();
                //Response.Write(body);
                string jsonString = DecryptAES(body, "qjkHuIy9D/9i=", "Mi9l/+7Zujhy12se6Yjy111A");
                Response.Write(jsonString);

                //Response.Write(client.GetWebPredict());


                //string abcd=System.Text.Encoding.ASCII.;
               // Response.Write(abc);

               // byte[] buffer = System.Text.Encoding.UTF8.GetBytes(body);
                //byte[] ss = Convert.FromBase64String(body);
                
                //string s = System.Text.Encoding.ASCII.GetString(ss);
                //string s = System.Text.Encoding.UTF8.GetString(ss);
                //string s = System.Text.Encoding.Default.GetString(ss);
                //string s = System.Text.Encoding.Unicode.GetString(ss);

//                 var stream = new MemoryStream(ss);
//                 var result = new BinaryFormatter().Deserialize(stream);


                
                //Response.Write(client.GetWebPredict().ToString());

                client.Close();
            }           

        }
        public static string DecryptAES(string decryptString, string decryptKey, string salt)
        {
            AesManaged aes = null;
            MemoryStream ms = null;
            CryptoStream cs = null;

            string str = null;

            try
            {
                Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(decryptKey, Encoding.UTF8.GetBytes(salt));

                aes = new AesManaged();
                aes.Key = rfc2898.GetBytes(aes.KeySize / 8);
                aes.IV = rfc2898.GetBytes(aes.BlockSize / 8);

                ms = new MemoryStream();
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
