namespace TowerDefence
{
    public interface ITowerFactory
    {
        int Price { get; }
        Tower CreateTower(int column, int row);
    }
}