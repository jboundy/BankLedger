using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess.Interfaces
{
    public interface IAccountDetails
    {
        void Deposit(decimal amountToDeposit);
        void Withdraw(decimal amountToWithdraw);
        decimal BalanceInquiry();
        void LogTransaction(TransactionType type);
    }
}
