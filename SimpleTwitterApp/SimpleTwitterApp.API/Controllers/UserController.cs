using SimpleTwitterApp.API.Repositories;
using System.Web.Http;

namespace SimpleTwitterApp.API.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            IUserRepository userRepository = new UserRepository();
            var users = userRepository.GetAll();
            return Ok(users);
        }
    }
}
