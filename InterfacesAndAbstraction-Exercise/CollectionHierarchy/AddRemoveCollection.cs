using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : Collection
    {
        
       
        public override int Add(string item)
        {
            Colection.Insert(0, item);
            return 0;
        }

        public override string Remove()
        {
            string result = Colection[Colection.Count - 1];
            Colection.RemoveAt(Colection.Count - 1);
            return result;
        }
    }
}
