using System;
using LockpickingMinigame.GameLogic;
using LockpickingMinigame.UI.ConsoleUI;

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
            Console.CursorVisible = false;
            
            var @lock = new Lock(DifficultyLevel);
            var player = new Player(StartPicklocksQuantity);
            
            StartPickingProcess(player, @lock);
        }

        private static void StartPickingProcess(Player player, Lock @lock)
        {
            var ui = new UIPainter();
            var process = player.StartPicking(@lock);

            ui.Initialize(process);
            while (process.IsActive)
            {
                HandleKeystrokes(process);
                ui.Update(process);
            }
        }

        private static void HandleKeystrokes(PickingProcess pickingProcess)
        {
            var currentAngle = pickingProcess.ActivePicklock.TiltAngle;

            // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    Console.Write("\b");
                    pickingProcess.ChangePicklockAngle(currentAngle - StepForAngle);
                    break;
                case ConsoleKey.RightArrow:
                    Console.Write("\b");
                    pickingProcess.ChangePicklockAngle(currentAngle + StepForAngle);
                    break;
                case ConsoleKey.Enter:
                    pickingProcess.Pick();
                    break;
            }
        }
    }
}