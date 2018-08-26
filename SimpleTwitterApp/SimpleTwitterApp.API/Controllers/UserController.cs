using SimpleTwitterApp.API.Repositories;
using System.Web.Http;

namespace SimpleTwitterApp.API.Controllers
{
    public class UserController : ApiController
    {
        IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [Route("api/users")]
        public IHttpActionResult GetAll()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [Route("api/users/{userName}")]
        public IHttpActionResult Get(string userName)
        {
            var user = _userRepository.GetByUserName(userName);
            return Ok(user);
        }
    }
}
