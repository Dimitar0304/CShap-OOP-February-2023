using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCitiesAndTheirPopulation
{
    public class SingletonDataContainer : ISingletonContainer
    {
        static SingletonDataContainer instance;
        Dictionary<string,int> countries = new Dictionary<string,int>();
        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");
            var elements = File.ReadAllLines(@"..\..\..\capital.txt");
            for (int i = 0; i < elements.Length; i+=2)
            {
                countries.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }
        public static SingletonDataContainer Instance()
        {
            if (instance==null)
            {
                instance = new SingletonDataContainer();
            }
            return instance;
        }
        public int GetPopulation(string name)
        {
            return countries[name];
        }
    }
}
