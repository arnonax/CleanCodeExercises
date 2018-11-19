using System;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        const int MAX_NUM_ENEMIES = 10;
        const int MAX_NUM_TOWERS = 12;
        const int BOARD_WIDTH = 15;
        public int towerSlot = 0;
        const int BOARD_HEIGHT = 12;
        public int check = 0;
        public int bank = 50;
        public int gold = 0;
        public int towerType;
        public int kills = 0;

        Enemy[] enemies = new Enemy[MAX_NUM_ENEMIES];
        TextBlock[] enemyTBs = new TextBlock[MAX_NUM_ENEMIES];
        Image[] enemyIMG = new Image[MAX_NUM_ENEMIES];
        Tower[] towers = new Tower[MAX_NUM_TOWERS];
        TextBlock[] towerTBs = new TextBlock[MAX_NUM_TOWERS];
        Image[] towerIMG = new Image[MAX_NUM_TOWERS];

        route myroute = new route();
        TextBlock[] runnerDisplay = new TextBlock[MAX_NUM_ENEMIES];

        DispatcherTimer timers;
        

        public MainWindow()
        {
            InitializeComponent();

            this.myboard.MouseDown += new MouseButtonEventHandler(GridCtrl_MouseDown);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Enemy(1, 15);
                enemies[i].Serial = i;
            }

            for (int i = 0; i < towers.Length; i++)
            {
                towers[i] = new Tower();
                towers[i].Build(0, i, "Tower1",5, 2,1, new point(14,14));
            }

            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            point marker = new point(0, 0);
            ColumnDefinition col;
            RowDefinition row;

            // create board
            for (int i = 0; i < BOARD_WIDTH; i++)
            {
                col = new ColumnDefinition();
                myboard.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < BOARD_HEIGHT; i++)
            {
                row = new RowDefinition();
                myboard.RowDefinitions.Add(row);
            }
 
            // Draw Grass
            for (int i = 0; i < BOARD_WIDTH; i++)
			{
                for (int j = 0; j < BOARD_HEIGHT; j++)
			{
                Image Grass = new Image();
                Grass.Source = new BitmapImage(new Uri(Environment.CurrentDirectory+"\\Pictures\\Background\\Grass.png",  UriKind.RelativeOrAbsolute));
                myboard.ShowGridLines = false;

                Grid.SetRow(Grass, j);
                Grid.SetColumn(Grass, i);
                myboard.Children.Add(Grass);
                }
			}
            // draw route
            for (int i = 0; i < myroute.myRoute.Length; i++)
            {
                marker = myroute.myRoute[i];
                Image theWay = new Image();
                theWay.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Background\\Route.png", UriKind.Absolute));
                
                Grid.SetRow(theWay, marker.y);
                Grid.SetColumn(theWay, marker.x);
                myboard.Children.Add(theWay);
                if (i == (myroute.myRoute.Length - 1))
                {
                    Image theEnd = new Image();
                    theEnd.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Background\\Home.png", UriKind.Absolute));

                    Grid.SetRow(theEnd, marker.y);
                    Grid.SetColumn(theEnd, marker.x);
                    myboard.Children.Add(theEnd);
                }
            }
            // create timer
            timers = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, new EventHandler(timerCycle), Dispatcher); // TODO: pace the game!
            timers.Start();
    }

        private void GridCtrl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timers.Stop();
            var point = Mouse.GetPosition(myboard);

            int col = 0;
            double accumulatedWidth = 0.0;
            double accumulatedHeight = 0.0;
            int row = 0;

            // calc row mouse was over
            foreach (var rowDefinition in myboard.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }
            // calc col mouse was over
            foreach (var columnDefinition in myboard.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }
            //Tower selection popup manu
            if (towerSlot < MAX_NUM_TOWERS)
            {

                PopUp pop = new PopUp(bank, col, row, towerType);
                pop.ShowDialog();
                towerType = pop.towerType;
            //tower selection
                switch (towerType)
                {
                    //SimpleTower
                    case 1:
                        if (bank >= 20)
                        {
                            var tower = towers[towerSlot];
                            point pointa = new point(col, row);
                            tower.Build(0, towerSlot, "Tower", 10, 3.6, 2, new point(col, row));

                            //Tower Picture
                            Image Tower = new Image();
                            Tower.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Towers\\" + tower.name + ".png", UriKind.Absolute));
                            towerIMG[check] = Tower;
                            Grid.SetRow(Tower, tower.location.y);
                            Grid.SetColumn(Tower, tower.location.x);
                            myboard.Children.Add(Tower);
                            bank = (bank - 20);
                            towerSlot++;
                            MessageBox.Show("You have " + bank + " gold left and you can build " + (MAX_NUM_TOWERS - towerSlot) + " more towers");
                        }
                        else { MessageBox.Show("You don't have enough gold for that!, you need 20 and you only have " + bank); }

                        break;
                    //Reapeter
                    case 2:
                        {

                            if (bank >= 35)
                            {
                                var tower = towers[towerSlot];
                                point pointa = new point(col, row);
                                tower.Build(0, towerSlot, "Reapeter", 5, 3, 7, new point(col, row));

                                //Tower Picture
                                Image Tower = new Image();
                                Tower.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Towers\\" + tower.name + ".png", UriKind.Absolute));
                                towerIMG[check] = Tower;
                                Grid.SetRow(Tower, tower.location.y);
                                Grid.SetColumn(Tower, tower.location.x);
                                myboard.Children.Add(Tower);
                                bank = (bank - 35);
                                towerSlot++;
                                MessageBox.Show("You have " + bank + " gold left and you can build " + (MAX_NUM_TOWERS - towerSlot) + " more towers");


                            }
                            else { MessageBox.Show("You don't have enough gold for that!, you need 35 and you only have " + bank); }
                        }
                        break;
                    //Sniper
                    case 3:
                        if (towerType == 3)
                        {

                            if (bank >= 60)
                            {
                                var tower = towers[towerSlot];
                                point pointa = new point(col, row);
                                tower.Build(0, towerSlot, "Sniper", 20, 9.4, 1, new point(col, row));

                                //Tower Picture
                                Image Tower = new Image();
                                Tower.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Towers\\" + tower.name + ".png", UriKind.Absolute));
                                towerIMG[check] = Tower;
                                Grid.SetRow(Tower, tower.location.y);
                                Grid.SetColumn(Tower, tower.location.x);
                                myboard.Children.Add(Tower);
                                bank = (bank - 60);
                                towerSlot++;
                                MessageBox.Show("You have " + bank + " gold left and you can build " + (MAX_NUM_TOWERS - towerSlot) + " more towers");


                            }
                            else { MessageBox.Show("You don't have enough gold for that!, you need 60 and you only have " + bank); }
                        }
                        break;
                }

            }
            else
            {
                MessageBox.Show("You cannot build more towers!");
            }
            timers.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void timerCycle(object sender, EventArgs e)
        {
            point marker = new point(0, 0);

            //first intervals- for craeting the enemies
            if (check < MAX_NUM_ENEMIES)
            {
                //Making Enemies
                var enemy = enemies[check];
                marker = enemy.location;
                //enemy HP
                TextBlock enemyTB = new TextBlock();

                enemyTB.FontSize = 20;
                enemyTB.FontWeight = FontWeights.Bold;
                enemyTB.Text = enemy.health.ToString();


                
                Grid.SetRow(enemyTB, marker.y);
                Grid.SetColumn(enemyTB, marker.x);
                myboard.Children.Add(enemyTB);
                enemyTBs[check] = enemyTB;

                //enemy Picture
                Image Enemy = new Image();
                Enemy.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\1.png", UriKind.Absolute));
                enemyIMG[check] = Enemy;
                Grid.SetRow(Enemy, marker.y);
                Grid.SetColumn(Enemy, marker.x);
                myboard.Children.Add(Enemy);
              
                check++;

                //Fire!!
                for (int towerIndex = 0; towerIndex < towers.Length; towerIndex++)
                {
                    var tower = towers[towerIndex];
                    var firstenemy = enemies[0];

                    for (int j = 0; j < tower.ammo; j++)
                    {
                        firstenemy = enemies[0];
                        for (int i = 1; i < enemies.Length; i++)
                        {
                            enemy = enemies[i];
                            if (enemy.tracker > firstenemy.tracker && tower.inrange(enemy) == true)
                            {
                                firstenemy = enemy;
                            }
                            else if (tower.inrange(firstenemy) == false && tower.inrange(enemy) == true) { firstenemy = enemy; }
                        }
                        tower.fire(firstenemy);
                    }

                }

                //Enemies movement and changing picture by level of power
                for (int i = 0; i < check; i++)
                {
                    enemy = enemies[i];
                    if (enemy.health <= 0) { kills++; }
                    enemy.move(myroute, out gold);
                    // Enemies Picture change by Power level
                    if (enemy.level > 3)
                    {
                        enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\2.png", UriKind.Absolute));
                        if (enemy.level > 5)
                        {
                            enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\3.png", UriKind.Absolute));
                            if (enemy.level > 7)
                            {
                                enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\4.png", UriKind.Absolute));
                                if (enemy.level > 9)
                                {
                                    enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\5.png", UriKind.Absolute));
                                    if (enemy.level > 12)
                                    {
                                        enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\6.png", UriKind.Absolute));
                                        if (enemy.level > 14)
                                        {
                                            enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\7.png", UriKind.Absolute));
                                            if (enemy.level > 16)
                                            {
                                                enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\8.png", UriKind.Absolute));
                                                if (enemy.level > 18)
                                                {
                                                    enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\9.png", UriKind.Absolute));
                                                    if (enemy.level > 20)
                                                    {
                                                        enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\10.png", UriKind.Absolute));
                                                        if (enemy.level > 22)
                                                        {
                                                            enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\11.png", UriKind.Absolute));

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


                    enemyTB = enemyTBs[i];
                    Enemy = enemyIMG[i];
                    bank += gold;
                    gold = 0;

                    marker = enemy.location;




                    Grid.SetRow(Enemy, marker.y);
                    Grid.SetColumn(Enemy, marker.x);

                    Grid.SetRow(enemyTB, marker.y);
                    Grid.SetColumn(enemyTB, marker.x);
                    enemyTB.Text = enemy.health.ToString();
                }
            }
            // called every timer interval after the enemies creation

            else
            {
                


                //Fire!!
                for (int towerIndex = 0; towerIndex < towers.Length; towerIndex++)
                {
                    var tower = towers[towerIndex];
                    var firstenemy = enemies[0];

                    for (int j = 0; j < tower.ammo; j++)
                    {
                        firstenemy = enemies[0];
                        for (int i = 1; i < enemies.Length; i++)
                        {
                            var enemy = enemies[i];
                            if (enemy.tracker > firstenemy.tracker && tower.inrange(enemy) == true)
                            {
                                firstenemy = enemy;
                            }
                            else if (tower.inrange(firstenemy) == false && tower.inrange(enemy) == true) { firstenemy = enemy; }
                        }
                        tower.fire(firstenemy);

                    }
                }

                // Enemies movement and changing picture by level of power
                for (int i = 0; i < enemies.Length; i++)
                {

                    var enemy = enemies[i];
                    if (enemy.health <= 0) { kills++; }
                    enemy.move(myroute, out gold);
                    bank += gold;
                    gold = 0;
                    if (enemy.location == myroute.endZone)
                    {
                        MessageBox.Show("you lose! but killed "+ kills);
                        timers.Stop();
                        break;
                    }
                    // Enemies Picture change by Power level
                    if (enemy.level > 3)
                    {
                        enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\2.png", UriKind.Absolute));
                        if (enemy.level > 5)
                        {
                            enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\3.png", UriKind.Absolute));
                            if (enemy.level > 7)
                            {
                                enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\4.png", UriKind.Absolute));
                                if (enemy.level > 9)
                                {
                                    enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\5.png", UriKind.Absolute));
                                    if (enemy.level > 12)
                                    {
                                        enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\6.png", UriKind.Absolute));
                                        if (enemy.level > 14)
                                        {
                                            enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\7.png", UriKind.Absolute));
                                            if (enemy.level > 16)
                                            {
                                                enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\8.png", UriKind.Absolute));
                                                if (enemy.level > 18)
                                                {
                                                    enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\9.png", UriKind.Absolute));
                                                    if (enemy.level > 20)
                                                    {
                                                        enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\10.png", UriKind.Absolute));
                                                        if (enemy.level > 22)
                                                        {
                                                            enemyIMG[i].Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Pictures\\Enemys\\11.png", UriKind.Absolute));

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
                    marker = enemy.location;

                    var enemyTB = enemyTBs[i];
                    var Enemy = enemyIMG[i];


                    if ((enemy.health * 3) < enemy.maxHealth)
                    {
                        enemyTB.Foreground = new SolidColorBrush(Colors.Red);

                    }
                    else
                    {

                        enemyTB.Foreground = new SolidColorBrush(Colors.Black);

                    }
                    enemyTB.Text = enemy.health.ToString();

                    Grid.SetRow(Enemy, marker.y);
                    Grid.SetColumn(Enemy, marker.x);

                    Grid.SetRow(enemyTB, marker.y);
                    Grid.SetColumn(enemyTB, marker.x);
     
                }


            }
        }
    }
}