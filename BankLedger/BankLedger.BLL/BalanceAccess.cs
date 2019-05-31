using System.Collections.ObjectModel;
using BankLedger.BLL.Interfaces;
using BankLedger.BLL.Models;
using BankLedger.DataAccess;
using BankLedger.DataAccess.Interfaces;
using BankLedger.DataAccess.Models;

namespace BankLedger.BLL
{
    public class BalanceAccess : IBalanceAccess
    {
        protected IAccountDetails _accountDetails;
        public BalanceAccess()
        {
            _accountDetails = new AccountDetails();
        }
        public decimal DepositFunds(ActiveAccount account, decimal amount)
        {
            _accountDetails.ModifyBalance(TransactionType.Deposit, amount, account);
            return _accountDetails.BalanceInquiry(account);
        }

        public decimal WithdrawFunds(ActiveAccount account, decimal amount)
        {
            var balance = _accountDetails.BalanceInquiry(account);
            if (balance >= amount)
            {
                _accountDetails.ModifyBalance(TransactionType.Withdraw, amount, account);
            }

            return _accountDetails.BalanceInquiry(account);
        }

        public decimal CurrentBalance(ActiveAccount account)
        {
            return _accountDetails.BalanceInquiry(account);
        }

        public ReadOnlyCollection<TransactionHistory> RetrieveTransactions(ActiveAccount account)
        {
            return _accountDetails.AllTransactions(account).AsReadOnly();
        }
    }
}
