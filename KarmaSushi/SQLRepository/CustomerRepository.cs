using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Dapper;
using Model;


namespace SQLRepository
{
    public class CustomerRepository : ICustomer
    {
        public Customer GetCustomerById(string id)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var result = connection.QuerySingle<Customer>("dbo.spCustomer_GetById", param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public Customer GetCustomerByName(string name)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", name);

                var result = connection.QuerySingle<Customer>("dbo.spCustomer_GetByName", param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
