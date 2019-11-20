using System;
using Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using SQLRepository;
using Implementation;
using ServiceContract;
using Controller;
using System.Text;
using System.Collections.Generic;

namespace KarmaSushi.Test
{
    [TestClass]
    public class Tests

    { 
        [TestMethod]
        public void testKrakaConnString()
        {
            StringBuilder connString = new StringBuilder("Data Source = kraka.ucn.dk;");
            connString.Append("Initial Catalog = dmab0918_1074178;");
            connString.Append("Persist Security Info = True;");
            connString.Append("User Id = dmab0918_1074178;");
            connString.Append("Password = Password1!");

            var x = Conexion.GetConnectionString();

            Assert.AreEqual(x, connString);
        }

        [TestMethod]
        public void TestGetEmployee()
        {
            Mock<IEmployee> mock = new Mock<IEmployee>();

            Employee employee = new Employee()
            {
                Id = 1,
                Name = "Jonas",
                Email = "jonas@mail.dk",
                Phone = "42234188",
            };

            mock.Setup(obj => obj.GetEmployeeById("1")).Returns(employee);

            EmployeeController employeeController = new EmployeeController(mock.Object);

            Employee employee1 = employeeController.GetEmployeeById("1");
        }

        [TestMethod]
        public void TestInsertOrder()
        {
            //Arrange
            Mock<IOrder> mock = new Mock<IOrder>();

            var t = new Table
            {
                Id = 1,
                Name = "Bord 1"
            };

            var p = new Product {
                Id = 1,
                Name = "Sushiroll",
                Description = "Lækkert",
                Price = 25
            };

            var ol = new OrderLine {
                Product = p,
                Quantity = 4
            };

            Order order = new Order
            {
                Id = 420,
                Price = 2,
                Time = DateTime.Now,
                Tables = new List<Table> { t },
                Customer = new Customer { Id = 1 },
                Employee = new Employee { Id = 1, Name = "Emma", Email = "emma@mail.gypsy", Phone = "42042042" },
                OrderLines = new List<OrderLine> { ol }
            };
        
            //Act
            mock.Setup(obj => obj.InsertOrder(order)).Returns(order);

            OrderController orderController = new OrderController(mock.Object);

            orderController.InsertOrder(order);

            //Assert
            Assert.AreEqual(420, order.Id);
        }

        [TestMethod]
        public void TestGetAllOrders()
        {
            Mock<IOrder> mock = new Mock<IOrder>();

            List<Order> orders = new List<Order>();

            mock.Setup(obj => obj.GetAllOrders()).Returns(orders);

            OrderController orderController = new OrderController(mock.Object);

            orderController.GetAllOrder();
        }

        [TestMethod]
        public void TestGetAllProducts()
        {
            Mock<IProduct> mock = new Mock<IProduct>();

            List<Product> products = new List<Product>();

            mock.Setup(obj => obj.GetAllProducts()).Returns(products);

            ProductController productController = new ProductController(mock.Object);

            productController.GetAllProducts();
        }
        
    }
}
