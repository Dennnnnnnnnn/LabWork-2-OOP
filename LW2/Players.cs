//Players.cs
namespace LW2
{
    /// <summary>
    /// Manages a collection of Player objects, including adding, 
    /// removing, and filtering operations.
    /// </summary>
    internal class Players
    {
        const int CMax = 50; //Maximum number of players in object collection
        private Player[] players; //Array to hold Player objects
        private int numberOfPlayers;  //Tracks the current count of players

        /// <summary>
        /// Initializes a new instance of the Players 
        /// class with a maximum capacity of 50 players.
        /// </summary>
        public Players()
        {
            numberOfPlayers = 0;
            players = new Player[CMax];
        }
        /// <summary>
        /// Gets the current number of players in the collection
        /// </summary>
        /// <returns>Current number of players in the collection</returns>
        public int GetNumberOfPlayers()
        {
            return numberOfPlayers;
        }
        /// <summary>
        /// Retrieves a player at the specified index
        /// </summary>
        /// <param name="index">Index of the player</param>
        /// <returns>Player by index</returns>
        public Player GetPlayer(int index)
        {
            return players[index];
        }
        /// <summary>
        /// Adds a new player to the collection if space allows
        /// </summary>
        /// <param name="pl">Player</param>
        public void AddPlayer(Player pl)
        {
            if (numberOfPlayers < CMax)
            {
                players[numberOfPlayers++] = pl;
            }
        }
        /// <summary>
        /// Removes a player at the specified 
        /// index and shifts remaining players
        /// </summary>
        /// <param name="index">Index of the player</param>
        public void RemovePlayer(int index)
        {
            players[index] = null;
            for (int j = index; j <= GetNumberOfPlayers() - 1; j++)
            {
                players[j] = players[j + 1];
            }
            numberOfPlayers--;
            if (players[CMax - 1] != null)
            {
                players[CMax - 1] = null;
            }
        }
        /// <summary>
        /// Sets the number of players in the collection
        /// </summary>
        /// <param name="n">Number of players</param>
        public void SetNumberOfPlayers(int n)
        {
            numberOfPlayers = n;
        }
        /// <summary>
        /// Calculates and returns the average points scored by players.
        /// </summary>
        /// <returns>Average score</returns>
        public double AverageScore()
        {
            double score = 0.0;     //Overall score
            for (int i = 0; i < numberOfPlayers; i++)
            {
                score += players[i].GetPoints();
            }
            double averageScore = score / numberOfPlayers;
            return averageScore;
        }
        /// <summary>
        /// Creates a new Players collection of players 
        /// who played all games and scored above average
        /// </summary>
        /// <param name="numberOfGames">Number of games</param>
        /// <returns>Object collection with players who 
        /// played all games and scored above average</returns>
        public Players ContainerOfPlayers(int numberOfGames)
        {
            Players idealPlayers = new Players();   //New object collection
                                                    //to store ideal players
            double averageScore = AverageScore();   //Average score
            int count = 0;  //Counts number of players in new object collection
            for (int i = 0; i < GetNumberOfPlayers(); i++)
            {
                Player player = GetPlayer(i);
                if (player == null)
                {
                    break;
                }
                if (player.GetMatchesPlayed() == numberOfGames
                    && player.GetPoints() > averageScore)
                {
                    Player idealPlayer = new Player(player.GetSurname(),
                        player.GetName(),
                        player.GetHeight(),
                        player.GetMatchesPlayed(),
                        player.GetPoints(),
                        player.GetMistakes());
                    idealPlayers.AddPlayer(idealPlayer);
                    count++;
                }
            }
            return idealPlayers;
        }
        /// <summary>
        /// Sorts players in ascending order by height and name
        /// </summary>
        /// <param name="containerOfPlayers">Container of players</param>
        /// <returns>Sorted container of players</returns>
        public Players Sort(Players containerOfPlayers) //for
        {
            if (containerOfPlayers != null)
                for (int i = 0; i < containerOfPlayers.GetNumberOfPlayers() - 1; i++)
                {
                    Player min = containerOfPlayers.players[i]; //Minimum player
                    int im = i;     //Minimum's player index
                    for (int j = i + 1; j < containerOfPlayers.GetNumberOfPlayers(); j++)
                        if (containerOfPlayers.players[j] < min)
                        {
                            min = containerOfPlayers.players[j];
                            im = j;
                        }
                    //Temporary variable to store player
                    Player temp = containerOfPlayers.players[i];
                    containerOfPlayers.players[i] = containerOfPlayers.players[im];
                    containerOfPlayers.players[im] = temp;
                }
            return containerOfPlayers;
        }
        /// <summary>
        /// Filters players based on a height range, 
        /// retaining those within specified bounds
        /// </summary>
        /// <param name="containerOfPlayers">Container of players</param>
        /// <param name="n1">Bound 1</param>
        /// <param name="n2">Bound 2</param>
        /// <returns>Players, whose height in the range</returns>
        public Players CheckHeight(Players containerOfPlayers,
            double n1, double n2)
        {
            if (n1 > 0 || n2 > 0)
            {
                for (int i = 0; i < containerOfPlayers.GetNumberOfPlayers(); i++)
                {
                    Player player = containerOfPlayers.GetPlayer(i);
                    if (player == null)
                    {
                        break;
                    }
                    if ((player.GetHeight() < n1) || (player.GetHeight() > n2))
                    {
                        containerOfPlayers.RemovePlayer(i);
                        i--;
                    }
                }
                return containerOfPlayers;
            }
            containerOfPlayers = null;
            return containerOfPlayers;
        }
    }
}
