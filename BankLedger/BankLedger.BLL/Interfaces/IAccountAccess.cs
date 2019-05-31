using BankLedger.BLL.Models;

namespace BankLedger.BLL.Interfaces
{
    public interface IAccountAccess
    {
        bool AccountCreate(string username, string password);
        ActiveAccount Login(string username, string password);
        void UpdateAccountDatabase(ActiveAccount account);
    }
}
