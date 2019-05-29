using System.Collections.Generic;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess.Interfaces
{
    public interface IAccountManagement
    {
        void CreateAccount(string userName, string password);
        Account Login(string username, string password);
        List<Account> GetAccounts();
    }
}
