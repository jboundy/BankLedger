using System.Collections.Generic;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess.Interfaces
{
    public interface IAccountDetails
    {
        void ModifyBalance(TransactionType type, decimal amount, IAccount account);
        decimal BalanceInquiry(IAccount account);
        List<TransactionHistory> AllTransactions(IAccount account);
    }
}
