using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    abstract class Bullet
    {
        public int speed{ get; set; }
        public int damege{ get; set; }
        public int rof{ get; set; }
        public int range{ get; set; }
        public string type{ get; set; }
        public virtual void bullet(int pspeed, int pdamage, int prof, int prange,string ptype)
        {
            speed = pspeed;
            damege = pdamage;
            rof = prof;
            range = prange;
            type = ptype;
        }
    }
}
