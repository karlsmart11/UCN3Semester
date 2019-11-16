using Contract;
using Dapper;
using Model;
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
    }
}
