using Raiding.Core.Interfaces;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IBaseHeroFactory _heroFactory;
        private ICollection<IBaseHero> heroes;

        public Engine(IReader reader, IWriter writer, IBaseHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            _heroFactory = heroFactory;
            heroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int countOfHeroes = int.Parse(reader.ReadLine());
            while (countOfHeroes != 0)
            {
                string heroName = reader.ReadLine();
                string type = reader.ReadLine();

                try
                {

                    heroes.Add(_heroFactory.Create(type, heroName));
                    countOfHeroes--;


                }

                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            int bossPower = int.Parse(reader.ReadLine());
           
            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }
            if (heroes.Sum(h => h.Power) >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
