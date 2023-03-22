using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Person
    {
        private string fullName;
        private int age;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName
        {
            get => fullName;
            private set
            {
                fullName = value;
            }
        }
        [MyRange(12,90)]
        public int Age
        {
            get=>age;
            private set
            {
                age = value;
            }
        }
    }
}
