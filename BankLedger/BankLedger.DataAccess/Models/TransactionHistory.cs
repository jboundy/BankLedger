using System;
using System.Collections.Generic;
using System.Text;

namespace BankLedger.DataAccess.Models
{
    public class TransactionHistory
    {
        public TransactionHistory(TransactionType type, decimal amount)
        {
            ChangedDate = DateTime.Now;
            Type = type;
            AmountChanged = amount;
        }
        public DateTime ChangedDate { get;}
        public TransactionType Type { get;}
        public decimal AmountChanged { get;}
    }
}
