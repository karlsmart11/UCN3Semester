﻿using System;
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
    }
}
