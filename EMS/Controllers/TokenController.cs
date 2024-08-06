using EMS.DTOs;
using EMS.Helper;
using EMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ILoginService _loginService;
        private readonly string Key = "ThisIsA16ByteKey";

        public TokenController(ITokenService tokenService, ILoginService loginService)
        {
            _tokenService = tokenService;
            _loginService = loginService;
        }

        [HttpPost("GenerateToken")]
        public async Task<ActionResult<string>> GenerateToken([FromBody]LoginUserDTO login)
        {
            var user = await _loginService.GetByUserName(login.UserId);
            if (user != null && user.Password == PasswordHasher.EncryptString(login.Password, Key))
            {
                var token = _tokenService.GenerateToken(user.Username);
                return Ok(token);
            }
            return NotFound();
        }
    }
}
