using System.Collections.Generic;
using BankLedger.DataAccess.Models;

namespace BankLedger.BLL.Interfaces
{
    public interface IBalanceAccess
    {
        decimal DepositFunds(decimal amount);
        decimal WithdrawFunds(decimal amount);
        decimal CurrentBalance(string username);
        List<TransactionHistory> RetrieveTransactions();
    }
}
