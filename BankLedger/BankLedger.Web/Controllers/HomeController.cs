using BankLedger.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankLedger.Web.Controllers
{
    public class HomeController : Controller
    {
        private IAccountAccess _accountAccess;
        public HomeController(IAccountAccess accountAccess)
        {
            _accountAccess = accountAccess;
        }
        public IActionResult Index()
        {
            return View();
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
            if (account?.Username != null)
            {
                return Content(Url.Action("BalanceHome", "Balance", account));
            }

            return BadRequest();
        }
    }
}
