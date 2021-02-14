using System.Collections.Generic;

namespace Lockpicking_Minigame
{
    public static class BreakageChanceProvider
    {
        public static readonly IReadOnlyDictionary<DifficultyLevel, double> _breakageChance;

        static BreakageChanceProvider()
        {
            _breakageChance = new Dictionary<DifficultyLevel, double>
            {
                {DifficultyLevel.Easy, 0.1},
                {DifficultyLevel.Normal, 0.3},
                {DifficultyLevel.Hard, 0.6},
                {DifficultyLevel.Nightmare, 0.8},
            };
        }

        public static double GetBreakageChance(DifficultyLevel difficultyLevel)
        {
            return _breakageChance[difficultyLevel];
        }
    }
}