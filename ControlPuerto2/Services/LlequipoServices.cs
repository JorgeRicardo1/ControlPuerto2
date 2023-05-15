using ControlPuerto2.Data;
using ControlPuerto2.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ControlPuerto2.Services
{
    public class LlequipoServices
    {
        public static async Task<EmpresaModel> Validar(string mac, string empresa)
        {
            var conexionBD = await DataConexion.conectar();
            try
            {
                EmpresaModel empre = new EmpresaModel();
                string query = $"SELECT * FROM empresas.llequipo WHERE nro_mac = '{mac}' and empresa = '{empresa}'";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                DataConexion.abrir();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        empre.empresa = reader.GetString("empresa");
                        empre.nro_mac = reader.GetString("nro_mac");
                        empre.activar = reader.GetString("activar");
                        empre.modulos = reader.GetString("modulos");
                    }
                }
                else
                {
                    DataConexion.cerrar();

                    string validacionPassword = $"{mac.Substring(mac.Length - 4),4}" + "M0D3L0";
                    string query2 = $"INSERT INTO `empresas`.`llequipo` (`empresa`, `nro_mac`, `activar`, `modulos`) VALUES ('{empresa}', '{mac}', '{validacionPassword}', 'M33');";
                    MySqlCommand comando2 = new MySqlCommand(query2);
                    MySqlDataReader reader2 = null;
                    comando2.Connection = conexionBD;
                    DataConexion.abrir();
                    reader2 = comando2.ExecuteReader();

                    reader2.Close();
                    DataConexion.cerrar();
                    return null;
                }
                reader.Close();
                string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
                new MySqlCommand($"UPDATE empresas.llequipo SET maquina = '{DeviceInfo.Name}',facceso = '{date}',eq_notas='{"M33 " + date}'" +
                    $"WHERE nro_mac='{mac}'; ", conexionBD).ExecuteNonQuery();
                conexionBD.Close();
                return empre;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
                conexionBD.Close();
                throw;
            }
        }
    }
}
