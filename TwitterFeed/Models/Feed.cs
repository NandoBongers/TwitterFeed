using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterFeed.Models
{
    public class Feed
    {
        public string text { get; set; }
        public List<Feed> getTweets(string key)
        {
            RestClient tweetClient = new RestClient("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=vsauce&count=4");
            RestRequest getRequest = new RestRequest(Method.GET);
            
            getRequest.AddHeader("Cache-Control", "no-cache");
            getRequest.AddHeader("Authorization", "bearer " + key);
            IRestResponse tweetResponse = tweetClient.Execute(getRequest);

            return JsonConvert.DeserializeObject<List<Feed>>(tweetResponse.Content);
        }
    }
}