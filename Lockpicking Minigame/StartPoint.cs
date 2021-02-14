using System;
using LockpickingMinigame.GameLogic;

namespace LockpickingMinigame
{
    public static class StartPoint
    {
        private const DifficultyLevel DifficultyLevel = GameLogic.DifficultyLevel.Easy;
        private const double StartPicklocksQuantity = 10;
        private static bool IsGameOver;

        private static void Main(string[] args)
        {
            var @lock = new Lock(DifficultyLevel);
            var player = new Player(StartPicklocksQuantity);

            if (!player.HasPicklocks())
            {
                Console.WriteLine("У игрока нет отмычек. Открытие замка не возможно.");
                return;
            }

            var process = player.StartPicking(@lock);
            while (!IsGameOver)
            {
                if (!player.HasPicklocks())
                {
                    Console.WriteLine("У игрока закончились отмычки!");
                    break;
                }
                
                Console.WriteLine($"Введите угол для отмычки.");
                process.ChangePicklockAngle(double.Parse(Console.ReadLine()));
                var result = process.TryToPick();

                if (result)
                    Console.WriteLine("Замок открыт!");    
            }
        }
    }
}