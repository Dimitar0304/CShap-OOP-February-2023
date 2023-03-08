
using MilitaryElite;
using MilitaryElite.Interfaces;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Private> privates = new List<Private>();
        List<ISoldier> soldiers = new List<ISoldier>();
        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens[0] == "Private")
            {
                Private Private = new Private(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]));
                privates.Add(Private);
                soldiers.Add(Private);
            }
            else if (tokens[0] == "Spy")
            {
                Spy spy = new Spy(tokens[1], tokens[2], tokens[3], int.Parse(tokens[4]));
                soldiers.Add(spy);
            }
            else if (tokens[0] == "LieutenantGeneral")
            {
                List<Private> LeitenatPrivates = new List<Private>();
                List<string> privatesInfo = new List<string>();
                for (int i = 5; i < tokens.Length; i++)
                {
                    privatesInfo.Add(tokens[i]);
                }
                foreach (var lPrivates in privatesInfo)
                {
                    foreach (var item in privates)
                    {
                        if (item.Id==lPrivates)
                        {
                            LeitenatPrivates.Add(item);
                        }
                    }
                    
                }



                LeutenantGeneral leutenantGeneral = new LeutenantGeneral(tokens[1], tokens[2], tokens[3],
                    decimal.Parse(tokens[4]), LeitenatPrivates.ToArray());
                soldiers.Add(leutenantGeneral);
            }
            else if (tokens[0]== "Engineer")
            {
                List<string> reparirsInfo = new List<string>();
                List<Repair> repairs = new List<Repair>();
                for (int i = 6; i < tokens.Length; i++)
                {
                    reparirsInfo.Add(tokens[i]);
                }
                //we must create repair
                int counter = 0;
                string currentName = string.Empty;
                int hoursWorked = 0;
                for (int i = 0; i < reparirsInfo.Count; i++)
                {

                    if (i%2==0)
                    {
                        currentName = reparirsInfo[i];
                        counter++;

                    }
                    else
                    {
                         hoursWorked = int.Parse(reparirsInfo[i]);
                        counter++;
                    }

                    if (counter==2)
                    {
                        Repair repair = new Repair(currentName, hoursWorked);
                        counter = 0;
                        repairs.Add(repair);
                    }
                }

                Engineer engineer = new Engineer(tokens[1], tokens[2], tokens[3], 
                    decimal.Parse(tokens[4]), tokens[5], repairs.ToArray());
                soldiers.Add(engineer);

            }
            else if (tokens[0]=="Commando")
            {
                List<string> missionInfo = new List<string>();
                List<Mission> missions = new List<Mission>();
                for (int i = 6; i < tokens.Length; i++)
                {
                    missionInfo.Add(tokens[i]);
                }
                //we create each mission
                int counter = 0;
                string missionName = string.Empty;
                string missionState = string.Empty;
                for (int i = 0; i < missionInfo.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        missionName = missionInfo[i];
                        counter++;

                    }
                    else
                    {
                        missionState =  missionInfo[i];
                        counter++;
                    }

                    if (counter == 2)
                    {
                        Mission mission = new Mission(missionName, missionState);
                        counter = 0;
                        missions.Add(mission);
                    }
                }

                Commando commando = new Commando(tokens[1], tokens[2], tokens[3],
                    decimal.Parse(tokens[4]), tokens[5], missions.ToArray());
                soldiers.Add(commando);
            }




            command = Console.ReadLine();

        }
        foreach (var item in soldiers)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

