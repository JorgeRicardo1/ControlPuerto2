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
    public class BbdoctosServices
    {
        public static async Task<ObservableCollection<BbdoctosModel>> GetArchivos(string idNave)
        {
			try
			{
                MySqlConnection conexionBD = await DataConexion.conectar();
                ObservableCollection<BbdoctosModel> archivos = new ObservableCollection<BbdoctosModel> { };
                BbdoctosModel archivo; 

                string query = $"SELECT * FROM bbdoctos WHERE id_nave = '{idNave}'";
                MySqlCommand comando = new MySqlCommand(query, conexionBD);

                DataConexion.abrir();
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        archivo = new BbdoctosModel()
                        {
                            id_doctos = reader.GetInt32("id_doctos"),
                            doc_grupo = reader.GetString("doc_grupo").ToString(),
                            doc_nombre = reader.GetString("doc_nombre").ToString(),
                            doc_clase1 = reader.GetInt32("doc_clase1"),
                            doc_clase2 = reader.GetInt32("doc_clase2"),
                            doc_tipo = reader.GetInt32("doc_tipo"),
                            doc_vence = reader.GetInt32("doc_vence"),
                            doc_extension = reader.GetString("doc_extension").ToString(),
                            doc_url = reader.GetString("doc_url").ToString(),
                            doc_descripcion = reader.GetString("doc_descripcion").ToString(),
                            id_nave = reader.GetInt32("id_doctos")
                        };
                        archivos.Add(archivo);
                    }
                }
                return archivos;
            }
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
				throw;
			}
        }
    }
}
