using System.Windows;
using System.Windows.Controls;
using KarmaClient.OrderServiceRef;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ///private readonly List<Button> _MenuItems = new List<Button>;
        public MainWindow()
        {
            InitializeComponent();

            OrderServiceClient client = new OrderServiceClient();

            System.Console.WriteLine("test");
          

            MenuPanel.Children.Add(new Button { Content = "test" });
            MenuPanel.Children.Add(new Button { Content = client.GetOrderById("5").Price.ToString() });
            
            foreach (var currentOrder in client.GetAllOrders())
            {
                MenuPanel.Children.Add(new Button { Content = new Button { Content = currentOrder.Time, FontSize = 8} });
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

            b.Click += RoutedEventHandler(addToOrderList);

            return b;
        }

        ///Adds menu item to order list by id
        private void addToOrderList(object sender, RoutedEventArgs e)
        {
            
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
