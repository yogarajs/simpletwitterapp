using System.Collections.Generic;

namespace SimpleTwitterApp.UI.Models
{
    public class AddTweetCompositeViewModel
    {
        public TweetModel TweetModel { get; set; }

        public List<TweetModel> MyTweets { get; set; }
    }
}