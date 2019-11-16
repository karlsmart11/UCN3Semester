using Contract;
using Dapper;
using ServiceKarma.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRepository
{
    public class ProductRepository : IProduct
    {
        public Product GetProductByCategory(Category category)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Category", category);

                var result = connection.QuerySingle<Product>("dbo.spProduct_GetByCategory", param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public Product GetProductByName(string name)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", name);

                var result = connection.QuerySingle<Product>("dbo.spProduct_GetByName", param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public Product GetProductByPrice(double price)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Price", price);

                var result = connection.QuerySingle<Product>("dbo.spProduct_GetByPrice", param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
