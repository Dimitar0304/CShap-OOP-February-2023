using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (string.IsNullOrWhiteSpace((string)obj))
            {
                return false;
            }
            return true;
           

        }
    }
}
