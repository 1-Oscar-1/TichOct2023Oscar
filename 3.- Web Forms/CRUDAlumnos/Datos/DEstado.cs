using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Datos
{
    public class DEstado
    {
        public static string _cnnString = ConfigurationManager.ConnectionStrings["dbTichConection"].ConnectionString;
        public static List<Estado> Consultar(int id)
        {
            List<Estado> list = new List<Estado>();
            string query = $"SP_ConsultarEstados";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEstado", id);
                con.Open();

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Estado estado = new Estado((int)reader["id"],  reader["nombre"].ToString());
                        list.Add(estado);
                    }
                }
            }
            return list;
        }
    }
}
