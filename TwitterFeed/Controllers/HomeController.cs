using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TwitterFeed.Controllers
{
    public class HomeController : Controller
    {
        Models.TwitterKey twitterKey = new Models.TwitterKey();
        Models.Feed feed = new Models.Feed();

        public ActionResult Index()
        {
            string key = twitterKey.getKey();
            List<Models.Feed> tweets = feed.getTweets(key);
            return View(tweets);
        }






    }
}