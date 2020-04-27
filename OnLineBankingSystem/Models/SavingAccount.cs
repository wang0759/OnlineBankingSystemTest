using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static test1.Enums;

namespace test1
{
    public class SavingAccount : Account
    {
        public static double PrimierAmount { get; set; } = 2000;
        public static double WithdrawPenaltyAmount { get; } = 10;

        public SavingAccount(Customer customer):base(customer)
        {

        }

        public override TransactionResult Deposit(Transaction transaction)
        {
            if (Balance>=2000)
            {
                Owner.Status = CustomerStatus.PREMIER;
            }
            else
            {
                Owner.Status = CustomerStatus.REGULAR;
            }

            return base.Deposit(transaction);
        }

        public override TransactionResult Withdraw(Transaction transaction)
        {
            // apply penalty
            if (Owner.Status == CustomerStatus.REGULAR && transaction.Type != TransactionType.TRANSFER_OUT)
            {
                Transaction penalty = new Transaction(WithdrawPenaltyAmount, TransactionType.PENALTY);

                if (transaction.Amount + penalty.Amount > Balance)
                {
                    return TransactionResult.INSUFFICIENT_FUND; 
                }
                else
                {
                    base.Withdraw(penalty);
                }
            }

            return base.Withdraw(transaction);
        }
    }
}