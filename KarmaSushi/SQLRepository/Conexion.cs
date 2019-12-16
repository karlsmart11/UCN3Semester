using System.Configuration;

namespace SQLRepository
{
    public static class Conexion
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
