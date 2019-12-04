using Dapper;
using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SQLRepository
{   
    public class TableRepository : ITableRepository
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
                parameters.Add("@Seats", table.Seats);

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

        public List<Table> GetAllTables()
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var allTables = connection.Query<Table>(sql: "SELECT * FROM [dmab0918_1074178].[dbo].[Table]").ToList();

                return allTables;
            }
        }

        public List<Table> GetTablesBySeats(int seats)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
  
                var allTablesSeats = connection.Query<Table>(sql: "dbo.spTable_GetByOrder", param: seats,
                    commandType: CommandType.StoredProcedure).ToList();

                return allTablesSeats;
            }
        }

        public List<Table> GetAvailableTables(string DesiredTime)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))

            {
                DateTime NewTime = Convert.ToDateTime(DesiredTime);
                var p = new DynamicParameters();
                p.Add("@Time", NewTime);


                var allAvailableTables = connection.Query<Table>(sql: "spTable_Available", param: p,
                    commandType: CommandType.StoredProcedure).ToList();

                return allAvailableTables;
            }
        }
    }
}
