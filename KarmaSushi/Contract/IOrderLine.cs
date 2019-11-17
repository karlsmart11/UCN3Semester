﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Contract
{
    public interface IOrderLine
    {
        /// <summary>
        /// Returns a list of order lines associated with a specific order.
        /// </summary>
        /// <param name="order">Order that the oder lines are associated with</param>
        /// <returns>A list of order lines</returns>
        List<OrderLine> GetOrderLinesByOrder(Order order);
    }
}
