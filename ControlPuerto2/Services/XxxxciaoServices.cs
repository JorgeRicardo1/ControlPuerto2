using ControlPuerto2.Data;
using ControlPuerto2.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ControlPuerto2.Services
{
    public class XxxxciaoServices
    {
        public static async Task<ObservableCollection<XxxxciaoModel>> GetOperarios()
        {
			try
			{
                MySqlConnection conexionBD = await DataConexion.conectar();
                ObservableCollection<XxxxciaoModel> operarios = new ObservableCollection<XxxxciaoModel>();

                MySqlCommand comando = new MySqlCommand("SELECT * FROM xxxxciao", conexionBD);
                DataConexion.abrir();
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        XxxxciaoModel operario = new XxxxciaoModel
                        {
                            obra = reader.GetString("obra"),
                            clave = reader.GetString("clave"),
                            nombre = reader.GetString("nombre"),
                            pasabordo = reader.GetString("pasabordo"),
                            cedula = reader.GetString("cedula"),
                            direccion = reader.GetString("direccion"),
                            ciudad = reader.GetString("ciudad"),
                            cargo = reader.GetString("cargo"),
                            telefono = reader.GetString("telefono"),
                            celular = reader.GetString("celular"),
                            email = reader.GetString("email")
                        };
                        operarios.Add(operario);
                    }
                }
                DataConexion.cerrar();
                return operarios;
            }
			catch (Exception)
			{

				throw;
			}
        }

        public static async Task<XxxxciaoModel> GetOperario(string claveOperario) 
        {
            try
            {
                MySqlConnection conexionBD = await DataConexion.conectar();
                XxxxciaoModel operario = new XxxxciaoModel();

                MySqlCommand comando = new MySqlCommand($"SELECT * FROM xxxxciao WHERE clave = '{claveOperario}'", conexionBD);
                DataConexion.abrir();
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        operario.obra = reader.GetString("obra");
                        operario.clave = reader.GetString("clave");
                        operario.nombre = reader.GetString("nombre");
                        operario.pasabordo = reader.GetString("pasabordo");
                        operario.cedula = reader.GetString("cedula");
                        operario.direccion = reader.GetString("direccion");
                        operario.ciudad = reader.GetString("ciudad");
                        operario.cargo = reader.GetString("cargo");
                        operario.telefono = reader.GetString("telefono");
                        operario.celular = reader.GetString("celular");
                        operario.email = reader.GetString("email");

                    }
                    DataConexion.cerrar();
                    return operario;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

