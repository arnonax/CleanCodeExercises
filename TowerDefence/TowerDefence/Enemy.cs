using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class Enemy
    {
        public int mh { get; set; }
        public int h { get; set; }
        public int sr { get; set; }
        public BoardLocation Location {get; set; }
        public int t { get; set; }
        public int v { get; set; }
        public int lv { get; set; }
        public Enemy(int ph)
        {
            mh = ph;
            h = mh;
            t = 0;
            Location = new BoardLocation(0, 0);
            v = 1;
            lv = 1;
        }
        public void M(Route route, out int g) 
        {
            g = 0;
            if (h > 0)
            {
                t++;
                if (t < route.locations.Length)
                    Location = route.locations[t];
            }
            else
            {
                Location = route.locations[0];
                mh = (int)(mh * 1.25);
                h = mh;
                t = 0;
                sr += 10;
                g = v;
                v++;
                lv++;

            }

        }
    }
}
