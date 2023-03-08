using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class MyList : Collection
    {
        public int Used { get { return Colection.Count; } }
       

        public override int Add(string item)
        {
            Colection.Insert(0, item);
            return 0;
        }

        public override string Remove()
        {
            string result = Colection[0];
            Colection.RemoveAt(0);
            return result;
        }
    }
}
