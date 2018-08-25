using SimpleTwitterApp.UI.Models;
using System.Collections.Generic;

namespace SimpleTwitterApp.UI.Services
{
    public interface ITweetService
    {
        List<TweetModel> GetAll();

        void Save(TweetModel tweetModel);
    }

    public class TweetService : ITweetService
    {
        public List<TweetModel> GetAll()
        {
            ITwitterApiRestClient twitterApiRestClient = new TwitterApiRestClient();
            IApiConfigService apiConfigService = new ApiConfigService();
            var tweetModel = twitterApiRestClient.GetAll<List<TweetModel>>(apiConfigService.TweetsEndPoint);
            return tweetModel;
        }

        public void Save(TweetModel tweetModel)
        {
            ITwitterApiRestClient twitterApiRestClient = new TwitterApiRestClient();
            IApiConfigService apiConfigService = new ApiConfigService();
            twitterApiRestClient.Save(tweetModel, apiConfigService.TweetsEndPoint);
        }
    }
}