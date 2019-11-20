using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KarmaClient.ProductServiceRef;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProductServicesClient client = new ProductServicesClient();
        private List<Product> pList = new List<Product>(); 
        public MainWindow()
        {
            InitializeComponent();
            PopulateMenu();            
        }

        private void PopulateMenu()
        {
            foreach (var p in client.GetAllProducts())
            {
                MenuPanel.Children.Add(new Button { Content = CreateButton(p) });
            }
        }

        //Create menu button object
        private Button CreateButton(Product product)
        {
            var rows = new Grid
            {
                RowDefinitions = { new RowDefinition(), new RowDefinition(), new RowDefinition()},
                
            };

            var columns = new Grid
            {
                ColumnDefinitions = {new ColumnDefinition(), new ColumnDefinition()},

            };
            
            rows.Children.Add(columns);
            Grid.SetRow(columns, 2);

            var namelbl = new Label();
            rows.Children.Add(namelbl);
            Grid.SetRow(namelbl, 0);
            namelbl.Content = product.Name;

            var descriptionlbl = new Label();
            rows.Children.Add(descriptionlbl);
            Grid.SetRow(descriptionlbl, 1);
            descriptionlbl.Content = product.Description;

            var pricelbl = new Label();
            columns.Children.Add(pricelbl);
            Grid.SetColumn(pricelbl, 0);
            descriptionlbl.Content = product.Price;

            var b = new Button
            {
                Content = rows
            };

            b.Click += new RoutedEventHandler((sender, e) => AddToOrderList(sender, e, product)); 

            return b;
        }

        ///Adds menu item to order list by id
        private void AddToOrderList(object sender, RoutedEventArgs e, Product p)
        {
            pList.Add(p);
            UpdateOrderList();
        }

        private void UpdateOrderList()
        {
            OrderList.ItemsSource = null;
            OrderList.ItemsSource = pList;            
        }
    }
}
