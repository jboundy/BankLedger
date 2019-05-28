using System;
using System.Collections.Generic;
using System.Text;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess
{
    public class AccountManagement
    {
        public AccountManagement()
        {
            Accounts = new List<Account>();
        }
        public List<Account> Accounts { get; set; }

        public void CreateAccount(string userName, string password)
        {
            var account = new Account
            {

            }
        }
    }
}
