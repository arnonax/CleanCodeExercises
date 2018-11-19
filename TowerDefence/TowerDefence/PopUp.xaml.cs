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
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : Window
    {
       public int towerType;
        public PopUp(int pgold, int pcol, int prow, int towerType)
        {
            InitializeComponent();
            Textastic.Text = "Grid clicked at column " + pcol + ", row " + prow + " you have " + pgold + " gold";
            if (SimpleButton.IsPressed == true)
            {
                towerType = 1;
                this.Close();
            }
        }

        private void Reapeter(object sender, RoutedEventArgs e)
        {
            towerType = 2;
            this.Close();
        }

        private void Simple(object sender, RoutedEventArgs e)
        {
            towerType = 1;
            this.Close();

        }

        private void Sniper(object sender, RoutedEventArgs e)
        {
            towerType = 3;
            this.Close();

        }

        private void nothing(object sender, RoutedEventArgs e)
        {
            towerType = 0;
            this.Close();
            
        }
    }
}
