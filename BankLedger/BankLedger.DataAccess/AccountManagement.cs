using System.Collections.Generic;
using BankLedger.DataAccess.Interfaces;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess
{
    public class AccountManagement : IAccountManagement
    {
        public AccountManagement()
        {
        }
        public List<Account> Accounts { get; set; }

        public void CreateAccount(string userName, string password)
        {
            var accounts = GetAccounts();
            accounts.Add(new Account
            {
                Username = userName,
                Password = password
            });
        }

        public Account Login(string username, string password)
        {
            return Accounts.Find(x => x.Username == username && x.Password == password);
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
