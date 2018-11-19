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
        public double r { get; set; }
        public BoardLocation l { get; set; }
        public int t { get; set; }
        public int d { get; set; }
        public string i = "T";
        public int a { get; set; }
        public int ma { get; set; }

        public void Initialize(int pc, int pn, string pnm, int pd,double pr, int pa, BoardLocation pl)
        {
            c = pc;
            n = pn;
            nm = pnm;
            d = pd;
            r = pr;
            l = pl;
            ma = pa;
            a = ma;
            i = nm[0].ToString();
        }
        public bool ir(Enemy pe)
        {
                double x = (l.x - pe.Location.x) * (l.x - pe.Location.x);
                double y = (l.y - pe.Location.y) * (l.y - pe.Location.y);
                double cl = Math.Sqrt(x + y);
                if (cl > r)
                {
                    return false;
                }
                else return true;

        }
        public void f(Enemy pe)
        {
            if (ir(pe) && a > 0)
            {
                pe.h = pe.h - d;
            }
        }
    }
}
