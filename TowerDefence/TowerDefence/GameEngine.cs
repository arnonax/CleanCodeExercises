using System.Collections.Generic;

namespace TowerDefence
{
    public class GameEngine
    {
        private readonly IGameUI _ui;
        private int _numberOfTowers;
        private readonly Enemy[] _enemies = new Enemy[MaxEnemies];
        private readonly List<Tower> _towers = new List<Tower>();
        public const int MaxEnemies = 10;
        public const int NumberOfColumns = 15;
        public const int NumberOfRows = 12;

        private readonly Parameters _params;

        public class Messages
        {
            public const string YouCannotBuildMoreTowers = "You cannot build more towers!";
        }

        public GameEngine(IGameUI ui)
            : this(ui, new Parameters())
        {
        }

        public GameEngine(IGameUI ui, Parameters parameters)
        {
            _ui = ui;
            _params = parameters.Clone();
            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i] = new Enemy();
            }
        }

        public enum TowerType
        {
            None,
            SimpleTower,
            Reapeter,
            Sniper
        }

        public int NumberOfEnemies { get; private set; }

        public int Gold { get; private set; } = 50;

        public int KillsCount { get; private set; }

        public IReadOnlyCollection<Enemy> Enemies
        {
            get { return _enemies; }
        }

        public IReadOnlyCollection<Tower> Towers
        {
            get { return _towers; }
        }

        public Route Route { get; } = new Route();

        public int MaxTowers
        {
            get { return _params.MaxTowers; }
        }

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
                _ui.ShowMessage(Messages.YouCannotBuildMoreTowers);
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
                _towers.Add(tower);
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
                var enemy = _enemies[NumberOfEnemies];
                _ui.EnemyCreated(enemy);

                NumberOfEnemies++;
            }
            PerformFights();

            //Enemies movement and changing picture by level of power
            for (int i = 0; i < NumberOfEnemies; i++)
            {
                var enemy = _enemies[i];
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

        private void PerformFights()
        {
            foreach (var tower in Towers)
            {
                for (int j = 0; j < tower.FightsPerRound; j++)
                {
                    var enemyToFightWith = FindEnemyToFightWith(tower);
                    tower.Fight(enemyToFightWith);
                }
            }
        }

        private Enemy FindEnemyToFightWith(Tower tower)
        {
            var enemyToFightWith = _enemies[0];
            for (int i = 1; i < _enemies.Length; i++)
            {
                var enemy = _enemies[i];
                if (enemy.ProgressInRoute > enemyToFightWith.ProgressInRoute && tower.IsInRange(enemy))
                {
                    enemyToFightWith = enemy;
                }
                else if (tower.IsInRange(enemyToFightWith) == false && tower.IsInRange(enemy))
                {
                    enemyToFightWith = enemy;
                }
            }
            return enemyToFightWith;
        }

        public class Parameters
        {
            public Parameters Clone()
            {
                return (Parameters) MemberwiseClone();
            }

            public int MaxTowers = 12;
        }
    }
}