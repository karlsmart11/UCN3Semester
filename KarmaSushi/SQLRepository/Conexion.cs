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
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["KarmaDB"].ToString();
        }
    }
}
