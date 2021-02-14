namespace LockpickingMinigame.GameLogic
{
    public class Player
    {
        public double PicklocksQuantity { get; private set; }

        public Player(double picklocksQuantity)
        {
            PicklocksQuantity = picklocksQuantity < 0 ? 0 : picklocksQuantity;
        }
        
        public void AddPicklocks(double number)
        {
            if (number < 0)
                return;
            
            PicklocksQuantity += number;
        }

        public void RemoveOnePicklock()
        {
            if (!HasPicklocks())
                return;

            PicklocksQuantity--;
        }

        public bool HasPicklocks()
        {
            return PicklocksQuantity > 0;
        }
        
        public PickingProcess StartPicking(Lock @lock)
        {
            return new PickingProcess(this, @lock);
        }
    }
}