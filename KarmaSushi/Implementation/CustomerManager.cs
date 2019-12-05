﻿using Model;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Controller;
using SQLRepository;

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
                    CodigoError = "10001",
                    Mensaje = ex.Message,
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
                    CodigoError = "10001",
                    Mensaje = ex.Message,
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
                    CodigoError = "10001",
                    Mensaje = ex.Message,
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
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator "
                });
            }
        }
    }
}
