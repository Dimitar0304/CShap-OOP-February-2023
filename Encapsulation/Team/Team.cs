using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
		private string name;
		private List<Person> firstTeam;
		private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
             this.reserveTeam = new List<Person>();
        }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return this.firstTeam.AsReadOnly(); }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.firstTeam.AsReadOnly(); }

        }
        public string Name
		{
			get { return name; }
			private set { name = value; }
        }
        public void AddPlayer(Person p)
        {
            if (p.Age<40)
            {
                firstTeam.Add(p);
            }
            else
            {
                reserveTeam.Add(p);
            }
        }


    }
}
