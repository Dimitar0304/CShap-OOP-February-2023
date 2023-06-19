using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Models
{
    public class Investor : IInvestor
    {
        private string name;
        private Stock stock;
        public Investor(string name)
        {
            this.name = name;
        }
        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public void Update(Stock stock)
        {
            Console.WriteLine($"Notified {name} of {stock.Symbol} change to {stock.Price:F2}");
        }
    }
}
