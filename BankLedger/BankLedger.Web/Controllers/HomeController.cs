using System.Diagnostics;
using BankLedger.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BankLedger.Web.Models;

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
            return new JsonResult(account);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
