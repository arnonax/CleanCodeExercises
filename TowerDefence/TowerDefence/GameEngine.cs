using System.Collections.Generic;
using System.Windows;

namespace TowerDefence
{
    public class GameEngine
    {
        // TODO: extract an interface from MainWindow and use it to remove coupling
        private MainWindow _ui;
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
                PopupWindow popupWindow = new PopupWindow(Gold, column, row);
                popupWindow.ShowDialog();
                var towerType = popupWindow.TowerType;
                //tower selection
                if (towerType == TowerType.None)
                    return;

                var factory = MainWindow.GetTowerFactory(towerType);
                _ui.CreateTower(column, row, factory);
            }
            else
            {
                MessageBox.Show("You cannot build more towers!");
            }
        }
    }
}