using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using System.Linq;

namespace KarmaSushi.Test
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void TestCustomerById()
        {
            CustomerController customerController = new CustomerController();

            var c = customerController.GetCustomerById("1");

            Assert.IsTrue(c.Id == 1);
        }

        [TestMethod]
        public void TestCustomerByName()
        {
            CustomerController customerController = new CustomerController();

            var c = customerController.GetCustomerByName("julian");

            Assert.IsTrue(c.Name == "julian");
        }

        [TestMethod]
        public void TestEmployyeById()
        {
            EmployeeController employeeController = new EmployeeController();

            var e = employeeController.GetEmployeeById("1");

            Assert.IsTrue(e.Id == 1);
        }

        [TestMethod]
        public void TestGetAllEmployee()
        {
            //TODO
        }

        [TestMethod]
        public void TestOrderById()
        {
            OrderController orderController = new OrderController();

            var o = orderController.GetOrderById("5");

            Assert.IsTrue(o.Id == 5);
            Assert.IsTrue(o.CustomerId == 1);
            Assert.IsTrue(o.EmployeeId == 1);
        }

        [TestMethod]
        public void TestGetAllOrders()
        {
            //TODO
        }

        [TestMethod]
        public void TestProductById()
        {
            ProductController productController = new ProductController();

            var p = productController.GetProductById("1");

            Assert.IsTrue(p.Id == 1);
            Assert.IsTrue(p.CategoryId == 1);
        }

        [TestMethod]
        public void TestProductByName()
        {
            ProductController productController = new ProductController();

            var p = productController.GetProductByName("SomeProduct");

            Assert.IsTrue(p.Name == "SomeProduct");
            Assert.IsTrue(p.CategoryId == 1);
        }

        [TestMethod]
        public void TestTableByOrder()
        {
            TableController tableController = new TableController();
            OrderController orderController = new OrderController();

            var o = orderController.GetOrderById("7");
            var tables = tableController.GetTablesByOrder(o);

            Assert.IsTrue(tables.Any());
        }

        [TestMethod]
        public void TestGetAllTables()
        {
            //TODO
        }
    }
}
