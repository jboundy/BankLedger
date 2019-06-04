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
        public BalanceAccess()
        {
            _accountDetails = new AccountDetails();
        }
        public decimal DepositFunds(ActiveAccount account, decimal amount)
        {
            var balance = _accountDetails.BalanceInquiry(account);
            ModifyBalance(TransactionType.Deposit, balance, amount, account);
            return _accountDetails.BalanceInquiry(account);
        }

        public decimal WithdrawFunds(ActiveAccount account, decimal amount)
        {
            var balance = _accountDetails.BalanceInquiry(account);
            if (balance >= amount)
            {
                ModifyBalance(TransactionType.Withdraw, balance, amount, account);
            }

            return _accountDetails.BalanceInquiry(account);
        }

        public decimal CurrentBalance(ActiveAccount account)
        {
            return _accountDetails.BalanceInquiry(account);
        }

        public List<TransactionHistory> RetrieveTransactions(ActiveAccount account)
        {
            return _accountDetails.AllTransactions(account);
        }

        private void ModifyBalance(TransactionType type, decimal currentBalance, decimal amount, IAccount account)
        {
            switch (type)
            {
                case TransactionType.Deposit:
                    currentBalance += amount;
                    break;

                case TransactionType.Withdraw:
                    if (currentBalance >= amount)
                    {
                        currentBalance -= amount;
                    }
                    break;
            }

            account.Balance = currentBalance;
            _accountDetails.UpdateDatabaseAccount(type, amount, account);
        }
    }
}
