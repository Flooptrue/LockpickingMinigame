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
            var ui = new ConsoleUI();
            var process = player.StartPicking(@lock);
            
            while (process.IsActive)
            {
                ui.DisplayBeforeKeyPressInfo(process);
                HandleKeystrokes(process);
                ui.DisplayAfterKeyPressInfo(process);
            }
            ui.DisplayFinalInfo(process);
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
    }
}