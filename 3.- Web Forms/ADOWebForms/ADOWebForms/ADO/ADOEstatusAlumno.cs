using ADOWebForms.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ADOWebForms.ADO
{
    public class ADOEstatusAlumno : ICRUD
    {
        // Lista
        List<EstatusAlumno> listEstatus = new List<EstatusAlumno>();
        // conection
        public static string _cnnString = ConfigurationManager.ConnectionStrings["dbTichConection"].ConnectionString;
        public void Actualizar(EstatusAlumno estatus)
        {
            int idEstatus = estatus.id;
            string claveEstatus = estatus.clave;
            string nombreEstatus = estatus.nombre;
            string query = $"update estatusAlumnos set clave = '{claveEstatus}', nombre = '{nombreEstatus}' where id = {idEstatus}";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }

        public int Agregar(EstatusAlumno estatus)
        {
            int idEstatus = estatus.id;
            string claveEstatus = estatus.clave;
            string nombreEstatus = estatus.nombre;

            string query = $"insert into estatusAlumnos values({idEstatus}, '{claveEstatus}', '{nombreEstatus}')";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            return idEstatus;
        }

        public List<EstatusAlumno> Consultar()
        {
            string query = $"select * from estatusAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listEstatus.Add(new EstatusAlumno(Convert.ToInt32(reader["id"]), reader["clave"].ToString(), reader["nombre"].ToString()));
                }
                con.Close();
            }
            return listEstatus;
        }

        public EstatusAlumno Consultar(int id)
        {
            Consultar();
            EstatusAlumno estatus = listEstatus.Find(e => e.id == id);
            return estatus;
        }

        public void Eliminar(int id)
        {
            string query = $"delete from estatusAlumnos where id = {id}";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}