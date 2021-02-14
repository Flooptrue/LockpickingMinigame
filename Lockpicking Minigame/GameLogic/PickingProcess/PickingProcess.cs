namespace LockpickingMinigame.GameLogic
{
    public class PickingProcess
    {
        public Player Player { get; }
        public  Lock Lock { get; }
        public bool IsActive { get; private set; }
        public Picklock ActivePicklock { get; private set; }

        public PickingProcess(Player player, Lock lockInstance)
        {
            Player = player;
            Lock = lockInstance;
            IsActive = player.HasPicklocks();
            ActivePicklock = IsActive ? new Picklock() : null;
        }

        public void Pick()
        {
            if (!IsActive)
                return;

            if (Lock.Pick(ActivePicklock))
            {
                EndProcess();
                return;
            }

            if (!ActivePicklock.IsBroken) 
                return;
            
            Player.RemoveOnePicklock();
            
            if (Player.HasPicklocks())
                ActivePicklock = new Picklock();
            else
                EndProcess();
        }

        public void ChangePicklockAngle(double angle)
        {
            if (!IsActive)
                return;

            ActivePicklock.TiltAngle = angle;
        }

        private void EndProcess()
        {
            IsActive = false;
            ActivePicklock = null;
        }
    }
}