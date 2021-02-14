namespace Lockpicking_Minigame
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