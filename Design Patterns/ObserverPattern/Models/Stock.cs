using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Models
{
    public abstract class Stock
    {
        private string symbol;
        private double price;
        private List<IInvestor> investors = new List<IInvestor>();

        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }
        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }
        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }
        public void Notify()
        {
            foreach (var investor in investors)
            {
                investor.Update(this);
            }
            Console.WriteLine("");
        }
        public string Symbol
        {
            get { return symbol; }
        }
        public double Price
        {
            get { return price;}
            set
            {
                if (price!=value)
                {
                    price = value;
                    Notify();
                }
            }
        }

    }
}
