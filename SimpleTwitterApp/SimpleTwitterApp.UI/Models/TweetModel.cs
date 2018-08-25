using SimpleTwitterApp.UI.Enums;
using System;

namespace SimpleTwitterApp.UI.Models
{
    public class TweetModel
    {
        public TweetModel()
        {
            UserDeviceTypeId = UserDeviceType.Desktop;
        }

        public int TweetId { get; set; }

        public string TweetContent { get; set; }

        public int UserId { get; set; }

        public UserDeviceType UserDeviceTypeId { get; set; }

        public int TwittedBy { get; set; }

        public DateTime TweetTime { get; set; }
    }
}