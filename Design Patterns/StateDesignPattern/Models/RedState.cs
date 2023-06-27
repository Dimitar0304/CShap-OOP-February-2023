using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StateDesignPattern.Models
{
    public class RedState : State
    {
        private double serviceFee;
        public RedState(State state)
        {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialise();
            
        }
        private void Initialise()
        {
            intersets = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            serviceFee = 15.0;
        }
        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance > upperLimit)
            {
                account.State = new SilverState(this);
            }
        }

        public override void PayInterest()
        {
           //no interests...
        }

        public override void WithDraw(double amount)
        {
            amount = amount - serviceFee;
            Console.WriteLine("No funds availble for withdrawwall!");
        }
    }
}
