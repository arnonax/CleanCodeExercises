using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class route
    {
       public point [] myRoute = new point[30];
       public point endZone = new point(0,0);
       public route()
       {
          myRoute[0] = new point(0,0);
          myRoute[1] = new point(1,0);
          myRoute[2] = new point(1, 1);
          myRoute[3] = new point(1,2);
          myRoute[4] = new point(2, 2);
          myRoute[5] = new point(3,2);
          myRoute[6] = new point(4,2);
          myRoute[7] = new point(5,2);
          myRoute[8] = new point(6,2);
          myRoute[9] = new point(7,2);
          myRoute[10] = new point(7,3);
          myRoute[11] = new point(7,4);
          myRoute[12] = new point(7,5);
          myRoute[13] = new point(6,5);
          myRoute[14] = new point(5,5);
          myRoute[15] = new point(4,5);
          myRoute[16] = new point(4,6);
          myRoute[17] = new point(4,7);
          myRoute[18] = new point(4,8);
          myRoute[19] = new point(5,8);
          myRoute[20] = new point(6,8);
          myRoute[21] = new point(7,8);
          myRoute[22] = new point(8,8);
          myRoute[23] = new point(9,8);
          myRoute[24] = new point(9,9);
          myRoute[25] = new point(10,9);
          myRoute[26] = new point(11,9);
          myRoute[27] = new point(12,9);
          myRoute[28] = new point(13,9);
          myRoute[29] = new point(14,9);
          endZone = myRoute[29];


       }

    }

}
