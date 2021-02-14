namespace LockpickingMinigame.GameLogic
{
    public static class WorkZone
    {
        public static double WorkZoneAngle { get; }

        static WorkZone()
        {
            WorkZoneAngle = 180;
        }
    
        public static double GetHalfAngle()
        {
            return WorkZoneAngle / 2;
        }
    }
}