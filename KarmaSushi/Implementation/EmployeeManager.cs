using Controller;
using Model;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Implementation
{
    public class EmployeeManager : IEmployeeService
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
                    ErrorCode = "10001",
                    Message = ex.Message,
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
                    ErrorCode = "10001",
                    Message = ex.Message,
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
                    ErrorCode = "10001",
                    Message = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public void ModifyEmployee(Employee employee)
        {
            try
            {
                using (var instance = new EmployeeController())
                {
                    instance.ModifyEmployee(employee);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    ErrorCode = "10001",
                    Message = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }
    }
}
