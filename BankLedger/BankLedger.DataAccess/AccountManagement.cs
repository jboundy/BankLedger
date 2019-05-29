﻿using System;
using System.Collections.Generic;
using System.Text;
using BankLedger.DataAccess.Interfaces;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess
{
    public class AccountManagement : IAccount
    {
        public AccountManagement()
        {
            Accounts = new List<Account>();
        }
        public List<Account> Accounts { get; set; }

        public void CreateAccount(string userName, string password)
        {
            Accounts.Add(new Account
            {
                Username = userName,
                Password = password
            });
        }

        public Account Login(string username, string password)
        {
            return Accounts.Find(x => x.Username == username && x.Password == password);
        }

        public void Logout(string username)
        {

        }
    }
}
