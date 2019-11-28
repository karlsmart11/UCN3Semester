using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Model;

namespace SQLRepository
{
    public class ProductRepository : IProduct
    {
       
        public Product GetProductById(string id)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@Id", id);

                var product = connection.QuerySingle<Product>(
                    sql:"dbo.spProduct_GetById",
                    param: p,
                    commandType: CommandType.StoredProcedure);

                product.Category = GetCategoryById(product.CategoryId);

                return product;
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
        public List<Product> GetAllProducts ()
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var allProducts = connection.Query<Product>(sql: "SELECT * FROM Product").ToList();

                foreach (var product in allProducts)
                {
                    product.Category = GetCategoryById(product.CategoryId);
                }

                return allProducts;
            }
        }
        private Category GetCategoryById(int productCategoryId)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@Id", productCategoryId);

                var cat = connection.QuerySingle<Category>(
                    sql: "dbo.spCategory_GetById",
                    param: p,
                    commandType: CommandType.StoredProcedure);

                return cat;
            }
        }
        //public Product GetProductByPrice(double price)
        //{
        //    using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@Price", price);

        //        var result = connection.QuerySingle<Product>("dbo.spProduct_GetByPrice", param: parameters, commandType: CommandType.StoredProcedure);

        //        return result;
        //    }
        //}
    }
}
