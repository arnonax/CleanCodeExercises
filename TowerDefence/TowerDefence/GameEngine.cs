using System.Collections.Generic;

namespace TowerDefence
{
    public class GameEngine
    {
        private readonly IGameUI _ui;
        private int _numberOfTowers;
        public const int MaxEnemies = 10;
        public const int MaxTowers = 12;
        public const int NumberOfColumns = 15;
        public const int NumberOfRows = 12;

        public GameEngine(IGameUI ui)
        {
            _ui = ui;
            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i] = new Enemy();
            }
        }

        public enum TowerType
        {
            None,
            SimpleTower,
            Reapeter,
            Sniper
        }

        public int NumberOfEnemies { get; set; }

        public int Gold { get; set; } = 50;

        public int KillsCount { get; set; }

        public Enemy[] Enemies { get; } = new Enemy[MaxEnemies];

        public List<Tower> Towers { get; } = new List<Tower>();

        public Route Route { get; } = new Route();

        public void UserClickedOnCell(int column, int row)
        {
            if (_numberOfTowers < MaxTowers)
            {
                var towerType = _ui.SelectTowerType(column, row, this);
                //tower selection
                if (towerType == TowerType.None)
                    return;

                var factory = GetTowerFactory(towerType);
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
                _numberOfTowers++;
                Towers.Add(tower);
                _ui.ShowMessage("You have " + Gold + " gold left and you can build " + (MaxTowers - _numberOfTowers) + " more towers");
            }
            else
            {
                _ui.ShowMessage("You don't have enough gold for that!, you need 20 and you only have " + Gold);
            }
        }

        private static ITowerFactory GetTowerFactory(TowerType towerType)
        {
            ITowerFactory factory = null;
            switch (towerType)
            {
                //SimpleTower
                case TowerType.SimpleTower:
                    factory = new SimpleTower.Factory();
                    break;

                case TowerType.Reapeter:
                    factory = new Reapeter.Factory();
                    break;

                case TowerType.Sniper:
                    factory = new Sniper.Factory();
                    break;
            }
            return factory;
        }

        public void PlayRound()
        {
//first intervals- for craeting the enemies
            if (NumberOfEnemies < MaxEnemies)
            {
                //Making Enemies
                var enemy = Enemies[NumberOfEnemies];
                _ui.EnemyCreated(enemy);

                NumberOfEnemies++;
            }
            _ui.PerformFights();

            //Enemies movement and changing picture by level of power
            for (int i = 0; i < NumberOfEnemies; i++)
            {
                var enemy = Enemies[i];
                if (enemy.Power <= 0)
                {
                    KillsCount++;
                }
                enemy.ProgressOrReset(Route, out int goldEarnedInRound);
                Gold = Gold + goldEarnedInRound;
                if (enemy.Location == Route.EndLocation)
                {
                    _ui.ShowMessage("you lose! but killed " + KillsCount);
                    _ui.GameEnded();
                    break;
                }
                // Enemies Picture change by Power level
                _ui.EnemyUpdated(enemy, i);
            }
        }
    }
}