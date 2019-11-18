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
    class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Method that creates an instance of EmployeeController and use the method GetEmployeeById from the controller.
        /// In case there is an error the try/catch will manage the error and display the custom error store in the class error in Domain layer/Model
        /// to about showing sensitive data to the customer
        /// </summary>
        /// <param Name="id"></param>
        /// <returns></returns>
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
                    Description = "Exception managed by the administrator "
                });
            }
        }
    }
}
