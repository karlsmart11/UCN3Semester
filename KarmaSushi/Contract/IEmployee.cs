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
        /// <summary>
        /// Method in interface use to return an employee found by the id
        /// </summary>
        /// <param name="id"> id of the employee store in the database</param>
        /// <returns></returns>
        Employee GetEmployeeById(string id);
    }
}
