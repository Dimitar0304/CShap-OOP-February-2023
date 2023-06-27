using System.Reflection.Metadata.Ecma335;

namespace StateDesignPattern.Models
{
    public abstract class State
    {
        protected Account account;
        protected double balance;

        protected double intersets;
        protected double lowerLimit;
        protected double upperLimit;

        public Account Account { get; set; }
        public double Balance { get; set; }

        public abstract void Deposit(double amount);
        public abstract void WithDraw(double amount);

        public abstract void PayInterest();
    }
}
