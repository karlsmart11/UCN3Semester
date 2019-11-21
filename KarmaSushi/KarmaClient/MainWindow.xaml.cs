using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using KarmaClient.OrderServiceRef;
using KarmaClient.ProductServiceRef;
using Product = KarmaClient.ProductServiceRef.Product;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Client reference for the Product service.
        /// </summary>
        private readonly ProductServicesClient _pClient = new ProductServicesClient();
        private readonly OrderServiceClient _oClient = new OrderServiceClient();
        /// <summary>
        /// List holding products to display in list of selected products.
        /// </summary>
        private readonly List<Product> _pList = new List<Product>();
        private readonly List<OrderLine> _oList = new List<OrderLine>();

        public MainWindow()
        {
            InitializeComponent();
            PopulateMenu();            
        }

        private void PopulateMenu()
        {
            foreach (var p in _pClient.GetAllProducts())
            {
                MenuPanel.Children.Add(CreateButton(p));
            }
        }

        // Create menu button object.
        private Button CreateButton(Product product)
        {
            // Grid defining the rows of stuff in the button.
            var rows = new Grid
            {
                RowDefinitions = { 
                    new RowDefinition(), 
                    new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
                    new RowDefinition()},
                Background = Brushes.Transparent,
                ShowGridLines = true,
                Height = 300, //Set this to match the height and width of the menuButton
                Width = 300
            };

            // Grid defining the two columns in the last row of the 'rows' grid.
            var columns = new Grid
            {
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) },
                    new ColumnDefinition() },
                Background = Brushes.Transparent
            };

            var nameLbl = new Label();
            rows.Children.Add(nameLbl);
            Grid.SetRow(nameLbl, 0);
            nameLbl.Content = product.Name;

            var descriptionLbl = new TextBlock{TextWrapping = TextWrapping.Wrap};
            rows.Children.Add(descriptionLbl);
            Grid.SetRow(descriptionLbl, 1);
            // If product.Description <= to 82 char put 
            descriptionLbl.Text = product.Description == null || product.Description.Length <= 178 ?
                product.Description : product.Description.Substring(0, Math.Min(178, product.Description.Length)) + ". . .";

            rows.Children.Add(columns);
            Grid.SetRow(columns, 2);

            var priceLbl = new Label();
            columns.Children.Add(priceLbl);
            Grid.SetColumn(priceLbl, 0);
            priceLbl.Content = product.Price;

            // Small button start--
            var bigDisBtn = new Button
            {
                Content = ">>>",
                Height = Double.NaN,
                Width = Double.NaN // Double.NaN = stretch from xaml
            };
            columns.Children.Add(bigDisBtn);
            Grid.SetColumn(bigDisBtn, 1);
            bigDisBtn.Click += (sender, e) => MessageBox.Show(product.Description);
            // --End small button

            var b = new Button
            {
                Content = rows,
                //Height = 120,  --Modify the button. Defaults for h+w can be found in App.xaml
                //Width = 120
            };

            // Attaches an event handler to the buttons click event
            b.Click += (sender, e) => AddToOrderList(product); 

            return b;
        }

        ///Adds menu item to order list by id
        private void AddToOrderList(Product p)
        {
            _pList.Add(p);

            //TODO create order line objects.

            UpdateOrderList();
        }

        private void CreateOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO add order lines to List<OrderLine>. Build Order object, populating all required properties.
            if (_pList.Count > 0)
            {
                var sum = new decimal(0.0);
                foreach (var p in _pList)
                {
                    //TODO Refactor p.price and order.price to matching type
                    sum =+ (decimal) p.Price;

                    var op = new OrderServiceRef.Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price
                    };

                    _oList.Add(new OrderLine
                    {
                        Product = op, 
                        Quantity = _pList.Count(x => x == p)
                    });
                }

                //TODO Find a way to attach tables
                var selectedTables = new List<Table>{new Table{Id = 1}, new Table{Id = 2}};

                var o = new Order
                {
                    Price = sum,
                    Employee = new Employee{Id = 1}, //TODO Find way to attach real employee
                    Tables = selectedTables.ToArray(),
                    OrderLines = _oList.ToArray()
                };

                _oClient.InsertOrder(o);
            }
            else
            {
                MessageBox.Show("No products selected");
            }

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // smallDel represents the small X buttons inside list
            Button smallDel = (Button) sender;
            if (smallDel != null)
            {
                if (smallDel.DataContext is Product product)
                {
                    _pList.Remove(product);
                }
            }
            else
            {
                foreach (var selected in OrderList.SelectedItems)
                {
                    _pList.Remove((Product) selected);
                }
            }

            UpdateOrderList();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            _pList.Clear();
            UpdateOrderList();
        }

        private void UpdateOrderList()
        {
            OrderList.ItemsSource = null;
            OrderList.ItemsSource = _pList;            
        }


        // This click event handler is only for demonstration purposes TODO remove when releasing
        private void LargeDescriptionButtonTemplate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Large Description of the product item goes here");
        }

    }
}
