using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Interface;
using Model;

namespace SQLRepository
{
    //Saved for the insert statement to receive the sql identity Id
    //Remember to do connection.execute(); for insert
    // p.add("@Id", 0, dbType: DBType.Int32, direction: ParameterDirection.Output);

    public class OrderRepository : IOrder
    {
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly CustomerRepository _customerRepository = new CustomerRepository();
        private readonly OrderLineRepository _orderLineRepository = new OrderLineRepository();

        public Order GetOrderById(string id)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@Id", id);

                var order = connection.QuerySingle<Order>(
                    sql: "dbo.spOrders_GetById", 
                    param: p,
                    commandType: CommandType.StoredProcedure);

                order.Employee = _employeeRepository.GetEmployeeById(order.EmployeeId.ToString());
                order.Customer = _customerRepository.GetCustomerById(order.CustomerId.ToString());
                order.OrderLines = _orderLineRepository.GetOrderLinesByOrder(order);

                return order;
            }
        }

        public int InsertOrder(Order order)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();

                //var customerIdentity = _customerRepository.InsertCustomer(Customer);
                //var employeeIdentity = _employeeRepository.InsertEmployee(Employee);
                
                p.Add("@Id", 0, 
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Output);
                p.Add("@Price", order.Price);
                p.Add("@Time", order.Time);
                p.Add("@CustomerId", order.Customer.Id);
                p.Add("@EmployeeId", order.Employee.Id);

                connection.Execute(sql: "dbo.spOrder_Insert", param: p,
                    commandType: CommandType.StoredProcedure);

                //Returned order identity 
                var orderIdentity = p.Get<int>("@Id");

                foreach (var table in order.Tables)
                {
                    table.OrderId = orderIdentity;
                    //var tableId = _tableRepository.InsertTable(table);
                }

                foreach (var orderLine in order.OrderLines)
                {
                    orderLine.OrderId = orderIdentity;
                    //var orderLineId = _orderLineRepository.InsertOrderLine(orderLine);
                }

                return orderIdentity;
            }
        }
    }
}
