using System.Collections.Generic;
using System.Linq;
using BankLedger.BLL.Interfaces;
using BankLedger.BLL.Models;

namespace BankLedger.BLL
{
    public class AccountAccess : IAccountAccess
    {
        public AccountAccess()
        {
        }

        public List<ActiveAccount> Accounts { get; set; }

        public bool AccountCreate(string username, string password)
        {
            var accounts = GetAccounts();
            if (accounts.All(x => x.Username != username))
            {
                Accounts.Add(new ActiveAccount
                {
                    Username = username,
                    Password = password
                });
                return true;
            }

            return false;
        }

        public ActiveAccount Login(string username, string password)
        {
            var account = FindAccount(username, password);
            if (account != null)
            {
                return new ActiveAccount
                {
                    Balance = account.Balance,
                    Password = account.Password,
                    TransactionHistory = account.TransactionHistory,
                    Username = account.Username
                };
            }

            return new ActiveAccount();
        }

        public void UpdateAccountDatabase(ActiveAccount account)
        {
            var accountFound = FindAccount(account.Username, account.Password);
            Accounts.Remove(accountFound);
            Accounts.Add(account);
        }

        public List<ActiveAccount> GetAccounts()
        {
            if (Accounts != null)
            {
                return Accounts;
            }

            Accounts = new List<ActiveAccount>();
            return Accounts;
        }

        private ActiveAccount FindAccount(string username, string password)
        {
            return GetAccounts().Find(x => x.Username == username && x.Password == password);
        }
    }
}
