using Login.Application;
using Microsoft.AspNetCore.Mvc;

namespace Midterm_Assignment1_Login.Controllers
{
    public class LoginController
    {
        public class LoginController : ApiController
        {
            private readonly UserService _userService;

            public LoginController(UserService userService)
            {
                _userService = userService;
            }

            [HttpPost]
            public IHttpActionResult Login(LoginViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                User user = _userService.Login(model.Username, model.Password);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
        }

        public class LoginViewModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }

  
}
