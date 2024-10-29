using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessNumberGame
{
    public class AuthService
    {
        private List<User> users = new List<User>();

        public void Register(string username, string password)
        {
            // Проверяем, существует ли пользователь
            if (users.Any(u => u.Username == username))
            {
                Console.WriteLine("Пользователь с таким именем уже существует.");
                return;
            }

            User newUser = new User(username, password);
            users.Add(newUser);
            Console.WriteLine($"Пользователь {username} зарегистрирован.");
        }

        public User Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null && user.ValidatePassword(password))
            {
                Console.WriteLine($"Пользователь {username} вошел в систему.");
                return user;
            }
            else
            {
                Console.WriteLine("Неверное имя пользователя или пароль.");
                return null;
            }
        }

        public void DisplayAllUsers()
        {
            Console.WriteLine("Список пользователей:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Username);
            }
        }
    }
}
