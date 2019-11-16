using Model;
using ServiceKarma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Contract
{
    
    public interface ICustomer
    {
       public Customer GetCustomerById(string id);
       public Customer GetCustomerByName(string name);
    }
}
