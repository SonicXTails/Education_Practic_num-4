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
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Education_Practic_num_1
{
    public partial class EF_Find_Page : Page
    {
        private Information_System_Of_MarketEntitie context = new Information_System_Of_MarketEntitie();
        public EF_Find_Page()
        {
            InitializeComponent();

            Hidden_all_items_Products();
            Update_DataSet_ComboBox();
        }

        private void Products_EF_Click(object sender, RoutedEventArgs e)
        {
            Visible_all_items_Products();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Hidden_all_items();
        }
        private void Find_by_Name_btn_Click(object sender, RoutedEventArgs e)
        {
            Products_EF_Find_DataGrid.ItemsSource = context.Stock.ToList().Where(item => item.Products.Product_Name.Contains(Find_by_Name_txtbox.Text));

            if (Products_EF_Find_DataGrid.Items.Count == 0)
            {
                MessageBox.Show("Такого значения нет или вы написали его некорректно!\nПопробуйте снова", "Значение не найдено", MessageBoxButton.OK, MessageBoxImage.Error);
                Products_EF_Find_DataGrid.ItemsSource = context.Stock.ToList();
            }

            Find_by_Name_txtbox.Text = String.Empty;
        }
        private void Find_by_Cost_btn_Click(object sender, RoutedEventArgs e)
        {
            float cost = 0;
            float.TryParse(Find_by_Cost_txtbox.Text, out cost);
            Products_EF_Find_DataGrid.ItemsSource = context.Stock.ToList().Where(item => (decimal)item.Products.Product_Cost == (decimal)cost);


            if (Products_EF_Find_DataGrid.Items.Count == 0)
            {
                MessageBox.Show("Такого значения нет или вы написали его некорректно!\nПопробуйте снова", "Значение не найдено", MessageBoxButton.OK, MessageBoxImage.Error);
                Products_EF_Find_DataGrid.ItemsSource = context.Stock.ToList();
            }

            Find_by_Cost_txtbox.Text = String.Empty;
        }

        private void Clear_by_name_Click(object sender, RoutedEventArgs e)
        {
            var selected = Choose_Item_To_Clear.SelectedItem as Products;
            Products_EF_Find_DataGrid.ItemsSource = context.Stock.ToList().Where(item => item.Products.Product_Name == selected.Product_Name);
        }


        // Методы для сокрытия элементов
        private void Hidden_all_items()
        {
            Exit.Visibility = Visibility.Hidden;
            Products_EF_Find_DataGrid.Visibility = Visibility.Hidden;
            Products_EF.Visibility = Visibility.Hidden;
            Block.Visibility = Visibility.Hidden;

            Products_EF_Find_DataGrid.Visibility = Visibility.Hidden;
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

        private void Hidden_all_items_Products()
        {
            Products_EF_Find_DataGrid.Visibility = Visibility.Hidden;
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
            Products_EF_Find_DataGrid.Visibility = Visibility.Visible;
            Find_by_Cost_btn.Visibility = Visibility.Visible;
            Find_by_Name_btn.Visibility = Visibility.Visible;
            Find_by_Name_txtbox.Visibility = Visibility.Visible;
            Find_by_Cost_txtbox.Visibility = Visibility.Visible;
            Find_by_Name_txtblock.Visibility = Visibility.Visible;
            Find_by_Cost_txtblock.Visibility = Visibility.Visible;
            Choose_Item_To_Clear.Visibility = Visibility.Visible;
            Clear_by_name.Visibility = Visibility.Visible;
            Clear_by_name_txtbox.Visibility = Visibility.Visible;
        }

        private void Update_DataSet_ComboBox()
        {
            Products_EF_Find_DataGrid.ItemsSource = context.Stock.ToList();

            Choose_Item_To_Clear.ItemsSource = context.Products.ToList();
            Choose_Item_To_Clear.DisplayMemberPath = "Product_Name";
        }
    }
}
