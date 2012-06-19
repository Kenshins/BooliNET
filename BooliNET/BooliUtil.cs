using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace BooliNET
{
    public static class BooliUtil
    {
        public static string AddIdKey()
        {
            return "";
        }

        public static string CreateUnique()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[16];
            var random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new String(stringChars);
            return finalString;
        }

        public static string CreateSha1(string inString)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] data = encoding.GetBytes(inString);
 
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] byteResult = sha.ComputeHash(data);

            string hex = BitConverter.ToString(byteResult);
            hex = hex.Replace("-", "");

            return hex.ToLower();
        }

        public static string CreateCompleteUrl(string searchUrl, string callerId, string key)
        {
            string time = ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            string unique = CreateUnique();
            string hash = CreateSha1(callerId + time + key + unique);

            string urlStart =  "http://api.booli.se/listings?";
            string urlEnd = "&callerId=" + callerId + "&time=" + time + "&unique=" + unique + "&hash=" + hash;

            return urlStart + searchUrl + urlEnd;
        }

        public static string DoGetJson(string url)
        {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();
                string rawJson;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    rawJson = sr.ReadToEnd();
                }

                return rawJson;
        }
    }
}
