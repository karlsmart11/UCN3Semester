
using KarmaClient.EmployeeServiceRef;
using KarmaClient.OrderServiceRef;
using KarmaClient.ProductServiceRef;
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
        private readonly EmployeeServiceClient _eClient = new EmployeeServiceClient();
        private readonly OrderServiceClient _oClient = new OrderServiceClient();
        private readonly ProductServicesClient _pClient = new ProductServicesClient();

        private readonly List<EmployeeServiceRef.Employee> arrayEmployees;
        private List<OrderLine> newOrderLineList;
        private Order orderModifed;
        private ProductServiceRef.Product productToAdd;
        private int employeeId = -1;

        public List<ProductServiceRef.Product> productsIdInOrder = new List<ProductServiceRef.Product>();

        public ModifyOrderWindow(Order order)
        {
            InitializeComponent();
            
            arrayEmployees = _eClient.GetAllEmployees();
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
                ProductServiceRef.Product product=_pClient.GetProductById(x.Id.ToString());
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
            ProductServiceRef.Product[] products = _pClient.GetAllProducts();

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
            List<EmployeeServiceRef.Employee> employeeList = _eClient.GetAllEmployees();

            foreach (var item in employeeList)
            {
                if (selecteNameInCombo.Equals(item.Name))
                {
                    employeeId = item.Id;
                }
            }

            string employeeIdInString = employeeId.ToString();
            EmployeeServiceRef.Employee employeeTosend = _eClient.GetEmployeeById(employeeIdInString);
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

            try
            {
                _oClient.ModifyOrder(orderModifed);
            }
            catch (System.ServiceModel.FaultException<OrderServiceRef.Error> ex)
            {
                MessageBox.Show($"Error code: {ex.Detail.ErrorCode}\n" +
                                $"Message: {ex.Detail.Message}\n" +
                                $"Details: {ex.Detail.Description}");
            }
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
