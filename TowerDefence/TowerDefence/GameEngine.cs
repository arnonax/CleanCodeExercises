using System.Collections.Generic;

namespace TowerDefence
{
    public class GameEngine
    {
        // TODO: extract an interface from MainWindow and use it to remove coupling
        private readonly MainWindow _ui;
        public const int MaxEnemies = 10;
        public const int MaxTowers = 12;
        public const int NumberOfColumns = 15;
        public const int NumberOfRows = 12;

        public GameEngine(MainWindow ui)
        {
            _ui = ui;
            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i] = new Enemy(15);
            }
        }

        public enum TowerType
        {
            None,
            SimpleTower,
            Reapeter,
            Sniper
        }

        public int NumberOfTowers { get; set; }

        public int NumberOfEnemies { get; set; }

        public int Gold { get; set; } = 50;

        public int KillsCount { get; set; }

        public Enemy[] Enemies { get; } = new Enemy[MaxEnemies];

        public List<Tower> Towers { get; } = new List<Tower>();

        public Route Route { get; } = new Route();

        public void UserClickedOnCell(int column, int row)
        {
            if (NumberOfTowers < MaxTowers)
            {
                var towerType = _ui.SelectTowerType(column, row, this);
                //tower selection
                if (towerType == TowerType.None)
                    return;

                var factory = MainWindow.GetTowerFactory(towerType);
                CreateTower(column, row, factory);
            }
            else
            {
                _ui.ShowMessage("You cannot build more towers!");
            }
        }

        private void CreateTower(int column, int row, ITowerFactory factory)
        {
            if (Gold >= factory.Price)
            {
                var tower = factory.CreateTower(column, row);

                _ui.DrawTower(tower);
                Gold = Gold - factory.Price;
                NumberOfTowers++;
                Towers.Add(tower);
                _ui.ShowMessage("You have " + Gold + " gold left and you can build " + (MaxTowers - NumberOfTowers) + " more towers");
            }
            else
            {
                _ui.ShowMessage("You don't have enough gold for that!, you need 20 and you only have " + Gold);
            }
        }
    }
}