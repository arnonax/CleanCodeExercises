using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
     class Tower
    {
        public int cost { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public double range { get; set; }
        public point location { get; set; }
        public int target { get; set; }
        public int damage { get; set; }
        public string image = "T";
        public int ammo { get; set; }
        public int maxAmmo { get; set; }

        public void Build(int pcost, int pnumber, string pname, int pdamage,double prange, int pammo, point plocation)
        {
            cost = pcost;
            number = pnumber;
            name = pname;
            damage = pdamage;
            range = prange;
            location = plocation;
            maxAmmo = pammo;
            ammo = maxAmmo;
            image = name[0].ToString();
        }
        public bool inrange(Enemy penemy)
        {
                double x = (location.x - penemy.location.x) * (location.x - penemy.location.x);
                double y = (location.y - penemy.location.y) * (location.y - penemy.location.y);
                double calc = Math.Sqrt(x + y);
                if (calc > range)
                {
                    return false;
                }
                else return true;

        }
        public void fire(Enemy penemy)
        {
            if (inrange(penemy) && ammo > 0)
            {
                penemy.health = penemy.health - damage;
            }
        }
    }
}
