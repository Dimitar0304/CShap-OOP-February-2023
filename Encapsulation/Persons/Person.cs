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

        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            LastName = lastName;
            FirstName = firstName;
        }

        public int Age
		{
			get { return age; }
			set { age = value; }
		}


		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}


		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}
        public override string ToString()
        {
			return $"{FirstName} {LastName} is {Age} years old";
        }
    }
}
