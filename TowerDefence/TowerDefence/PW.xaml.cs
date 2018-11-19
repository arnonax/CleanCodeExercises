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
    /// Interaction logic for PW.xaml
    /// </summary>
    public partial class PW : Window
    {
       public int tt;
        public PW(int pg, int pc, int pr, int ptt)
        {
            InitializeComponent();
            txt.Text = "Grid clicked at column " + pc + ", row " + pr + " you have " + pg + " gold";
            if (b1.IsPressed == true)
            {
                ptt = 1;
                this.Close();
            }
        }

        private void R(object sender, RoutedEventArgs e)
        {
            tt = 2;
            this.Close();
        }

        private void Sm(object sender, RoutedEventArgs e)
        {
            tt = 1;
            this.Close();

        }

        private void Sn(object sender, RoutedEventArgs e)
        {
            tt = 3;
            this.Close();

        }

        private void N(object sender, RoutedEventArgs e)
        {
            tt = 0;
            this.Close();
            
        }
    }
}
