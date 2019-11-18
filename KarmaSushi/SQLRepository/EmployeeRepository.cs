using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Model;

namespace SQLRepository
{
   public class EmployeeRepository : IEmployee
    {
        /// <summary>
        /// Method that manage the connection to the database given the parameters and returning an Employee searched by Id.
        /// The word using is use to define which objects are going to release resources(destruct the object) once finished.
        /// The method use stored procedures in the database in this case giving them one parameter
        /// </summary>
        /// <param Name="id">Id of the wanted employee</param>
        /// <returns>Employee</returns>
        public Employee GetEmployeeById(string id)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var result = connection.QuerySingle<Employee>("dbo.spEmployee_Insert", param: parameters, commandType: CommandType.StoredProcedure);
              
                return result ;
            }
        }

        public int InsertEmployee(Employee employee)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@Id",0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@Name", employee.Name);
                p.Add("@Phone", employee.Phone);
                p.Add("@Email", employee.Email);

                var employeeIdentity = connection.Execute(
                    sql: "dbo.spEmployee_Insert",
                    param: p,
                    commandType: CommandType.StoredProcedure);

                return employeeIdentity;
            }
        }
    }
}
