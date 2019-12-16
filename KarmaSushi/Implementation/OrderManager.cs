using System;
using System.Collections.Generic;
using System.ServiceModel;
using Controller;
using Model;
using ServiceContract;

namespace Implementation
{
    public class OrderManager : IOrderService
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
                    ErrorCode = "10001",
                    Message = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public Order InsertOrder(Order order)
        {
            try
            {
                using (var instance = new OrderController())
                {
                    return instance.InsertOrder(order);
                }
            }
            catch (Exception e)
            {
                throw new FaultException<Error>(new Error()
                {
                    ErrorCode = "10001",
                    Message = e.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                using (var instance = new OrderController())
                {
                    return instance.GetAllOrder();
                }
            }
            catch (Exception e)
            {
                throw new FaultException<Error>(new Error()
                {
                    ErrorCode = "10001",
                    Message = e.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public Order ModifyOrder(Order order)
        {
            try
            {
                using (var instance = new OrderController())
                {
                    return instance.ModifyOrder(order);
                }
            }
            catch (Exception e)
            {
                throw new FaultException<Error>(new Error()
                {
                    ErrorCode = "10001",
                    Message = e.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public bool DeleteOrder(string id)
        {
            try
            {
                using (var instance = new OrderController())
                {
                    return instance.DeleteOrder(id);
                }
            }
            catch (Exception e)
            {
                throw new FaultException<Error>(new Error()
                {
                    ErrorCode = "10001",
                    Message = e.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }


    }
}
