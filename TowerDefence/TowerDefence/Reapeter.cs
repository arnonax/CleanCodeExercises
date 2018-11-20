namespace TowerDefence
{
    internal class Reapeter : Tower
    {
        public Reapeter(int column, int row)
            : base("Reapeter", 5, 3, 7, new BoardLocation(column, row))
            {
        }
    }
}