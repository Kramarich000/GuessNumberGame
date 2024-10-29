// File: AuthService.cs

using System;

namespace GuessNumberGame
{
    public class AuthService
    {
        public User RegisterUser()
        {
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine();
            return new User { Username = username };
        }
    }
}
