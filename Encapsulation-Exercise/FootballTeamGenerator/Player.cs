﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const string StatsExeption = "{0} should be between 0 and 100.";

        private string name;
        private double stats;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name,int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Shooting = shooting;
            Passing = passing;
            Name = name;
        }

        public int Endurance
        {
            get => endurance;
         private   set
            {
                if (value<0||value>100)
                {
                    throw new ArgumentException(string.Format(StatsExeption, nameof(Endurance)));
                }
                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(StatsExeption,nameof(Sprint)));
                }
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(StatsExeption, nameof(Dribble)));
                }
                dribble = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(StatsExeption, nameof(Shooting)));
                }
                shooting = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(StatsExeption, nameof(Passing)));
                }
                passing = value;
            }
        }
        public double Stats
        {
            get { return (Endurance + Sprint+Dribble +Shooting +Passing)/5.0; }
            private set { Stats = value; }
        }


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

    }
}
