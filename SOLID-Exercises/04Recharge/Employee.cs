namespace P04.Recharge
{
    using _04Recharge;
    using System;

    public class Employee :  ISleeper,IWorker
    {
        private string id;
        private int workingHours;

        public Employee(string id) 
        {
            this.id = id;
        }

        public  void Sleep()
        {
            // sleep...
            Console.WriteLine("Sleep");
        }

      

        public void Work(int hours)
        {
            workingHours += hours;
        }
    }
}
