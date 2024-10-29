// Изменение в Program.cs

using System;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthService authService = new AuthService();
            User user = authService.RegisterUser();

            // Главный игровой процесс
            // (поместить сюда вызов основной логики игры)
        }
    }
}
