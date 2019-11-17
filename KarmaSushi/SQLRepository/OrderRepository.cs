using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Dapper;
using Model;
using ServiceKarma.Model;

namespace SQLRepository
{
    //Saved for the insert statement to receive the sql identity id
    //Remember to do connection.execute(); for insert
    // p.add("@Id", 0, dbType: DBType.Int32, direction: ParameterDirection.Output);

    public class OrderRepository : IOrder
    {
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly CustomerRepository _customerRepository = new CustomerRepository();
        //private readonly OrderLineRepository _orderLineRepository = new OrderLineRepository();

        public Order GetOrderById(string id)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@Id", id);
                var result = connection.QuerySingle<Order>("dbo.spOrders_GetById", param: p, commandType: CommandType.StoredProcedure);

                result.Employee = _employeeRepository.GetEmployeeById(result.EmployeeId.ToString());
                result.Customer = _customerRepository.GetCustomerById(result.CustomerId.ToString());
                //result.OrderLines = _orderLineRepository.GetOrderLinesById(result.OrderLineId.ToString());

                return result;
            }
        }
    }
}
