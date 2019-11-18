using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Interface
{
    public interface IOrder
    {
        /// <summary>
        /// Returns order from database.
        /// Finding it by Id.
        /// </summary>
        /// <param Name="id">Id of the order to be returned</param>
        /// <returns>An order</returns>
        Order GetOrderById(string id);
    }
}
