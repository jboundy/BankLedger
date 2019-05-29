using System;
using System.Collections.Generic;
using System.Text;

namespace BankLedger.DataAccess.Models
{
    public class TransactionHistory
    {
        public DateTime ChangedDate { get; set; }
        public TransactionType Type { get; set;}
        public decimal AmountChanged { get; set; }
    }
}
