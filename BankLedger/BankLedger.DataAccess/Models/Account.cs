using System.Collections.Generic;
using BankLedger.DataAccess.Interfaces;

namespace BankLedger.DataAccess.Models
{
    public class Account : IAccount
    {
        public Account()
        {
            TransactionHistory = new List<TransactionHistory>();
        }
        
        public decimal Balance { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<TransactionHistory> TransactionHistory { get; set; }

    }
}
