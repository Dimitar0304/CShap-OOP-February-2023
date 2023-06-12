using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    public class Customer
    {
        public Credit Credit { get; set; }
        public Bank Bank { get; set; }
        public Customer(string name)
        {
            Name = name;
            Bank = new Bank(0);
            Credit = new Credit(0);
        }
        public string Name { get; set; }

    }
}
