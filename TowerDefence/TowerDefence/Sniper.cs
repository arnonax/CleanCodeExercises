namespace TowerDefence
{
    internal class Sniper : Tower
    {
        public Sniper(int column, int row) 
            : base("Sniper", 20, 9.4, 1, new BoardLocation(column, row))
            {
        }
    }
}