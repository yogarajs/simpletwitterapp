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
    }
}