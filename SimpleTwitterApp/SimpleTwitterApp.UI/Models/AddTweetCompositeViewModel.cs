using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleTwitterApp.UI.Models
{
    public class AddTweetCompositeViewModel
    {
        public TweetModel TweetModel { get; set; }

        public List<TweetModel> MyTweets { get; set; }
    }
}