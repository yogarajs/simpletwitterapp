using SimpleTwitterApp.API.Models;
using System.Collections.Generic;
using System;

namespace SimpleTwitterApp.API.Repositories
{
    public interface ITweetRepository
    {
        List<TweetModel> GetAll();

        List<TweetModel> GetAllByUser(int userId);

        void Save(TweetModel tweetModel);
    }

    public class TweetRepository : ITweetRepository
    {
        public List<TweetModel> GetAll()
        {
            return new List<TweetModel>()
            {
                new TweetModel()
                {
                    TweetId = 1
                },
                new TweetModel()
                {
                    TweetId = 2
                }
            };
        }

        public List<TweetModel> GetAllByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void Save(TweetModel tweetModel)
        {
            throw new NotImplementedException();
        }
    }
}