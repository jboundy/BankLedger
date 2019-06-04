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
        public IActionResult BalanceHome(ActiveAccount account)
        {
            var transactions = _balanceAccess.RetrieveTransactions(account);
            var balance = _balanceAccess.CurrentBalance(account);
            account.TransactionHistory = transactions;
            account.Balance = balance;
            return View(account);
        }

        [HttpPut]
        public IActionResult Withdraw(ActiveAccount account, decimal amount)
        {
            if (!ModelState.IsValid) return BadRequest();
            return new JsonResult( _balanceAccess.WithdrawFunds(account, amount));
        }

        [HttpPut]
        public IActionResult Deposit(ActiveAccount account, decimal amount)
        {
            if (!ModelState.IsValid) return BadRequest();
            return new JsonResult( _balanceAccess.DepositFunds(account, amount));
        }
    }
}