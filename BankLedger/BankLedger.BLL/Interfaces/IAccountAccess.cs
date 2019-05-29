using BankLedger.DataAccess.Models;

namespace BankLedger.BLL.Interfaces
{
    public interface IAccountAccess
    {
        bool AccountCreate(string username, string password);
        bool Login(string username, string password);
    }
}
