using System;
using LockpickingMinigame.GameLogic;

namespace LockpickingMinigame.UI.ConsoleUI
{
    public class UIPainter
    {
        public void DisplayBeforeKeyPressInfo(PickingProcess pickingProcess)
        {
            var playerInfo = $"У игрока {pickingProcess.Player.PicklocksQuantity} отмычек;";
            var picklockInfo = $"Текущее положение отмычки {pickingProcess.ActivePicklock.TiltAngle} градусов;";
            
            Console.Clear();
            Console.WriteLine(playerInfo);
            Console.WriteLine(picklockInfo);
        }

        public void DisplayAfterKeyPressInfo(PickingProcess pickingProcess)
        {
            // if (!_shouldPrintLockPickingResult)
            //     return;
            //
            // var lockStatus = pickingProcess.Lock.IsOpened 
            //     ? "Замок открыт!" 
            //     : $"Замок повернулся на n %.";
            //
            // Console.WriteLine("-------------------------------------------------------------------");
            // Console.WriteLine(lockStatus);
        }

        public void DisplayFinalInfo(PickingProcess pickingProcess)
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
            
            Console.WriteLine(resultMessage);
            Console.WriteLine(playerInfo);
            Console.WriteLine(lockInfo);
        }
    }
}