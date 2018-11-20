namespace TowerDefence
{
    public interface IGameUI
    {
        void ShowMessage(string text);
        void DrawTower(Tower tower);
        GameEngine.TowerType SelectTowerType(int column, int row, GameEngine gameEngine);
    }
}