using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TowerDefence
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
       public int towerType;
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
            towerType = 2;
            this.Close();
        }

        private void BuildTower(object sender, RoutedEventArgs e)
        {
            towerType = 1;
            this.Close();

        }

        private void BuildSn(object sender, RoutedEventArgs e)
        {
            towerType = 3;
            this.Close();

        }

        private void ForgetButtonClicked(object sender, RoutedEventArgs e)
        {
            towerType = 0;
            this.Close();
            
        }
    }
}
