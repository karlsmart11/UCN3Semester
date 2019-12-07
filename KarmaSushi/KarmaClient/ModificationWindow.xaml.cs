using System;
using System.Globalization;
using System.Windows;
using KarmaClient.CategoryServiceRef;
using KarmaClient.CustomerServiceRef;
using KarmaClient.ProductServiceRef;
using KarmaClient.EmployeeServiceRef;
using KarmaClient.TableServiceRef;
using Category = KarmaClient.CategoryServiceRef.Category;
using Error = KarmaClient.ProductServiceRef.Error;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for ModificationWindow.xaml
    /// </summary>
    public partial class ModificationWindow : Window
    {
        private readonly ProductServicesClient _pClient = new ProductServicesClient();
        private readonly EmployeeServiceClient _eClient = new EmployeeServiceClient();
        private readonly TableServicesClient _tClient = new TableServicesClient();
        private readonly CustomerServiceClient _cClient = new CustomerServiceClient();
        private readonly CategoryServiceClient _catClient = new CategoryServiceClient();

        private Customer _currCustomer;
        private Category _currCategory;
        private Employee _currEmployee;
        private Product _currProduct;
        private Table _currTable;

        public ModificationWindow()
        {
            InitializeComponent();
        }

        public ModificationWindow(MainWindow.TypeOfItem typeOfItem)
        {
            InitializeComponent();
            SetTxtAndLabels(typeOfItem);

            SaveBtn.Click += (sender, args) => Save(typeOfItem);
        }

        private void SetTxtAndLabels(MainWindow.TypeOfItem typeOfItem)
        {
            ComboBox.ItemsSource = null;
            ComboBox5.ItemsSource = null;

            switch (typeOfItem)
            {
                case MainWindow.TypeOfItem.Pro:
                    Label1.Content = "Select Product:";
                    Label2.Content = "Name:";
                    Label3.Content = "Description:";
                    Label4.Content = "Price:";
                    Label5.Content = "Category:";

                    Txt5.IsEnabled = false;

                    ComboBox.ItemsSource = _pClient.GetAllProducts();
                    ComboBox5.Visibility = Visibility.Visible;
                    ComboBox5.ItemsSource = _catClient.GetAllCategories();

                    GoBtn.Click += (sender, args) =>
                    {
                        _currProduct = (Product) ComboBox.SelectionBoxItem;
                        
                        Txt2.Text = _currProduct.Name;
                        Txt3.Text = _currProduct.Description;
                        Txt4.Text = _currProduct.Price.ToString(CultureInfo.CurrentCulture);
                        Txt5.Text = _currProduct.Category.Name;
                        ComboBox5.SelectedItem = _currProduct.Category; //TODO Fix so current products category is pre-selected in combobox
                    };
                    break;

                case MainWindow.TypeOfItem.Cat:
                    Label1.Content = "Select Category";
                    Label2.Content = "Name:";
                    Label3.Visibility = Visibility.Hidden;
                    Label4.Visibility = Visibility.Hidden;
                    Label5.Visibility = Visibility.Hidden;

                    Txt3.Visibility = Visibility.Hidden;
                    Txt4.Visibility = Visibility.Hidden;
                    Txt5.Visibility = Visibility.Hidden;

                    ComboBox.ItemsSource = _catClient.GetAllCategories();

                    GoBtn.Click += (sender, args) =>
                    {
                        _currCategory = (Category) ComboBox.SelectionBoxItem;

                        Txt2.Text = _currCategory.Name;
                    };
                    break;

                case MainWindow.TypeOfItem.Cus:
                    Label1.Content = "Select Customer:";
                    Label2.Content = "Name:";
                    Label3.Content = "Phone:";
                    Label4.Content = "Email:";
                    Label5.Content = "Address:";

                    ComboBox.ItemsSource = _cClient.GetAllCustomers();

                    GoBtn.Click += (sender, args) =>
                    {
                        _currCustomer = (Customer) ComboBox.SelectionBoxItem;

                        Txt2.Text = _currCustomer.Name;
                        Txt3.Text = _currCustomer.Phone;
                        Txt4.Text = _currCustomer.Email;
                        Txt5.Text = _currCustomer.Address;
                    };
                    break;

                case MainWindow.TypeOfItem.Emp:
                    Label1.Content = "Select Employee:";
                    Label2.Content = "Name:";
                    Label3.Content = "Phone:";
                    Label4.Content = "Email:";
                    Label5.Visibility = Visibility.Hidden;

                    Txt5.Visibility = Visibility.Hidden;

                    ComboBox.ItemsSource = _eClient.GetAllEmployees();

                    GoBtn.Click += (sender, args) =>
                    {
                        _currEmployee = (Employee) ComboBox.SelectionBoxItem;

                        Txt2.Text = _currEmployee.Name;
                        Txt3.Text = _currEmployee.Phone;
                        Txt4.Text = _currEmployee.Email;
                    };
                    break;

                case MainWindow.TypeOfItem.Tab:
                    Label1.Content = "Select Category";
                    Label2.Content = "Name:";
                    Label3.Content = "Seats:";
                    Label4.Visibility = Visibility.Hidden;
                    Label5.Visibility = Visibility.Hidden;

                    Txt4.Visibility = Visibility.Hidden;
                    Txt5.Visibility = Visibility.Hidden;

                    ComboBox.ItemsSource = _tClient.GetAllTables();

                    GoBtn.Click += (sender, args) =>
                    {
                        _currTable = (Table) ComboBox.SelectionBoxItem;

                        Txt2.Text = _currTable.Name;
                        Txt3.Text = _currTable.Seats.ToString();
                    };
                    break;

                default:
                    MessageBox.Show("Default");
                    break;
            }
        }

        private void Save(MainWindow.TypeOfItem typeOfItem)
        {
            switch (typeOfItem)
            {
                case MainWindow.TypeOfItem.Emp:
                    if (_currEmployee != null)
                    {
                        _currEmployee.Name = Txt2.Text;
                        _currEmployee.Phone = Txt3.Text;
                        _currEmployee.Email = Txt4.Text;
                        
                        _eClient.ModifyEmployee(_currEmployee);
                    }
                    Close();
                    break;

                case MainWindow.TypeOfItem.Cat:
                    if (_currCategory != null)
                    {
                        _currCategory.Name = Txt2.Text;

                        _catClient.ModifyCategory(_currCategory);
                    }
                    Close();
                    break;

                case MainWindow.TypeOfItem.Cus:
                    if (_currCustomer != null)
                    {
                        _currCustomer.Name = Txt2.Text;
                        _currCustomer.Phone = Txt3.Text;
                        _currCustomer.Email = Txt4.Text;
                        _currCustomer.Address = Txt5.Text;

                        _cClient.ModifyCustomer(_currCustomer);
                    }
                    Close();
                    break;

                case MainWindow.TypeOfItem.Pro:
                    if (_currProduct != null)
                    {
                        _currProduct.Name = Txt2.Text;
                        _currProduct.Description = Txt3.Text;
                        _currProduct.Price = double.Parse(Txt4.Text);

                        var catFromBox = (Category) ComboBox5.SelectionBoxItem;
                        if (catFromBox != null)
                        {
                            _currProduct.Category = new ProductServiceRef.Category
                            {
                                Id = catFromBox.Id,
                                Name = catFromBox.Name
                            };
                        }
                        try
                        {
                            _pClient.ModifyProduct(_currProduct);
                        }
                        catch (System.ServiceModel.FaultException<Error> ex)
                        {
                            MessageBox.Show( 
                                "Error code: " + ex.Detail.ErrorCode
                                               + "Message: " + ex.Detail.Message
                                               + "Details: " + ex.Detail.Description);
                        }
                    }
                    Close();
                    break;

                case MainWindow.TypeOfItem.Tab:
                    if (_currTable != null)
                    {
                        _currTable.Name = Txt2.Text;
                        _currTable.Seats = int.Parse(Txt3.Text);
                    }
                    Close();
                    break;
                default:
                    MessageBox.Show("Please choose something to modify.");
                    break;
            }
        }
        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}