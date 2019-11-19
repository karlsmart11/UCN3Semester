﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Interface
{  
    
    public interface ICustomer
    {
       Customer GetCustomerById(string id);
       Customer GetCustomerByName(string name);
    }
}