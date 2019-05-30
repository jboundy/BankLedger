using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankLedger.BLL.Interfaces;
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

        [HttpPut]
        public async Task<IActionResult> Withdraw(decimal amount)
        {
            if (!ModelState.IsValid) return BadRequest();
            return new JsonResult(await Task.Run(() => _balanceAccess.WithdrawFunds(amount)));
        }

        [HttpPut]
        public async Task<IActionResult> Deposit(decimal amount)
        {
            if (!ModelState.IsValid) return BadRequest();
            return new JsonResult(await Task.Run(() => _balanceAccess.DepositFunds(amount)));
        }

        [HttpGet]
        public async Task<IActionResult> CurrentBalance(string username)
        {
            if (!ModelState.IsValid) return BadRequest();
            return new JsonResult(await Task.Run(() => _balanceAccess.CurrentBalance(username)));
        }

        [HttpPut]
        public async Task<IActionResult> TransactionHistory()
        {
            if (!ModelState.IsValid) return BadRequest();
            return new JsonResult(await Task.Run(() => _balanceAccess.RetrieveTransactions()));
        }
    }
}