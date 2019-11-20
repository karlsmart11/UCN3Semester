﻿using System;
using System.Collections.Generic;
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
        private readonly ProductServicesClient _client = new ProductServicesClient();
        /// <summary>
        /// List holding products to display in list of selected products.
        /// </summary>
        private readonly List<Product> _pList = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();
            PopulateMenu();            
        }

        private void PopulateMenu()
        {
            foreach (var p in _client.GetAllProducts())
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
                RowDefinitions = { new RowDefinition(), new RowDefinition(), new RowDefinition()},
                Background = Brushes.Transparent,
                ShowGridLines = true,
                Height = 300, //Set this to match the height and width of the menuButton
                Width = 300
            };

            // Grid defining the two columns in the last row of the 'rows' grid.
            var columns = new Grid
            {
                ColumnDefinitions = { new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) },
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
            descriptionLbl.Text = product.Description == null || product.Description.Length <= 82 ?
                product.Description : product.Description.Substring(0, Math.Min(82, product.Description.Length));

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
            //Client.InsertOrder(Order)
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var selected in OrderList.SelectedItems)
            {
                _pList.Remove((Product)selected);
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
