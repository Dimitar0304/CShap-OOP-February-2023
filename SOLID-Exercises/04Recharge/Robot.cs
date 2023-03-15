using _04Recharge;
using System;

namespace P04.Recharge
{
    public class Robot : IWorker, IRechargeable
    {
        private int capacity;
        private int currentPower;
        private int workingHours;
        private string id;

        public Robot(string id, int capacity) 
        {
            this.id = id;   
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower
        {
            get { return this.currentPower; }
            set { this.currentPower = value; }
        }

        public void Work(int hours)
        {
            if (hours > this.currentPower)
            {
                hours = currentPower;
            }
            workingHours += hours;
           
            this.currentPower -= hours;
        }

        public  void Recharge()
        {
            this.currentPower = this.capacity;
        }
    }
}