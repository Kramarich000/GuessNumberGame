// File: User.cs

using System;
using System.Collections.Generic;
using System.IO;

namespace GuessNumberGame
{
    public class User
    {
        public string Username { get; set; }
        public List<int> Scores { get; set; } = new List<int>();

        public void SaveScore(int score)
        {
            Scores.Add(score);
            File.AppendAllText("scores.txt", $"{Username}: {score}\n");
        }

        public void DisplayScores()
        {
            Console.WriteLine($"Результаты игрока {Username}:");
            foreach (var score in Scores)
            {
                Console.WriteLine(score);
            }
        }
    }
}
