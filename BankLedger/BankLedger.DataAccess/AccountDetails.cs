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

        public void ModifyBalance(TransactionType type, decimal amount)
        {
            switch (type)
            {
              case TransactionType.Deposit:
                  _account.Balance += amount;
                  break;

              case TransactionType.Withdraw:
                  _account.Balance -= amount;
                  break;
            }

            LogTransaction(type, amount);
        }

        public decimal BalanceInquiry()
        {
            return _account.Balance;
        }

        public void LogTransaction(TransactionType type, decimal amountChanged)
        {
            _account.TransactionHistory.Add(new TransactionHistory
            {
                ChangedDate = DateTime.Now,
                Type = type,
                AmountChanged = amountChanged
            });
        }
    }
}
