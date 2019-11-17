using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Contract;
using Dapper;
using Model;

namespace SQLRepository
{
    //TODO: Missing interface, some namespace fuckery is going on
    public class OrderLineRepository : IOrderLine
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
    }
}
