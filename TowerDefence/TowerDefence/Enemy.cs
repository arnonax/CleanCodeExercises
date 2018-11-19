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
        public int sr { get; set; }
        public BoardLocation Location {get; set; }
        public int ProgressInRoute { get; set; }
        public int v { get; set; }
        public int lv { get; set; }
        public Enemy(int power)
        {
            InitialPower = power;
            Power = InitialPower;
            ProgressInRoute = 0;
            Location = new BoardLocation(0, 0);
            v = 1;
            lv = 1;
        }
        public void M(Route route, out int g) 
        {
            g = 0;
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
                sr += 10;
                g = v;
                v++;
                lv++;

            }

        }
    }
}
