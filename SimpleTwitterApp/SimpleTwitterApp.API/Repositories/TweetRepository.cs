using SimpleTwitterApp.API.Models;
using System.Collections.Generic;
using System;
using System.Linq;

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

        public TweetRepository()
        {

        }

        public List<TweetModel> GetAll()
        {
            return tweets;
        }

        public List<TweetModel> GetAllByUsername(string username)
        {
            return tweets.Where(x => x.Username == username).ToList();
        }

        public void Save(TweetModel tweetModel)
        {
            tweetModel.TweetTime = DateTime.Now;
            tweets.Add(tweetModel);
        }
    }
}