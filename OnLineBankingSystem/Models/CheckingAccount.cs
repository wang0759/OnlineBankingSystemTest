using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static test1.Enums;

namespace test1
{
    public class CheckingAccount : Account 
    {
        public double MaxDailyWithdrawAmount { get; set; } = 300;

        public CheckingAccount(Customer customer):base(customer)
        {
            
        }

        public override TransactionResult Withdraw(Transaction transaction)
        {
            if (transaction.Type!=TransactionType.TRANSFER_OUT 
                && this.Owner.Status == CustomerStatus.REGULAR 
                && transaction.Amount > MaxDailyWithdrawAmount)
            {
                return TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT;
            }

            return base.Withdraw(transaction);
        }
    }
}