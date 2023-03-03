using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public List<Player> Players { get=>players; private set =>players=value; }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            bool isExist = false;
            for (int i = 0; i < players.Count; i++)
            {

            
                if (players[i].Name == playerName)
                {
                    isExist = true;
                    players.Remove(players[i]);
                }
            }
            if (isExist == false)
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }
        }
        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(p => p.Stats);
                }

                return 0;
            }
        }

    }
}
