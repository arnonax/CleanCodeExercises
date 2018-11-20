using System.Windows;

namespace TowerDefence
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow
    {
        // TODO: change to readonly property
        public MainWindow.TowerType TowerType;
        public PopupWindow(int gold, int column, int row)
        {
            InitializeComponent();
            txt.Text = "Grid clicked at column " + column + ", row " + row + " you have " + gold + " gold";
            if (BuildTowerButton.IsPressed)
            {
                Close();
            }
        }

        private void BuildReaper(object sender, RoutedEventArgs e)
        {
            TowerType = MainWindow.TowerType.Reapeter;
            Close();
        }

        private void BuildTower(object sender, RoutedEventArgs e)
        {
            TowerType = MainWindow.TowerType.SimpleTower;
            Close();

        }

        private void BuildSniper(object sender, RoutedEventArgs e)
        {
            TowerType = MainWindow.TowerType.Sniper;
            Close();

        }

        private void ForgetButtonClicked(object sender, RoutedEventArgs e)
        {
            TowerType = 0;
            Close();
            
        }
    }
}
