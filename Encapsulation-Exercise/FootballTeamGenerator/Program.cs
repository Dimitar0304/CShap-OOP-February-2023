using FootballTeamGenerator;

List<Team> teams = new List<Team>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "END")
    {
        break;
    }
    try
    {

    string[] commandInfo = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
    switch (commandInfo[0])
    {
        case "Team":
            Team team = new Team(commandInfo[1]);
            teams.Add(team);
            break;
        case "Add":
            bool isExist = false;
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Name == commandInfo[1])
                {
                    isExist = true;
                    Player player = new Player(commandInfo[2], int.Parse(commandInfo[3]), int.Parse(commandInfo[4]), int.Parse(commandInfo[5]), int.Parse(commandInfo[6]), int.Parse(commandInfo[7]));
                    teams[i].AddPlayer(player);
                }
            }
            if (isExist == false)
            {
                throw new ArgumentException($"Team {commandInfo[1]} does not exist.");

            }
            break;
        case "Remove":
            isExist = false;
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Name == commandInfo[1])
                {
                    isExist = true;
                    teams[i].RemovePlayer(commandInfo[2]);
                }
            }
            if (isExist == false)
            {
                throw new ArgumentException($"Team {commandInfo[1]} does not exist.");
            }
            break;
        case "Rating":
                isExist = false;
                for (int i = 0; i < teams.Count; i++)
                {
                    if (teams[i].Name == commandInfo[1])
                    {
                        isExist = true;
                        Console.WriteLine($"{teams[i].Name} - {teams[i].Rating:F0}");
                    }
                }
                if (isExist==false)
                {
                    throw new ArgumentException($"Team {commandInfo[1]} does not exist.");
                }
                break;
    }
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }
}
