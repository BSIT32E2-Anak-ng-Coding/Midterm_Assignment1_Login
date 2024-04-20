using Login.Application;
using Microsoft.AspNetCore.Mvc;
using Midterm_Assignment1_Login.Services;

namespace Midterm_Assignment1_Login.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _userService.Login(username, password);
            if (user != null)
            {
                // Redirect to dashboard or home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }
    }
}
