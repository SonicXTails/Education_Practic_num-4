using Education_Practic_num_1.Information_System_Of_MarketDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace Education_Practic_num_1
{
    public partial class DataSet_Find_Page : Page
    {
        // Инициализация
        StockTableAdapter stock = new StockTableAdapter();
        ProductsTableAdapter products = new ProductsTableAdapter();
        public DataSet_Find_Page()
        {
            InitializeComponent();
            Update_DataGrid();

            Function_for_Update_Combobox_with_Products_Names();

            Hidden_all_items_Products();
        }

        // Меню
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Hidden_all_items();
        }


        private void Products_DataGrid_Click(object sender, RoutedEventArgs e)
        {
            Visible_all_items_Products();
        }

        private void Find_by_Name_btn_Click(object sender, RoutedEventArgs e)
        {
            Products_DataGrid_Find.ItemsSource = stock.SearchByNameProducts(Find_by_Name_txtbox.Text);

            if (Products_DataGrid_Find.Items.Count == 0)
            {
                MessageBox.Show("Такого значения нет!\nПопробуйте снова", "Значение не найдено", MessageBoxButton.OK, MessageBoxImage.Error);
                Update_DataGrid();
            }

            Find_by_Name_txtbox.Text = String.Empty;
        }

        private void Find_by_Cost_btn_Click(object sender, RoutedEventArgs e)
        {
            float Cost = 0;
            float.TryParse(Find_by_Cost_txtbox.Text, out Cost);
            Products_DataGrid_Find.ItemsSource = stock.SearchByCostProducts(Cost);

            if (Products_DataGrid_Find.Items.Count == 0)
            {
                MessageBox.Show("Такого значения нет!\nПопробуйте снова", "Значение не найдено", MessageBoxButton.OK, MessageBoxImage.Error);
                Update_DataGrid();
            }

            Find_by_Cost_txtbox.Text = String.Empty;
        }

        private void Clear_by_name_Click(object sender, RoutedEventArgs e)
        {
            var ID_Product = (int)(Choose_Item_To_Clear.SelectedItem as DataRowView).Row[0];
            Products_DataGrid_Find.ItemsSource = products.FilterByProductID(ID_Product);
        }




        // Методы для сокрытия элементов
        private void Hidden_all_items()
        {
            Exit.Visibility = Visibility.Hidden;
            Products_DataGrid.Visibility = Visibility.Hidden;
            Block.Visibility = Visibility.Hidden;

            Products_DataGrid_Find.Visibility = Visibility.Hidden;
            Find_by_Cost_btn.Visibility = Visibility.Hidden;
            Find_by_Name_btn.Visibility = Visibility.Hidden;
            Find_by_Name_txtbox.Visibility = Visibility.Hidden;
            Find_by_Cost_txtbox.Visibility = Visibility.Hidden;
            Find_by_Name_txtblock.Visibility = Visibility.Hidden;
            Find_by_Cost_txtblock.Visibility = Visibility.Hidden;
            Choose_Item_To_Clear.Visibility = Visibility.Hidden;
            Clear_by_name.Visibility = Visibility.Hidden;
            Clear_by_name_txtbox.Visibility= Visibility.Hidden;
        }

        private void Hidden_all_items_Products()
        {
            Products_DataGrid_Find.Visibility = Visibility.Hidden;
            Find_by_Cost_btn.Visibility = Visibility.Hidden;
            Find_by_Name_btn.Visibility = Visibility.Hidden;
            Find_by_Name_txtbox.Visibility = Visibility.Hidden;
            Find_by_Cost_txtbox.Visibility = Visibility.Hidden;
            Find_by_Name_txtblock.Visibility = Visibility.Hidden;
            Find_by_Cost_txtblock.Visibility = Visibility.Hidden;
            Choose_Item_To_Clear.Visibility = Visibility.Hidden;
            Clear_by_name.Visibility = Visibility.Hidden;
            Clear_by_name_txtbox.Visibility = Visibility.Hidden;
        }

        private void Visible_all_items_Products()
        {
            Products_DataGrid_Find.Visibility = Visibility.Visible;
            Find_by_Cost_btn.Visibility = Visibility.Visible;
            Find_by_Name_btn.Visibility = Visibility.Visible;
            Find_by_Name_txtbox.Visibility = Visibility.Visible;
            Find_by_Cost_txtbox.Visibility = Visibility.Visible;
            Find_by_Name_txtblock.Visibility = Visibility.Visible;
            Find_by_Cost_txtblock.Visibility = Visibility.Visible;
            Choose_Item_To_Clear.Visibility= Visibility.Visible;
            Clear_by_name.Visibility = Visibility.Visible;
            Clear_by_name_txtbox.Visibility= Visibility.Visible;
        }

        private void Update_DataGrid()
        {
            Products_DataGrid_Find.ItemsSource = stock.GetFullDataFromBD();

            Products_DataGrid_Find.Columns[0].Visibility = Visibility.Collapsed;
            Products_DataGrid_Find.Columns[3].Visibility = Visibility.Collapsed;
            Products_DataGrid_Find.Columns[4].Visibility = Visibility.Collapsed;
        }

        private void Function_for_Update_Combobox_with_Products_Names()
        {
            Choose_Item_To_Clear.ItemsSource = products.GetData();
            Choose_Item_To_Clear.DisplayMemberPath = "Product_Name";
        }
    }
}
