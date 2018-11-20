namespace TowerDefence
{
    internal class SimpleTower : Tower
    {
        public SimpleTower(int column, int row)
            : base("Tower", 10, 3.6, 2, new BoardLocation(column, row))
        {
        }
    }
}