using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class cls_r
    {
       public ClsP [] r = new ClsP[30];
       public ClsP e = new ClsP(0,0);
       public cls_r()
       {
          r[0] = new ClsP(0,0);
          r[1] = new ClsP(1,0);
          r[2] = new ClsP(1, 1);
          r[3] = new ClsP(1,2);
          r[4] = new ClsP(2, 2);
          r[5] = new ClsP(3,2);
          r[6] = new ClsP(4,2);
          r[7] = new ClsP(5,2);
          r[8] = new ClsP(6,2);
          r[9] = new ClsP(7,2);
          r[10] = new ClsP(7,3);
          r[11] = new ClsP(7,4);
          r[12] = new ClsP(7,5);
          r[13] = new ClsP(6,5);
          r[14] = new ClsP(5,5);
          r[15] = new ClsP(4,5);
          r[16] = new ClsP(4,6);
          r[17] = new ClsP(4,7);
          r[18] = new ClsP(4,8);
          r[19] = new ClsP(5,8);
          r[20] = new ClsP(6,8);
          r[21] = new ClsP(7,8);
          r[22] = new ClsP(8,8);
          r[23] = new ClsP(9,8);
          r[24] = new ClsP(9,9);
          r[25] = new ClsP(10,9);
          r[26] = new ClsP(11,9);
          r[27] = new ClsP(12,9);
          r[28] = new ClsP(13,9);
          r[29] = new ClsP(14,9);
          e = r[29];


       }

    }

}
