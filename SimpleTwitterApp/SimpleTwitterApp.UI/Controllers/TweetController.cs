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
            return View(tweets);
        }
    }
}