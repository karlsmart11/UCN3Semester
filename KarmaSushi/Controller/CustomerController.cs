using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLRepository;
using Interface;
using Model;

namespace ServiceKarma.Controller
{
    public class CustomerController : IDisposable
    {
        public Customer GetCustomerById (string id)
        {
            ICustomer instance = new CustomerRepository();
            return instance.GetCustomerById(id);
        }


        public Customer GetCustomerByName (string name)
        {
            ICustomer instance = new CustomerRepository();
            return instance.GetCustomerByName(name);
        }




        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

   
}