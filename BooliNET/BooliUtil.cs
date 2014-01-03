using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Globalization;

namespace BooliNET
{
    public static class BooliUtil
    {
        public enum IdType
        {
            Listings,
            Sold,
        }

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

            string urlStart =  "http://api.booli.se";
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

        public static void CheckPositiveOrZeroInt(int inInt, string paramName)
        {
            if (inInt < 0)
            {
                throw new ArgumentException("Parameter must be a positive or zero integer!", paramName);
            }
        }

        public static void CheckCorrectDate(string inString, string paramName)
        {
            if (inString.Length != 8)
            {
                throw new ArgumentException("A created date must be on the format 20100101!", paramName);
            }

            string year = inString.Substring(0, 4);
            string month = inString.Substring(4, 2);
            string day = inString.Substring(6, 2);

            try
            {
                DateTime.Parse(year + "-" + month + "-" + day);
            }
            catch (FormatException)
            {
                throw new FormatException("A created date must be on the format 20100101!");
            }
        }

        public static void LatLongCheck(string inString, string paramName)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            string[] splitString = inString.Split(',');
            if (splitString.Length != 2)
            {
                throw new ArgumentException("Latitude must be between 90 and -90 and Longitude must be between 180 and -180 and be in the format 1.0,1.0!", paramName);
            }
            double Lat = double.Parse(splitString[0], NumberStyles.Float);
            double Long = double.Parse(splitString[1], NumberStyles.Float);

            if (Lat < -90 || Lat > 90)
            {
                throw new ArgumentException("Latitude must be between 90 and -90 and Longitude must be between 90 and -90 and be in the format 1.0,1.0!", paramName);
            }

            if (Long < -180 || Long > 180)
            {
                throw new ArgumentException("Latitude must be between 90 and -90 and Longitude must be between 180 and -180 and be in the format 1.0,1.0!", paramName);
            }
        }

        public static void LatCheck(string inString, string paramName)
        {
            double Lat = double.Parse(inString, NumberStyles.Float);

            if (Lat < -90 || Lat > 90)
            {
                throw new ArgumentException("Latitude must be between 90 and -90 and Longitude must be between 90 and -90!", paramName);
            }
        }

        public static void LongCheck(string inString, string paramName)
        {
            double Long = double.Parse(inString, NumberStyles.Float);

            if (Long < -180 || Long > 180)
            {
                throw new ArgumentException("Latitude must be between 90 and -90 and Longitude must be between 180 and -180!", paramName);
            }
        }
    }
}
