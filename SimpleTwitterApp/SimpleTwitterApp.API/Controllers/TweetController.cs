using SimpleTwitterApp.API.Repositories;
using System.Web.Http;

namespace SimpleTwitterApp.API.Controllers
{
    public class TweetController : ApiController
    {
        public IHttpActionResult Get()
        {
            ITweetRepository tweetRepository = new TweetRepository();
            var tweets = tweetRepository.GetAll();
            return Ok(tweets);
        }
    }
}
