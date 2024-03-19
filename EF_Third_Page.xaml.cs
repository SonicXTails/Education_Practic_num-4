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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Education_Practic_num_1
{
    public partial class EF_Third_Page : Page
    {
        private Information_System_Of_MarketEntitie context = new Information_System_Of_MarketEntitie();
        public EF_Third_Page()
        {
            InitializeComponent();

            BD_DataSet_Grid.ItemsSource = context.Stock.ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Exit.Visibility = Visibility.Hidden;
            BD_DataSet_Grid.Visibility = Visibility.Hidden;
        }
    }
}
