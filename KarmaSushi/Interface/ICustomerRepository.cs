using Model;
using System.Collections.Generic;

namespace Interface
{  
    public interface ICustomerRepository
    {
       Customer GetCustomerById(string id);
       Customer GetCustomerByName(string name);
       Customer InsertCustomer(Customer customer);
       void ModifyCustomer(Customer customer);
       List<Customer> GetAllCustomers();
    }
}
