// File: Program.cs

using System;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthService authService = new AuthService();
            User currentUser = null;

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Регистрация");
                Console.WriteLine("2. Вход");
                Console.WriteLine("3. Выход");
                
                var choice = Console.ReadLine();
                
                if (choice == "1") // Регистрация
                {
                    Console.Write("Введите имя пользователя: ");
                    string username = Console.ReadLine();
                    Console.Write("Введите пароль: ");
                    string password = Console.ReadLine();
                    
                    authService.Register(username, password);
                }
                else if (choice == "2") // Вход
                {
                    Console.Write("Введите имя пользователя: ");
                    string username = Console.ReadLine();
                    Console.Write("Введите пароль: ");
                    string password = Console.ReadLine();
                    
                    currentUser = authService.Login(username, password);
                }
                else if (choice == "3") // Выход
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный выбор. Пожалуйста, попробуйте еще раз.");
                    continue;
                }

                if (currentUser != null)
                {
                    while (true)
                    {
                        Console.WriteLine("\nВыберите действие для игрока:");
                        Console.WriteLine("1. Играть в игру");
                        Console.WriteLine("2. Просмотреть результаты");
                        Console.WriteLine("3. Выйти из аккаунта");

                        var userChoice = Console.ReadLine();
                        
                        if (userChoice == "1") // Играть в игру
                        {
                            PlayGame(currentUser);
                        }
                        else if (userChoice == "2") // Просмотреть результаты
                        {
                            currentUser.DisplayScores();
                        }
                        else if (userChoice == "3") // Выйти из аккаунта
                        {
                            currentUser = null;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный выбор. Пожалуйста, попробуйте еще раз.");
                        }
                    }
                }
            }
        }
    }
}
