using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class Enemy
    {
        public int InitialPower { get; set; }
        public int Power { get; set; }
        public BoardLocation Location {get; set; }
        public int ProgressInRoute { get; set; }
        public int Value { get; set; }
        public int Level { get; set; } // TODO: remove this property and use Value instead as they always have the same value
        public Enemy(int power)
        {
            InitialPower = power;
            Power = InitialPower;
            ProgressInRoute = 0;
            Location = new BoardLocation(0, 0);
            Value = 1;
            Level = 1;
        }
        public void M(Route route, out int goldEarned) 
        {
            goldEarned = 0;
            if (Power > 0)
            {
                ProgressInRoute++;
                if (ProgressInRoute < route.locations.Length)
                    Location = route.locations[ProgressInRoute];
            }
            else
            {
                Location = route.locations[0];
                InitialPower = (int)(InitialPower * 1.25);
                Power = InitialPower;
                ProgressInRoute = 0;
                goldEarned = Value;
                Value++;
                Level++;

            }

        }
    }
}
