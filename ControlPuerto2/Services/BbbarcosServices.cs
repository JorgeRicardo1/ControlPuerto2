using ControlPuerto2.Data;
using ControlPuerto2.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ControlPuerto2.Services
{
    internal class BbbarcosServices
    {
        public static async Task<ObservableCollection<BbbarcosModel>> getBarcos()
        {
            MySqlConnection conexionBD = await DataConexion.conectar();
            ObservableCollection<BbbarcosModel> barcos = new ObservableCollection<BbbarcosModel>();
            BbbarcosModel barco;

            string query = "SELECT * FROM bbbarcos WHERE nav_asigna = '';";
            MySqlCommand comando = new MySqlCommand(query, conexionBD);
            DataConexion.abrir();
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    barco = new BbbarcosModel()
                    {
                        id_nave = reader.GetInt32("id_nave"),
                        nav_omi = reader.GetString("nav_omi").ToString(),
                        nav_numero = reader.GetString("nav_numero").ToString(),
                        nav_nombre = reader.GetString("nav_nombre").ToString(),
                        nav_pais = reader.GetString("nav_nombre").ToString(),
                        nav_mmsi = reader.GetString("nav_nombre").ToString(),
                        nav_tipo = reader.GetInt32("nav_tipo"),
                        nav_ab = Convert.ToDouble(reader.GetDecimal("nav_ab")),
                        nav_an = Convert.ToDouble(reader.GetDecimal("nav_an")),
                        nav_dwt = Convert.ToDouble(reader.GetDecimal("nav_dwt")),
                        nav_eslora = Convert.ToDouble(reader.GetDecimal("nav_eslora")),
                        nav_manga = Convert.ToDouble(reader.GetDecimal("nav_manga")),
                        nav_calado = Convert.ToDouble(reader.GetDecimal("nav_eslora")),
                        nav_creado = Convert.ToDouble(reader.GetDecimal("nav_eslora")),
                        nav_doble = reader.GetInt32("nav_doble"),
                        nav_clasif = reader.GetInt32("nav_clasif"),
                        nav_armad = reader.GetString("nav_nombre").ToString(),
                        nav_dueno = reader.GetString("nav_nombre").ToString(),
                        nav_armnm = reader.GetString("nav_nombre").ToString(),
                        nav_duennm = reader.GetString("nav_nombre").ToString(),
                        nav_asigna = reader.GetString("nav_nombre").ToString(),
                        nav_estado = reader.GetInt32("nav_estado"),
                        nav_Afecha = reader.GetDateTime("nav_Afecha"),
                        nav_Zfecha = reader.GetDateTime("nav_Zfecha")
                    };
                    barcos.Add(barco);
                }
            }
            DataConexion.cerrar();
            return barcos;
        }

        public static async Task<BbbarcosModel> getBarco(string id)
        {
            try
            {
                MySqlConnection conexioBD = await DataConexion.conectar();
                BbbarcosModel barco = new BbbarcosModel();

                string query = $"SELECT * FROM bbbarcos WHERE id_nave = '{id}'";
                MySqlCommand comando = new MySqlCommand(query, conexioBD);
                DataConexion.abrir();
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        barco.id_nave = reader.GetInt32("id_nave");
                        barco.nav_omi = reader.GetString("nav_omi").ToString();
                        barco.nav_numero = reader.GetString("nav_numero").ToString();
                        barco.nav_nombre = reader.GetString("nav_nombre").ToString();
                        barco.nav_pais = reader.GetString("nav_nombre").ToString();
                        barco.nav_mmsi = reader.GetString("nav_nombre").ToString();
                        barco.nav_tipo = reader.GetInt32("nav_tipo");
                        barco.nav_ab = Convert.ToDouble(reader.GetDecimal("nav_ab"));
                        barco.nav_an = Convert.ToDouble(reader.GetDecimal("nav_an"));
                        barco.nav_dwt = Convert.ToDouble(reader.GetDecimal("nav_dwt"));
                        barco.nav_eslora = Convert.ToDouble(reader.GetDecimal("nav_eslora"));
                        barco.nav_manga = Convert.ToDouble(reader.GetDecimal("nav_manga"));
                        barco.nav_calado = Convert.ToDouble(reader.GetDecimal("nav_eslora"));
                        barco.nav_creado = Convert.ToDouble(reader.GetDecimal("nav_eslora"));
                        barco.nav_doble = reader.GetInt32("nav_doble");
                        barco.nav_clasif = reader.GetInt32("nav_clasif");
                        barco.nav_armad = reader.GetString("nav_nombre").ToString();
                        barco.nav_dueno = reader.GetString("nav_nombre").ToString();
                        barco.nav_armnm = reader.GetString("nav_nombre").ToString();
                        barco.nav_duennm = reader.GetString("nav_nombre").ToString();
                        barco.nav_asigna = reader.GetString("nav_nombre").ToString();
                        barco.nav_estado = reader.GetInt32("nav_estado");
                        barco.nav_Afecha = reader.GetDateTime("nav_Afecha");
                        barco.nav_Zfecha = reader.GetDateTime("nav_Zfecha");
                        DataConexion.cerrar();
                        return barco;
                    }
                }
                DataConexion.cerrar();
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static async Task<int> ContarBarcosOperario(string NombreOperario)
        {
            try
            {
                MySqlConnection conexioBD = await DataConexion.conectar();
                int contador = 0;

                string query = $"SELECT * FROM b385.bbbarcos where nav_asigna = '{NombreOperario}';";
                MySqlCommand comando = new MySqlCommand(query, conexioBD);
                DataConexion.abrir();
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contador++;
                    }
                }
                return contador;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task AsignarOperario(int idNave, XxxxciaoModel operario)
        {
            try
            {
                MySqlConnection conexioBD = await DataConexion.conectar();

                string query = $"UPDATE `b385`.`bbbarcos` SET `nav_asigna` = '{operario.nombre}' WHERE (`id_nave` = '{idNave}');;";
                MySqlCommand comando = new MySqlCommand(query, conexioBD);
                DataConexion.abrir();
                MySqlDataReader reader = comando.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<ObservableCollection<BbbarcosModel>> GetBarcosOperario(string nombreOperario)
        {
            try
            {
                MySqlConnection conexionBD = await DataConexion.conectar();
                ObservableCollection<BbbarcosModel> barcos = new ObservableCollection<BbbarcosModel>();
                BbbarcosModel barco;

                string query = $"SELECT * FROM bbbarcos WHERE nav_asigna = '{nombreOperario}';";
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                DataConexion.abrir();
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        barco = new BbbarcosModel()
                        {
                            id_nave = reader.GetInt32("id_nave"),
                            nav_omi = reader.GetString("nav_omi").ToString(),
                            nav_numero = reader.GetString("nav_numero").ToString(),
                            nav_nombre = reader.GetString("nav_nombre").ToString(),
                            nav_pais = reader.GetString("nav_nombre").ToString(),
                            nav_mmsi = reader.GetString("nav_nombre").ToString(),
                            nav_tipo = reader.GetInt32("nav_tipo"),
                            nav_ab = Convert.ToDouble(reader.GetDecimal("nav_ab")),
                            nav_an = Convert.ToDouble(reader.GetDecimal("nav_an")),
                            nav_dwt = Convert.ToDouble(reader.GetDecimal("nav_dwt")),
                            nav_eslora = Convert.ToDouble(reader.GetDecimal("nav_eslora")),
                            nav_manga = Convert.ToDouble(reader.GetDecimal("nav_manga")),
                            nav_calado = Convert.ToDouble(reader.GetDecimal("nav_eslora")),
                            nav_creado = Convert.ToDouble(reader.GetDecimal("nav_eslora")),
                            nav_doble = reader.GetInt32("nav_doble"),
                            nav_clasif = reader.GetInt32("nav_clasif"),
                            nav_armad = reader.GetString("nav_nombre").ToString(),
                            nav_dueno = reader.GetString("nav_nombre").ToString(),
                            nav_armnm = reader.GetString("nav_nombre").ToString(),
                            nav_duennm = reader.GetString("nav_nombre").ToString(),
                            nav_asigna = reader.GetString("nav_nombre").ToString(),
                            nav_estado = reader.GetInt32("nav_estado"),
                            nav_Afecha = reader.GetDateTime("nav_Afecha"),
                            nav_Zfecha = reader.GetDateTime("nav_Zfecha")
                        };
                        barcos.Add(barco);
                    }
                }
                DataConexion.cerrar();
                return barcos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
