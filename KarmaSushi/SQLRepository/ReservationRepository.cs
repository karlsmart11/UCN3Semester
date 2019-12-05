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
    public class ReservationRepository : IReservationRepository
    {
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
        public List<Reservation> GetAllReservations()
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var allReservations = connection.Query<Reservation>(sql: "SELECT * FROM [dmab0918_1074178].[dbo].[Reservation]").ToList();

                return allReservations;
            }
        }
        public Reservation UpdateReservation(Reservation reservation)
        {
            byte[] rowVersion;
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@Id", reservation.Id);
                p.Add("@Time", reservation.Time);

                rowVersion = connection.ExecuteScalar<byte[]>(
                    sql:"dbo.spReservation_Update",
                    param: p,
                    commandType: CommandType.StoredProcedure);
            }

            if (rowVersion == null)
            {
                throw new DBConcurrencyException(
                    "The entity you were trying to edit has changed. Reload the entity and try again.");
            }

            return reservation;
        }
        public Reservation DeleteReservation(Reservation reservation)
        {
            using (IDbConnection conexion = new SqlConnection(Conexion.GetConnectionString()))
            {
                conexion.Open();
               
                var p = new DynamicParameters();

                p.Add("@Id", reservation.Id);
                var result = conexion.Execute("dbo.spReservation_Delete", param: p, commandType: CommandType.StoredProcedure);

                return reservation;
            }
        }


        public void InsertReservedTable(Reservation reservation, Table table)
        {
            using (IDbConnection connection = new SqlConnection(Conexion.GetConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
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
