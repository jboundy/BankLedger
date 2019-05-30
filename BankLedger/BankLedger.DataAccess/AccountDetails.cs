using System.Collections.Generic;
using BankLedger.DataAccess.Interfaces;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess
{
    public class AccountDetails : IAccountDetails
    {
        private IAccount _account;
        public AccountDetails(IAccount account)
        {
            _account = account;
        }
        public void ModifyBalance(TransactionType type, decimal amount)
        {
            switch (type)
            {
              case TransactionType.Deposit:
                  _account.Balance += amount;
                  break;

              case TransactionType.Withdraw:
                  if (_account.Balance >= amount)
                  {
                      _account.Balance -= amount;
                  }
                  break;
            }

            LogTransaction(type, amount);
        }

        public decimal BalanceInquiry()
        {
            return _account.Balance;
        }

        public List<TransactionHistory> AllTransactions()
        {
            return _account.TransactionHistory;
        }

        private void LogTransaction(TransactionType type, decimal amountChanged)
        {
            _account.TransactionHistory.Add(new TransactionHistory(type, amountChanged));
        }
    }
}
