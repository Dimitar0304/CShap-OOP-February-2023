using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDesignPattern.Models
{
    public class SilverState : State
    {
        public SilverState(State state):this(state.Balance,state.Account)
        {
            
        }
        public SilverState(double balance,Account account)
        {
            this.Balance = balance;
            this.Account = account;
            Initialise();
        }

        private void Initialise()
        {
            intersets = 0.0;
            lowerLimit = 0.0;
            upperLimit = 1000.0;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance>upperLimit)
            {
                account.State = new GoldState(this);
            }
            if (balance<lowerLimit)
            {
                account.State = new RedState(this);
            }
        }

        public override void PayInterest()
        {
            Balance += intersets * balance;
        }

        public override void WithDraw(double amount)
        {
            Balance -=amount;
            StateChangeCheck();
        }
    }
}
