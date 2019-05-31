using System.Collections.ObjectModel;
using BankLedger.BLL.Models;
using BankLedger.DataAccess.Models;

namespace BankLedger.BLL.Interfaces
{
    public interface IBalanceAccess
    {
        decimal DepositFunds(ActiveAccount account, decimal amount);
        decimal WithdrawFunds(ActiveAccount account, decimal amount);
        decimal CurrentBalance(ActiveAccount account);
        ReadOnlyCollection<TransactionHistory> RetrieveTransactions(ActiveAccount account);
    }
}
