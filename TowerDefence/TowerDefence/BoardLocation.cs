using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class BoardLocation
    {
        public int x { get; set; }
        public int y { get; set; }
        public BoardLocation(int px, int py)
        {
            x = px;
            y = py;
        }
        public void set(int px, int py)
        {
            x = px;
            y = py;
        }
    }
}
