using System.Linq;
using BankLedger.BLL.Interfaces;
using BankLedger.BLL.Models;
using BankLedger.DataAccess;
using BankLedger.DataAccess.Interfaces;

namespace BankLedger.BLL
{
    public class AccountAccess : IAccountAccess
    {
        private IAccountManagement _accountManagement;
        public AccountAccess()
        {
            _accountManagement = new AccountManagement();
        }
        public bool AccountCreate(string username, string password)
        {
            var accounts = _accountManagement.GetAccounts();
            if (accounts.All(x => x.Username != username))
            {
                _accountManagement.CreateAccount(username, password);
                return true;
            }

            return false;
        }

        public ActiveAccount Login(string username, string password)
        {
            var account = _accountManagement.Login(username, password);
            if (account != null)
            {
                return new ActiveAccount
                {
                    Balance = account.Balance,
                    Password = account.Password,
                    TransactionHistory = account.TransactionHistory,
                    Username = account.Username
                };
            }

            return new ActiveAccount();
        }
    }
}
