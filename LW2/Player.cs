//Player.cs
using System;

namespace LW2
{
    /// <summary>
    /// Represents a basketball player with personal and game statistics.
    /// </summary>
    internal class Player
    {
        // Fields for storing player details
        private string surname, name;
        private double height;
        private int matchesPlayed, points, mistakes;

        /// <summary>
        /// Initializes a new instance of the Player class with default values.
        /// </summary>
        public Player()
        {
            surname = "";
            name = "";
            height = 0.0;
            matchesPlayed = 0;
            points = 0;
            mistakes = 0;
        }
        /// <summary>
        /// Initializes a new instance of the Player class with specified values.
        /// </summary>
        /// <param name="surname">Player's surname</param>
        /// <param name="name">Player's name</param>
        /// <param name="height">Player's height in meters</param>
        /// <param name="matchesPlayed">Total matches the player played</param>
        /// <param name="points">Total points scored by the player</param>
        /// <param name="mistakes">Total mistakes made by the player</param>
        public Player(string surname, string name, double height, 
            int matchesPlayed, int points, int mistakes)
        {
            this.surname = surname;
            this.name = name;
            this.height = height;
            this.matchesPlayed = matchesPlayed;
            this.points = points;
            this.mistakes = mistakes;
        }
        /// <summary>
        /// Get player's surname
        /// </summary>
        /// <returns>Plaeyr's surname</returns>
        public string GetSurname()
        {
            return surname;
        }
        /// <summary>
        /// Get player's name
        /// </summary>
        /// <returns>Player's name</returns>
        public string GetName()
        {
            return name;
        }
        /// <summary>
        /// Get player's height in meters
        /// </summary>
        /// <returns>Player's height</returns>
        public double GetHeight()
        {
            return height;
        }
        /// <summary>
        /// Total matches the player has played
        /// </summary>
        /// <returns>Matches played</returns>
        public int GetMatchesPlayed()
        {
            return matchesPlayed;
        }
        /// <summary>
        /// Total points scored by the player
        /// </summary>
        /// <returns>Returns total points</returns>
        public int GetPoints()
        {
            return points;
        }
        /// <summary>
        /// Total mistakes made by the player
        /// </summary>
        /// <returns>Returns total mistakes</returns>
        public int GetMistakes()
        {
            return mistakes;
        }
        /// <summary>
        /// Sets player's surname
        /// </summary>
        /// <param name="surname">Player's surname</param>
        public void SetSurname(string surname)
        {
            this.surname = surname;
        }
        /// <summary>
        /// Sets player's name
        /// </summary>
        /// <param name="name">Player's name</param>
        public void SetName(string name)
        {
            this.name = name;
        }
        /// <summary>
        /// Sets player's height
        /// </summary>
        /// <param name="height">Player's height</param>
        public void SetHeight(double height)
        {
            this.height = height;
        }
        /// <summary>
        /// Sets matches played
        /// </summary>
        /// <param name="matchesPlayed">Number of matches</param>
        public void SetMatchesPlayes(int matchesPlayed)
        {
            this.matchesPlayed = matchesPlayed;
        }
        /// <summary>
        /// Sets total points
        /// </summary>
        /// <param name="points">Points</param>
        public void SetPoints(int points)
        {
            this.points = points;
        }
        /// <summary>
        /// Sets total mistakes
        /// </summary>
        /// <param name="mistakes">Total points</param>
        public void SetMistakes(int mistakes)
        {
            this.mistakes = mistakes;
        }
        /// <summary>
        /// Sets player
        /// </summary>
        /// <param name="surname">Sets player's surname</param>
        /// <param name="name">Sets player's name</param>
        /// <param name="height">Sets player's height</param>
        /// <param name="matchesPlayed">Sets matches played</param>
        /// <param name="points">Sets total points</param>
        /// <param name="mistakes">Sets total mistakes</param>
        public void Set(string surname, string name, double height,
            int matchesPlayed, int points, int mistakes)
        {
            this.surname = surname;
            this.name = name;
            this.height = height;
            this.matchesPlayed = matchesPlayed;
            this.points = points;
            this.mistakes = mistakes;
        }
        /// <summary>
        /// Overloaded operators for comparing players based on height and name
        /// </summary>
        /// <param name="p1">Player 1 to compare</param>
        /// <param name="p2">Player 2 to compare</param>
        /// <returns>Returns true if p1 is greater than p2</returns>
        public static bool operator >(Player p1, Player p2)
        {
            int p = String.Compare(p1.GetName(), p2.GetName(), 
                StringComparison.CurrentCulture);
            if (p1.GetHeight() > p2.GetHeight())
            {
                return true;
            }
            else if (p1.GetHeight() == p2.GetHeight())
            {
                return p > 0;
            }
            else
                return false;
        }
        /// <summary>
        /// Overloaded operators for comparing players based on height and name
        /// </summary>
        /// <param name="p1">Player 1 to compare</param>
        /// <param name="p2">Player 2 to compare</param>
        /// <returns>Returns true if p1 is less than p2</returns>
        public static bool operator <(Player p1, Player p2)
        {
            int p = String.Compare(p1.GetName(), p2.GetName(), 
                StringComparison.CurrentCulture);
            if (p1.GetHeight() < p2.GetHeight())
            {
                return true;
            }
            else if (p1.GetHeight() == p2.GetHeight())
            {
                return p < 0;
            }
            else
                return false;
        }
        
        /// <summary>
        /// Converts player information to a formatted string
        /// </summary>
        /// <returns>Returns formatted player information</returns>
        public override string ToString()
        {
            return string.Format("{0,-13} {1, -10} {2, -13:f2} " +
                "{3, -12} {4, -12} {5, -5}",
                        surname,
                        name,
                        height,
                        matchesPlayed,
                        points,
                        mistakes); 
        }
    }
}
