namespace TowerDefence
{
    internal class Reapeter : Tower
    {
        public class Factory : ITowerFactory
        {
            public int Price
            {
                get { return 35; }
            }

            public Tower CreateTower(int column, int row)
            {
                return new Reapeter(column, row);
            }
        }

        private Reapeter(int column, int row)
            : base("Reapeter", 5, 3, 7, new BoardLocation(column, row))
            {
        }
    }
}