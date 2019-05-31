using BankLedger.BLL.Interfaces;
using BankLedger.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankLedger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private IBalanceAccess _balanceAccess;

        public BalanceController(IBalanceAccess balanceAccess)
        {
            _balanceAccess = balanceAccess;
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