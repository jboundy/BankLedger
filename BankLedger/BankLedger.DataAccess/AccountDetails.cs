﻿using System.Collections.Generic;
using BankLedger.DataAccess.Interfaces;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess
{
    public class AccountDetails : IAccountDetails
    {
        private Account _account;
        public AccountDetails(string username)
        {
            _account = GetAccount(username);
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
