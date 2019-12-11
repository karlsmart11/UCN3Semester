using System;
using System.Globalization;
using System.Windows;
using KarmaClient.CategoryServiceRef;
using KarmaClient.CustomerServiceRef;
using KarmaClient.ProductServiceRef;
using KarmaClient.EmployeeServiceRef;
using KarmaClient.TableServiceRef;
using Category = KarmaClient.CategoryServiceRef.Category;

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

        public ModificationWindow(MainWindow.TypeOfItem typeOfItem)
        {
            InitializeComponent();
            SetTxtAndLabels(typeOfItem);

            SaveBtn.Click += (s, a) => Save(typeOfItem);
           
            RefreshBtn.Click += (s, a) => Refresh(typeOfItem);

        }

        private void SetTxtAndLabels(MainWindow.TypeOfItem typeOfItem)
        {
            //Initialize combo boxes
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

                    ComboBox.DropDownClosed += (s, a) =>
                    {
                        _currProduct = (Product)ComboBox.SelectionBoxItem;

                        Txt2.Text = _currProduct.Name;
                        Txt3.Text = _currProduct.Description;
                        Txt4.Text = _currProduct.Price.ToString(CultureInfo.CurrentCulture);
                        Txt5.Text = _currProduct.Category.Name;
                        ComboBox5.SelectedItem = _currProduct.Category; //TODO Fix so current products category is pre-selected in combobox
                        SaveBtn.IsEnabled = true;
                    };

                    GoBtn.Click += (sender, args) =>
                    {
                        _currProduct = (Product) ComboBox.SelectionBoxItem;
                        
                        Txt2.Text = _currProduct.Name;
                        Txt3.Text = _currProduct.Description;
                        Txt4.Text = _currProduct.Price.ToString(CultureInfo.CurrentCulture);
                        Txt5.Text = _currProduct.Category.Name;
                        ComboBox5.SelectedItem = _currProduct.Category; //TODO Fix so current products category is pre-selected in combobox
                        SaveBtn.IsEnabled = true;
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

                    ComboBox.DropDownClosed += (s, a) =>
                    {
                        _currCategory = (Category)ComboBox.SelectionBoxItem;

                        Txt2.Text = _currCategory.Name;
                        SaveBtn.IsEnabled = true;
                    };

                    GoBtn.Click += (sender, args) =>
                    {
                        _currCategory = (Category)ComboBox.SelectionBoxItem;

                        Txt2.Text = _currCategory.Name;
                        SaveBtn.IsEnabled = true;
                    };
                    break;

                case MainWindow.TypeOfItem.Cus:
                    Label1.Content = "Select Customer:";
                    Label2.Content = "Name:";
                    Label3.Content = "Phone:";
                    Label4.Content = "Email:";
                    Label5.Content = "Address:";

                    ComboBox.ItemsSource = _cClient.GetAllCustomers();

                    ComboBox.DropDownClosed += (s, a) =>
                    {
                        _currCustomer = (Customer)ComboBox.SelectionBoxItem;

                        Txt2.Text = _currCustomer.Name;
                        Txt3.Text = _currCustomer.Phone;
                        Txt4.Text = _currCustomer.Email;
                        Txt5.Text = _currCustomer.Address;
                        SaveBtn.IsEnabled = true;
                    };

                    GoBtn.Click += (sender, args) =>
                    {
                        _currCustomer = (Customer) ComboBox.SelectionBoxItem;

                        Txt2.Text = _currCustomer.Name;
                        Txt3.Text = _currCustomer.Phone;
                        Txt4.Text = _currCustomer.Email;
                        Txt5.Text = _currCustomer.Address;
                        SaveBtn.IsEnabled = true;
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

                    ComboBox.DropDownClosed += (s, a) =>
                    {
                        _currEmployee = (Employee)ComboBox.SelectionBoxItem;

                        Txt2.Text = _currEmployee.Name;
                        Txt3.Text = _currEmployee.Phone;
                        Txt4.Text = _currEmployee.Email;

                        SaveBtn.IsEnabled = true;
                    };

                    GoBtn.Click += (sender, args) =>
                    {
                        _currEmployee = (Employee) ComboBox.SelectionBoxItem;

                        Txt2.Text = _currEmployee.Name;
                        Txt3.Text = _currEmployee.Phone;
                        Txt4.Text = _currEmployee.Email;

                        SaveBtn.IsEnabled = true;
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

                    ComboBox.DropDownClosed += (s, a) =>
                    {
                        _currTable = (Table)ComboBox.SelectionBoxItem;

                        Txt2.Text = _currTable.Name;
                        Txt3.Text = _currTable.Seats.ToString();
                        SaveBtn.IsEnabled = true;
                    };

                    GoBtn.Click += (sender, args) =>
                    {
                        _currTable = (Table) ComboBox.SelectionBoxItem;

                        Txt2.Text = _currTable.Name;
                        Txt3.Text = _currTable.Seats.ToString();
                        SaveBtn.IsEnabled = true;
                    };
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(typeOfItem), typeOfItem, null);
            }
        }

        private void Save(MainWindow.TypeOfItem typeOfItem)
        {
            switch (typeOfItem)
            {
                case MainWindow.TypeOfItem.Emp:
                    _currEmployee.Name = Txt2.Text;
                    _currEmployee.Phone = Txt3.Text;
                    _currEmployee.Email = Txt4.Text;

                    try
                    {
                        _eClient.ModifyEmployee(_currEmployee);
                        Close();
                    }
                    catch (System.ServiceModel.FaultException<EmployeeServiceRef.Error> ex)
                    {
                        MessageBox.Show($"Error code: {ex.Detail.ErrorCode}\n" +
                                        $"Message: {ex.Detail.Message}\n" +
                                        $"Details: {ex.Detail.Description}");
                    }
                    break;

                case MainWindow.TypeOfItem.Cat:
                    _currCategory.Name = Txt2.Text;

                    try
                    {
                        _catClient.ModifyCategory(_currCategory);
                        Close();
                    }
                    catch (System.ServiceModel.FaultException<CategoryServiceRef.Error> ex)
                    {
                        MessageBox.Show($"Error code: {ex.Detail.ErrorCode}\n" +
                                        $"Message: {ex.Detail.Message}\n" +
                                        $"Details: {ex.Detail.Description}");
                    }
                    break;

                case MainWindow.TypeOfItem.Cus:
                    _currCustomer.Name = Txt2.Text;
                    _currCustomer.Phone = Txt3.Text;
                    _currCustomer.Email = Txt4.Text;
                    _currCustomer.Address = Txt5.Text;

                    try
                    {
                        _cClient.ModifyCustomer(_currCustomer);
                        Close();
                    }
                    catch (System.ServiceModel.FaultException<CustomerServiceRef.Error> ex)
                    {
                        MessageBox.Show($"Error code: {ex.Detail.ErrorCode}\n" +
                                        $"Message: {ex.Detail.Message}\n" +
                                        $"Details: {ex.Detail.Description}");
                    }
                    break;

                case MainWindow.TypeOfItem.Pro:
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
                        Close();
                    }
                    catch (System.ServiceModel.FaultException<ProductServiceRef.Error> ex)
                    {
                        MessageBox.Show($"Error code: {ex.Detail.ErrorCode}\n" +
                                        $"Message: {ex.Detail.Message}\n" +
                                        $"Details: {ex.Detail.Description}");
                    }
                    break;

                case MainWindow.TypeOfItem.Tab:
                    _currTable.Name = Txt2.Text;
                    _currTable.Seats = int.Parse(Txt3.Text);

                    try
                    {
                        _tClient.ModifyTable(_currTable);
                        Close();
                    }
                    catch (System.ServiceModel.FaultException<TableServiceRef.Error> ex)
                    {
                        MessageBox.Show($"Error code: {ex.Detail.ErrorCode}\n" +
                                        $"Message: {ex.Detail.Message}\n" +
                                        $"Details: {ex.Detail.Description}");
                    }
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

        private void Refresh(MainWindow.TypeOfItem type)
        {
            Txt2.Text = "";
            Txt3.Text = "";
            Txt4.Text = "";
            Txt5.Text = "";
            switch (type)
            {
                case MainWindow.TypeOfItem.Cat:
                    ComboBox.ItemsSource = _catClient.GetAllCategories();
                    break;
                case MainWindow.TypeOfItem.Cus:
                    ComboBox.ItemsSource = _cClient.GetAllCustomers();
                    break;
                case MainWindow.TypeOfItem.Emp:
                    ComboBox.ItemsSource = _eClient.GetAllEmployees();
                    break;
                case MainWindow.TypeOfItem.Pro:
                    ComboBox.ItemsSource = _pClient.GetAllProducts();
                    ComboBox5.ItemsSource = null;
                    break;
                case MainWindow.TypeOfItem.Tab:
                    ComboBox.ItemsSource = _tClient.GetAllTables();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

      

       
    }
}