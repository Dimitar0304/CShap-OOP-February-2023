using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddCollection : Collection
    {
        


        public override int Add(string item)
        {
            Colection.Add(item);
            return Colection.Count - 1;
        }

        public override string Remove()
        {
            throw new NotImplementedException();
        }
    }
}
