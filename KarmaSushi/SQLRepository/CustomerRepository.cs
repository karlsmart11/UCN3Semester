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
    public class CustomerRepository : ICustomerRepository
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

                var result = connection.QuerySingle<Customer>(
                    sql: "dbo.spCustomer_GetByName",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                return connection.Query<Customer>(sql:"SELECT * FROM Customer;").ToList();
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

                customer.Id = p.Get<int>("@Id");

                return customer;
            }
        }
        public void ModifyCustomer(Customer customer)
        {
            byte[] rowVersion;
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                rowVersion = connection.ExecuteScalar<byte[]>(
                    sql: "dbo.spCustomer_Update",
                    param: customer,
                    commandType: CommandType.StoredProcedure);
            }

            if (rowVersion == null)
            {
                throw new DBConcurrencyException(
                    "The entity you were trying to edit has changed. Reload the entity and try again.");
            }
        }
    }
}
