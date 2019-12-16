using System.Collections.Generic;
using Model;

namespace Interface
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Method in interface use to return an employee found by the Id
        /// </summary>
        /// <param name="id">Id of the employee store in the database</param>
        /// <returns></returns>
        Employee GetEmployeeById(string id);
        Employee InsertEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        void ModifyEmployee(Employee employee);
    }
}
