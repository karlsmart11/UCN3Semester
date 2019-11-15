using Contract;
using ServiceKarma.Model;
using SQLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controller
{
   public class EmployeeController : IDisposable
    {
        public Employee GetEmployeeById(string id)
        {
            IEmployee instance = new EmployeeRepository();
            return instance.GetEmployeeById(id);
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
