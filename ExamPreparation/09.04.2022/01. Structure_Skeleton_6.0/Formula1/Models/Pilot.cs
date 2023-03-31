using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace = false;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }
                if (value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }
                fullName = value;
            }
        }

        public IFormulaOneCar  Car
        {
            get => car;
           private  set
            {
                if (value==null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                car = value;
            }
        }

        public int NumberOfWins { get; set; }

        public bool CanRace
        {
            get => canRace;
            private set
            {
                canRace = value;
            }
        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace  =true;
        }

        public void WinRace()
        {
           this.NumberOfWins++; 
        }
        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }

      
    }
    
}
