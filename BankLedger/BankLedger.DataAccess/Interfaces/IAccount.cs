using System.Collections.Generic;
using BankLedger.DataAccess.Models;

namespace BankLedger.DataAccess.Interfaces
{
    public interface IAccount
    {
        decimal Balance { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        List<TransactionHistory> TransactionHistory { get; set; }
    }
}
