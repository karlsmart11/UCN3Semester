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
        /// <summary>
        /// Method that creates a new instance of the class EmployeeRepository in an IEmployee interface variable
        /// and return and Employee found by the id
        /// </summary>
        /// <param name="id">Id of the wanted employee</param>
        /// <returns>Employee</returns>
        public Employee GetEmployeeById(string id)
        {
            IEmployee instance = new EmployeeRepository();
            return instance.GetEmployeeById(id);
        }

        /// <summary>
        /// IDisposable allows the system to close an unmanaged resource that is not in use anymore
        /// Very normal when working with API
        /// </summary>
        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
