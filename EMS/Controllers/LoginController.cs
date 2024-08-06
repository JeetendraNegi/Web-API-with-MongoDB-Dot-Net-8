using BL;
using EMS.Helper;
using EMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly string Key = "ThisIsA16ByteKey";

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Login>>> GetAll()
        {
            var data = await _loginService.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> Get(Guid id)
        {
            return Ok(await _loginService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Login login)
        {
            login.Password = PasswordHasher.EncryptString(login.Password, Key);
            await _loginService.Create(login);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Login login)
        {
            login.Password = PasswordHasher.EncryptString(login.Password, Key);
            await _loginService.Update(id, login);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _loginService.Delete(id);
            return Ok();
        }
    }
}
