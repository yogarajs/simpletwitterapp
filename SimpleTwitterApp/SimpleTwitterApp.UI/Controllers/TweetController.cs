using SimpleTwitterApp.UI.Models;
using SimpleTwitterApp.UI.Services;
using System.Web.Mvc;

namespace SimpleTwitterApp.UI.Controllers
{
    public class TweetController : Controller
    {
        public ActionResult Index()
        {
            ITweetService tweetService = new TweetService();
            var tweets = tweetService.GetAll();

            IUserService userService = new UserService();
            var users = userService.GetAll();

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
            ITweetService tweetService = new TweetService();
            tweetService.Save(tweetModel);
            return RedirectToAction("Index", "Tweet");
        }
    }
}