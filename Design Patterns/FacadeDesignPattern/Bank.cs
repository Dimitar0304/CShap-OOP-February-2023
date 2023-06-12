using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    public class Bank
    {
        public Bank(decimal balance)
        {
            Balance = balance;
        }
        public decimal Balance { get; set; }

        public void WhatIsMyBalace()
        {
            Console.WriteLine(Balance);
        }

    }
}
