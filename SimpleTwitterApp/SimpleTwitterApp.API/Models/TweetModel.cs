using SimpleTwitterApp.API.Enums;
using System;

namespace SimpleTwitterApp.API.Models
{
    public class TweetModel
    {
        public TweetModel()
        {
            UserDeviceTypeId = UserDeviceType.Desktop;
        }

        public long TweetId { get; set; }

        public string TweetContent { get; set; }

        public string Username { get; set; }

        public UserDeviceType UserDeviceTypeId { get; set; }

        public string TwittedBy { get; set; }

        public DateTime TweetTime { get; set; }
    }
}