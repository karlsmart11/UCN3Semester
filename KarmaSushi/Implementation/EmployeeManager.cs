using Controller;
using Model;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class EmployeeService : IEmployeeService
    {
        public Employee GetEmployeeById(string id)
        {
            try
            {
                using (var instance = new EmployeeController())
                {
                    return instance.GetEmployeeById(id);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public Employee InsertEmployee(Employee employee)
        {
            try
            {
                using (var instance = new EmployeeController())
                {
                    return instance.InsertEmployee(employee);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                using (var instance = new EmployeeController())
                {
                    return instance.GetAllEmployees();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }
    }
}
