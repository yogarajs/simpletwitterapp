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

        public IHttpActionResult GetAll()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }
    }
}
