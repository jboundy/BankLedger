using BankLedger.DataAccess.Models;

namespace BankLedger.BLL.Interfaces
{
    public interface IAccountAccess
    {
        bool AccountCreate(string username, string password);
        Account Login(string username, string password);
    }
}
