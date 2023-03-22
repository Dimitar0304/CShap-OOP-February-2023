using System.Collections.Generic;
using System.Linq;
using ValidationAttributes.Utils;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "peter",
                 13
             ); 

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);


        }
    }
}
