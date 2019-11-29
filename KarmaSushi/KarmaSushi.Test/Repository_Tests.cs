using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using SQLRepository;
using Moq;
using Interface;
using Controller;

namespace KarmaSushi.Test
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void TestInsertOrder()
        {
            // Arrange
            var oRep = new OrderRepository();

            var o = new Order
            {
                Price = new decimal(1099),
                Employee = new Employee { Id = 1},
                Tables = new List<Table>
                {
                    new Table { Id = 1},
                    new Table { Id = 2 }
                },
                OrderLines = new List<OrderLine> 
                { 
                    new OrderLine { Product = new Product { Id = 1}, Quantity = 2 }, 
                    new OrderLine { Product = new Product { Id = 2}, Quantity = 1 }
                }
            };

            // Act
            var insertedOrder = oRep.InsertOrder(o);

            // Assert
            Assert.IsNotNull(insertedOrder);
        }

        [TestMethod]
        public void TestInsertCustomer()
        {
            CustomerRepository customerRepository = new CustomerRepository();

            var c = new Customer
            {
                Name = "TestJonas",
                Phone = "42042042",
                Email = "jonas@test.dk",
                Address = "vej 1"
            };

            var insertedCustomer = customerRepository.InsertCustomer(c);

            Assert.IsNotNull(insertedCustomer);
        }

        [TestMethod]
        public void TestInsertEmployee()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();

            var e = new Employee
            {
                Name = "TestJonas",
                Email = "jonas@test.dk",
                Phone = "42042042"
            };

            var insertedEmployee = employeeRepository.InsertEmployee(e);

            Assert.IsNotNull(insertedEmployee);
        }

        //[TestMethod]
        //public void TestInsertProduct()
        //{
        //    ProductController productController = new ProductController();

        //    var p = new Product
        //    {
        //        Name = "TestSushi",
        //        Description = "test",
        //        Price = 69,
        //        Category = new Category { Id = 1, Name = "Appetizer" }
        //    };

        //    var insertedProduct = productController.
        //}

        [TestMethod]
        public void TestInsertReservation()
        {
            ReservationController reservationController = new ReservationController();
            var tables = new List<Table>();
            var t = new Table
            {
                Id = 1
            };

            var t2 = new Table
            {
                Id = 2
            };

            var e = new Employee
            {
                Id = 1
            };

            var c = new Customer
            {
                Id = 1
            };

            var r = new Reservation
            {
                Time = DateTime.Now,
                Tables = tables,
                Employee = e,
                Customer = c
            };

            var insertedReservation = reservationController.InsertReservation(r);

            Assert.IsNotNull(insertedReservation);
        }

        [TestMethod]
        public void TestInsertTable()
        {
            TableController tableController = new TableController();

            var t = new Table
            {
                Name = "TestBord",
                Seats = 10
            };

            var insertedTable = tableController.InsertTable(t);

            Assert.IsNotNull(insertedTable);
        }

        //[TestMethod]
        //public void TestInsertCustomerMock()
        //{
        //    Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();

        //    var c = new Customer
        //    {
        //        Id = 1,
        //        Name = "TestJonas",
        //        Phone = "42042042",
        //        Email = "jonas@test.dk",
        //        Address = "vej 1"
        //    };

        //    mock.Setup(obj => obj.InsertCustomer(c));

        //    var insertedCustomer = mock.InsertCustomer(c);

        //    Assert.IsNotNull(insertedCustomer);
        //}
    }
}
