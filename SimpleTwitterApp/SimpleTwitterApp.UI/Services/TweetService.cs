using SimpleTwitterApp.UI.Models;
using System.Collections.Generic;

namespace SimpleTwitterApp.UI.Services
{
    public interface ITweetService
    {
        List<TweetModel> GetAll();
    }

    public class TweetService : ITweetService
    {
        public List<TweetModel> GetAll()
        {
            ITwitterApiRestClient twitterApiRestClient = new TwitterApiRestClient();
            var tweetModel = twitterApiRestClient.GetAll<List<TweetModel>>();
            return tweetModel;
        }
    }
}