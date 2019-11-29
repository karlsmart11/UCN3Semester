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
        private readonly ICustomerRepository _customerRepository;

        public CustomerController() { }

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomerById (string id)
        {
            ICustomerRepository instance =  new CustomerRepository();
            return instance.GetCustomerById(id);
        }
        public Customer GetCustomerByName (string name)
        {
            ICustomerRepository instance = new CustomerRepository();
            return instance.GetCustomerByName(name);
        }
        public Customer InsertCustomer(Customer customer)
        {
            ICustomerRepository instance = new CustomerRepository();
            return instance.InsertCustomer(customer);
        }
        
        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

   
}