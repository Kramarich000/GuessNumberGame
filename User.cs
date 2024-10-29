using System;
using System.Collections.Generic;
using System.IO;

namespace GuessNumberGame
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; } // Хранение пароля
        public List<(int Score, int Attempts)> GameResults { get; set; } = new List<(int, int)>();

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            LoadScores(); // Загружаем результаты при создании пользователя
        }

        public void SaveScore(int score, int attempts)
        {
            GameResults.Add((score, attempts));
            File.AppendAllText("scores.txt", $"{Username}: {score}, {attempts}\n"); // Сохраняем результаты в файл
        }

        public void DisplayScores()
        {
            Console.WriteLine($"Результаты игрока {Username}:");
            if (GameResults.Count == 0)
            {
                Console.WriteLine("У вас еще нет игр.");
                return;
            }

            foreach (var result in GameResults)
            {
                Console.WriteLine($"Число: {result.Score}, Попыток: {result.Attempts}");
            }
        }

        public bool ValidatePassword(string password)
        {
            return Password == password; // Проверка пароля
        }

        private void LoadScores()
        {
            if (File.Exists("scores.txt"))
            {
                var lines = File.ReadAllLines("scores.txt");
                foreach (var line in lines)
                {
                    if (line.StartsWith(Username))
                    {
                        var parts = line.Split(new[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 3)
                        {
                            int score = int.Parse(parts[1].Trim());
                            int attempts = int.Parse(parts[2].Trim());
                            GameResults.Add((score, attempts)); // Загружаем результаты из файла
                        }
                    }
                }
            }
        }
    }
}
