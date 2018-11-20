using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace TowerDefence
{
    public partial class MainWindow
    {
        private readonly TextBlock[] _enemyTextBlocks = new TextBlock[GameEngine.MaxEnemies];
        private readonly Image[] _enemyImages = new Image[GameEngine.MaxEnemies];

        private DispatcherTimer _gameTimer;

        private readonly GameEngine _game = new GameEngine();

        public MainWindow()
        {
            InitializeComponent();

            Board.MouseDown += Board_MouseDown;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // create board
            for (int i = 0; i < GameEngine.NumberOfColumns; i++)
            {
                var columnDefinition = new ColumnDefinition();
                Board.ColumnDefinitions.Add(columnDefinition);
            }

            for (int i = 0; i < GameEngine.NumberOfRows; i++)
            {
                var rowDefinition = new RowDefinition();
                Board.RowDefinitions.Add(rowDefinition);
            }
 
            // Draw Grass
            for (int i = 0; i < GameEngine.NumberOfColumns; i++)
            {
                for (int j = 0; j < GameEngine.NumberOfRows; j++)
                {
                    Image grassImage = new Image();
                    grassImage.Source =
                        new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Background\\Grass.png",
                            UriKind.RelativeOrAbsolute));
                    Board.ShowGridLines = false;

                    Grid.SetRow(grassImage, j);
                    Grid.SetColumn(grassImage, i);
                    Board.Children.Add(grassImage);
                }
            }
            // draw route
            for (int i = 0; i < _game.Route.Locations.Length; i++)
            {
                var location = _game.Route.Locations[i];
                Image routeImage = new Image();
                routeImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Background\\Route.png", UriKind.Absolute));
                
                Grid.SetRow(routeImage, location.Y);
                Grid.SetColumn(routeImage, location.X);
                Board.Children.Add(routeImage);
                if (i == _game.Route.Locations.Length - 1)
                {
                    Image te = new Image();
                    te.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Background\\Home.png", UriKind.Absolute));

                    Grid.SetRow(te, location.Y);
                    Grid.SetColumn(te, location.X);
                    Board.Children.Add(te);
                }
            }
            // create timer
            _gameTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, GameTimer_Tick, Dispatcher); // TODO: pace the game!
            _gameTimer.Start();
    }

        private void Board_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _gameTimer.Stop();
            var clickedPoint = Mouse.GetPosition(Board);

            int column = 0;

            // calc row mouse was over
            var row = GetRowAndColumnFromMousePoint(clickedPoint, ref column);
            //Tower selection popup manu
            if (_game.NumberOfTowers < GameEngine.MaxTowers)
            {
                PopupWindow popupWindow = new PopupWindow(_game.Gold, column, row);
                popupWindow.ShowDialog();
                var towerType = popupWindow.TowerType;
                //tower selection
                var factory = GetTowerFactory(towerType);

                CreateTower(column, row, factory);
            }
            else
            {
                MessageBox.Show("You cannot build more towers!");
            }
            _gameTimer.Start();
        }

        private static ITowerFactory GetTowerFactory(GameEngine.TowerType towerType)
        {
            ITowerFactory factory = null;
            switch (towerType)
            {
                //SimpleTower
                case GameEngine.TowerType.SimpleTower:
                    factory = new SimpleTower.Factory();
                    break;

                case GameEngine.TowerType.Reapeter:
                    factory = new Reapeter.Factory();
                    break;

                case GameEngine.TowerType.Sniper:
                    factory = new Sniper.Factory();
                    break;
            }
            return factory;
        }

        private void CreateTower(int column, int row, ITowerFactory factory)
        {
            if (_game.Gold >= factory.Price)
            {
                var tower = factory.CreateTower(column, row);

                DrawTower(tower);
                _game.Gold = (_game.Gold - factory.Price);
                _game.NumberOfTowers++;
                _game.Towers.Add(tower);
                MessageBox.Show(
                    "You have " + _game.Gold + " gold left and you can build " + (GameEngine.MaxTowers - _game.NumberOfTowers) + " more towers");
            }
            else
            {
                MessageBox.Show("You don't have enough gold for that!, you need 20 and you only have " + _game.Gold);
            }
        }

        // TODO: remove duplication between CreateSniper, CreateReapeter and CreateSimpleSniper
        private void DrawTower(Tower tower)
        {
            Image towerImage = new Image();
            towerImage.Source =
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Towers\\" + tower.ImageFilename + ".png",
                    UriKind.Absolute));
            Grid.SetRow(towerImage, tower.Location.Y);
            Grid.SetColumn(towerImage, tower.Location.X);
            Board.Children.Add(towerImage);
        }

        private int GetRowAndColumnFromMousePoint(Point p, ref int column)
        {
            double y = 0.0;
            double x = 0.0;
            int row = 0;
            foreach (var rowDefinition in Board.RowDefinitions)
            {
                y += rowDefinition.ActualHeight;
                if (y >= p.Y)
                    break;
                row++;
            }
            // calc col mouse was over
            foreach (var columnDefinition in Board.ColumnDefinitions)
            {
                x += columnDefinition.ActualWidth;
                if (x >= p.X)
                    break;
                column++;
            }
            return row;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //first intervals- for craeting the enemies
            if (_game.NumberOfEnemies < GameEngine.MaxEnemies)
            {
                //Making Enemies
                var enemy = _game.Enemies[_game.NumberOfEnemies];
                var enemyLocation = enemy.Location;
                //enemy HP
                var enemyTextBlock = CreateEnemyTextBlock(enemy, enemyLocation);
                _enemyTextBlocks[_game.NumberOfEnemies] = enemyTextBlock;

                //enemy Picture
                var enemyImage = CreateEnemyImage(enemyLocation);
                Board.Children.Add(enemyImage);
              
                _game.NumberOfEnemies++;

                //Fire!!
                foreach (var tower in _game.Towers)
                {
                    for (int j = 0; j < tower.FightsPerRound; j++)
                    {
                        var enemyToFightWith = FindEnemyToFightWith(tower);
                        tower.Fight(enemyToFightWith);
                    }
                }

                //Enemies movement and changing picture by level of power
                for (int i = 0; i < _game.NumberOfEnemies; i++)
                {
                    enemy = _game.Enemies[i];
                    if (enemy.Power <= 0) { _game.KillsCount++; }
                    enemy.ProgressOrReset(_game.Route, out int goldEarnedInRound);
                    // Enemies Picture change by Power level
                    var updatedEnemyImage = _enemyImages[i];
                    updatedEnemyImage.Source = GetEnemyImage(enemy);


                    enemyTextBlock = _enemyTextBlocks[i];
                    enemyImage = updatedEnemyImage;
                    _game.Gold = _game.Gold + goldEarnedInRound;
                    
                    UpdateEnemyLocation(enemy, enemyImage, enemyTextBlock);
                }
            }
            // called every timer interval after the enemies creation

            else
            {
                //Fire!!
                foreach (var tower in _game.Towers)
                {
                    for (int j = 0; j < tower.FightsPerRound; j++)
                    {
                        var enemy = FindEnemyToFightWith(tower);
                        tower.Fight(enemy);
                    }
                }

                // Enemies movement and changing picture by level of power
                for (int i = 0; i < _game.Enemies.Length; i++)
                {

                    var enemy = _game.Enemies[i];
                    if (enemy.Power <= 0) { _game.KillsCount++; }
                    enemy.ProgressOrReset(_game.Route, out int goldEarnedInRound);
                    _game.Gold = _game.Gold + goldEarnedInRound;
                    if (enemy.Location == _game.Route.EndLocation)
                    {
                        MessageBox.Show("you lose! but killed "+ _game.KillsCount);
                        _gameTimer.Stop();
                        break;
                    }
                    // Enemies Picture change by Power level
                    _enemyImages[i].Source = GetEnemyImage(enemy);

                    var enemyTextBlock = _enemyTextBlocks[i];
                    var enemyImage = _enemyImages[i];


                    SetEnemyTextColor(enemy, enemyTextBlock);
                    UpdateEnemyLocation(enemy, enemyImage, enemyTextBlock);    
                }
            }
        }

        private static void SetEnemyTextColor(Enemy enemy, TextBlock enemyTextBlock)
        {
            enemyTextBlock.Foreground = (enemy.Power * 3) < enemy.InitialPower ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Black);
        }

        private static void UpdateEnemyLocation(Enemy enemy, Image enemyImage, TextBlock enemyTextBlock)
        {
            var enemyLocation = enemy.Location;


            Grid.SetRow(enemyImage, enemyLocation.Y);
            Grid.SetColumn(enemyImage, enemyLocation.X);

            Grid.SetRow(enemyTextBlock, enemyLocation.Y);
            Grid.SetColumn(enemyTextBlock, enemyLocation.X);
            enemyTextBlock.Text = enemy.Power.ToString();
        }

        private static ImageSource GetEnemyImage(Enemy enemy)
        {
            var imageLevels = new[]{3, 5, 7, 9, 12, 14, 16, 18, 20, 22};
            var i = 0;
            while (enemy.Value > imageLevels[i])
                i++;

            return new BitmapImage(new Uri(
                Environment.CurrentDirectory + $"\\Pictures\\Enemys\\{i+1}.png",
                UriKind.Absolute));
        }

        private Enemy FindEnemyToFightWith(Tower tower)
        {
            var enemyToFightWith = _game.Enemies[0];
            for (int i = 1; i < _game.Enemies.Length; i++)
            {
                var enemy = _game.Enemies[i];
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

        private Image CreateEnemyImage(BoardLocation enemyLocation)
        {
            Image enemyImage = new Image();
            enemyImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\1.png",
                UriKind.Absolute));
            _enemyImages[_game.NumberOfEnemies] = enemyImage;
            Grid.SetRow(enemyImage, enemyLocation.Y);
            Grid.SetColumn(enemyImage, enemyLocation.X);
            return enemyImage;
        }

        private TextBlock CreateEnemyTextBlock(Enemy enemy, BoardLocation enemyLocation)
        {
            TextBlock enemyTextBlock = new TextBlock();

            enemyTextBlock.FontSize = 20;
            enemyTextBlock.FontWeight = FontWeights.Bold;
            enemyTextBlock.Text = enemy.Power.ToString();


            Grid.SetRow(enemyTextBlock, enemyLocation.Y);
            Grid.SetColumn(enemyTextBlock, enemyLocation.X);
            Board.Children.Add(enemyTextBlock);
            return enemyTextBlock;
        }
    }
}