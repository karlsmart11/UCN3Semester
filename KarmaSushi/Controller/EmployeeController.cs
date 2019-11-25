using SQLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Model;


namespace Controller
{
   public class EmployeeController : IDisposable
    {
        private readonly IEmployee _employeeRepository = null;

        public EmployeeController() { }

        public EmployeeController(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Method that creates a new instance of the class EmployeeRepository in an IEmployee interface variable
        /// and return and Employee found by the Id
        /// </summary>
        /// <param name="id">Id of the wanted employee</param>
        /// <returns>Employee</returns>
        public Employee GetEmployeeById(string id)
        {
            IEmployee instance = _employeeRepository ?? new EmployeeRepository();
            return instance.GetEmployeeById(id);
        }

        public Employee InsertEmployee(Employee employee)
        {
            IEmployee instance = new EmployeeRepository();
            return instance.InsertEmployee(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            IEmployee instance = _employeeRepository ?? new EmployeeRepository();
            return instance.GetAllEmployees();
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
