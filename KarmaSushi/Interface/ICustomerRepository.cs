using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Interface
{  
    
    public interface ICustomerRepository
    {
       Customer GetCustomerById(string id);
       Customer GetCustomerByName(string name);
       Customer InsertCustomer(Customer customer);
       void ModifyCustomer(Customer customer);
    }
}
