using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Interface;
using Model;


namespace SQLRepository
{
    public class CustomerRepository : ICustomer
    {
        public Customer GetCustomerById(string id)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                connection.Open();
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
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Name", name);

                var result = connection.QuerySingle<Customer>("dbo.spCustomer_GetByName", param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public Customer InsertCustomer(Customer customer)
        {

            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                connection.Open();
                var p = new DynamicParameters();

                p.Add("@Name", customer.Name);
                p.Add("@Phone", customer.Phone);
                p.Add("@Email", customer.Email);
                p.Add("@Address", customer.Address);
                p.Add("@Id", customer.Id, dbType: DbType.Int32, direction: ParameterDirection.Output);

                var employeeIdentity = connection.ExecuteScalar(
                    "dbo.spCustomer_Insert",
                    param: p,
                    commandType: CommandType.StoredProcedure);

                var pIdCustomer = p.Get<Int32>("Id");
                customer.Id = pIdCustomer;

                return customer;
            }
        }
    }
}
