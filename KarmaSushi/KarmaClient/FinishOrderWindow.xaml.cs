using System.Collections.Generic;
using System.Linq;
using System.Windows;
using KarmaClient.OrderServiceRef;
using KarmaClient.EmployeeServiceRef;
using KarmaClient.TableServiceRef;
using Table = KarmaClient.TableServiceRef.Table;
using Employee = KarmaClient.EmployeeServiceRef.Employee;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for FinishOrderWindow.xaml
    /// </summary>
    public partial class FinishOrderWindow : Window
    {
        /// <summary>
        /// Client reference for the Order service.
        /// </summary>
        private readonly OrderServiceClient _oClient = new OrderServiceClient();
        /// <summary>
        /// Client reference for the Employee service.
        /// </summary>
        private readonly EmployeeServiceClient _eClient = new EmployeeServiceClient();
        /// <summary>
        /// Client reference for the Table service.
        /// </summary>
        private readonly TableServicesClient _tClient = new TableServicesClient();
        /// <summary>
        /// List of all available tables from the database.
        /// </summary>
        private readonly List<Table> _availableTables;
        /// <summary>
        /// List of tables selected from available tables. To be saved with the Order.
        /// </summary>
        private readonly List<Table> _selectedTables = new List<Table>();

        /// <summary>
        /// Half finished order with missing fields that needs to be set.
        /// </summary>
        public Order CurrentOrder { get; set; }

        public FinishOrderWindow()
        {
            InitializeComponent();
            _availableTables = _tClient.GetAllTables();
            PopulateComboBox();
            PopulateLists();
        }

        private void PopulateComboBox()
        {
            EmployeeComboBox.ItemsSource = null;
            EmployeeComboBox.ItemsSource = _eClient.GetAllEmployees();
        }

        private void PopulateLists()
        {
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
            if (_selectedTables.Count > 0)
            {
                // Cast from EmployeeServiceRef.Employee to OrderServiceRef.Employee type.
                var selectedEmp = (Employee) EmployeeComboBox.SelectedItem;
                // Sets the Orders Employee with selected Employee.
                CurrentOrder.Employee = new OrderServiceRef.Employee
                {
                    Id = selectedEmp.Id, 
                    Name = selectedEmp.Name, 
                    Phone = selectedEmp.Phone, 
                    Email = selectedEmp.Email
                };

                // Linq method casts each selected table from TableServiceRef.Table to OrderServiceRef.Table type,
                // and sets the Orders Tables property with the created list.
                CurrentOrder.Tables = _selectedTables.Select(
                    t => new OrderServiceRef.Table
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToArray();
                
                // Inserts finished Order into database.
                _oClient.InsertOrder(CurrentOrder);
                
                this.Close();
            } 
            else
            {
                MessageBox.Show("Choose at least one table");
            }
        }

        private void AddCommentBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var cw = new CommentWindow { CurrentOrder = CurrentOrder };
            cw.Show();
        }
    }
}
