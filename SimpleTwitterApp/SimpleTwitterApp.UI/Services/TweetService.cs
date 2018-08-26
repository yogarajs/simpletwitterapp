using SimpleTwitterApp.UI.Models;
using System.Collections.Generic;

namespace SimpleTwitterApp.UI.Services
{
    public interface ITweetService
    {
        List<TweetModel> GetAll();

        List<TweetModel> GetAllByUserName(string username);

        void Save(TweetModel tweetModel);
    }

    public class TweetService : ITweetService
    {
        ITwitterApiRestClient _twitterApiRestClient;
        IApiConfigService _apiConfigService;

        public TweetService()
        {
            _twitterApiRestClient = new TwitterApiRestClient();
            _apiConfigService = new ApiConfigService();
        }

        public List<TweetModel> GetAll()
        {
            var tweetModel = _twitterApiRestClient.GetAll<List<TweetModel>>(_apiConfigService.TweetsEndPoint);
            return tweetModel;
        }

        public List<TweetModel> GetAllByUserName(string username)
        {
            var endpoint = $"{ _apiConfigService.TweetsGetAllByUsernameEndPoint}{username}";
            var tweetModel = _twitterApiRestClient.GetAll<List<TweetModel>>(endpoint);
            return tweetModel;
        }

        public void Save(TweetModel tweetModel)
        {
            _twitterApiRestClient.Save(tweetModel, _apiConfigService.TweetsEndPoint);
        }
    }
}