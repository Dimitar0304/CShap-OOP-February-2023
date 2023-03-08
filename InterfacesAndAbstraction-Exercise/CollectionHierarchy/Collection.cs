using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public abstract class Collection
    {
		private List<string> collection;

        public Collection()
        {
            Colection = new List<string>();
        }

        public List<string> Colection
		{
			get { return collection; }
			set { collection = value; }
		}

        public abstract string Remove();

        public abstract int Add(string item);
        
    }
}
