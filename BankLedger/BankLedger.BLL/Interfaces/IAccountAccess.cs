using System.Collections.Generic;
using BankLedger.BLL.Models;
using BankLedger.DataAccess.Models;

namespace BankLedger.BLL.Interfaces
{
    public interface IAccountAccess
    {
        bool AccountCreate(string username, string password);
        ActiveAccount Login(string username, string password);
        List<Account> GetAccounts();
    }
}
