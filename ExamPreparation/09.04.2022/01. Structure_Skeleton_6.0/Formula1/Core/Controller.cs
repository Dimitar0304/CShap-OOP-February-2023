using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
                formulaOneCarRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepository.FindByName(pilotName);
            if (pilot == null || pilot.CanRace == true)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }
            var car = formulaOneCarRepository.FindByName(carModel);
            if (car==null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            pilot.AddCar(car);

            return $"Pilot {pilot.FullName} will drive a {pilot.Car.GetType().Name} {pilot.Car.Model} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = raceRepository.FindByName(raceName);
            var pilot = pilotRepository.FindByName(pilotFullName);
            
            if (race==null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (pilot==null)
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }
            if (pilot.CanRace==false)
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            race.AddPilot(pilot);

            return $"Pilot { pilot.FullName} is added to the { race.RaceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            //create a formula car by this type 
            //"Ferrari" or "Williams"
            //if exist "Formula one car { model } is already created.",throw invalidOperationExeption
            //if type of carr is invalid "Formula one car type { type } is not valid." throw invalidOpEx
            //else "Car { type }, model { model } is created."- as message
            IFormulaOneCar car;
            if (type== "Ferrari")
            {
                 car  =new Ferrari(model, horsepower, engineDisplacement);

            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            if (formulaOneCarRepository.FindByName(car.Model)==null)
            {
                formulaOneCarRepository.Add(car);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }
            return $"Car {car.GetType().Name}, model {car.Model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            //add pilot to pilot repository
            //if it exist - "Pilot { full name } is already created." - throw invalidOperaionExeption
            //else - "Pilot { full name } is created."
            var pilot = new Pilot(fullName);

            if (pilotRepository.FindByName(pilot.FullName)==null)
            {
                pilotRepository.Add(pilot);
            }
            else
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }
            return $"Pilot {pilot.FullName} is created.";

        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = new Race(raceName, numberOfLaps);
            if (raceRepository.FindByName(raceName)==null)
            {
                raceRepository.Add(race);
                

            }
            else
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }
            return $"Race {race.RaceName} is created.";
        }

        public string PilotReport()
        {
            List<IPilot> pilots = pilotRepository.Models.OrderByDescending(x => x.NumberOfWins).ToList();
            var sb = new StringBuilder();
            foreach (var pilot in pilots)
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            List<IRace> races = raceRepository.Models.Where(x=>x.TookPlace==true).ToList();
            var sb = new StringBuilder();
            foreach (var race in races)
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race==null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (race.Pilots.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }
            if (race.TookPlace==true)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }
            var pilots = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3);
            race.TookPlace = true;
            var ssb = new StringBuilder();
            foreach (var pilot in pilots)
            {
                ssb.AppendLine($"Pilot {pilot.FullName } wins the {race.RaceName} race.");
            }
            return ssb.ToString().Trim();
        }
    }
}
