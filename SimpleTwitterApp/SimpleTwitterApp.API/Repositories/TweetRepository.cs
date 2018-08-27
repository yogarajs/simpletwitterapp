using SimpleTwitterApp.API.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using SimpleTwitterApp.API.Contexts;
using SimpleTwitterApp.API.Enums;
using SimpleTwitterApp.API.Entities;

namespace SimpleTwitterApp.API.Repositories
{
    public interface ITweetRepository
    {
        List<TweetModel> GetAll();

        List<TweetModel> GetAllByUsername(string username);

        void Save(TweetModel tweetModel);
    }

    public class TweetRepository : ITweetRepository
    {
        static readonly List<TweetModel> tweets = new List<TweetModel>()
        {
            new TweetModel()
                {
                    TweetId = 1,
                    TweetContent = "Sample tweet",
                    Username = "rajans",
                    TwittedBy = "yogarajs",
                    TweetTime = DateTime.Now
                },
                new TweetModel()
                {
                    TweetId = 2,
                    TweetContent = "Sample tweet",
                    Username = "rajans",
                    TwittedBy = "yogarajs",
                    TweetTime = DateTime.Now
                }
        };

        readonly ITweetContext _tweetContext;

        public TweetRepository()
        {
            _tweetContext = new TweetContext();
        }

        public List<TweetModel> GetAll()
        {
            var tweets = from tweet in _tweetContext.Tweets
                         join user in _tweetContext.Users on tweet.UserId equals user.UserId
                         join twittedBy in _tweetContext.Users on tweet.TwittedBy equals twittedBy.UserId
                         join userDevice in _tweetContext.UserDevices on tweet.UserDeviceId equals userDevice.UserDeviceId
                         select new TweetModel()
                         {
                             TweetId = tweet.TweetId,
                             TweetContent = tweet.TweetContent,
                             TweetTime = tweet.TweetTime,
                             Username = user.Username,
                             TwittedBy = twittedBy.Username,
                             UserDeviceTypeId = (UserDeviceType)userDevice.DeviceTypeId
                         };

            return tweets.ToList();
        }

        public List<TweetModel> GetAllByUsername(string username)
        {
            var userTweets = from user in _tweetContext.Users
                             join tweet in _tweetContext.Tweets on user.UserId equals tweet.UserId
                             join twittedBy in _tweetContext.Users on tweet.TwittedBy equals twittedBy.UserId
                             join userDevice in _tweetContext.UserDevices on tweet.UserDeviceId equals userDevice.UserDeviceId
                             where user.Username == username
                             select new TweetModel()
                             {
                                 TweetId = tweet.TweetId,
                                 TweetContent = tweet.TweetContent,
                                 TweetTime = tweet.TweetTime,
                                 Username = user.Username,
                                 TwittedBy = twittedBy.Username,
                                 UserDeviceTypeId = (UserDeviceType)userDevice.DeviceTypeId
                             };

            return userTweets.ToList();
        }

        public void Save(TweetModel tweetModel)
        {
            var userId = _tweetContext.Users.Where(x => x.Username == tweetModel.Username).Select(x => x.UserId).FirstOrDefault();
            var twittedBy = _tweetContext.Users.Where(x => x.Username == tweetModel.TwittedBy).Select(x => x.UserId).FirstOrDefault();

            // TODO: User device should come from UI/Client once user logs in to the APP.
            var userDeviceId = _tweetContext.UserDevices.Where(x => x.UserId == twittedBy).Select(x => x.UserDeviceId).FirstOrDefault();
            
            // user tweets from new device
            if (userDeviceId == 0)
            {
                UserDeviceEntity userDeviceEntity = new UserDeviceEntity()
                {
                    UserId = userId,
                    DeviceName = "Test device", // TODO: Pass device name from UI/Client
                    DeviceTypeId = (int)UserDeviceType.Desktop, // TODO: Pass device type from UI/Client
                };
                _tweetContext.UserDevices.Add(userDeviceEntity);
                _tweetContext.SaveChanges();
            }

            var tweetEntity = new TweetEntity()
            {
                TweetContent = tweetModel.TweetContent,
                TwittedBy = twittedBy,
                UserId = userId,
                UserDeviceId = userDeviceId,
                TweetTime = DateTime.Now
            };

            _tweetContext.Tweets.Add(tweetEntity);
            _tweetContext.SaveChanges();
        }
    }
}