namespace TowerDefence
{
    // TODO: consider replacing with event handlers
    public interface IGameUI
    {
        void ShowMessage(string text);
        void DrawTower(Tower tower);
        GameEngine.TowerType SelectTowerType(int column, int row, GameEngine gameEngine);
        void EnemyCreated(Enemy enemy);
        void PerformFights();
        void GameEnded();
        void EnemyUpdated(Enemy enemy, int enemyIndex);
    }
}