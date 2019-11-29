using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interface;
using Model;
using SQLRepository;

namespace Controller
{
    public class OrderController : IDisposable
    {
        public OrderController()
        {
            _orderRepository = new OrderRepository();
        }

        public OrderController(IOrder orderRepository)
        {
            _orderRepository = orderRepository;
        }

        IOrder _orderRepository = null;

        public Order GetOrderById(string id)
        {
           
            return _orderRepository.GetOrderById(id);
        }

        public Order InsertOrder(Order order)
        {
           
            return _orderRepository.InsertOrder(order);
        }

        public List<Order> GetAllOrder()
        {
     
            return _orderRepository.GetAllOrders();
        }

       

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}