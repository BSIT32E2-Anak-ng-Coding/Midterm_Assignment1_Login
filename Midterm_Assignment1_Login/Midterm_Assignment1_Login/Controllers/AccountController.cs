using Microsoft.AspNetCore.Mvc;
using Midterm_Assignment1_Login.Services;

namespace Midterm_Assignment1_Login.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool success = _authService.RegisterUser(model.Username, model.Password, model.Email);
            if (success)
            {
                // Redirect to login page or show confirmation message
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Username already exists.");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool success = _authService.Login(model.Username, model.Password, out Domain.User user);
            if (success)
            {
                // Redirect to dashboard or home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(model);
            }
        }
    }
}
