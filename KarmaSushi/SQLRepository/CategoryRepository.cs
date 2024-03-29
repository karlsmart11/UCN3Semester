﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Interface;
using Model;

namespace SQLRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category GetCategoryById(int productCategoryId)
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

        public List<Category> GetAllCategories()
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                return connection.Query<Category>("SELECT * FROM Category;").ToList();
            }
        }

        public void ModifyCategory(Category category)
        {
            byte[] rowVersion;
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                rowVersion = connection.ExecuteScalar<byte[]>(
                    sql: "dbo.spCategory_Update",
                    param: category,
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
