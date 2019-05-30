using System.Diagnostics;
using System.Threading.Tasks;
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
        public async Task<IActionResult> AccountCreate([FromQuery] string username, string password)
        {
            if (!ModelState.IsValid) return BadRequest();
            await Task.Run(() => _accountAccess.AccountCreate(username,password));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> AccountLogin(string username, string password)
        {
            var account = await Task.Run(() => _accountAccess.Login(username, password));
            return ViewComponent("BalanceComponent", account);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
