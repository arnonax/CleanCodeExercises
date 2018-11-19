using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class Route
    {
       public BoardLocation [] locations = new BoardLocation[30];
       public BoardLocation EndLocation = new BoardLocation(0,0);
       public Route()
       {
          locations[0] = new BoardLocation(0,0);
          locations[1] = new BoardLocation(1,0);
          locations[2] = new BoardLocation(1, 1);
          locations[3] = new BoardLocation(1,2);
          locations[4] = new BoardLocation(2, 2);
          locations[5] = new BoardLocation(3,2);
          locations[6] = new BoardLocation(4,2);
          locations[7] = new BoardLocation(5,2);
          locations[8] = new BoardLocation(6,2);
          locations[9] = new BoardLocation(7,2);
          locations[10] = new BoardLocation(7,3);
          locations[11] = new BoardLocation(7,4);
          locations[12] = new BoardLocation(7,5);
          locations[13] = new BoardLocation(6,5);
          locations[14] = new BoardLocation(5,5);
          locations[15] = new BoardLocation(4,5);
          locations[16] = new BoardLocation(4,6);
          locations[17] = new BoardLocation(4,7);
          locations[18] = new BoardLocation(4,8);
          locations[19] = new BoardLocation(5,8);
          locations[20] = new BoardLocation(6,8);
          locations[21] = new BoardLocation(7,8);
          locations[22] = new BoardLocation(8,8);
          locations[23] = new BoardLocation(9,8);
          locations[24] = new BoardLocation(9,9);
          locations[25] = new BoardLocation(10,9);
          locations[26] = new BoardLocation(11,9);
          locations[27] = new BoardLocation(12,9);
          locations[28] = new BoardLocation(13,9);
          locations[29] = new BoardLocation(14,9);
          EndLocation = locations[29];


       }

    }

}
