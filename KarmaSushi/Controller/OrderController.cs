using System;
using System.Collections.Generic;
using Interface;
using Model;
using SQLRepository;

namespace Controller
{
    public class OrderController : IDisposable
    {
        public Order GetOrderById(string id)
        {
            IOrderRepository instance = new OrderRepository();
            return instance.GetOrderById(id);
        }

        public Order InsertOrder(Order order)
        {
            IOrderRepository instance = new OrderRepository();
            return instance.InsertOrder(order);
        }

        public List<Order> GetAllOrder()
        {
            IOrderRepository instance = new OrderRepository();
            return instance.GetAllOrders();
        }

        public Order ModifyOrder(Order order)
        {
            IOrderRepository instance = new OrderRepository();
            return instance.ModifyOrder(order);
        }

        public bool DeleteOrder(string id)
        {
            IOrderRepository instance = new OrderRepository();
            return instance.DeleteOrder(id);
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}