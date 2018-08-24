using SimpleTwitterApp.API.Models;
using SimpleTwitterApp.API.Repositories;
using System.Net;
using System.Web.Http;

namespace SimpleTwitterApp.API.Controllers
{
    public class TweetController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ITweetRepository tweetRepository = new TweetRepository();
            var tweets = tweetRepository.GetAll();
            return Ok(tweets);
        }

        public IHttpActionResult GetAllByUser(int userId)
        {
            ITweetRepository tweetRepository = new TweetRepository();
            var tweets = tweetRepository.GetAllByUser(userId);
            return Ok(tweets);
        }

        public IHttpActionResult Post(TweetModel tweetModel)
        {
            ITweetRepository tweetRepository = new TweetRepository();
            tweetRepository.Save(tweetModel);
            return StatusCode(HttpStatusCode.Created);
        }
    }
}
