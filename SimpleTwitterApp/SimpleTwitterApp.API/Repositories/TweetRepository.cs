using SimpleTwitterApp.API.Models;
using System.Collections.Generic;

namespace SimpleTwitterApp.API.Repositories
{
    public interface ITweetRepository
    {
        List<TweetModel> GetAll();
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
                    TweetId = 12
                }
            };
        }
    }
}