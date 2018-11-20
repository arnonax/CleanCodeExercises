namespace TowerDefence
{
    internal class Sniper : Tower
    {
        public class Factory : ITowerFactory
        {
            public int Price
            {
                get { return 60; }
            }

            public Tower CreateTower(int column, int row)
            {
                return new Sniper(column, row);
            }
        }

        private Sniper(int column, int row)
            : base("Sniper", 20, 9.4, 1, new BoardLocation(column, row))
        {
        }
    }
}