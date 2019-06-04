using System.Collections.Generic;
using BankLedger.BLL.Models;
using BankLedger.DataAccess.Models;

namespace BankLedger.BLL.Interfaces
{
    public interface IBalanceAccess
    {
        decimal DepositFunds(ActiveAccount account, decimal amount);
        decimal WithdrawFunds(ActiveAccount account, decimal amount);
        decimal CurrentBalance(ActiveAccount account);
        List<TransactionHistory> RetrieveTransactions(ActiveAccount account);
    }
}
