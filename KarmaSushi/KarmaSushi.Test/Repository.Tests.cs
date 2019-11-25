using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using SQLRepository;

namespace KarmaSushi.Test
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void TestInsertOrder()
        {
            var orep = new OrderRepository();

            var o = new Order
            {
                Price = new Decimal(1099),
                Employee = new Employee { Id = 1},
                Tables = new List<Table> { new Table { Id = 1}, new Table { Id = 2 } },
                OrderLines = new List<OrderLine> {  new OrderLine { Product = new Product { Id = 1}, Quantity = 2 },
                new OrderLine { Product = new Product { Id = 2}, Quantity = 1 }}
            };

            orep.InsertOrder(o);
        }
    }
}
