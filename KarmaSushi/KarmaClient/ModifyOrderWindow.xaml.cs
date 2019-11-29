
using KarmaClient.EmployeeServiceRef;
using KarmaClient.OrderServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ModifyOrderWindow.xaml
    /// </summary>
    public partial class ModifyOrderWindow : Window
    {
        private int employeeId = -1;
     
        public static EmployeeServiceRef.EmployeeServiceClient  proxyEmployee = new EmployeeServiceRef.EmployeeServiceClient();
        public static OrderServiceRef.OrderServiceClient proxyOrder = new OrderServiceRef.OrderServiceClient();
        
        public static List<EmployeeServiceRef.Employee> arrayEmployees = proxyEmployee.GetAllEmployees();
        public static OrderServiceRef.Employee employeeById;
       
        private Order orderModifed;
        public ModifyOrderWindow(Order order)
        {
           
            InitializeComponent();
            getOrder(order);
            populateEmployeeCB();
            PopulateFields();
            PopulateDataGrid();
          
        }

        public void PopulateFields()
        {
            priceTxt.Text = CalculatePrice().ToString();
            timeTxt.Text = orderModifed.Time.ToString();

            if (orderModifed.Customer != null)
            {
                customerCB.Items.Add(orderModifed.Customer.Name.ToString());
                customerCB.SelectedIndex = 0;
            }

            foreach (var item in employeeCB.Items)
            {
                string nameInCombo = item.ToString();
                if (nameInCombo.Equals(orderModifed.Employee.Name.ToString()))
                {
                    employeeCB.SelectedItem = nameInCombo;
                    employeeId = orderModifed.Employee.Id;
                }
            }
            
            commentTxt.Text = orderModifed.Comment;
        }

        public void populateEmployeeCB()
        {
            foreach (var item in arrayEmployees)
            {
                employeeCB.Items.Add(item.Name);
            }
        }
       
        public void PopulateGridItems()
        {
            foreach (var item in orderModifed.OrderLines)
            {
                Button button = new Button();
                
            }
        }

       
            //public void PopulateDataGrid()
            //{
            //    DataTable dt = new DataTable();


            //    DataColumn Name = new DataColumn("Name", typeof(string));
            //    DataColumn Description = new DataColumn("Description", typeof(string));
            //    DataColumn Price = new DataColumn("Price", typeof(double));
            //    DataColumn Quantity = new DataColumn("Quantity", typeof(int));


            //    dt.Columns.Add(Name);
            //    dt.Columns.Add(Description);
            //    dt.Columns.Add(Price);
            //    dt.Columns.Add(Quantity);

            //    try
            //    {
            //        foreach (var item in orderModifed.OrderLines)
            //        {
            //            DataRow newRow = dt.NewRow();
            //            newRow[0] = item.Product.Name;
            //            newRow[1] = item.Product.Description;
            //            newRow[2] = item.Product.Price;
            //            newRow[3] = item.Quantity.ToString();
            //            dt.Rows.Add(newRow);
            //        }
            //        productsDataGrid.ItemsSource = dt.DefaultView;
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //}

            public double CalculatePrice()
        {
            double priceTotal = 0;
            foreach (var item in orderModifed.OrderLines)
            {
                priceTotal += (item.Product.Price) * (item.Quantity);
            }

            return priceTotal;
        }

        public void getOrder(Order order)
        {
            orderModifed = order;
        }
        public void ModifyOrder()
        {


            
            string selecteNameInCombo = employeeCB.SelectedItem.ToString();
           List<EmployeeServiceRef.Employee> employeeList = proxyEmployee.GetAllEmployees();

            foreach (var item in employeeList)
            {
                if (selecteNameInCombo.Equals(item.Name))
                {
                    employeeId = item.Id;
                }
            }
           
                
            

            string employeeIdInString = employeeId.ToString();
            EmployeeServiceRef.Employee employeeTosend = proxyEmployee.GetEmployeeById(employeeIdInString);
            orderModifed.Price= Convert.ToDecimal(priceTxt.Text);
            OrderServiceRef.Employee emplo = new OrderServiceRef.Employee();
            emplo.Id = employeeTosend.Id;
            emplo.Name = employeeTosend.Name;
            emplo.Phone = employeeTosend.Phone;
            emplo.Email = employeeTosend.Email;
            orderModifed.Employee = emplo;
            orderModifed.Comment = commentTxt.Text;

            proxyOrder.ModifyOrder(orderModifed);

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ModifyOrder();
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            this.Close();
        }

       

     
        //private void productsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    OrderLine[] orderLines= orderModifed.OrderLines;
        //    var myvalue = productsDataGrid.SelectedIndex.ToString();
            
        //    MessageBox.Show(myvalue.ToString());
        //}
    }
}
