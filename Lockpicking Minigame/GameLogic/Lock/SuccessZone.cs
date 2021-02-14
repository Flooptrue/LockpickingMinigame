using System;

namespace Lockpicking_Minigame
{
    public class SuccessZone
    {
        private readonly Random _randomizer;

        public double LowerBorder { get; private set; }
        public double UpperBorder { get; private set; }
        public DifficultyLevel CurrentDifficultyLevel { get; }
        
        public SuccessZone(DifficultyLevel difficultyLevel)
        {
            _randomizer = new Random();
            CurrentDifficultyLevel = difficultyLevel;
            DefineSuccessZone();
        }

        public bool IsSuccess(double angle)
        {
            return LowerBorder <= angle && angle <= UpperBorder;
        }

        public void DefineSuccessZone()
        {
            var randomValue = _randomizer.NextDouble();
            var successAngle = WorkZone.WorkZoneAngle * randomValue - WorkZone.GetHalfAngle();
            var deviation = DeviationProvider.GetDeviation(CurrentDifficultyLevel);
            LowerBorder = successAngle - deviation;
            UpperBorder = successAngle + deviation;
        }
    }
}