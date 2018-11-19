using System;
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
    public partial class MainWindow : Window
    {
        const int MaxEnemies = 10;
        const int MaxTowers = 12;
        const int NumberOfColumns = 15;
        public int numberOfTowers = 0;
        const int numberOfRows = 12;
        public int ch = 0;
        public int gold = 50;
        public int goldEarnedInRound = 0;
        public int towerType;
        public int killsCount = 0;

        Enemy[] enemies = new Enemy[MaxEnemies];
        TextBlock[] enemyTextBlocks = new TextBlock[MaxEnemies];
        Image[] enemyImages = new Image[MaxEnemies];
        Tower[] towers = new Tower[MaxTowers];
        Image[] towerImages = new Image[MaxTowers];

        cls_r r = new cls_r();

        DispatcherTimer _gameTimer;
        

        public MainWindow()
        {
            InitializeComponent();

            Board.MouseDown += Board_MouseDown;

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Enemy(1, 15);
                enemies[i].sr = i;
            }

            for (int i = 0; i < towers.Length; i++)
            {
                towers[i] = new Tower();
                towers[i].Initialize(0, i, "Tower1",5, 2,1, new ClsP(14,14));
            }

            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ClsP m = new ClsP(0, 0);
            ColumnDefinition columnDefinition;
            RowDefinition rowDefinition;

            // create board
            for (int i = 0; i < NumberOfColumns; i++)
            {
                columnDefinition = new ColumnDefinition();
                Board.ColumnDefinitions.Add(columnDefinition);
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                rowDefinition = new RowDefinition();
                Board.RowDefinitions.Add(rowDefinition);
            }
 
            // Draw Grass
            for (int i = 0; i < NumberOfColumns; i++)
			{
                for (int j = 0; j < numberOfRows; j++)
			{
                Image grassImage = new Image();
                grassImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory+"\\Pictures\\Background\\Grass.png",  UriKind.RelativeOrAbsolute));
                Board.ShowGridLines = false;

                Grid.SetRow(grassImage, j);
                Grid.SetColumn(grassImage, i);
                Board.Children.Add(grassImage);
                }
			}
            // draw route
            for (int i = 0; i < r.r.Length; i++)
            {
                m = r.r[i];
                Image w = new Image();
                w.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Background\\Route.png", UriKind.Absolute));
                
                Grid.SetRow(w, m.y);
                Grid.SetColumn(w, m.x);
                Board.Children.Add(w);
                if (i == (r.r.Length - 1))
                {
                    Image te = new Image();
                    te.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Background\\Home.png", UriKind.Absolute));

                    Grid.SetRow(te, m.y);
                    Grid.SetColumn(te, m.x);
                    Board.Children.Add(te);
                }
            }
            // create timer
            _gameTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, new EventHandler(GameTimer_Tick), Dispatcher); // TODO: pace the game!
            _gameTimer.Start();
    }

        private void Board_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _gameTimer.Stop();
            var p = Mouse.GetPosition(Board);

            int column = 0;
            double aw = 0.0;
            double ah = 0.0;
            int row = 0;

            // calc row mouse was over
            row = I(ah, p, row, aw, ref column);
            //Tower selection popup manu
            if (numberOfTowers < MaxTowers)
            {

                PopupWindow popupWindow = new PopupWindow(gold, column, row);
                popupWindow.ShowDialog();
                towerType = popupWindow.towerType;
            //tower selection
                switch (towerType)
                {
                    //SimpleTower
                    case 1:
                        if (gold >= 20)
                        {
                            var tower = towers[numberOfTowers];
                            tower.Initialize(0, numberOfTowers, "Tower", 10, 3.6, 2, new ClsP(column, row));

                            //Tower Picture
                            Image towerImage = new Image();
                            towerImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Towers\\" + tower.nm + ".png", UriKind.Absolute));
                            towerImages[ch] = towerImage;
                            Grid.SetRow(towerImage, tower.l.y);
                            Grid.SetColumn(towerImage, tower.l.x);
                            Board.Children.Add(towerImage);
                            gold = (gold - 20);
                            numberOfTowers++;
                            MessageBox.Show("You have " + gold + " gold left and you can build " + (MaxTowers - numberOfTowers) + " more towers");
                        }
                        else { MessageBox.Show("You don't have enough gold for that!, you need 20 and you only have " + gold); }

                        break;
                    //Reapeter
                    case 2:
                        {

                            if (gold >= 35)
                            {
                                var tw = towers[numberOfTowers];
                                ClsP pa = new ClsP(column, row);
                                tw.Initialize(0, numberOfTowers, "Reapeter", 5, 3, 7, new ClsP(column, row));

                                //Tower Picture
                                Image t = new Image();
                                t.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Towers\\" + tw.nm + ".png", UriKind.Absolute));
                                towerImages[ch] = t;
                                Grid.SetRow(t, tw.l.y);
                                Grid.SetColumn(t, tw.l.x);
                                Board.Children.Add(t);
                                gold = (gold - 35);
                                numberOfTowers++;
                                MessageBox.Show("You have " + gold + " gold left and you can build " + (MaxTowers - numberOfTowers) + " more towers");


                            }
                            else { MessageBox.Show("You don't have enough gold for that!, you need 35 and you only have " + gold); }
                        }
                        break;
                    //Sniper
                    case 3:
                        if (towerType == 3)
                        {

                            if (gold >= 60)
                            {
                                var tw = towers[numberOfTowers];
                                tw.Initialize(0, numberOfTowers, "Sniper", 20, 9.4, 1, new ClsP(column, row));

                                //Tower Picture
                                Image t = new Image();
                                t.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Towers\\" + tw.nm + ".png", UriKind.Absolute));
                                towerImages[ch] = t;
                                Grid.SetRow(t, tw.l.y);
                                Grid.SetColumn(t, tw.l.x);
                                Board.Children.Add(t);
                                gold = (gold - 60);
                                numberOfTowers++;
                                MessageBox.Show("You have " + gold + " gold left and you can build " + (MaxTowers - numberOfTowers) + " more towers");


                            }
                            else { MessageBox.Show("You don't have enough gold for that!, you need 60 and you only have " + gold); }
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

        private int I(double ah, Point p, int r, double aw, ref int c)
        {
            foreach (var rd in Board.RowDefinitions)
            {
                ah += rd.ActualHeight;
                if (ah >= p.Y)
                    break;
                r++;
            }
            // calc col mouse was over
            foreach (var cd in Board.ColumnDefinitions)
            {
                aw += cd.ActualWidth;
                if (aw >= p.X)
                    break;
                c++;
            }
            return r;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            ClsP m = new ClsP(0, 0);

            //first intervals- for craeting the enemies
            if (ch < MaxEnemies)
            {
                //Making Enemies
                var enemy = this.enemies[ch];
                m = enemy.l;
                //enemy HP
                TextBlock enemyTextBlock = new TextBlock();

                enemyTextBlock.FontSize = 20;
                enemyTextBlock.FontWeight = FontWeights.Bold;
                enemyTextBlock.Text = enemy.h.ToString();


                
                Grid.SetRow(enemyTextBlock, m.y);
                Grid.SetColumn(enemyTextBlock, m.x);
                Board.Children.Add(enemyTextBlock);
                enemyTextBlocks[ch] = enemyTextBlock;

                //enemy Picture
                Image enemyImage = new Image();
                enemyImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\1.png", UriKind.Absolute));
                enemyImages[ch] = enemyImage;
                Grid.SetRow(enemyImage, m.y);
                Grid.SetColumn(enemyImage, m.x);
                Board.Children.Add(enemyImage);
              
                ch++;

                //Fire!!
                for (int ti = 0; ti < towers.Length; ti++)
                {
                    var tw = towers[ti];
                    var fe = this.enemies[0];

                    for (int j = 0; j < tw.a; j++)
                    {
                        fe = this.enemies[0];
                        for (int i = 1; i < this.enemies.Length; i++)
                        {
                            enemy = this.enemies[i];
                            if (enemy.t > fe.t && tw.ir(enemy))
                            {
                                fe = enemy;
                            }
                            else if (tw.ir(fe) == false && tw.ir(enemy)) { fe = enemy; }
                        }
                        tw.f(fe);
                    }

                }

                //Enemies movement and changing picture by level of power
                for (int i = 0; i < ch; i++)
                {
                    enemy = this.enemies[i];
                    if (enemy.h <= 0) { killsCount++; }
                    enemy.M(r, out goldEarnedInRound);
                    // Enemies Picture change by Power level
                    if (enemy.lv > 3)
                    {
                        enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\2.png", UriKind.Absolute));
                        if (enemy.lv > 5)
                        {
                            enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\3.png", UriKind.Absolute));
                            if (enemy.lv > 7)
                            {
                                enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\4.png", UriKind.Absolute));
                                if (enemy.lv > 9)
                                {
                                    enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\5.png", UriKind.Absolute));
                                    if (enemy.lv > 12)
                                    {
                                        enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\6.png", UriKind.Absolute));
                                        if (enemy.lv > 14)
                                        {
                                            enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\7.png", UriKind.Absolute));
                                            if (enemy.lv > 16)
                                            {
                                                enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\8.png", UriKind.Absolute));
                                                if (enemy.lv > 18)
                                                {
                                                    enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\9.png", UriKind.Absolute));
                                                    if (enemy.lv > 20)
                                                    {
                                                        enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\10.png", UriKind.Absolute));
                                                        if (enemy.lv > 22)
                                                        {
                                                            enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\11.png", UriKind.Absolute));

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                    enemyTextBlock = enemyTextBlocks[i];
                    enemyImage = enemyImages[i];
                    gold += goldEarnedInRound;
                    goldEarnedInRound = 0;

                    m = enemy.l;




                    Grid.SetRow(enemyImage, m.y);
                    Grid.SetColumn(enemyImage, m.x);

                    Grid.SetRow(enemyTextBlock, m.y);
                    Grid.SetColumn(enemyTextBlock, m.x);
                    enemyTextBlock.Text = enemy.h.ToString();
                }
            }
            // called every timer interval after the enemies creation

            else
            {
                


                //Fire!!
                for (int ti = 0; ti < towers.Length; ti++)
                {
                    var tw = towers[ti];
                    var fi = this.enemies[0];

                    for (int j = 0; j < tw.a; j++)
                    {
                        fi = this.enemies[0];
                        for (int i = 1; i < this.enemies.Length; i++)
                        {
                            var en = this.enemies[i];
                            if (en.t > fi.t && tw.ir(en))
                            {
                                fi = en;
                            }
                            else if (tw.ir(fi) == false && tw.ir(en)) { fi = en; }
                        }
                        tw.f(fi);

                    }
                }

                // Enemies movement and changing picture by level of power
                for (int i = 0; i < this.enemies.Length; i++)
                {

                    var en = this.enemies[i];
                    if (en.h <= 0) { killsCount++; }
                    en.M(r, out goldEarnedInRound);
                    gold += goldEarnedInRound;
                    goldEarnedInRound = 0;
                    if (en.l == r.e)
                    {
                        MessageBox.Show("you lose! but killed "+ killsCount);
                        _gameTimer.Stop();
                        break;
                    }
                    // Enemies Picture change by Power level
                    if (en.lv > 3)
                    {
                        enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\2.png", UriKind.Absolute));
                        if (en.lv > 5)
                        {
                            enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\3.png", UriKind.Absolute));
                            if (en.lv > 7)
                            {
                                enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\4.png", UriKind.Absolute));
                                if (en.lv > 9)
                                {
                                    enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\5.png", UriKind.Absolute));
                                    if (en.lv > 12)
                                    {
                                        enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\6.png", UriKind.Absolute));
                                        if (en.lv > 14)
                                        {
                                            enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\7.png", UriKind.Absolute));
                                            if (en.lv > 16)
                                            {
                                                enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\8.png", UriKind.Absolute));
                                                if (en.lv > 18)
                                                {
                                                    enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\9.png", UriKind.Absolute));
                                                    if (en.lv > 20)
                                                    {
                                                        enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\10.png", UriKind.Absolute));
                                                        if (en.lv > 22)
                                                        {
                                                            enemyImages[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\11.png", UriKind.Absolute));

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    m = en.l;

                    var etb = enemyTextBlocks[i];
                    var em = enemyImages[i];


                    if ((en.h * 3) < en.mh)
                    {
                        etb.Foreground = new SolidColorBrush(Colors.Red);

                    }
                    else
                    {

                        etb.Foreground = new SolidColorBrush(Colors.Black);

                    }
                    etb.Text = en.h.ToString();

                    Grid.SetRow(em, m.y);
                    Grid.SetColumn(em, m.x);

                    Grid.SetRow(etb, m.y);
                    Grid.SetColumn(etb, m.x);
     
                }


            }
        }
    }
}