using System.Collections.Generic;
using System.Linq;
using System.Windows;
using KarmaClient.OrderServiceRef;
using KarmaClient.ProductServiceRef;
using KarmaClient.EmployeeServiceRef;
using KarmaClient.TableServiceRef;
using Product = KarmaClient.ProductServiceRef.Product;
using Table = KarmaClient.TableServiceRef.Table;
using Employee = KarmaClient.EmployeeServiceRef.Employee;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for FinishOrderWindow.xaml
    /// </summary>
    public partial class FinishOrderWindow : Window
    {

        #region For testing
        private readonly List<Table> _availableTables;
        private readonly List<Table> _selectedTables = new List<Table>();
        #endregion

        /// <summary>
        /// Client reference for the Order service.
        /// </summary>
        private readonly OrderServiceClient _oClient = new OrderServiceClient();
        private readonly EmployeeServiceClient _eClient = new EmployeeServiceClient();
        private readonly TableServicesClient _tClient = new TableServicesClient();
        public Order CurrentOrder { get; set; }

        public FinishOrderWindow()
        {
            InitializeComponent();
            _availableTables = _tClient.GetAllTables();
            PopulateLists();
        }

        private void PopulateLists()
        {
            EmployeeComboBox.ItemsSource = null;
            EmployeeComboBox.ItemsSource = _eClient.GetAllEmployees();

            TableListBox.ItemsSource = null;
            TableListBox.ItemsSource = _availableTables;

            SelectedTablesListBox.ItemsSource = null;
            SelectedTablesListBox.ItemsSource = _selectedTables;
        }

        private void SelectTableBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Table selectedTable in TableListBox.SelectedItems)
            {
                _selectedTables.Add(selectedTable);
                _availableTables.Remove(_availableTables.Find(x => x == selectedTable));
            }
            PopulateLists();
        }

        private void RemoveTableBtn_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (Table selectedTable in SelectedTablesListBox.SelectedItems)
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
