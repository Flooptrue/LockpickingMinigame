namespace LockpickingMinigame
{
    public class Picklock
    {
        private double _tiltAngle;
        
        public double TiltAngle
        {
            get => _tiltAngle;
            set
            {
                if (value < -WorkZone.GetHalfAngle())
                    _tiltAngle = -WorkZone.GetHalfAngle();
                else if (value > WorkZone.GetHalfAngle())
                    _tiltAngle = WorkZone.GetHalfAngle();
                else
                    _tiltAngle = value;    
            }
        }
        public bool IsBroken { get; set; }
    }
}