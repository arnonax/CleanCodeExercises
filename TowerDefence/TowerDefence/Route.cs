namespace TowerDefence
{
    public class Route
    {
        // TODO: change to readonly indexer
        public BoardLocation[] Locations = new BoardLocation[30];

        public BoardLocation EndLocation;

        public Route()
        {
            Locations[0] = new BoardLocation(0, 0);
            Locations[1] = new BoardLocation(1, 0);
            Locations[2] = new BoardLocation(1, 1);
            Locations[3] = new BoardLocation(1, 2);
            Locations[4] = new BoardLocation(2, 2);
            Locations[5] = new BoardLocation(3, 2);
            Locations[6] = new BoardLocation(4, 2);
            Locations[7] = new BoardLocation(5, 2);
            Locations[8] = new BoardLocation(6, 2);
            Locations[9] = new BoardLocation(7, 2);
            Locations[10] = new BoardLocation(7, 3);
            Locations[11] = new BoardLocation(7, 4);
            Locations[12] = new BoardLocation(7, 5);
            Locations[13] = new BoardLocation(6, 5);
            Locations[14] = new BoardLocation(5, 5);
            Locations[15] = new BoardLocation(4, 5);
            Locations[16] = new BoardLocation(4, 6);
            Locations[17] = new BoardLocation(4, 7);
            Locations[18] = new BoardLocation(4, 8);
            Locations[19] = new BoardLocation(5, 8);
            Locations[20] = new BoardLocation(6, 8);
            Locations[21] = new BoardLocation(7, 8);
            Locations[22] = new BoardLocation(8, 8);
            Locations[23] = new BoardLocation(9, 8);
            Locations[24] = new BoardLocation(9, 9);
            Locations[25] = new BoardLocation(10, 9);
            Locations[26] = new BoardLocation(11, 9);
            Locations[27] = new BoardLocation(12, 9);
            Locations[28] = new BoardLocation(13, 9);
            Locations[29] = new BoardLocation(14, 9);
            EndLocation = Locations[29];
        }
    }
}