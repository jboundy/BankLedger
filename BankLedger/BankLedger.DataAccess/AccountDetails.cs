using System.Collections.Generic;
using BankLedger.DataAccess.Interfaces;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess
{
    public class AccountDetails : IAccountDetails
    {
        public AccountDetails()
        {
        }
        public void ModifyBalance(TransactionType type, decimal amount, IAccount account)
        {
            switch (type)
            {
              case TransactionType.Deposit:
                  account.Balance += amount;
                  break;

              case TransactionType.Withdraw:
                  if (account.Balance >= amount)
                  {
                      account.Balance -= amount;
                  }
                  break;
            }

            LogTransaction(type, amount, account);
        }

        public decimal BalanceInquiry(IAccount account)
        {
            return account.Balance;
        }

        public List<TransactionHistory> AllTransactions(IAccount account)
        {
            return account.TransactionHistory;
        }

        private void LogTransaction(TransactionType type, decimal amountChanged, IAccount account)
        {
            account.TransactionHistory.Add(new TransactionHistory(type, amountChanged));
        }
    }
}
