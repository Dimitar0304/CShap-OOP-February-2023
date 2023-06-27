using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDesignPattern.Models
{
    public class GoldState : State
    {
        public GoldState(State state):this(state.Account,state.Balance)
        {
            
        }
        public GoldState(Account account,double balance)
        {
            this.Account = account;
            this.Balance = balance;
            Initilise();
        }

        private void Initilise()
        {
            intersets = 0.05;
            lowerLimit = 1000.0;
            upperLimit = 1000000.0;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance<0.0)
            {
                account.State = new RedState(this);
            }
            else if (balance<lowerLimit)
            {
                account.State = new SilverState(this);
            }
        }

        public override void PayInterest()
        {
            Balance += intersets * balance;
            StateChangeCheck();
        }

        public override void WithDraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }
    }
}
