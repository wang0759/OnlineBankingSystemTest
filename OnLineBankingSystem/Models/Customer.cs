using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static test1.Enums;

namespace test1
{
    public class Customer
    {
        public int Id { get; }//auto implemented property
        public string Name { get; }
        public CustomerStatus Status { get; set; }
        public CheckingAccount Checking { get; set; }
        public SavingAccount Saving { get; set; }

        public Customer(string name)
        {
            
            this.Name = name;
            Random generator = new Random();
            Id = generator.Next(1000, 9000);
        }


    }
}