namespace TowerDefence
{
    class BoardLocation
    {
        public int x { get; set; }
        public int y { get; set; }
        public BoardLocation(int px, int py)
        {
            x = px;
            y = py;
        }
        public void set(int px, int py)
        {
            x = px;
            y = py;
        }
    }
}
