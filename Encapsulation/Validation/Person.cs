using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class Person
    {
		private string firstName;
		private string lastName;
		private int age;
		private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public decimal Salary
		{
			get { return salary; }
			private set 
			{
				if (value<650m)
				{
					throw new Exception("Salary cannot be less than 650 leva!");
				}
				salary = value;	
			}
		}


		public int Age
		{
			get { return age; }
			private set 
			{
				if (value<=0)
				{
					throw new Exception("Age must not be zero or negative");
				}
				age = value;
			}
		}


		public string LastName
		{
			get { return lastName; }
			 private set
			{
				if (value.Length<3)
				{
					throw new Exception("Last name cannot contain fewer than 3 symbols!");
				}
				lastName = value;
			}
		}


		public string FirstName
		{
			get { return firstName; }
			private set 
			{
				if (value.Length<3)
				{
					throw new Exception("First name cannot contain fewer than 3 symbols!");
				}
				firstName = value;
			}

		}

        public override string ToString()
        {
			return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
