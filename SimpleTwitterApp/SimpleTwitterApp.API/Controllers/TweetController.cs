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

        [Route("api/tweets")]
        public IHttpActionResult GetAll()
        {
            var tweets = _tweetRepository.GetAll();
            return Ok(tweets);
        }

        [Route("api/tweets/{userName}")]
        public IHttpActionResult GetAllByUsername(string userName)
        {
            var tweets = _tweetRepository.GetAllByUsername(userName);
            return Ok(tweets);
        }

        [HttpPost]
        [Route("api/tweets")]
        public IHttpActionResult Post([FromBody]TweetModel tweetModel)
        {
            _tweetRepository.Save(tweetModel);
            return StatusCode(HttpStatusCode.Created);
        }
    }
}
