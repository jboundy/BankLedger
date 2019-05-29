using System.Collections.Generic;

namespace BankLedger.DataAccess.Models
{
    public class Account
    {
        public Account()
        {
            Balance = 0;
            TransactionHistory = new List<TransactionHistory>();
        }
        
        public decimal Balance { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<TransactionHistory> TransactionHistory { get; set; }

    }
}
