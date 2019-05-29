using System;
using System.Collections.Generic;
using System.Text;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess.Interfaces
{
    public interface IAccount
    {
        void CreateAccount(string userName, string password);
        Account Login(string username, string password);
        void Logout(string username);
    }
}
