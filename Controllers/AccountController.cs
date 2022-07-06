using BeautyBareAPI.Models;
using BeautyBareAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautyBareAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserModel dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginModel dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token); 
        }
    }
}
