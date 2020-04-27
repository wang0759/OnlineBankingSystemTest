using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static test1.Enums;

namespace test1
{
    public class Account
    {
        public Customer Owner{get;}
        public double Balance { get; private set; }
        public List<Transaction> TransactionHistory { get; set; }

        public Account(Customer customer)
        {
            Owner = customer;
            TransactionHistory = new List<Transaction>();
            Balance = 0;
        }

        public virtual TransactionResult Deposit(Transaction transaction)
        {
            Balance += transaction.Amount;
            TransactionHistory.Add(transaction);

            return TransactionResult.SUCCESS;
        }

        public virtual TransactionResult Withdraw(Transaction transaction)
        {
            if (transaction.Amount > Balance)
            {
                return TransactionResult.INSUFFICIENT_FUND;
            }

            Balance -= transaction.Amount;
            TransactionHistory.Add(transaction);

            return TransactionResult.SUCCESS;
        }
    }
}