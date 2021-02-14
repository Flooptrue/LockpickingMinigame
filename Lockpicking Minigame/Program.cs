using System;

namespace Lockpicking_Minigame
{
    class Program
    {
        static void Main(string[] args)
        {
            Lock easyLock = new Lock(DifficultyLevel.Easy);
            Player player = new Player(10);

            var process = player.StartPicking(easyLock);
            
            while (!easyLock.IsOpened)
            {
                if (player.PicklocksQuantity <= 0)
                    break;
                
                Console.WriteLine($"Введите угол для отмычки.");
                process.ChangePicklockAngle(double.Parse(Console.ReadLine()));
                var result = process.TryToPick();

                if (result)
                    Console.WriteLine("Замок открыт!");    
            }

            var lockState = easyLock.IsOpened ? "взломан" : "не взломан";
            Console.WriteLine($"\nСостояние замка : {lockState}.\nОсталось отмычек: {player.PicklocksQuantity} шт.");
        }
    }
}