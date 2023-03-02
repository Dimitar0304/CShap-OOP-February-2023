using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
		
		private string firstName;
		private string lastName;
		private int age;
		private decimal salary;

		public decimal Salary
		{
			get { return salary; }
			private set { salary = value; }
		}


		public Person(string firstName, string lastName,int age, decimal salary)
        {
            Age = age;
            LastName = lastName;
            FirstName = firstName;
			Salary = salary;	
        }

        public int Age
		{
			get { return age; }
			 private set { age = value; }
		}


		public string LastName
		{
			get { return lastName; }
			private set { lastName = value; }
		}


		public string FirstName
		{
			get { return firstName; }
			private set { firstName = value; }
		}
		public void IncreaseSalary(decimal increasePercentage)
		{
			if (this.Age>30)
			{
				Salary += this.Salary * increasePercentage / 100;
			}
			else
			{
				Salary += this.Salary * increasePercentage / 200;
			}
		}
        public override string ToString()
        {
			return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}
