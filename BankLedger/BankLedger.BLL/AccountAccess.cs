using System.Collections.Generic;
using System.Linq;
using BankLedger.BLL.Interfaces;
using BankLedger.BLL.Models;
using BankLedger.DataAccess.Models;

namespace BankLedger.BLL
{
    public class AccountAccess : IAccountAccess
    {
        public AccountAccess()
        {
        }
        
        public bool AccountCreate(string username, string password)
        {
            var accounts = GetAccounts();
            if (accounts.All(x => x.Username != username))
            {
                FakeDbAccounts.DbAccounts.Add(new ActiveAccount
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
            return (ActiveAccount) FindAccount(username, password);
        }

        private List<Account> GetAccounts()
        {
            if (FakeDbAccounts.DbAccounts != null)
            {
                return FakeDbAccounts.DbAccounts;
            }

            FakeDbAccounts.DbAccounts = new List<Account>();
            return FakeDbAccounts.DbAccounts;
        }

        private Account FindAccount(string username, string password)
        {
            return GetAccounts().Find(x => x.Username == username && x.Password == password);
        }
    }
}
