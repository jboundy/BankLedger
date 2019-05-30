using System;
using System.Collections.Generic;
using System.Text;
using BankLedger.DataAccess.Models;
using NUnit.Framework;

namespace BankLedger.Tests
{
    public class AccountDetailsTests
    {
        private Account _account;
        public AccountDetailsTests()
        {
            _account = new Account
            {
                Username = "justin",
                Password = "password"
            };
        }

        [Test]
        public void Can_Change_AccountBalance_Deposit()
        {
            _account.Balance += 50;
            Assert.IsTrue(_account.Balance > 0);
        }
    }
}
