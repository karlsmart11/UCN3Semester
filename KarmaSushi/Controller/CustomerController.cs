using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLRepository;
using Interface;
using Model;
using System.Text;

namespace Controller
{ 
    public class CustomerController : IDisposable
    {

        
        
        public CustomerController()
        {
         
        }

        public Customer GetCustomerById (string id)
        {
            ICustomer instance =  new CustomerRepository();
            return instance.GetCustomerById(id);
        }


        public Customer GetCustomerByName (string name)
        {
            ICustomer instance = new CustomerRepository();
            return instance.GetCustomerByName(name);
        }

        public Customer InsertCustomer(Customer customer)
        {
            ICustomer instance = new CustomerRepository();
            return instance.InsertCustomer(customer);
        }




        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

   
}