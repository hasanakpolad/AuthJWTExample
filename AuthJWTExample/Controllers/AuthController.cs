using AuthJWTExample.Auth;
using AuthJWTExample.DTOes;
using Microsoft.AspNetCore.Mvc;

namespace AuthJWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private TokenProvider _token;
        public AuthController(TokenProvider token)
        {
            _token = token;
        }
        [HttpPost(nameof(Login))]
        public IActionResult Login(LoginDto model)
        {
            var tokens = _token.CreateToken(model);
            return Ok(tokens);
        }

        [HttpPost(nameof(LogOut))]
        public IActionResult LogOut()
        {
            return Ok();
        }

        [HttpPost(nameof(Register))]
        public IActionResult Register(RegisterDto model)
        {
            return StatusCode(201);
        }
    }
}
