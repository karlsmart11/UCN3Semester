using Dapper;
using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLRepository
{   //Todo implement interface itable
    public class TableRepository
    {
        public Table InsertTable(Table table)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", 0,
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Output);
                parameters.Add("@Name", table.Name);

                connection.Execute("dbo.spTable_Insert", param: parameters,
                    commandType: CommandType.StoredProcedure);
                
                table.Id = parameters.Get<int>("@Id");
                
                return table;
            }
        }

        public List<Table> GetTablesByOrder(Order order)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@Id", order.Id);

                var tables = connection.Query<Table>(sql: "dbo.spTable_GetByOrder", param: p,
                    commandType: CommandType.StoredProcedure).ToList();

                return tables;
            }
        }
        
    }
}
