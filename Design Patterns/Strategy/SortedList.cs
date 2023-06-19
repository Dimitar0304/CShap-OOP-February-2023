using Strategy.Interfaces;
using Strategy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class SortedList:ISort
    {
        private SortStrategy sortStrategy;
        private List<string> list= new List<string>();
        public void SetSortedStrategy(SortStrategy sortStrategy)
        {
            this.sortStrategy = sortStrategy;
        }
        public void Add(string item)
        {
            list.Add(item);
        }
        public void Clear()
        {
            list.Clear();
        }

        public void Sort()
        {
            sortStrategy.Sort(list);
            foreach (string item in list)
            {
                Console.WriteLine(" " + item);
            }
            Console.WriteLine();
        }
    }
}
