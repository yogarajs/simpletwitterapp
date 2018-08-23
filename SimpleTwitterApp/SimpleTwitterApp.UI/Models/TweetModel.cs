using System;

namespace SimpleTwitterApp.UI.Models
{
    public class TweetModel
    {
        public int TweetId { get; set; }

        public string TweetContent { get; set; }

        public int UserId { get; set; }

        public int UserDeviceId { get; set; }

        public int TwittedBy { get; set; }

        public DateTime TweetTime { get; set; }
    }
}