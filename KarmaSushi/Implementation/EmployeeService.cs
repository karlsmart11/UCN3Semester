using Controller;
using Model;
using ServiceContract;
using ServiceKarma.Model;
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
               
                throw new FaultException<Error>(new Error() { CodigoError = "10001", Mensaje = ex.Message, Description = "Exception Administrada por el servcio" });
            }

        }
    }
}
