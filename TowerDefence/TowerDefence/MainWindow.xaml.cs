using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace TowerDefence
{
    public partial class MainWindow : IGameUI
    {
        private readonly TextBlock[] _enemyTextBlocks = new TextBlock[GameEngine.MaxEnemies];
        private readonly Image[] _enemyImages = new Image[GameEngine.MaxEnemies];

        private DispatcherTimer _gameTimer;

        private readonly GameEngine _game;

        public MainWindow()
        {
            _game = new GameEngine(this);
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
                    const string grassImageFilename = "\\Pictures\\Background\\Grass.png";
                    DrawImageOnBoard(grassImageFilename, new BoardLocation(i, j));
                }
            }
            // draw route
            foreach (var location in _game.Route.Locations)
            {
                const string routeImageFilename = "\\Pictures\\Background\\Route.png";
                DrawImageOnBoard(routeImageFilename, location);
            }
            // draw home
            const string homeImageFilename = "\\Pictures\\Background\\Home.png";
            DrawImageOnBoard(homeImageFilename, _game.Route.EndLocation);

            // create timer
            _gameTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, GameTimer_Tick, Dispatcher); // TODO: pace the game!
            _gameTimer.Start();
    }

        private Image DrawImageOnBoard(string imageFilename, BoardLocation location)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + imageFilename, UriKind.Absolute));

            Grid.SetRow(image, location.Y);
            Grid.SetColumn(image, location.X);
            Board.Children.Add(image);

            return image;
        }

        private void Board_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _gameTimer.Stop();
            var clickedPoint = Mouse.GetPosition(Board);

            int column = 0;

            // calc row mouse was over
            var row = GetRowAndColumnFromMousePoint(clickedPoint, ref column);
            //Tower selection popup manu
            _game.UserClickedOnCell(column, row);
            _gameTimer.Start();
        }

        public void DrawTower(Tower tower)
        {
            DrawImageOnBoard("\\Pictures\\Towers\\" + tower.ImageFilename + ".png", tower.Location);
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
            _game.PlayRound();
        }

        // TODO: get rid of enemyIndex
        public void EnemyUpdated(Enemy enemy, int enemyIndex)
        {
            var updatedEnemyImage = _enemyImages[enemyIndex];
            updatedEnemyImage.Source = GetEnemyImage(enemy);

            var enemyTextBlock = _enemyTextBlocks[enemyIndex];
            var enemyImage = updatedEnemyImage;

            SetEnemyTextColor(enemy, enemyTextBlock);
            UpdateEnemyLocation(enemy, enemyImage, enemyTextBlock);
        }

        public void GameEnded()
        {
            _gameTimer.Stop();
        }

        public void EnemyCreated(Enemy enemy)
        {
            var enemyLocation = enemy.Location;
            //enemy HP
            var enemyTextBlock = CreateEnemyTextBlock(enemy, enemyLocation);
            _enemyTextBlocks[_game.NumberOfEnemies] = enemyTextBlock;

            //enemy Picture
            CreateEnemyImage(enemyLocation);
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

        private void CreateEnemyImage(BoardLocation enemyLocation)
        {
            var enemyImage = DrawImageOnBoard("\\Pictures\\Enemys\\1.png", enemyLocation);
            _enemyImages[_game.NumberOfEnemies] = enemyImage;
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

        public GameEngine.TowerType SelectTowerType(int column, int row, GameEngine gameEngine)
        {
            PopupWindow popupWindow = new PopupWindow(gameEngine.Gold, column, row);
            popupWindow.ShowDialog();
            var towerType = popupWindow.TowerType;
            return towerType;
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }
    }
}