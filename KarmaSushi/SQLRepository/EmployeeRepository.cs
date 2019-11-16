using Contract;
using Dapper;
using ServiceKarma.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRepository
{
   public class EmployeeRepository : IEmployee
    {
        public Employee GetEmployeeById(string id)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var result = connection.QuerySingle<Employee>("dbo.spEmployee_GetById", param: parameters, commandType: CommandType.StoredProcedure);
              
                return result ;
            }
        }
    }
}
