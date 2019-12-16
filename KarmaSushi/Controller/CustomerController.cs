using System;
using System.Collections.Generic;
using SQLRepository;
using Interface;
using Model;

namespace Controller
{ 
    public class CustomerController : IDisposable
    {
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
        public void ModifyCustomer(Customer customer)
        {
            ICustomerRepository instance = new CustomerRepository();
            instance.ModifyCustomer(customer);
        }
        
        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<Customer> GetAllCustomers()
        {
            ICustomerRepository instance = new CustomerRepository();
            return instance.GetAllCustomers();
        }
    }
}