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
        public decimal BalanceInquiry(IAccount account)
        {
            return FindAccount(account).Balance;
        }

        public List<TransactionHistory> AllTransactions(IAccount account)
        {
            return FindAccount(account).TransactionHistory;
        }
        
        public void UpdateDatabaseAccount(TransactionType type, decimal amountChanged, IAccount account)
        {
            var accountToRemove = FindAccount(account);
            account.TransactionHistory = account.TransactionHistory == null ? new List<TransactionHistory>() : accountToRemove.TransactionHistory;
            account.TransactionHistory.Add(new TransactionHistory(type, amountChanged));
            UpdateDb(accountToRemove, account);
        }

        private Account FindAccount(IAccount account)
        {
            return FakeDbAccounts.DbAccounts.Find(acc => acc.Username == account.Username && acc.Password == account.Password);
        }

        private void UpdateDb(IAccount accountToRemove, IAccount accountToAdd)
        {
            FakeDbAccounts.DbAccounts.Remove((Account)accountToRemove);
            FakeDbAccounts.DbAccounts.Add((Account)accountToAdd);
        }
    }
}
