
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StopajHesapAPI.Models;
using StopajHesapAPI.Services.Abstraction;

namespace NetCoreAPIBasicAuthenticationSample.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserModel model)
        {
            var user = _userService.Login(model.userName, model.password);

            if (user == null)
            {
                return NotFound("Kullanıcı adı veya şifre yanlış!");
            }

            user.password = "";

            return Ok(user);
        }
    }
}