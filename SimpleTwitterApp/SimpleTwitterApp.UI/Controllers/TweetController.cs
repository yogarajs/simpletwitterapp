using SimpleTwitterApp.UI.Constants;
using SimpleTwitterApp.UI.Filters;
using SimpleTwitterApp.UI.Models;
using SimpleTwitterApp.UI.Services;
using System.Linq;
using System.Web.Mvc;

namespace SimpleTwitterApp.UI.Controllers
{
    [AppAuthorizationFilter]
    public class TweetController : Controller
    {
        ITweetService _tweetService;
        IUserService _userService;

        public TweetController()
        {
            _tweetService = new TweetService();
            _userService = new UserService();
        }

        public ActionResult Index()
        {
            var tweets = _tweetService.GetAll();
            var users = _userService.GetAll();
            var tweetCompositeViewModel = new TweetCompositeViewModel()
            {
                Tweets = tweets,
                MyTweets = tweets.Where(x => x.TwittedBy == Session[AppConstants.USER_SESSION] as string).ToList(),
                Users = users
            };

            return View(tweetCompositeViewModel);
        }

        public ActionResult AddTweet(string username)
        {
            var tweets = _tweetService.GetAllByUserName(username);
            var addTweetCompositeViewModel = new AddTweetCompositeViewModel()
            {
                MyTweets = tweets,
                TweetModel = new TweetModel()
                {
                    Username = username,
                    TwittedBy = Session[AppConstants.USER_SESSION] as string
                }
            };

            return View(addTweetCompositeViewModel);
        }

        public ActionResult Post(TweetModel tweetModel)
        {
            _tweetService.Save(tweetModel);
            return RedirectToAction("Index", "Tweet");
        }
    }
}