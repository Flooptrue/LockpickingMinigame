namespace LockpickingMinigame.GameLogic
{
    public class PickingProcess
    {
        private readonly Player _player;
        private readonly Lock _lock;
        private Picklock _activePicklock;

        public PickingProcess(Player player, Lock lockInstance)
        {
            _player = player;
            _lock = lockInstance;
            _activePicklock = new Picklock();
        }

        public bool TryToPick()
        {
            if (_player.PicklocksQuantity <= 0)
                return false;
            
            if (_player.PicklocksQuantity > 0 && _activePicklock.IsBroken)
                _activePicklock = new Picklock();

            var pickResult = _lock.Pick(_activePicklock);

            if (_activePicklock.IsBroken)
                _player.RemoveOnePicklock();

            return pickResult;
        }

        public void ChangePicklockAngle(double angle)
        {
            if (_player.PicklocksQuantity <= 0)
                return;

            _activePicklock.TiltAngle = angle;
        }
    }
}