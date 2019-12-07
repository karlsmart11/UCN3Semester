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
    public class ProductRepository : IProductRepository
    {
       private readonly CategoryRepository _categoryRepository = new CategoryRepository();

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

                product.Category = _categoryRepository.GetCategoryById(product.CategoryId);

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
                var allProducts = connection.Query<Product>(sql: "SELECT * FROM Product;").ToList();

                foreach (var product in allProducts)
                {
                    product.Category = _categoryRepository.GetCategoryById(product.CategoryId);
                }

                return allProducts;
            }
        }

        public void ModifyProduct(Product product)
        {
            byte[] rowVersion;
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@Id", product.Id);
                p.Add("@Name", product.Name);
                p.Add("@Description", product.Description);
                p.Add("@Price", product.Price);
                p.Add("@CategoryId", product.Category.Id);
                p.Add("@RowVer", product.RowVer);

                rowVersion = connection.ExecuteScalar<byte[]>(
                    sql: "dbo.spProduct_Update",
                    param: p,
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
