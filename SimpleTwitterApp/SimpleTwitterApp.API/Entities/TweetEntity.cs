using System;

namespace SimpleTwitterApp.API.Entities
{
    public class TweetEntity
    {
        public long TweetId { get; set; }

        public string TweetContent { get; set; }

        public long UserId { get; set; }

        public long UserDeviceId { get; set; }

        public long TwittedBy { get; set; }

        public DateTime TweetTime { get; set; }
    }
}