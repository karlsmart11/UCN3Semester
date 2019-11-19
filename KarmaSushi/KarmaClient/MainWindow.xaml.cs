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
                MenuPanel.Children.Add(new Button { Content = new Button { Content = currentOrder.Time } });
            }
            
        }
    }
}
