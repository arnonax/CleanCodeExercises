namespace TowerDefence
{
    class BoardLocation
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public BoardLocation(int px, int py)
        {
            X = px;
            Y = py;
        }
        public void Set(int px, int py)
        {
            X = px;
            Y = py;
        }
    }
}
