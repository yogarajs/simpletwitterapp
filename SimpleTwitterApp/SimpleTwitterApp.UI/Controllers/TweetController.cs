using SimpleTwitterApp.UI.Filters;
using SimpleTwitterApp.UI.Models;
using SimpleTwitterApp.UI.Services;
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
                Users = users
            };

            return View(tweetCompositeViewModel);
        }

        public ActionResult AddTweet(int userId)
        {
            var tweetModel = new TweetModel()
            {
                UserId = userId
            };
            return View(tweetModel);
        }

        public ActionResult Post(TweetModel tweetModel)
        {
            _tweetService.Save(tweetModel);
            return RedirectToAction("Index", "Tweet");
        }
    }
}