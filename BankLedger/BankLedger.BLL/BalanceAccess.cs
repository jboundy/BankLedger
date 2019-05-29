using System;
using System.Collections.Generic;
using System.Text;
using BankLedger.DataAccess;
using BankLedger.DataAccess.Interfaces;
using BankLedger.DataAccess.Models;

namespace BankLedger.BLL
{
    public class BalanceAccess
    {
        private IAccountDetails _accountDetails;
        public BalanceAccess(string username)
        {
            _accountDetails = n
        }
        public void DepositFunds(decimal amount)
        {
            _accountDetails.ModifyBalance(TransactionType.Deposit, amount);
        }

        public void WithdrawFunds(string userName, decimal amount)
        {
            var balance = _accountDetails.BalanceInquiry();
            if (balance >= amount)
            {
                _accountDetails.ModifyBalance(TransactionType.Withdraw, amount);
            }
        }

        public decimal CurrentBalance(string username)
        {
           return _accountDetails.BalanceInquiry();
        }
    }
}
