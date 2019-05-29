using System.Collections.Generic;

namespace BankLedger.BLL.Interfaces
{
    public interface IBalanceAccess
    {
        decimal DepositFunds(decimal amount);
        decimal WithdrawFunds(decimal amount);
        decimal CurrentBalance(string username);
        List<string> RetrieveTransactions();
    }
}
