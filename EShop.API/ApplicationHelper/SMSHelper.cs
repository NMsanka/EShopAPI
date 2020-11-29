using EShop.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace EShop.API
{
    public static class SMSHelper
    {
        static string mbnumber, sendMessage, sender;
        //  Device = "http://api.silverstreet.com/send.php";
        public static string SendSMS(SMSModel smsmodel, string CountryFormat)
        {
            if (smsmodel.RecipientNumber == null)
                return null;

            sender = smsmodel.Sender.Replace(" ", string.Empty);

            smsmodel.Message = smsmodel.Message.Replace("(%FIRSTNAME%)", smsmodel.FirstName);
            smsmodel.Message = smsmodel.Message.Replace("(%LASTNAME%)", smsmodel.LastName);
            smsmodel.Message = smsmodel.Message.Replace("((%PREFERREDNAME%))", smsmodel.PreferredName);

            if (smsmodel.isShortCode) sendMessage = Uri.EscapeUriString(smsmodel.Message);
            else sendMessage = Uri.EscapeUriString(smsmodel.Message);
            mbnumber = smsmodel.RecipientNumber;
            //replace + sign in number
            mbnumber = mbnumber.Replace("+", string.Empty);
            //replace - sign in number
            mbnumber = mbnumber.Replace("-", string.Empty);
            //replace ( sign in number
            mbnumber = mbnumber.Replace("(", string.Empty);
            //replace ) sign in number
            mbnumber = mbnumber.Replace(")", string.Empty);
            //replace " " sign in number
            mbnumber = mbnumber.Replace(" ", string.Empty);
            //remove white space charcters
            mbnumber = mbnumber.Trim();

            if (CountryFormat == "MY") return SMSSenderMY(mbnumber, sender, sendMessage, smsmodel.Device, smsmodel.isShortCode);
            else if (CountryFormat == "US") return SMSSenderUS(mbnumber, sender, sendMessage, smsmodel.Device, smsmodel.isShortCode); 
            else if (CountryFormat == "SG") return SMSSenderSG(mbnumber, sender, sendMessage, smsmodel.Device, smsmodel.isShortCode);
            else return SMSSender(mbnumber, sendMessage, smsmodel.Device);
        }

        private static string SMSSenderMY(string mobile, string sender, string message, string device, bool isShortCode)
        {
            string smsOutput = "", postData = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(device);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            if (isShortCode)
            {
                postData = "username=cpadmin2&password=QSxT3KqG&concat=1&bodytype=1&destination=" + mobile.Replace(" ", string.Empty) + "&sender=" + sender + "&body=" + message;
            }
            else
            {
                postData = "username=cpadmin&password=ygWLvBg&concat=1&bodytype=1&destination=" + mobile.Replace(" ", string.Empty) + "&sender=" + sender + "&body=" + message;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            if (result == "01")
            {
                smsOutput = "OK";
            }
            else if (result == "100")
            {
                smsOutput = "Parameter(s) are missing.";
            }
            else if (result == "110")
            {
                smsOutput = "Bad combination of parameters.";
            }
            else if (result == "120")
            {
                smsOutput = "Invalid parameter(s).";
            }
            else if (result == "130")
            {
                smsOutput = "Insufficient credits for the account.";
            }
            else
            {
                smsOutput = result.ToString();
            }
            stream.Dispose();
            reader.Dispose();

            return smsOutput;
        }

        private static string SMSSenderUS(string mobile, string sender, string message, string device, bool isShortCode)
        {
            string smsOutput = "", postData = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(device);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            if (isShortCode)
            {
                postData = "username=cpadmin2&password=QSxT3KqG&concat=1&bodytype=1&destination=" + mobile.Replace(" ", string.Empty) + "&sender=" + sender + "&body=" + message;
            }
            else
            {
                postData = "username=cpadmin2&password=QSxT3KqG&concat=1&bodytype=1&destination=" + mobile.Replace(" ", string.Empty) + "&sender=" + sender + "&body=" + message;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            if (result == "01")
            {
                smsOutput = "OK";
            }
            else if (result == "100")
            {
                smsOutput = "Parameter(s) are missing.";
            }
            else if (result == "110")
            {
                smsOutput = "Bad combination of parameters.";
            }
            else if (result == "120")
            {
                smsOutput = "Invalid parameter(s).";
            }
            else if (result == "130")
            {
                smsOutput = "Insufficient credits for the account.";
            }
            else
            {
                smsOutput = result.ToString();
            }
            stream.Dispose();
            reader.Dispose();

            return smsOutput;
        }

        private static string SMSSenderSG(string mobile, string sender, string message, string device, bool isShortCode)
        {
            string smsOutput = "", postData = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(device);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            if (isShortCode)
            {
                postData = "username=cpadmin2&password=QSxT3KqG&concat=1&bodytype=1&destination=" + mobile.Replace(" ", string.Empty) + "&sender=" + sender + "&body=" + message;
            }
            else
            {
                postData = "username=cpadmin2&password=QSxT3KqG&concat=1&bodytype=1&destination=" + mobile.Replace(" ", string.Empty) + "&sender=" + sender + "&body=" + message;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            if (result == "01")
            {
                smsOutput = "OK";
            }
            else if (result == "100")
            {
                smsOutput = "Parameter(s) are missing.";
            }
            else if (result == "110")
            {
                smsOutput = "Bad combination of parameters.";
            }
            else if (result == "120")
            {
                smsOutput = "Invalid parameter(s).";
            }
            else if (result == "130")
            {
                smsOutput = "Insufficient credits for the account.";
            }
            else
            {
                smsOutput = result.ToString();
            }
            stream.Dispose();
            reader.Dispose();

            return smsOutput;
        }
        private static string SMSSender(string mobile, string message, string device)
        {
            string smsOutput = "", getmessage = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(device);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                getmessage = HttpUtility.UrlEncode(message);
                string postData = "md=smsapi&pass=Notify&num=" + mobile + "&msg=" + getmessage;
                byte[] bytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bytes.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string result = reader.ReadToEnd();
                stream.Dispose();
                reader.Dispose();

                smsOutput = "OK";
            }
            catch (Exception ex)
            {
                smsOutput = ex.Message;
            }

            return smsOutput;
        }
    }
}