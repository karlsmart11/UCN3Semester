using System;
using Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using SQLRepository;
using Controller;
using System.Text;
using System.Collections.Generic;

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
        public void TestReservationByCustomer()
        {
            //TODO
            ReservationController reservationController = new ReservationController();
            CustomerController customerController = new CustomerController();

            var c = customerController.GetCustomerById("1");

            var r = reservationController.GetByCustomer(c);

            Assert.IsTrue(r.Customer.Id == 1);
        }

        [TestMethod]
        public void TestTableByOrder()
        {
            //TODO
        }

        [TestMethod]
        public void TestGetAllTables()
        {
            //TODO
        }
    }
}
