using System;
using static test1.Enums;

namespace test1
{
    public class Transaction
    {
        public double Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction(double Amount, TransactionType Type)
        {
            this.Amount = Amount;
            this.Type = Type;
            TransactionDate = DateTime.Now;
        }
    }
}