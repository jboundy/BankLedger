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
            Accounts = new List<Account>();
        }
        public List<Account> Accounts { get; set; }
        public bool AccountCreate(string username, string password)
        {
            var accounts = GetAccounts();
            if (accounts.All(x => x.Username != username))
            {
                Accounts.Add(new Account
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
            var account = Accounts.Find(x => x.Username == username && x.Password == password);
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
        
        public List<Account> GetAccounts()
        {
            if (Accounts != null)
            {
                return Accounts;
            }

            return new List<Account>();
        }
    }
}
