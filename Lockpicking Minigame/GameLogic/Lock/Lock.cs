using System;

namespace LockpickingMinigame.GameLogic
{
    public class Lock
    {
        private readonly Random _randomizer;
        private readonly DifficultyLevel _difficultyLevel;
        private readonly SuccessZone _successZone;
        public bool IsOpened { get; private set; }

        public Lock(DifficultyLevel difficultyLevel)
        {
            _randomizer = new Random();
            _difficultyLevel = difficultyLevel;
            _successZone = new SuccessZone(difficultyLevel);
            IsOpened = false;
        }

        public bool Pick(Picklock picklock)
        {
            if (picklock.IsBroken)
                throw new Exception("Attempt to pick lock with broken picklock.");
                    
            if (!IsOpened)
                IsOpened = _successZone.IsSuccess(picklock.TiltAngle);

            if (!IsOpened)
                BreakPicklock(picklock);

            return IsOpened;
        }

        private void BreakPicklock(Picklock picklock)
        {
            if (_randomizer.NextDouble() < BreakageChanceProvider.GetBreakageChance(_difficultyLevel))
                picklock.IsBroken = true;
        }
    }
}