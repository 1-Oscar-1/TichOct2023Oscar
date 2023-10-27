using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DEstatusAlumno
    {
        public static string _cnnString = ConfigurationManager.ConnectionStrings["dbTichConection"].ConnectionString;
        public static List<EstatusAlumno> Consultar(int id)
        {
            List<EstatusAlumno> list = new List<EstatusAlumno>();
            string query = $"SP_ConsultarEstatus";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEstatus", id);
                con.Open();

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EstatusAlumno estatus = new EstatusAlumno(int.Parse(reader["id"].ToString()), reader["clave"].ToString(), reader["nombre"].ToString());
                        list.Add(estatus);
                    }
                }
                con.Close();
            }
            return list;
        }
    }
}
