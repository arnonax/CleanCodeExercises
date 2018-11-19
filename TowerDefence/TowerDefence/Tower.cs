using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
     class Tower
    {
        public int c { get; set; }
        public int n { get; set; }
        public string nm { get; set; }
        public double FightingRadius { get; set; }
        public BoardLocation Location { get; set; }
        public int t { get; set; }
        public int Strength { get; set; }
        public string i = "T";
        public int a { get; set; }
        public int ma { get; set; }

        public void Initialize(int pc, int pn, string pnm, int pd,double pr, int pa, BoardLocation pl)
        {
            c = pc;
            n = pn;
            nm = pnm;
            Strength = pd;
            FightingRadius = pr;
            Location = pl;
            ma = pa;
            a = ma;
            i = nm[0].ToString();
        }

        public bool IsInRange(Enemy enemy)
        {
            double x = (Location.x - enemy.Location.x) * (Location.x - enemy.Location.x);
            double y = (Location.y - enemy.Location.y) * (Location.y - enemy.Location.y);
            double distance = Math.Sqrt(x + y);
            if (distance > FightingRadius)
            {
                return false;
            }
            return true;
        }

        public void Fight(Enemy enemy)
        {
            if (IsInRange(enemy) && a > 0)
            {
                enemy.Power = enemy.Power - Strength;
            }
        }
    }
}
