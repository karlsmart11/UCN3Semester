using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        private readonly TableRepository _tableRepository = new TableRepository();

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
                order.Tables = _tableRepository.GetTablesByOrder(order);

                return order;
            }
        }
        public Order InsertOrder(Order order)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@Id", 0,
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Output);
                p.Add("@Price", order.Price);
                //p.Add("@Time", order.Time);
                p.Add("@CustomerId", order.Customer?.Id ?? 1);
                p.Add("@EmployeeId", order.Employee.Id);

                connection.Execute(
                    sql: "dbo.spOrders_Insert",
                    param: p,
                    commandType: CommandType.StoredProcedure);

                //Returned order identity 
                order.Id = p.Get<int>("@Id");

                foreach (var table in order.Tables)
                {
                    InsertTablesOrders(order, table);
                }

                foreach (var orderLine in order.OrderLines)
                {
                    orderLine.OrderId = order.Id;
                    _orderLineRepository.InsertOrderLine(orderLine);
                }

                return order;
            }
        }
        public List<Order> GetAllOrders()
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var allOrders = connection.Query<Order>(sql: "SELECT * FROM Orders").ToList();

                foreach (var order in allOrders)
                {
                    if (order.CustomerId != 0)
                    {
                        order.Customer = _customerRepository.GetCustomerById(order.CustomerId.ToString());
                    }
                    order.Employee = _employeeRepository.GetEmployeeById(order.EmployeeId.ToString());
                    order.OrderLines = _orderLineRepository.GetOrderLinesByOrder(order);
                    order.Tables = _tableRepository.GetTablesByOrder(order);
                }

                return allOrders;
            }
        }
        public void InsertTablesOrders(Order order, Table table)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@OrderId", order.Id);
                p.Add("@TableId", table.Id);

                connection.Execute(
                    sql: "dbo.spTablesOrders_Insert",
                    param: p,
                    commandType: CommandType.StoredProcedure);
            }
        }

      


           
        }

        //public int AmountOfOrdersInDb()
        //{
        //    using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
        //        return connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Orders");
        //}
    }
