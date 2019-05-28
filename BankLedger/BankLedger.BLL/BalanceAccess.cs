using System;
using System.Collections.Generic;
using System.Text;
using BankLedger.DataAccess;

namespace BankLedger.BLL
{
    public class BalanceAccess
    {
        private AccountDetails _accountDetails;
        public BalanceAccess(string username)
        {
            _accountDetails = new AccountDetails(username);
        }
        public void DepositFunds(string username, decimal amount)
        {
            _accountDetails.Deposit(amount);
        }

        public void WithdrawFunds(string userName, decimal amount)
        {
            var balance = _accountDetails.BalanceInquiry();
            if (balance >= amount)
            {
                _accountDetails.Withdraw(amount);
            }
        }

        public decimal CurrentBalance(string username)
        {
           return _accountDetails.BalanceInquiry();
        }
    }
}
