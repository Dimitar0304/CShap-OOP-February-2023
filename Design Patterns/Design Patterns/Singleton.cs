using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class Singleton
    {
        public static Singleton instance;
      
        public string Name { get;private set; }
        protected Singleton()
        { Name = "Dimitar";
        }
        

        public static Singleton Instance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
