using System;
using LockpickingMinigame.GameLogic;

namespace LockpickingMinigame.UI.ConsoleUI
{
    public class UIPainter
    {
        private readonly MessagePrinter _playerInfo;
        private readonly MessagePrinter _picklockInfo;

        public UIPainter()
        {
            _playerInfo= new MessagePrinter("У игрока [n] отмычек;"," 00;-00;");
            _picklockInfo= new MessagePrinter("Текущее положение отмычки [n] градусов;", " 000;-000;");
        }

        public void DisplayBeforeKeyPressInfo(PickingProcess pickingProcess)
        {
            var picklocksQuantity = new[] {pickingProcess.Player.PicklocksQuantity};
            var tiltAngle = new[] {pickingProcess.ActivePicklock.TiltAngle};
            
            _playerInfo.Print(picklocksQuantity);
            _picklockInfo.Print(tiltAngle);
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
            Console.WriteLine("-------------------------------------------------------------------");
            
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