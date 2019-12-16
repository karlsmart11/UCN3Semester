using KarmaClient.CustomerServiceRef;
using System;
using System.Windows;

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for CreateCustomerWindow.xaml
    /// </summary>
    public partial class CreateCustomerWindow : Window
    {
        private readonly CustomerServiceClient _cClient = new CustomerServiceClient();
       private Customer _currCustomer = new Customer();
        public CreateCustomerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _currCustomer.Name = txtName.Text;
            _currCustomer.Phone = txtPhone.Text;
            _currCustomer.Email = txtEmail.Text;
            _currCustomer.Address = txtAddress.Text;
            try
            {
                _cClient.InsertCustomer(_currCustomer);
                MessageBox.Show("Customer created");
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
