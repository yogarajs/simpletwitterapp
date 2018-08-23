using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleTwitterApp.API.Entities
{
    public class TweetEntity
    {
        public int TweetId { get; set; }

        public string TweetContent { get; set; }

        public int UserId { get; set; }

        public int UserDeviceId { get; set; }

        public int TwittedBy { get; set; }

        public DateTime TweetTime { get; set; }
    }
}