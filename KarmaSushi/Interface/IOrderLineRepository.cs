﻿using System.Collections.Generic;
using Model;

namespace Interface
{
    public interface IOrderLineRepository
    {
        /// <summary>
        /// Returns a list of order lines associated with a specific order.
        /// </summary>
        /// <param Name="order">Order that the oder lines are associated with</param>
        /// <returns>A list of order lines</returns>
        List<OrderLine> GetOrderLinesByOrder(Order order);
    }
}
