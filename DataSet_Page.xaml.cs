using Education_Practic_num_1.Information_System_Of_MarketDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using static MaterialDesignThemes.Wpf.Theme;


namespace Education_Practic_num_1
{
    public partial class DataSet_Page : Page
    {
        ProductsTableAdapter product = new ProductsTableAdapter();
        StockTableAdapter stock = new StockTableAdapter();

        public DataSet_Page()
        {
            InitializeComponent();
            Products_DataGrid.ItemsSource = product.GetData();
            Stock_DataGrid.ItemsSource = stock.GetDataBy1();

            Stock_DataGrid.Visibility = Visibility.Hidden;
            Products_DataGrid.Visibility = Visibility.Hidden;

            Write_to_Add_in_Grid_Product.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Cost.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Description.Visibility = Visibility.Hidden;

            Write_to_Change_in_Grid_Product.Visibility = Visibility.Hidden;
            Write_to_Change_in_Grid_Cost.Visibility = Visibility.Hidden;
            Write_to_Change_in_Grid_Description.Visibility = Visibility.Hidden;

            Add_to_Grid.Visibility = Visibility.Hidden;
            Change_in_Grid.Visibility = Visibility.Hidden;
            Delete_in_Grid.Visibility = Visibility.Hidden;

            Name_to_Change.Visibility = Visibility.Hidden;
            Name_to_Delete.Visibility = Visibility.Hidden;

            Write_to_Change_in_Grid_Count.Visibility = Visibility.Hidden;

            Write_to_Change_in_Grid_Count.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Count.Visibility = Visibility.Hidden;

            Add_to_Grid_Stock.Visibility = Visibility.Hidden;
            Change_in_Grid_Stock.Visibility = Visibility.Hidden;
            Delete_in_Grid_Stock.Visibility = Visibility.Hidden;
            Name_to_Change_Stock.Visibility = Visibility.Hidden;
            Name_to_Delete_Stock.Visibility = Visibility.Hidden;


            Products_DataGrid.ItemsSource = product.GetData();
            Stock_DataGrid.ItemsSource = stock.GetDataBy1();

            Name_to_Delete.ItemsSource = product.GetData();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = product.GetData();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = product.GetData();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = product.GetData();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Block.Visibility = Visibility.Hidden;
            Stock_DataGrid.Visibility = Visibility.Hidden;
            Products_DataGrid.Visibility = Visibility.Hidden;

            Write_to_Add_in_Grid_Product.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Cost.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Description.Visibility = Visibility.Hidden;

            Write_to_Change_in_Grid_Product.Visibility = Visibility.Hidden;
            Write_to_Change_in_Grid_Cost.Visibility = Visibility.Hidden;
            Write_to_Change_in_Grid_Description.Visibility = Visibility.Hidden;

            Add_to_Grid.Visibility = Visibility.Hidden;
            Change_in_Grid.Visibility = Visibility.Hidden;
            Delete_in_Grid.Visibility = Visibility.Hidden;

            Name_to_Change.Visibility = Visibility.Hidden;
            Name_to_Delete.Visibility = Visibility.Hidden;

            Exit.Visibility = Visibility.Hidden;
            Open_Table_Products.Visibility = Visibility.Hidden;
            Open_Table_Stock.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Count.Visibility = Visibility.Hidden;

            Write_to_Change_in_Grid_Count.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Count.Visibility = Visibility.Hidden;

            Add_to_Grid_Stock.Visibility = Visibility.Hidden;
            Delete_in_Grid_Stock.Visibility = Visibility.Hidden;
            Change_in_Grid_Stock.Visibility = Visibility.Hidden;

            Name_to_Change_Stock.Visibility = Visibility.Hidden;
            Name_to_Delete_Stock.Visibility = Visibility.Hidden;
        }




        private void Open_Table_Products_Click(object sender, RoutedEventArgs e)
        {
            Stock_DataGrid.Visibility = Visibility.Hidden;
            Products_DataGrid.Visibility = Visibility.Visible;

            Add_to_Grid.Visibility = Visibility.Visible;
            Write_to_Add_in_Grid_Product.Visibility = Visibility.Visible;
            Write_to_Add_in_Grid_Cost.Visibility = Visibility.Visible;
            Write_to_Add_in_Grid_Description.Visibility = Visibility.Visible;


            Name_to_Delete.Visibility = Visibility.Visible;
            Delete_in_Grid.Visibility = Visibility.Visible;


            Write_to_Change_in_Grid_Product.Visibility = Visibility.Visible;
            Write_to_Change_in_Grid_Cost.Visibility = Visibility.Visible;
            Write_to_Change_in_Grid_Description.Visibility = Visibility.Visible;
            Change_in_Grid.Visibility = Visibility.Visible;
            Name_to_Change.Visibility = Visibility.Visible;

            Block.Visibility = Visibility.Hidden;

            Write_to_Change_in_Grid_Count.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Count.Visibility = Visibility.Hidden;

            Add_to_Grid_Stock.Visibility = Visibility.Hidden;
            Delete_in_Grid_Stock.Visibility = Visibility.Hidden;
            Change_in_Grid_Stock.Visibility = Visibility.Hidden;

            Name_to_Change_Stock.Visibility = Visibility.Hidden;
            Name_to_Delete_Stock.Visibility = Visibility.Hidden;
        }
        private void Add_to_Grid_Click(object sender, RoutedEventArgs e)
        {
            float cost = 0;
            float.TryParse(Write_to_Add_in_Grid_Cost.Text, out cost);
            product.InsertQuery(Write_to_Add_in_Grid_Product.Text, cost, Write_to_Add_in_Grid_Description.Text);
            Products_DataGrid.ItemsSource = product.GetData();

            Write_to_Add_in_Grid_Product.Text = "Введите имя продукта";
            Write_to_Add_in_Grid_Cost.Text = "Введите стоимость";
            Write_to_Add_in_Grid_Description.Text = "Введите описание";

            Products_DataGrid.ItemsSource = product.GetData();
            Stock_DataGrid.ItemsSource = stock.GetDataBy1();

            Name_to_Delete.ItemsSource = product.GetData();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = product.GetData();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = product.GetData();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = product.GetData();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";
        }

        private void Write_to_Add_in_Grid_Product_GotFocus(object sender, RoutedEventArgs e)
        {
            Write_to_Add_in_Grid_Product.Text = "";
        }
        private void Write_to_Add_in_Grid_Cost_GotFocus(object sender, RoutedEventArgs e)
        {
            Write_to_Add_in_Grid_Cost.Text = "";
        }
        private void Write_to_Add_in_Description_GotFocus(object sender, RoutedEventArgs e)
        {
            Write_to_Add_in_Grid_Description.Text = "";
        }
        private void Write_to_Add_in_Count_GotFocus(object sender, RoutedEventArgs e)
        {
            Write_to_Add_in_Grid_Count.Text = "";
        }



        private void Delete_in_Grid_Click(object sender, RoutedEventArgs e)
        {
            DataRowView Name_to_del_in_stock = (DataRowView)Name_to_Delete.SelectedItem;
            int productId_by_name = Convert.ToInt32(Name_to_del_in_stock["Product_ID"]);

            stock.DeleteQuery(productId_by_name);

            if (Name_to_Delete.SelectedItem != null)
            {
                DataRowView Name_to_del_in_product = (DataRowView)Name_to_Delete.SelectedItem;
                string productName = Name_to_del_in_product["Product_Name"].ToString();

                product.DeleteQuery(productName);
                Products_DataGrid.ItemsSource = product.GetData();
            }

            Products_DataGrid.ItemsSource = product.GetData();
            Stock_DataGrid.ItemsSource = stock.GetDataBy1();

            Name_to_Delete.ItemsSource = product.GetData();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = product.GetData();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = product.GetData();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = product.GetData();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";
        }



        private void Change_in_Grid_Click(object sender, RoutedEventArgs e)
        {
            DataRowView Name_to_up_in_products = (DataRowView)Name_to_Change.SelectedItem;
            int productId_by_name = Convert.ToInt32(Name_to_up_in_products["Product_ID"]);

            if ((Write_to_Change_in_Grid_Cost.Text == null || Write_to_Change_in_Grid_Cost.Text == "Введите стоимость") && (Write_to_Change_in_Grid_Description.Text == null || Write_to_Change_in_Grid_Description.Text == "Введите описание"))
            {
                product.UpdateQueryName(Write_to_Change_in_Grid_Product.Text, productId_by_name);
            }
            else if ((Write_to_Change_in_Grid_Product.Text == null || Write_to_Change_in_Grid_Product.Text == "Введите имя продукта") && (Write_to_Change_in_Grid_Description.Text == null || Write_to_Change_in_Grid_Description.Text == "Введите описание"))
            {
                float cost = 0;
                float.TryParse(Write_to_Change_in_Grid_Cost.Text, out cost);
                product.UpdateQueryCost(cost, productId_by_name);
            }
            else if ((Write_to_Change_in_Grid_Product.Text == null || Write_to_Change_in_Grid_Product.Text == "Введите имя продукта") && (Write_to_Change_in_Grid_Cost.Text == null || Write_to_Change_in_Grid_Cost.Text == "Введите стоимость"))
            {
                product.UpdateQueryDescription(Write_to_Change_in_Grid_Description.Text, productId_by_name);
            }
            else
            {
                product.UpdateQueryName(Write_to_Change_in_Grid_Product.Text, productId_by_name);
                float cost = 0;
                float.TryParse(Write_to_Change_in_Grid_Cost.Text, out cost);
                product.UpdateQueryCost(cost, productId_by_name);
                product.UpdateQueryDescription(Write_to_Change_in_Grid_Description.Text, productId_by_name);
            }



            Write_to_Change_in_Grid_Product.Text = "Введите имя продукта";
            Write_to_Change_in_Grid_Cost.Text = "Введите стоимость";
            Write_to_Change_in_Grid_Description.Text = "Введите описание";

            Products_DataGrid.ItemsSource = product.GetData();
            Stock_DataGrid.ItemsSource = stock.GetDataBy1();

            Name_to_Delete.ItemsSource = product.GetData();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = product.GetData();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = product.GetData();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = product.GetData();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";
        }


        private void Write_to_Change_in_Grid_Product_GotFocus(object sender, RoutedEventArgs e)
        {
            Write_to_Change_in_Grid_Product.Text = "";
        }
        private void Write_to_Change_in_Grid_Cost_GotFocus(object sender, RoutedEventArgs e)
        {
            Write_to_Change_in_Grid_Cost.Text = "";
        }
        private void Write_to_Change_in_Description_GotFocus(object sender, RoutedEventArgs e)
        {
            Write_to_Change_in_Grid_Description.Text = "";
        }
        private void Write_to_Change_in_Count_GotFocus(object sender, RoutedEventArgs e)
        {
            Write_to_Change_in_Grid_Count.Text = "";
        }















        private void Open_Table_Stock_Click(object sender, RoutedEventArgs e)
        {
            Block.Visibility = Visibility.Hidden;
            Products_DataGrid.Visibility = Visibility.Hidden;
            Stock_DataGrid.Visibility = Visibility.Visible;

            Add_to_Grid.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Product.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Cost.Visibility = Visibility.Hidden;
            Write_to_Add_in_Grid_Description.Visibility = Visibility.Hidden;


            Name_to_Delete.Visibility = Visibility.Hidden;
            Delete_in_Grid.Visibility = Visibility.Hidden;


            Write_to_Change_in_Grid_Product.Visibility = Visibility.Hidden;
            Write_to_Change_in_Grid_Cost.Visibility = Visibility.Hidden;
            Write_to_Change_in_Grid_Description.Visibility = Visibility.Hidden;
            Change_in_Grid.Visibility = Visibility.Hidden;
            Name_to_Change.Visibility = Visibility.Hidden;

            Write_to_Change_in_Grid_Count.Visibility = Visibility.Visible;
            Write_to_Add_in_Grid_Count.Visibility = Visibility.Visible;

            Add_to_Grid_Stock.Visibility = Visibility.Visible;
            Delete_in_Grid_Stock.Visibility= Visibility.Visible;
            Change_in_Grid_Stock.Visibility = Visibility.Visible;

            Name_to_Change_Stock.Visibility = Visibility.Visible;
            Name_to_Delete_Stock.Visibility = Visibility.Visible;


            Products_DataGrid.ItemsSource = product.GetData();
            Stock_DataGrid.ItemsSource = stock.GetDataBy1();

            Name_to_Delete.ItemsSource = product.GetData();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = product.GetData();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = product.GetData();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = product.GetData();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";
        }

        private void Add_to_Grid_Stock_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int.TryParse(Write_to_Add_in_Grid_Count.Text, out count);

            stock.InsertQuery();
            int maxProductId = product.GetData().Max(row => row.Product_ID);
            stock.UpdateQuery(count, maxProductId);


            Write_to_Add_in_Grid_Count.Text = "Введите количество";


            Products_DataGrid.ItemsSource = product.GetData();
            Stock_DataGrid.ItemsSource = stock.GetDataBy1();

            Name_to_Delete.ItemsSource = product.GetData();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = product.GetData();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = product.GetData();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = product.GetData();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";
        }

        private void Change_in_Grid_Stock_Click(object sender, RoutedEventArgs e)
        {
            DataRowView Name_to_up_in_products = (DataRowView)Name_to_Change_Stock.SelectedItem;
            int productId_by_name = Convert.ToInt32(Name_to_up_in_products["Product_ID"]);

            int count = 0;
            int.TryParse(Write_to_Change_in_Grid_Count.Text, out count);

            stock.UpdateQueryStockCount(count, productId_by_name);


            Write_to_Change_in_Grid_Count.Text = "Введите количество";

            Products_DataGrid.ItemsSource = product.GetData();
            Stock_DataGrid.ItemsSource = stock.GetDataBy1();

            Name_to_Delete.ItemsSource = product.GetData();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = product.GetData();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = product.GetData();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = product.GetData();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

        }

        private void Delete_in_Grid_Stock_Click(object sender, RoutedEventArgs e)
        {
            DataRowView Name_to_del_in_stock = (DataRowView)Name_to_Delete_Stock.SelectedItem;
            int productId_by_name = Convert.ToInt32(Name_to_del_in_stock["Product_ID"]);

            stock.DeleteQuery(productId_by_name);

            if (Name_to_Delete_Stock.SelectedItem != null)
            {
                DataRowView Name_to_del_in_product = (DataRowView)Name_to_Delete_Stock.SelectedItem;
                string productName = Name_to_del_in_product["Product_Name"].ToString();

                product.DeleteQuery(productName);
                Products_DataGrid.ItemsSource = product.GetData();
            }


            Products_DataGrid.ItemsSource = product.GetData();
            Stock_DataGrid.ItemsSource = stock.GetDataBy1();

            Name_to_Delete.ItemsSource = product.GetData();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = product.GetData();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = product.GetData();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = product.GetData();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";
        }
    }
}