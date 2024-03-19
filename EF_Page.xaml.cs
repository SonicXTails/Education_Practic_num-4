using Education_Practic_num_1.Information_System_Of_MarketDataSetTableAdapters;
using System;
using System.Collections.Generic;
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

namespace Education_Practic_num_1
{
    public partial class EF_Page : Page
    {
        private Information_System_Of_MarketEntitie context = new Information_System_Of_MarketEntitie();

        public EF_Page()
        {
            InitializeComponent();

            DataContext = new StockView();

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

            Products_DataGrid.ItemsSource = context.Products.ToList();
            Stock_DataGrid.ItemsSource = context.Stock.ToList();

            Name_to_Delete.ItemsSource = context.Products.ToList();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = context.Products.ToList();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = context.Products.ToList();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = context.Products.ToList();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

            using (var context = new Information_System_Of_MarketEntitie())
            {
                Stock_DataGrid.ItemsSource = context.StockView.ToList();
            }
        }
        private void Add_to_Grid_Click(object sender, RoutedEventArgs e)
        {
            Products product = new Products();
            product.Product_Name = Write_to_Add_in_Grid_Product.Text;

            float cost = 0;
            float.TryParse(Write_to_Add_in_Grid_Cost.Text, out cost);
            product.Product_Cost = cost;
            product.Product_Description = Write_to_Add_in_Grid_Description.Text;



            Stock_DataGrid.ItemsSource = context.Stock.ToList();
            context.Products.Add(product);
            context.SaveChanges();

            Write_to_Add_in_Grid_Product.Text = "Введите имя продукта";
            Write_to_Add_in_Grid_Cost.Text = "Введите стоимость";
            Write_to_Add_in_Grid_Description.Text = "Введите описание";


            Products_DataGrid.ItemsSource = context.Products.ToList();
            Stock_DataGrid.ItemsSource = context.Stock.ToList();

            Name_to_Delete.ItemsSource = context.Products.ToList();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = context.Products.ToList();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = context.Products.ToList();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = context.Products.ToList();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

            using (var context = new Information_System_Of_MarketEntitie())
            {
                Stock_DataGrid.ItemsSource = context.StockView.ToList();
            }
        }

        private void Change_in_Grid_Click(object sender, RoutedEventArgs e)
        {
            Products productToUpdate = Name_to_Change.SelectedItem as Products;
            productToUpdate.Product_Name = Write_to_Change_in_Grid_Product.Text;
            float cost = 0;
            float.TryParse(Write_to_Change_in_Grid_Cost.Text, out cost);
            productToUpdate.Product_Cost = cost;
            productToUpdate.Product_Description = Write_to_Change_in_Grid_Description.Text;
            context.SaveChanges();

            Products_DataGrid.ItemsSource = context.Products.ToList();
            Stock_DataGrid.ItemsSource = context.Stock.ToList();

            Name_to_Delete.ItemsSource = context.Products.ToList();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = context.Products.ToList();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = context.Products.ToList();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = context.Products.ToList();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

            using (var context = new Information_System_Of_MarketEntitie())
            {
                Stock_DataGrid.ItemsSource = context.StockView.ToList();
            }
        }

        private void Delete_in_Grid_Click(object sender, RoutedEventArgs e)
        {
            Products productToDelete = Name_to_Delete.SelectedItem as Products;

            var sell = context.Stock.Where(s => s.ID_Product == productToDelete.Product_ID);
            context.Stock.RemoveRange(sell);

            context.Products.Remove(productToDelete);
            context.SaveChanges();

            Products_DataGrid.ItemsSource = context.Products.ToList();
            Stock_DataGrid.ItemsSource = context.Stock.ToList();

            Name_to_Delete.ItemsSource = context.Products.ToList();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = context.Products.ToList();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = context.Products.ToList();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = context.Products.ToList();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

            using (var context = new Information_System_Of_MarketEntitie())
            {
                Stock_DataGrid.ItemsSource = context.StockView.ToList();
            }
        }

        private void Add_to_Grid_Stock_Click(object sender, RoutedEventArgs e)
        {
            Products product = new Products();
            product.Product_Name = Write_to_Add_in_Grid_Product.Text;
            float cost = 0;
            float.TryParse(Write_to_Add_in_Grid_Cost.Text, out cost);
            product.Product_Cost = cost;
            product.Product_Description = Write_to_Add_in_Grid_Description.Text;
            context.Products.Add(product);
            context.SaveChanges();

            int count = 0;
            int.TryParse(Write_to_Add_in_Grid_Count.Text, out count);

            Stock existingStockEntry = context.Stock.FirstOrDefault(s => s.ID_Product == product.Product_ID);
            if (existingStockEntry != null)
            {
                existingStockEntry.Stock_Number_of_Products = count;
            }
            else
            {
                Stock newStockEntry = new Stock
                {
                    Stock_Number_of_Products = count,
                    Stock_Date_of_Receipt = DateTime.Now,
                    ID_Product = product.Product_ID
                };
                context.Stock.Add(newStockEntry);
            }

            context.SaveChanges();


            Products_DataGrid.ItemsSource = context.Products.ToList();
            Stock_DataGrid.ItemsSource = context.Stock.ToList();

            Name_to_Delete.ItemsSource = context.Products.ToList();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = context.Products.ToList();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = context.Products.ToList();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = context.Products.ToList();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

            using (var context = new Information_System_Of_MarketEntitie())
            {
                Stock_DataGrid.ItemsSource = context.StockView.ToList();
            }

        }

        private void Change_in_Grid_Stock_Click(object sender, RoutedEventArgs e)
        {

            int count = 0;
            int.TryParse(Write_to_Change_in_Grid_Count.Text, out count);

            Products selectedProduct = Name_to_Change_Stock.SelectedItem as Products;

            Stock stockEntry = context.Stock.FirstOrDefault(s => s.ID_Product == selectedProduct.Product_ID);
            stockEntry.Stock_Number_of_Products = count;

            context.SaveChanges();


            Products_DataGrid.ItemsSource = context.Products.ToList();
            Stock_DataGrid.ItemsSource = context.Stock.ToList();

            Name_to_Delete.ItemsSource = context.Products.ToList();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = context.Products.ToList();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = context.Products.ToList();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = context.Products.ToList();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

            using (var context = new Information_System_Of_MarketEntitie())
            {
                Stock_DataGrid.ItemsSource = context.StockView.ToList();
            }
        }


        private void Delete_in_Grid_Stock_Click(object sender, RoutedEventArgs e)
        {
            Products productToDelete = Name_to_Delete_Stock.SelectedItem as Products;

            var relatedStockEntries = context.Stock.Where(s => s.ID_Product == productToDelete.Product_ID);
            context.Stock.RemoveRange(relatedStockEntries);

            context.Products.Remove(productToDelete);
            context.SaveChanges();

            Products_DataGrid.ItemsSource = context.Products.ToList();
            Stock_DataGrid.ItemsSource = context.Stock.ToList();

            Name_to_Delete.ItemsSource = context.Products.ToList();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = context.Products.ToList();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = context.Products.ToList();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = context.Products.ToList();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

            using (var context = new Information_System_Of_MarketEntitie())
            {
                Stock_DataGrid.ItemsSource = context.StockView.ToList();
            }
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

            Products_DataGrid.ItemsSource = context.Products.ToList();
            Stock_DataGrid.ItemsSource = context.Stock.ToList();

            Name_to_Delete.ItemsSource = context.Products.ToList();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = context.Products.ToList();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = context.Products.ToList();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = context.Products.ToList();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

            using (var context = new Information_System_Of_MarketEntitie())
            {
                Stock_DataGrid.ItemsSource = context.StockView.ToList();
            }
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

            Products_DataGrid.ItemsSource = context.Products.ToList();
            Stock_DataGrid.ItemsSource = context.Stock.ToList();

            Name_to_Delete.ItemsSource = context.Products.ToList();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = context.Products.ToList();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = context.Products.ToList();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = context.Products.ToList();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

            using (var context = new Information_System_Of_MarketEntitie())
            {
                Stock_DataGrid.ItemsSource = context.StockView.ToList();
            }
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
            Delete_in_Grid_Stock.Visibility = Visibility.Visible;
            Change_in_Grid_Stock.Visibility = Visibility.Visible;

            Name_to_Change_Stock.Visibility = Visibility.Visible;
            Name_to_Delete_Stock.Visibility = Visibility.Visible;

            Products_DataGrid.ItemsSource = context.Products.ToList();
            Stock_DataGrid.ItemsSource = context.Stock.ToList();

            Name_to_Delete.ItemsSource = context.Products.ToList();
            Name_to_Delete.DisplayMemberPath = "Product_Name";

            Name_to_Change.ItemsSource = context.Products.ToList();
            Name_to_Change.DisplayMemberPath = "Product_Name";

            Name_to_Delete_Stock.ItemsSource = context.Products.ToList();
            Name_to_Delete_Stock.DisplayMemberPath = "Product_Name";

            Name_to_Change_Stock.ItemsSource = context.Products.ToList();
            Name_to_Change_Stock.DisplayMemberPath = "Product_Name";

            using (var context = new Information_System_Of_MarketEntitie())
            {
                Stock_DataGrid.ItemsSource = context.StockView.ToList();
            }
        }
    }
}