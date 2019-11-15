using ServiceKarma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IEmployee
    {
        Employee GetEmployeeById(string id);
    }
}
