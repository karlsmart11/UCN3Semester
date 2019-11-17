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
        public Order GetOrderById(string id)
        {
            IOrder instance = new OrderRepository();
            return instance.GetOrderById(id);
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}