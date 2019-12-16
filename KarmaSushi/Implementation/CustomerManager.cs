using Model;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using Controller;

namespace Implementation
{
    public class CustomerManager : ICustomerService
    {
        public Customer GetCustomerById(string id)
        {
            try
            {
                using (var instance = new CustomerController())
                {
                    return instance.GetCustomerById(id);
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

        public Customer GetCustomerByName(string name)
        {
            try
            {
                using (var instance = new CustomerController())
                {
                    return instance.GetCustomerByName(name);
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

        public Customer InsertCustomer(Customer customer)
        {
            try
            {
                using (var instance = new CustomerController())
                {
                    return instance.InsertCustomer(customer);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    ErrorCode = "10001",
                    Message = ex.Message,
                    Description = "Exception managed by the administrator "
                });
            }
        }

        public void ModifyCustomer(Customer customer)
        {
            try
            {
                using (var instance = new CustomerController())
                {
                   instance.ModifyCustomer(customer);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    ErrorCode = "10001",
                    Message = ex.Message,
                    Description = "Exception managed by the administrator "
                });
            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                using (var instance = new CustomerController())
                {
                    return instance.GetAllCustomers();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    ErrorCode = "10001",
                    Message = ex.Message,
                    Description = "Exception managed by the administrator "
                });
            }
        }
    }
}
