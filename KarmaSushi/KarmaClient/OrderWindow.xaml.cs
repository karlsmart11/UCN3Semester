using KarmaClient.OrderServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
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

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public readonly OrderServiceClient _oClient = new OrderServiceClient();

        public Order[] arrayOrder;
        public int selecetedId = -1;
        public List<int> IdOrdersList;

        public OrderWindow()
        {
            InitializeComponent();
            arrayOrder = _oClient.GetAllOrders();
            populateDataGridWithSOAP();
        }

        public void updateDataGrid()
        {
            DataTable dt = setUpDataGrid();

            try
            {
                IdOrdersList = new List<int>();

                foreach (var item in arrayOrder)
                {
                    DateTime date = item.Time;
                    DateTime dateNow = DataSelected.SelectedDate.Value;
                    TextBox textBoxProductsName = new TextBox();
                    int result = DateTime.Compare(date.Date, dateNow.Date);

                    if (result == 0)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow[0] = item.Price.ToString();
                        newRow[1] = date;

                        if (item.Customer != null)
                        {
                            newRow[2] = item.Customer.Name.ToString();
                        }
                        else
                        {
                            newRow[2] = null;
                        }

                        newRow[3] = item.Employee.Name.ToString();
                        IdOrdersList.Add(item.Id);

                        foreach (var orderLinesItem in item.OrderLines)
                        {
                            textBoxProductsName.Text += (orderLinesItem.Product.Name.ToString() + " X ");
                            textBoxProductsName.Text += (orderLinesItem.Quantity.ToString() + " \n");
                        }

                        newRow[4] = textBoxProductsName.Text;
                        dt.Rows.Add(newRow);
                    }
                }

                GridOrder.ItemsSource = dt.DefaultView;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void populateDataGridWithSOAP()
        {
            DataTable dt = setUpDataGrid();

            try
            {
                IdOrdersList = new List<int>();

                foreach (var item in arrayOrder)
                {
                    DateTime date = item.Time;
                    DateTime dateNow = DateTime.Today;                    
                    TextBox textBoxProductsName = new TextBox();
                    int result = DateTime.Compare(date.Date, dateNow.Date);

                    if (result == 0)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow[0] = item.Price.ToString();
                        newRow[1] = date;

                        if (item.Customer != null)
                        {
                            newRow[2] = item.Customer.Name.ToString();
                        }
                        else
                        {
                            newRow[2] = null;
                        }

                        newRow[3] = item.Employee.Name.ToString();
                        IdOrdersList.Add(item.Id);

                        foreach (var orderLinesItem in item.OrderLines)
                        {
                            textBoxProductsName.Text += (orderLinesItem.Product.Name.ToString() + " X ");
                            textBoxProductsName.Text += (orderLinesItem.Quantity.ToString() + " \n");
                        }

                        newRow[4] = textBoxProductsName.Text;
                        dt.Rows.Add(newRow);
                    }

                }

                GridOrder.ItemsSource = dt.DefaultView;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void DataSelected_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable dt = setUpDataGrid();

            try
            {
                IdOrdersList = new List<int>();

                foreach (var item in arrayOrder)
                {
                    DateTime date = item.Time;
                    DateTime dateNow = DataSelected.SelectedDate.Value;
                    int result = DateTime.Compare(date.Date, dateNow.Date);
                    TextBox textBoxProductsName = new TextBox();

                    if (result == 0)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow[0] = item.Price.ToString();
                        newRow[1] = date;

                        if (item.Customer != null)
                        {
                            newRow[2] = item.Customer.Name.ToString();
                        }
                        else
                        {
                            newRow[2] = null;
                        }

                        newRow[3] = item.Employee.Name.ToString();
                        IdOrdersList.Add(item.Id);

                        foreach (var orderLinesItem in item.OrderLines)
                        {
                            textBoxProductsName.Text += (orderLinesItem.Product.Name.ToString() + " X ");
                            textBoxProductsName.Text += (orderLinesItem.Quantity.ToString() + " \n");
                        }

                        newRow[4] = textBoxProductsName.Text;
                        dt.Rows.Add(newRow);
                    }
                }

                GridOrder.ItemsSource = dt.DefaultView;
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        public DataTable setUpDataGrid()
        {
            DataTable dt = new DataTable();
            DataColumn Price = new DataColumn("Price", typeof(decimal));
            DataColumn Time = new DataColumn("Time", typeof(DateTime));
            DataColumn Customer = new DataColumn("Customer", typeof(string));
            DataColumn Employee = new DataColumn("Employee", typeof(string));
            DataColumn Products = new DataColumn("Product", typeof(string));

            dt.Columns.Add(Price);
            dt.Columns.Add(Time);
            dt.Columns.Add(Customer);
            dt.Columns.Add(Employee);
            dt.Columns.Add(Products);

            return dt;
        }

        private void GridOrder_CurrentCellChanged(object sender, EventArgs e)
        {
            int currentRowIndex = GridOrder.Items.IndexOf(GridOrder.CurrentItem);

            if (currentRowIndex >= 0)
            {
                selecetedId = IdOrdersList[currentRowIndex];
                Test.Content = currentRowIndex;
                TestOrderLineId.Content = selecetedId;
            }
            else
            {
                Test.Content = currentRowIndex;
                TestOrderLineId.Content = selecetedId;
            }
        }

        private void ModityOrder_Click(object sender, RoutedEventArgs e)
        {
            if (selecetedId != -1)
            {
                Order order = _oClient.GetOrderById(selecetedId.ToString());
                ModifyOrderWindow modifyOrderWindow = new ModifyOrderWindow(order);
                modifyOrderWindow.Show();
                selecetedId = -1;
                //if (proxyOder.State == CommunicationState.Opened)
                //    proxyOder.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("No order selected");
            }
        }

        private void CancelOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (selecetedId != -1)
            {
                _oClient.DeleteOrder(selecetedId.ToString());
                arrayOrder = _oClient.GetAllOrders();
                updateDataGrid();
            }
            else
            {
                MessageBox.Show("No order selected");
            }
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
