using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    public class Credit
    {
        public Credit(decimal sum)
        {
            SumThatWeMustGiveForCredit = sum;

        }
        public decimal SumThatWeMustGiveForCredit { get; set; }

        public void AddSumToCredit(decimal sum)
        {
            SumThatWeMustGiveForCredit -= sum;
            Console.WriteLine($"You give {sum} for your credit");
            Console.WriteLine($"Remaing money {SumThatWeMustGiveForCredit}$");
        }
    }
}
