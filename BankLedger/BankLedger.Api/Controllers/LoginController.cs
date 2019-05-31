using BankLedger.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankLedger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IAccountAccess _accountAccess;

        public LoginController(IAccountAccess accountAccess)
        {
            _accountAccess = accountAccess;
        }
        [HttpPost]
        public IActionResult AccountCreate([FromForm] string username, string password)
        {
            if (!ModelState.IsValid) return BadRequest();
            _accountAccess.AccountCreate(username,password);
            return Ok();
        }

        [HttpGet]
        public IActionResult AccountLogin(string username, string password)
        {
            var account = _accountAccess.Login(username, password);
            return new JsonResult(account);
        }
    }
}
