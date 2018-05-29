using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Twitter.Connector
{
    public class TokenManager
    {
        private string _key = "Your key here";
        private string _secret = "Your secret here";
        private string _token = "";
        public string Token {
            get
            {
                if  (string.IsNullOrWhiteSpace (_token))
                    _token = GenerateBearerToken();
                return _token;
            }
      
        }

        private string GenerateBearerToken()
        {
            var requestStr = HttpUtility.UrlEncode(_key) + ":" + HttpUtility.UrlEncode(_secret);
            requestStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(requestStr));

            var request = WebRequest.Create("https://api.twitter.com/oauth2/token");
            request.Headers.Add("Authorization", "Basic " + requestStr);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            var bytearrayRequestContent = Encoding.UTF8.GetBytes("grant_type=client_credentials");
            var requestStream = request.GetRequestStream();
            requestStream.Write(bytearrayRequestContent, 0, bytearrayRequestContent.Length);
            requestStream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseStream = response.GetResponseStream();
                var responseJson = new StreamReader(responseStream).ReadToEnd();
                var jobjectResponse = JObject.Parse(responseJson);
                return jobjectResponse["access_token"].ToString();
            }
            throw new Exception($"Error creating token with status {response.StatusCode}" );
         
        }
    }
}
