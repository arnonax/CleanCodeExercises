namespace TowerDefence
{
    internal class SimpleTower : Tower
    {
        public class Factory : ITowerFactory
        {
            public int Price
            {
                get { return 20; }
            }

            public Tower CreateTower(int column, int row)
            {
                return new SimpleTower(column, row);
            }
        }

        private SimpleTower(int column, int row)
            : base("Tower", 10, 3.6, 2, new BoardLocation(column, row))
        {
        }
    }
}