using System.Collections.Generic;

namespace SimpleTwitterApp.UI.Models
{
    public class TweetCompositeViewModel
    {
        public List<TweetModel> Tweets { get; set; }

        public List<TweetModel> MyTweets { get; set; }

        public List<UserModel> Users { get; set; }
    }
}