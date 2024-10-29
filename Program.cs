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

            Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
            Console.WriteLine("Выберите уровень сложности: 1 - Легкий, 2 - Средний, 3 - Сложный");
            int difficulty = int.Parse(Console.ReadLine());
            int maxNumber = difficulty switch
            {
                1 => 10,
                2 => 50,
                3 => 100,
                _ => 10
            };

            Random random = new Random();
            int secretNumber = random.Next(1, maxNumber + 1);
            int attempts = 0;
            bool guessed = false;

            Console.WriteLine($"Я загадал число от 1 до {maxNumber}. Попробуйте угадать!");

            while (!guessed)
            {
                Console.Write("Введите ваше число: ");
                int userGuess = int.Parse(Console.ReadLine());
                attempts++;

                if (userGuess < secretNumber)
                {
                    Console.WriteLine("Слишком низкое число. Попробуйте снова.");
                }
                else if (userGuess > secretNumber)
                {
                    Console.WriteLine("Слишком высокое число. Попробуйте снова.");
                }
                else
                {
                    guessed = true;
                    Console.WriteLine($"Поздравляем! Вы угадали число {secretNumber} за {attempts} попыток.");
                }
            }

        }
    }
}
