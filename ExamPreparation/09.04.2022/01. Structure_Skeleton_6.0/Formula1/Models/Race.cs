﻿using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace = false;
        private List<IPilot> pilots = new List<IPilot>();

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid race name: { value}.");
                }
                if (value.Length<5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }
                raceName = value;
            }
        }

        public int NumberOfLaps { get => numberOfLaps;
        private set
            {
                if (value<1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace { get => tookPlace; set => tookPlace = value; }

        public ICollection<IPilot> Pilots { get=>pilots; set =>pilots =value.ToList(); }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            string tookPlace = string.Empty;

            if (this.TookPlace==true)
            {
                tookPlace = "Yes";
            }
            else
            {
                tookPlace = "No";
            }

            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: { NumberOfLaps }");
            sb.AppendLine($"Took place: {tookPlace}");

            return sb.ToString().Trim();
        }
    }
}
