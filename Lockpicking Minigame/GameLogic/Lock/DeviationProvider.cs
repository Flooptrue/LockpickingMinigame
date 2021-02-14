using System.Collections.Generic;

namespace LockpickingMinigame
{
    public static class DeviationProvider
    {
        public static readonly IReadOnlyDictionary<DifficultyLevel, double> _deviations;

        static DeviationProvider()
        {
            _deviations = new Dictionary<DifficultyLevel, double>
            {
                {DifficultyLevel.Easy, 10},
                {DifficultyLevel.Normal, 7},
                {DifficultyLevel.Hard, 4},
                {DifficultyLevel.Nightmare, 1},
            };
        }

        public static double GetDeviation(DifficultyLevel difficultyLevel)
        {
            return _deviations[difficultyLevel];
        }
    }
}