using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using Education_Practic_num_1.Information_System_Of_MarketDataSetTableAdapters;

namespace Education_Practic_num_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataSet_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new DataSet_Page();
        }

        private void EF_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new EF_Page();
        }
    }
}