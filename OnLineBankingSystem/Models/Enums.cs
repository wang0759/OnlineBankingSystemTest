using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test1
{
    public class Enums //https://www.tutorialsteacher.com/csharp/csharp-enum
    {
        public enum CustomerStatus 
        {
            REGULAR,
            PREMIER
        }

        public enum TransactionResult
        {
            SUCCESS,
            INSUFFICIENT_FUND,
            EXCEED_MAX_WITHDRAW_AMOUNT
        }

        public enum TransactionType
        {
            DEPOSIT,
            WITHDRAW,
            PENALTY,
            TRANSFER_OUT,
            TRANSFER_IN
        }





    }
}