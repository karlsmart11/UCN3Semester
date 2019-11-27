using KarmaClient.OrderServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace KarmaClient
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public static OrderServiceRef.OrderServiceClient proxyOder = new OrderServiceRef.OrderServiceClient();
        public static Order[] arrayOrder = proxyOder.GetAllOrders();
       // public static OrderLine[] arrayOrderLine = proxyOder.
        public OrderWindow()
        {
            InitializeComponent();
    
            populateDataGridWithSOAP();
        }


        public void populateDataGridWithSOAP()
        {
          

            DataTable dt = setUpDataGrid();

           

            try
            {

                List<int> IdOrdersList = new List<int>();
                foreach (var item in arrayOrder)
            {

                DateTime date = item.Time;

                DateTime dateNow = DateTime.Today;

                int result = DateTime.Compare(date.Date, dateNow.Date);
                if (result==0)
                {
                    DataRow newRow = dt.NewRow();
                    newRow[0] = item.Price.ToString();
                    newRow[1] = date;
                    newRow[2] = item.Customer.Name.ToString();
                    newRow[3] = item.Employee.Name.ToString();
                    IdOrdersList.Add(item.Id);
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

                List<int> IdOrdersList = new List<int>();
                foreach (var item in arrayOrder)
                {

                    DateTime date = item.Time;

                    DateTime dateNow = DataSelected.SelectedDate.Value;
                    
                    int result = DateTime.Compare(date.Date, dateNow.Date);
                    if (result == 0)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow[0] = item.Price.ToString();
                        newRow[1] = date;
                        newRow[2] = item.Customer.Name.ToString();
                        newRow[3] = item.Employee.Name.ToString();
                        IdOrdersList.Add(item.Id);
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

           
            dt.Columns.Add(Price);
            dt.Columns.Add(Time);
            dt.Columns.Add(Customer);
            dt.Columns.Add(Employee);
          
            return dt;

        }
    }
}
