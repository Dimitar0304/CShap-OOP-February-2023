using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    public class Mortgage
    {
        public Customer customer { get; set; }
        public Mortgage(Customer customer)
        {
            this.customer = customer;
        }


        public void GetCredit()
        {
            if (customer.Credit.SumThatWeMustGiveForCredit==0)
            {
                Console.WriteLine("yes you can get credit!");

                customer.Credit = new Credit(decimal.Parse(Console.ReadLine()));
                customer.Bank.Balance += customer.Credit.SumThatWeMustGiveForCredit;
            }
            else
            {
                Console.WriteLine("You can't get credit because you must to pay your previous credit");
            }
        }
    }
}
