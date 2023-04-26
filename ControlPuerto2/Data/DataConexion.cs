using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlPuerto2.Data
{
    public class DataConexion
    {
        public static MySqlConnection conexionBD { get; set; }
        private static string connectionString = "Database = b385; Data Source = 192.168.1.189; User Id = victor; Password= 123456";

        public static async Task<MySqlConnection> conectar()
        {
            try
            {
                conexionBD = new MySqlConnection(connectionString);
                return conexionBD;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("El error es " + ex.Message);
                //throw;
            }
            return null;
        }
        public static void getConnectionString()
        {
            //connectionString = $"Database = {empresa[0].empresa}; Data Source = {empresa[0].ipserver}; User Id = {empresa[0].usuario}; Password= {empresa[0].serverPassword}";
            //connectionString = "Database = b385; Data Source = 192.168.1.189; User Id = victor; Password= 123456";
        }

        public static void abrir()
        {
            conexionBD.Open();
        }

        public static void cerrar()
        {
            conexionBD.Close();
        }
    }
}
