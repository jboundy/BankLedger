using BankLedger.BLL.Interfaces;
using BankLedger.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankLedger.Web.Controllers
{
    public class BalanceController : Controller
    {
        private IBalanceAccess _balanceAccess;

        public BalanceController(IBalanceAccess balanceAccess)
        {
            _balanceAccess = balanceAccess;
        }

        [HttpGet]
        public IActionResult Index(ActiveAccount account)
        {
            return View("Index", account);
        }

        [HttpPut]
        public IActionResult Withdraw(decimal amount)
        {
            if (!ModelState.IsValid) return BadRequest();
            return new JsonResult( _balanceAccess.WithdrawFunds(amount));
        }

        [HttpPut]
        public IActionResult Deposit(decimal amount)
        {
            if (!ModelState.IsValid) return BadRequest();
            return new JsonResult( _balanceAccess.DepositFunds(amount));
        }

        [HttpGet]
        public IActionResult CurrentBalance()
        {
            if (!ModelState.IsValid) return BadRequest();
            return new JsonResult( _balanceAccess.CurrentBalance());
        }

        [HttpGet]
        public IActionResult TransactionHistory()
        {
            if (!ModelState.IsValid) return BadRequest();
            return new JsonResult( _balanceAccess.RetrieveTransactions());
        }
    }
}