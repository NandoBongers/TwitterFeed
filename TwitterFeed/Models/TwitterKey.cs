using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterFeed.Models
{
    public class TwitterKey
    {
        public string access_token { get; set; }
        public string oathCode { get { return "b3dNd1FvWEk1ZXpKZEVmNndyQVJiMzhxQzpZUmc0S3dBTHZtSXB2UzdvWE02b05YeGpsQnozZ3puRWlaMUJCSjZscnZPY2pFb1lpMw=="; } }

        public string getKey()
        {
            RestClient authClient = new RestClient("https://api.twitter.com/oauth2/token");
            RestRequest postRequest = new RestRequest(Method.POST);           

            postRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            postRequest.AddHeader("Authorization", "Basic " + oathCode);
            postRequest.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials", ParameterType.RequestBody);
            IRestResponse response = authClient.Execute(postRequest);

            return JsonConvert.DeserializeObject<TwitterKey>(response.Content).access_token;
        }
    }
}