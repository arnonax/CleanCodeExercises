using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    abstract class ClsBt
    {
        public int s{ get; set; }
        public int d{ get; set; }
        public int r{ get; set; }
        public int rn{ get; set; }
        public string t{ get; set; }
        public virtual void B(int ps, int pd, int pr, int prn,string pt)
        {
            s = ps;
            d = pd;
            r = pr;
            rn = prn;
            t = pt;
        }
    }
}
