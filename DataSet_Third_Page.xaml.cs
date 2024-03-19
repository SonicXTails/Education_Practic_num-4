using Education_Practic_num_1.Information_System_Of_MarketDataSetTableAdapters;
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
    public partial class DataSet_Third_Page : Page
    {
        StockTableAdapter stock = new StockTableAdapter();
        public DataSet_Third_Page()
        {
            InitializeComponent();

            BD_DataSet_Grid.ItemsSource = stock.GetFullDataFromBD();

            Exit.Visibility = Visibility.Visible;
            BD_DataSet_Grid.Visibility = Visibility.Visible;

            BD_DataSet_Grid.Columns[0].Visibility = Visibility.Collapsed;
            BD_DataSet_Grid.Columns[3].Visibility = Visibility.Collapsed;
            BD_DataSet_Grid.Columns[4].Visibility = Visibility.Collapsed;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Exit.Visibility = Visibility.Hidden;
            BD_DataSet_Grid.Visibility = Visibility.Hidden;
        }
    }
}
