using SimpleTwitterApp.UI.Models;
using SimpleTwitterApp.UI.Services;
using System.Web.Mvc;

namespace SimpleTwitterApp.UI.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;

        public AccountController()
        {
            _userService = new UserService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel loginModel)
        {
            var isValidUser = _userService.ValidateUser(loginModel.Username, loginModel.Password);
            if (isValidUser)
            {
                return RedirectToAction("Index", "Tweet");
            }
            return RedirectToAction("Index");
        }
    }
}