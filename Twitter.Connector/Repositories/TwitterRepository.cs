using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Twitter.Connector.Models;

namespace Twitter.Connector.Repositories
{
    public class TwitterRepository
    {
        private TokenManager _tokenManager;

        public TwitterRepository()
        {
            _tokenManager = new TokenManager();
        }

        public List< Status> Search(string query)
        {
            query = HttpUtility.UrlEncode(query);
            var request = WebRequest.Create($"https://api.twitter.com/1.1/search/tweets.json?q={query}");
            request.Headers.Add("Authorization", "Bearer " + _tokenManager.Token);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
          
            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(
                    $"cannot search in twitter error code:{response.StatusCode}: {response.StatusDescription}");

            var stream = response.GetResponseStream();
            var jsonResp = new StreamReader(stream).ReadToEnd();
            var searchResults = JsonConvert.DeserializeObject<TwitterSearchResult>(jsonResp);
            return searchResults.statuses.ToList();
        }
    }
}
