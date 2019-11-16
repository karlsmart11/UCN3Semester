using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SQLRepository
{
    class Conexion
    {
        /// <summary>
        /// Method that returns a connectionstring mainly use when working with the database
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["KarmaDB"].ToString();
        }
    }
}
