using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class Enemy
    {

        public int s { get; set; }
        public int mh { get; set; }
        public int h { get; set; }
        public int sr { get; set; }
        public ClsP l {get; set; }
        public int t { get; set; }
        public int v { get; set; }
        public int lv { get; set; }
        public Enemy(int ps, int ph)
        {
            s = ps;
            mh = ph;
            h = mh;
            t = 0;
            l = new ClsP(0, 0);
            v = 1;
            lv = 1;
        }
        public void M(cls_r w, out int g) 
        {
            g = 0;
            if (h > 0)
            {

                for (int i = 0; i < s; i++)
                {
                    t++;
                    if (t >= w.r.Length)
                    {
                        break;
                    }
                    l = w.r[t];
                }
            }
            else
            {
                l = w.r[0];
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
