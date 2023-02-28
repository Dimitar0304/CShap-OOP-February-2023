using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public class Hero
    {
        
        public Hero(string username,int level)
        {
            Username = username;    
            Level = level;  
        }

        public int Level { get; set; }

        public string Username { get; set; }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}"; ;
        }

    }
}
