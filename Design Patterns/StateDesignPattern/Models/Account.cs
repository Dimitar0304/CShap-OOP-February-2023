using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDesignPattern.Models
{
    public class Account
    {
        private State state;
        private string owner;
        public Account(string owner)
        {
            this.owner = owner;
            state = new SilverState(0.0, this);

        }
        public double Balance
        {
            get { return state.Balance; }

        }
        public State State
        {
            get { return state; }
            set { state = value; }
        }
        public void Deposit(double ammount)
        {
            state.Deposit(ammount);
            Console.WriteLine($"Deposied {ammount}");
            Console.WriteLine($"Balance {this.Balance}");
            Console.WriteLine($"Status {this.GetType().Name}");
            Console.WriteLine();
        }
        public void WithDraw(double ammount)
        {
            state.WithDraw(ammount);
            Console.WriteLine($"Withdraw {ammount}");
            Console.WriteLine($"Balance {this.Balance}");
            Console.WriteLine($"Status {this.GetType().Name}");
            Console.WriteLine();
        }
        public void PayInterests()
        {
            state.PayInterest();
            Console.WriteLine("Interest Paid");
            Console.WriteLine($"Balance {this.Balance}");
            Console.WriteLine($"Status {this.GetType().Name}");
            Console.WriteLine();
        }
    }
}
