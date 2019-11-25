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
using System.Windows.Shapes;
using KarmaClient.OrderServiceRef;
using KarmaClient.ProductServiceRef;
using KarmaClient.EmployeeServiceRef;
using Product = KarmaClient.ProductServiceRef.Product;
using Table = KarmaClient.OrderServiceRef.Table;
using Employee = KarmaClient.EmployeeServiceRef.Employee;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for FinishOrderWindow.xaml
    /// </summary>
    public partial class FinishOrderWindow : Window
    {

        #region For testing
        private readonly ProductServicesClient _pClient = new ProductServicesClient();
        private readonly List<Product> _availableTables;
        private readonly List<Product> _selectedTables = new List<Product>();
        #endregion

        /// <summary>
        /// Client reference for the Order service.
        /// </summary>
        private readonly OrderServiceClient _oClient = new OrderServiceClient();
        private readonly EmployeeServiceClient _eClient = new EmployeeServiceClient();
        public Order CurrentOrder { get; set; }
        public List<Table> ListData { get; set; }


        public FinishOrderWindow()
        {
            InitializeComponent();
            _availableTables = _pClient.GetAllProducts().ToList();
            PopulateLists();
        }

        private void PopulateLists()
        {
            EmployeeComboBox.ItemsSource = null;
            EmployeeComboBox.ItemsSource = _eClient.GetAllEmployees();

            TableListBox.ItemsSource = null;
            TableListBox.ItemsSource = _availableTables;
            //TableListBox.ItemsSource = ListData;

            SelectedTablesListBox.ItemsSource = null;
            SelectedTablesListBox.ItemsSource = _selectedTables;
        }

        private void SelectTableBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO change type to table
            foreach (Product selectedTable in TableListBox.SelectedItems)
            {
                _selectedTables.Add(selectedTable);
                _availableTables.Remove(_availableTables.Find(x => x == selectedTable));
            }
            PopulateLists();
        }

        private void RemoveTableBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO change type to table
            foreach (Product selectedTable in SelectedTablesListBox.SelectedItems)
            {
                _availableTables.Add(selectedTable);
                _selectedTables.Remove(_selectedTables.Find(x => x == selectedTable));
            }
            PopulateLists();
        }

        private void CreateOrderBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //    CurrentOrder.Employee = (Employee) EmployeeComboBox.SelectionBoxItem;
            //    //CurrentOrder.Tables = _selectedTables.ToArray();
            //    _oClient.InsertOrder(CurrentOrder);

            //    this.Close();
        }
}
}
