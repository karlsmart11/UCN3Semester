using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace SQLRepository
{
    public class ReservationRepository : IReservation
    {
        public Reservation GetByCustomer(Customer customer)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Customer", customer);

                var result = connection.QuerySingle<Reservation>("dbo.spReservation_GetByCustomer", param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public Reservation InsertReservation(Reservation reservation)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@Time", reservation.Time);
                p.Add("@CustomerId", reservation.Customer?.Id ?? 1);
                p.Add("@EmployeeId", reservation.Employee.Id);

                connection.Execute(
                    sql: "dbo.spReservation_Insert",
                    param: p,
                    commandType: CommandType.StoredProcedure);

                //Returned reservation identity
                reservation.Id = p.Get<int>("@Id");

                foreach (var table in reservation.Tables)
                {
                    InsertReservedTable(reservation, table);
                }

                return reservation;
            }
        }



        public void InsertReservedTable(Reservation reservation, Table table)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@ReservationId", reservation.Id);
                p.Add("@TableId", table.Id);

                connection.Execute(
                    sql: "dbo.spReservedTable_Insert",
                    param: p,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
