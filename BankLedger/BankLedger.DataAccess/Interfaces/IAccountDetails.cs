using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess.Interfaces
{
    public interface IAccountDetails
    {
        void ModifyBalance(TransactionType type, decimal amount);
        decimal BalanceInquiry();
    }
}
