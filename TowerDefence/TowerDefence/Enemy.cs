namespace TowerDefence
{
    public class Enemy
    {
        public int InitialPower { get; set; }
        public int Power { get; set; }
        public BoardLocation Location {get; set; }
        public int ProgressInRoute { get; set; }
        public int Value { get; set; }

        public Enemy(int power)
        {
            InitialPower = power;
            Power = InitialPower;
            ProgressInRoute = 0;
            Location = new BoardLocation(0, 0);
            Value = 1;
        }
        public void ProgressOrReset(Route route, out int goldEarned) 
        {
            goldEarned = 0;
            if (Power > 0)
            {
                ProgressInRoute++;
                if (ProgressInRoute < route.Locations.Length)
                    Location = route.Locations[ProgressInRoute];
            }
            else
            {
                Location = route.Locations[0];
                InitialPower = (int)(InitialPower * 1.25);
                Power = InitialPower;
                ProgressInRoute = 0;
                goldEarned = Value;
                Value++;
            }
        }
    }
}
