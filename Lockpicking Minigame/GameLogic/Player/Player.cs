namespace LockpickingMinigame
{
    public class Player
    {
        public double PicklocksQuantity { get; private set; }
        
        public Player(double picklocksQuantity)
        {
            PicklocksQuantity = picklocksQuantity;
        }
        
        public void AddPicklocks(double number)
        {
            if (number < 0)
                return;
            
            PicklocksQuantity += number;
        }

        public void RemoveOnePicklock()
        {
            PicklocksQuantity--;
        }

        public PickingProcess StartPicking(Lock @lock)
        {
            return new PickingProcess(this, @lock);
        }
    }
}