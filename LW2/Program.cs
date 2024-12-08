//Program.cs
//TASK: Text file U3.txt contains information about the basketball team's players.
//The first line of the file the command name, the number of matches played;
//other lines - information about players: surname, name, height, matches played,
//points, mistakes. Create a class Player to store data about single basketball player.
//Create a container class Players to store all data about given players.
//Create a container of players who have played all the games and scored more points
//than scoring average. Sort the created container according to the height and the
//player's name. In the container, leave only those players whose height
//is in the range [n1, n2] and remove the others.

using System;
using System.IO;

namespace LW2
{
    internal class Program
    {
        const string filename = "U3.txt"; //File with initial data
        const string result = "Result.txt"; //Result file
        static void Main(string[] args)
        {
            if (File.Exists(result))
                File.Delete(result);

            string commandName; //Command name
            int numberOfGames; //Number of games
            int numberOfPlayers; //Number of players
            //Container to store information about all players
            Players players = new Players(); 
            Read(filename, players, out commandName, 
                out numberOfGames, out numberOfPlayers);

            PrintContainer(result, "Initial data", 
                commandName, numberOfPlayers, players);
            //Container to store information about players, who
            //have played all the games and scored more points
            //than scoring average
            Players containerOfPlayers = 
                players.ContainerOfPlayers(numberOfGames);
            PrintContainer(result, "Container", commandName, 
                numberOfPlayers, containerOfPlayers);
            PrintContainer(result, "Sorted container",commandName, 
                numberOfPlayers, containerOfPlayers.Sort(containerOfPlayers));

            Console.WriteLine("Enter the value for n1");
            double n1 = double.Parse(Console.ReadLine()); //Start number of height
            Console.WriteLine("Enter the value for n2");
            double n2 = double.Parse(Console.ReadLine()); //End number of height
            PrintContainer(result, 
                $"Players, whose height is in the range [{n1};{n2}]", 
                commandName, numberOfPlayers,
                containerOfPlayers.CheckHeight(containerOfPlayers, n1, n2));
        }
        static void Read(string filename, Players players, 
            out string commandName, out int numberOfGames, 
            out int numberOfPlayers)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(';');
                commandName = parts[0];
                numberOfGames = int.Parse(parts[1]);
                line = reader.ReadLine();
                for (numberOfPlayers = 0; line != null; numberOfPlayers++)
                {
                    parts = line.Split(';');
                    string surname = parts[0];
                    string name = parts[1];
                    double height = double.Parse(parts[2]);
                    int matchesPlayed = int.Parse(parts[3]);
                    int points = int.Parse(parts[4]);
                    int mistakes = int.Parse(parts[5]);
                    Player player = new Player(surname, name, 
                        height, matchesPlayed, points, mistakes);
                    players.AddPlayer(player);
                    line = reader.ReadLine();
                }
            }
        }
        static void PrintContainer(string filename, string header, 
            string commandName, int numberOfPlayers, Players players)
        {
            using (StreamWriter wr = new StreamWriter(filename, true))
            {
                wr.WriteLine(header);
                if (header == "Initial data")
                {
                    wr.WriteLine("Command name: "  + commandName);
                    wr.WriteLine("Number of players: " + numberOfPlayers);
                }
                if (players != null && players.GetNumberOfPlayers() != 0) 
                {
                    wr.WriteLine("-------------------------------------" +
                        "-----------------------------------");
                    wr.WriteLine("Surname       Name      Height     " +
                        " Matches      Points      Mistakes");
                    wr.WriteLine("--------------------------------------" +
                        "----------------------------------");
                    for (int i = 0; i < players.GetNumberOfPlayers(); i++)
                    {
                        Player player = players.GetPlayer(i);
                        wr.WriteLine("{0,-13} {1, -10} {2, -13:f2} " +
                            "{3, -12} {4, -12} {5, -5}",
                            player.GetSurname(),
                            player.GetName(), 
                            player.GetHeight(),
                            player.GetMatchesPlayed(),
                            player.GetPoints(), 
                            player.GetMistakes());
                    }
                    wr.WriteLine("-------------------------------------" +
                        "-----------------------------------\r\n");
                }
                else
                {
                    wr.WriteLine("No suitable players found\r\n");
                }
            }
        }
    }
}
