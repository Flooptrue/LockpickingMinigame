using System;
using LockpickingMinigame.GameLogic;

namespace LockpickingMinigame.UI.ConsoleUI
{
    public class UIPainter
    {
        private readonly UpdatableInfoWithNumbers _playerInfo;
        private readonly UpdatableInfoWithNumbers _picklockInfo;

        public UIPainter()
        {
            _playerInfo = new UpdatableInfoWithNumbers("У игрока [n] отмычек;"," 00;-00;");
            _picklockInfo = new UpdatableInfoWithNumbers("Текущее положение отмычки [n] градусов;", " 000;-000;");
        }

        public void Initialize(PickingProcess pickingProcess)
        {
            var picklocksQuantity = new[] {pickingProcess.Player.PicklocksQuantity};
            var tiltAngle = new[] {pickingProcess.ActivePicklock.TiltAngle};
            
            _playerInfo.Print(picklocksQuantity);
            _picklockInfo.Print(tiltAngle);
            Console.WriteLine("--------------------------------------------------------");
        }

        public void Update(PickingProcess pickingProcess)
        {
            var picklocksQuantity = new[] {pickingProcess.Player.PicklocksQuantity};
            var tiltAngle = new[] {pickingProcess.ActivePicklock.TiltAngle};
            
            _playerInfo.Print(picklocksQuantity);
            _picklockInfo.Print(tiltAngle);
        }
    }
}