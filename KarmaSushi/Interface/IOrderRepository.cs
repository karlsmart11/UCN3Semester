﻿using System.Collections.Generic;
using Model;

namespace Interface
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Returns order from database.
        /// Finding it by Id.
        /// </summary>
        /// <param name="id">Id of the order to be returned</param>
        /// <returns>An order</returns>
        Order GetOrderById(string id);
        Order InsertOrder(Order order);
        List<Order> GetAllOrders();
        Order ModifyOrder(Order order);
        bool DeleteOrder(string id);
    }
}
