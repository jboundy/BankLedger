using System.Collections.Generic;
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
        public BalanceAccess(ActiveAccount activeAccount)
        {
            _accountDetails = new AccountDetails(activeAccount);
            
        }
        public decimal DepositFunds(decimal amount)
        {
            _accountDetails.ModifyBalance(TransactionType.Deposit, amount);
            return _accountDetails.BalanceInquiry();
        }

        public decimal WithdrawFunds(decimal amount)
        {
            var balance = _accountDetails.BalanceInquiry();
            if (balance >= amount)
            {
                _accountDetails.ModifyBalance(TransactionType.Withdraw, amount);
            }

            return _accountDetails.BalanceInquiry();
        }

        public decimal CurrentBalance(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {

                return _accountDetails.BalanceInquiry();

            }

            return 0;
        }

        public List<TransactionHistory> RetrieveTransactions()
        {
            return _accountDetails.AllTransactions();
        }
    }
}
