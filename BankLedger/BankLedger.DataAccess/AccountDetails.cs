using System;
using BankLedger.DataAccess.Interfaces;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess
{
    public class AccountDetails : IAccountDetails
    {
        private Account _account;
        public AccountDetails(string userName)
        {
            _account = FindAccount(userName);
        }
        public void Deposit(decimal amountToDeposit)
        {
            _account.Balance += amountToDeposit;
            LogTransaction(TransactionType.Deposit);
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw <= _account.Balance)
            {
                _account.Balance -= amountToWithdraw;
            }
            LogTransaction(TransactionType.Withdraw);
        }

        public decimal BalanceInquiry()
        {
            return _account.Balance;
        }

        public void LogTransaction(TransactionType type)
        {
            _account.TransactionHistory.Add(new TransactionHistory
            {
                ChangedDate = DateTime.Now,
                Type = type
            });
        }
    }
}
