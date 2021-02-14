using System;
using LockpickingMinigame.GameLogic;

namespace LockpickingMinigame
{
    public static class StartPoint
    {
        private const DifficultyLevel DifficultyLevel = GameLogic.DifficultyLevel.Easy;
        private const double StartPicklocksQuantity = 10;
        private const double StepForAngle = 1;

        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            var @lock = new Lock(DifficultyLevel);
            var player = new Player(StartPicklocksQuantity);
            
            StartPickingProcess(player, @lock);
        }

        private static void StartPickingProcess(Player player, Lock @lock)
        {
            var process = player.StartPicking(@lock);
            while (process.IsActive)
            {
                PrintStateInfo(process);
                HandleKeystrokes(process);
            }
            PrintFinalInfo(process);
        }

        private static void PrintStateInfo(PickingProcess pickingProcess)
        {
            var playerInfo = $"У игрока {pickingProcess.Player.PicklocksQuantity} отмычек;";
            var picklockInfo = $"Текущее положение отмычки {pickingProcess.ActivePicklock.TiltAngle} градусов;";
            
            Console.Clear();
            Console.WriteLine(playerInfo);
            Console.WriteLine(picklockInfo);
        }

        private static void HandleKeystrokes(PickingProcess pickingProcess)
        {
            var currentAngle = pickingProcess.ActivePicklock.TiltAngle;

            // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    pickingProcess.ChangePicklockAngle(currentAngle - StepForAngle);
                    break;
                case ConsoleKey.RightArrow:
                    pickingProcess.ChangePicklockAngle(currentAngle + StepForAngle);
                    break;
                case ConsoleKey.Enter:
                    pickingProcess.Pick();
                    break;
            }
        }
        
        private static void PrintFinalInfo(PickingProcess pickingProcess)
        {
            string resultMessage;
            if (!pickingProcess.Player.HasPicklocks())
            {
                resultMessage = "У игрока закончились отмычки!";
            }
            else if (pickingProcess.Lock.IsOpened)
            {
                resultMessage = "Замок взломан!";
            }
            else 
            {
                resultMessage = "Непонятная причина!";
            }
            
            var playerInfo = $"У игрока {pickingProcess.Player.PicklocksQuantity} отмычек;";
            var lockInfo = pickingProcess.Lock.IsOpened ? "Замок открыт;" : "Замок закрыт;";

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine(resultMessage);
            Console.WriteLine(playerInfo);
            Console.WriteLine(lockInfo);
        }
    }
}