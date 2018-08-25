using SimpleTwitterApp.API.Models;
using SimpleTwitterApp.API.Repositories;
using System.Net;
using System.Web.Http;

namespace SimpleTwitterApp.API.Controllers
{
    public class TweetController : ApiController
    {
        ITweetRepository _tweetRepository;

        public TweetController()
        {
            _tweetRepository = new TweetRepository();
        }

        public IHttpActionResult GetAll()
        {
            var tweets = _tweetRepository.GetAll();
            return Ok(tweets);
        }

        public IHttpActionResult GetAllByUser(int userId)
        {
            var tweets = _tweetRepository.GetAllByUser(userId);
            return Ok(tweets);
        }

        public IHttpActionResult Post(TweetModel tweetModel)
        {
            _tweetRepository.Save(tweetModel);
            return StatusCode(HttpStatusCode.Created);
        }
    }
}
