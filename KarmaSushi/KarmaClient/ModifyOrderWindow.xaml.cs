
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
        public List<ProductServiceRef.Product> productsIdInOrder = new List<ProductServiceRef.Product>();
        private int employeeId = -1;

        public static EmployeeServiceRef.EmployeeServiceClient proxyEmployee = new EmployeeServiceRef.EmployeeServiceClient();
        public static OrderServiceRef.OrderServiceClient proxyOrder = new OrderServiceRef.OrderServiceClient();
        public static ProductServiceRef.ProductServicesClient proxyProducts = new ProductServiceRef.ProductServicesClient();
        public static List<EmployeeServiceRef.Employee> arrayEmployees = proxyEmployee.GetAllEmployees();
        public static OrderServiceRef.Employee employeeById;
        private List<ProductServiceRef.Product> productsList = new List<ProductServiceRef.Product>();
        private Order orderModifed;
        List<OrderLine> newOrderLineList;
        ProductServiceRef.Product productToAdd;


        public ModifyOrderWindow(Order order)
        {

            InitializeComponent();
            getOrder(order);
            populateEmployeeCB();
            PopulateFields();
            PopulateTextBlock();
            PopulateProductsInMenu();


        }
      
        public void PopulateFields()
        {
            priceTxt.Text = CalculatePriceBeforeAdd().ToString();
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

      

        public void PopulateTextBlock()
        {


            foreach (var item in orderModifed.OrderLines)
            {
                int quantity = item.Quantity;
                for (int i = 0; i < quantity; i++)
                {
                    ProductServiceRef.Product productNew = new ProductServiceRef.Product();
                    productNew.Id = item.Product.Id;
                    productNew.Name = item.Product.Name;
                    productNew.Price = item.Product.Price;
                    productsIdInOrder.Add(productNew);
                }

            }


           
            listTableProducts.ItemsSource = null;
            listTableProducts.ItemsSource = productsIdInOrder;

        }

        public void updateTextBlock()
        {
          listTableProducts.ItemsSource = null;
          listTableProducts.ItemsSource = productsIdInOrder;
        }

        public void PopulateOrderLineNew()
        {
            newOrderLineList = new List<OrderLine>();
            var q = from x in productsIdInOrder
                    group x by x.Id into g
                    let count = g.Count()
                    orderby count descending
                    select new { Id = g.Key, Count = count};

            foreach (var x in q)
            {
                OrderLine newOrderLine = new OrderLine();
                ProductServiceRef.Product product=proxyProducts.GetProductById(x.Id.ToString());
                OrderServiceRef.Product productConverted = new OrderServiceRef.Product();
                productConverted.Id = product.Id;
                productConverted.Name = product.Name;
                productConverted.Price = product.Price;
                newOrderLine.Product = productConverted;
                newOrderLine.Quantity = x.Count;
                newOrderLineList.Add(newOrderLine);
                //Console.WriteLine("Count: " + x.Count + " Id: " + x.Id );
            }
           

        }

       
        public void PopulateProductsInMenu()
        {
            ProductServiceRef.Product[] products = proxyProducts.GetAllProducts();

            ProductsList.ItemsSource = null;
            ProductsList.ItemsSource = products;
        }
      
        public double CalculatePriceBeforeAdd()
        {
            double priceTotal = 0;
            foreach (var item in orderModifed.OrderLines)
            {
                priceTotal += (item.Product.Price) * (item.Quantity);
            }

            return priceTotal;
        }
        public double CalculatePriceAfterAdd()
        {
            double priceTotal = 0;
            foreach (var item in newOrderLineList)
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
            orderModifed.Price = Convert.ToDecimal(priceTxt.Text);
            OrderServiceRef.Employee emplo = new OrderServiceRef.Employee();
            emplo.Id = employeeTosend.Id;
            emplo.Name = employeeTosend.Name;
            emplo.Phone = employeeTosend.Phone;
            emplo.Email = employeeTosend.Email;
            orderModifed.Employee = emplo;
            orderModifed.Comment = commentTxt.Text;
           // PopulateOrderLineNew();
            orderModifed.OrderLines = newOrderLineList.ToArray();
            proxyOrder.ModifyOrder(orderModifed);

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ModifyOrder();
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();

            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // smallDel represents the small X buttons inside list
            var smallDel = (Button)sender;
            if (smallDel != null)
            {
                if (smallDel.DataContext is ProductServiceRef.Product product)
                {
                    productsIdInOrder.Remove(product);
                }
            }
            else
            {
                foreach (var selected in listTableProducts.SelectedItems)
                {
                    productsIdInOrder.Remove((ProductServiceRef.Product)selected);
                }
            }
            PopulateOrderLineNew();
            priceTxt.Text = CalculatePriceAfterAdd().ToString();
            updateTextBlock();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            this.Close();
        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var smallDel = (Button)sender;
            if (smallDel != null)
            {
                if (smallDel.DataContext is ProductServiceRef.Product product)
                {
                    productToAdd = product;
                }
            }

            productsIdInOrder.Add(productToAdd);

            PopulateOrderLineNew();
            priceTxt.Text = CalculatePriceAfterAdd().ToString();
            updateTextBlock();

        }
    }

}
