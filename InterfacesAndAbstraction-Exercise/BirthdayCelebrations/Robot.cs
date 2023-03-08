using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Robot : IIdentityInCity
    {
        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }
        public string Id { get ; set ; }
    }
}
