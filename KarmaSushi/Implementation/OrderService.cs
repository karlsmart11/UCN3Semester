using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Model;
using ServiceContract;

namespace Implementation
{
    class OrderService : IOrderService
    {
        public Order GetOrderById(string id)
        {
            try
            {
                using (var instance = new OrderController())
                {
                    return instance.GetOrderById(id);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception Administrada por el servcio"
                });
            }
        }
    }
}
