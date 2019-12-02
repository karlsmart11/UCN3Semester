using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Interface;
using Model;

namespace SQLRepository
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly ProductRepository _productRepository = new ProductRepository();

        public List<OrderLine> GetOrderLinesByOrder(Order order)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@Id", order.Id);

                var lines = connection.Query<OrderLine>(
                    sql: "dbo.spOrderLine_GetByOrder",
                    param: p,
                    commandType: CommandType.StoredProcedure).ToList();

                foreach (var ol in lines)
                {
                    ol.Product = _productRepository.GetProductById(ol.ProductId.ToString());
                }

                return lines;
            }
        }

        public OrderLine InsertOrderLine(OrderLine orderLine)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ProductId", orderLine.Product.Id);
                p.Add("@Quantity", orderLine.Quantity);
                p.Add("@OrderId", orderLine.OrderId);
                p.Add("@Id", 0,
                   dbType: DbType.Int32,
                   direction: ParameterDirection.Output);

                connection.Execute(sql: "dbo.spOrderLine_Insert",
                    param: p,
                    commandType: CommandType.StoredProcedure);

                orderLine.Id = p.Get<int>("@Id");
                return orderLine;
            }
        }

        public OrderLine ModifyOrderLine(OrderLine orderLine)
        {
            using (IDbConnection conexion = new SqlConnection(Conexion.GetConnectionString()))
            {
                conexion.Open();
                var p = new DynamicParameters();

                p.Add("@Id", orderLine.Id);
                p.Add("@ProductId", orderLine.Product.Id);
                p.Add("@Quantity", orderLine.Quantity);


                var result = conexion.Execute("dbo.spOrderLine_Update", param: p , commandType: CommandType.StoredProcedure);
             
                return  orderLine;

            }
        }

        public bool DeleteOrderLine(OrderLine orderLine)
        {
            using (IDbConnection conexion = new SqlConnection(Conexion.GetConnectionString()))
            {
                conexion.Open();
                var p = new DynamicParameters();
                p.Add("@OrderId", orderLine.OrderId);

                var result = conexion.Execute("dbo.spOrderLine_Delete", param: p, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
