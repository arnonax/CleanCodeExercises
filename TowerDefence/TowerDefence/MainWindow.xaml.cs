﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace TowerDefence
{
    /// <Summary>
    /// 1) Tower and enemy creation
    /// 2) Board and Route creation
    /// 3) Timer Ticking
    /// 4) On-click tower creation
    /// 5) Endgame
    /// 6) Going from textbaxed to pictuers
    /// 7) Enemy Level up!
    /// 8) Getting the Enemy pictures up
    /// 9) Setting the Image source to Relative
    /// </summary>
    public partial class MainWindow
    {
        private const int MaxEnemies = 10;
        private const int MaxTowers = 12;
        private const int NumberOfColumns = 15;
        private int _numberOfTowers;
        private const int NumberOfRows = 12;
        private int _numberOfEnemies;
        private int _gold = 50;
        private int _goldEarnedInRound;
        private int _towerType;
        private int _killsCount;

        private readonly Enemy[] _enemies = new Enemy[MaxEnemies];
        private readonly TextBlock[] _enemyTextBlocks = new TextBlock[MaxEnemies];
        private readonly Image[] _enemyImages = new Image[MaxEnemies];
        private readonly Tower[] _towers = new Tower[MaxTowers];

        private readonly Route _route = new Route();

        private DispatcherTimer _gameTimer;
        

        public MainWindow()
        {
            InitializeComponent();

            Board.MouseDown += Board_MouseDown;

            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i] = new Enemy(15);
            }

            for (int i = 0; i < _towers.Length; i++)
            {
                _towers[i] = new Tower();
                _towers[i].Initialize("Tower1",5, 2,1, new BoardLocation(14,14));
            }

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // create board
            for (int i = 0; i < NumberOfColumns; i++)
            {
                var columnDefinition = new ColumnDefinition();
                Board.ColumnDefinitions.Add(columnDefinition);
            }

            for (int i = 0; i < NumberOfRows; i++)
            {
                var rowDefinition = new RowDefinition();
                Board.RowDefinitions.Add(rowDefinition);
            }
 
            // Draw Grass
            for (int i = 0; i < NumberOfColumns; i++)
            {
                for (int j = 0; j < NumberOfRows; j++)
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
            for (int i = 0; i < _route.Locations.Length; i++)
            {
                var location = _route.Locations[i];
                Image routeImage = new Image();
                routeImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Background\\Route.png", UriKind.Absolute));
                
                Grid.SetRow(routeImage, location.Y);
                Grid.SetColumn(routeImage, location.X);
                Board.Children.Add(routeImage);
                if (i == _route.Locations.Length - 1)
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
            if (_numberOfTowers < MaxTowers)
            {
                PopupWindow popupWindow = new PopupWindow(_gold, column, row);
                popupWindow.ShowDialog();
                _towerType = popupWindow.TowerType;
                //tower selection
                switch (_towerType)
                {
                    //SimpleTower
                    case 1:
                        if (_gold >= 20)
                        {
                            CreateSimpleTower(column, row);
                        }
                        else { MessageBox.Show("You don't have enough gold for that!, you need 20 and you only have " + _gold); }

                        break;
                    //Reapeter
                    case 2:
                        {

                            if (_gold >= 35)
                            {
                                CreateReapeter(column, row);
                            }
                            else { MessageBox.Show("You don't have enough gold for that!, you need 35 and you only have " + _gold); }
                        }
                        break;
                    //Sniper
                    case 3:
                        if (_towerType == 3)
                        {

                            if (_gold >= 60)
                            {
                                CreateSniper(column, row);
                            }
                            else { MessageBox.Show("You don't have enough gold for that!, you need 60 and you only have " + _gold); }
                        }
                        break;
                }

            }
            else
            {
                MessageBox.Show("You cannot build more towers!");
            }
            _gameTimer.Start();
        }

        // TODO: remove duplication between CreateSniper, CreateReapeter and CreateSimpleSniper
        private void DrawTower(Tower tower)
        {
//Tower Picture
            Image towerImage = new Image();
            towerImage.Source =
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Towers\\" + tower.ImageFilename + ".png",
                    UriKind.Absolute));
            Grid.SetRow(towerImage, tower.Location.Y);
            Grid.SetColumn(towerImage, tower.Location.X);
            Board.Children.Add(towerImage);
        }

        private void CreateSniper(int column, int row)
        {
            var tower = _towers[_numberOfTowers];
            tower.Initialize("Sniper", 20, 9.4, 1, new BoardLocation(column, row));

            DrawTower(tower);
            _gold = (_gold - 60);
            _numberOfTowers++;
            MessageBox.Show(
                "You have " + _gold + " gold left and you can build " + (MaxTowers - _numberOfTowers) + " more towers");
        }

        private void CreateReapeter(int column, int row)
        {
            var tower = _towers[_numberOfTowers];
            tower.Initialize("Reapeter", 5, 3, 7, new BoardLocation(column, row));

            DrawTower(tower);
            _numberOfTowers++;
            _gold = (_gold - 35);
            MessageBox.Show(
                "You have " + _gold + " gold left and you can build " + (MaxTowers - _numberOfTowers) + " more towers");
        }

        private void CreateSimpleTower(int column, int row)
        {
            var tower = _towers[_numberOfTowers];
            tower.Initialize("Tower", 10, 3.6, 2, new BoardLocation(column, row));

            DrawTower(tower);
            _gold = (_gold - 20);
            _numberOfTowers++;
            MessageBox.Show(
                "You have " + _gold + " gold left and you can build " + (MaxTowers - _numberOfTowers) + " more towers");
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
            if (_numberOfEnemies < MaxEnemies)
            {
                //Making Enemies
                var enemy = _enemies[_numberOfEnemies];
                var enemyLocation = enemy.Location;
                //enemy HP
                var enemyTextBlock = CreateEnemyTextBlock(enemy, enemyLocation);
                _enemyTextBlocks[_numberOfEnemies] = enemyTextBlock;

                //enemy Picture
                var enemyImage = CreateEnemyImage(enemyLocation);
                Board.Children.Add(enemyImage);
              
                _numberOfEnemies++;

                //Fire!!
                foreach (var tower in _towers)
                {
                    for (int j = 0; j < tower.FightsPerRound; j++)
                    {
                        var enemyToFightWith = FindEnemyToFightWith(tower);
                        tower.Fight(enemyToFightWith);
                    }
                }

                //Enemies movement and changing picture by level of power
                for (int i = 0; i < _numberOfEnemies; i++)
                {
                    enemy = _enemies[i];
                    if (enemy.Power <= 0) { _killsCount++; }
                    enemy.ProgressOrReset(_route, out _goldEarnedInRound);
                    // Enemies Picture change by Power level
                    var updatedEnemyImage = _enemyImages[i];
                    updatedEnemyImage.Source = GetEnemyImage(enemy);


                    enemyTextBlock = _enemyTextBlocks[i];
                    enemyImage = updatedEnemyImage;
                    _gold += _goldEarnedInRound;
                    _goldEarnedInRound = 0;

                    UpdateEnemyLocation(enemy, enemyImage, enemyTextBlock);
                }
            }
            // called every timer interval after the enemies creation

            else
            {
                //Fire!!
                foreach (var tower in _towers)
                {
                    for (int j = 0; j < tower.FightsPerRound; j++)
                    {
                        var enemy = FindEnemyToFightWith(tower);
                        tower.Fight(enemy);
                    }
                }

                // Enemies movement and changing picture by level of power
                for (int i = 0; i < _enemies.Length; i++)
                {

                    var enemy = _enemies[i];
                    if (enemy.Power <= 0) { _killsCount++; }
                    enemy.ProgressOrReset(_route, out _goldEarnedInRound);
                    _gold += _goldEarnedInRound;
                    _goldEarnedInRound = 0;
                    if (enemy.Location == _route.EndLocation)
                    {
                        MessageBox.Show("you lose! but killed "+ _killsCount);
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

        private Image CreateEnemyImage(BoardLocation enemyLocation)
        {
            Image enemyImage = new Image();
            enemyImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\1.png",
                UriKind.Absolute));
            _enemyImages[_numberOfEnemies] = enemyImage;
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