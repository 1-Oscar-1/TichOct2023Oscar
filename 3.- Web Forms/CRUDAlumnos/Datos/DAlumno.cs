using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Datos
{
    public class DAlumno
    {
        public static string _cnnString = ConfigurationManager.ConnectionStrings["dbTichConection"].ConnectionString;
        public static List<Alumno> Consultar()
        {
            List<Alumno> listAlumnos = new List<Alumno>();
            string query = $"select * from Alumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listAlumnos.Add(new Alumno(
                            (int)reader["id"],
                            reader["nombre"].ToString(),
                            reader["primerApellido"].ToString(),
                            reader["segundoApellido"].ToString(),
                            reader["correo"].ToString(),
                            reader["telefono"].ToString(),
                            Convert.ToDateTime(reader["fechaNacimiento"].ToString()),
                            reader["curp"].ToString(),
                            reader["sueldo"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["sueldo"]),
                            Convert.ToInt32(reader["idEstadoOrigen"]),
                            Convert.ToInt32(reader["idEstatus"])));
                }
                con.Close();
            }
            return listAlumnos;
        }
        public static Alumno Consultar(int id)
        {
            Alumno alumno = null;
            string query = $"SP_ConsultarAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAlumno", id);
                con.Open();

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        alumno = new Alumno(
                            (int)reader["id"],
                            reader["nombre"].ToString(),
                            reader["primerApellido"].ToString(),
                            reader["segundoApellido"].ToString(),
                            reader["correo"].ToString(),
                            reader["telefono"].ToString(),
                            Convert.ToDateTime(reader["fechaNacimiento"].ToString()),
                            reader["curp"].ToString(),
                            reader["sueldo"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["sueldo"]),
                            Convert.ToInt32(reader["idEstadoOrigen"]),
                            Convert.ToInt32(reader["idEstatus"]));
                    }
                }
                con.Close();
            }
            return alumno;
        }
        public static void Agregar(Alumno alumno)
        {
            int id = alumno.id;
            string nombre = alumno.nombre;
            string primerApe = alumno.primerApellido;
            string segundoApe = alumno.segundoApellido;
            string correo = alumno.correo;
            string telefono = alumno.telefono;
            DateTime fechaNacimiento = alumno.fechaNacimiento;
            string curp = alumno.curp;
            decimal sueldo = alumno.sueldo;
            int idEstado = alumno.idEstado;
            int idEstatus = alumno.idEstatus;

            string query = $"insert into Alumnos(nombre, primerApellido, segundoApellido, correo, telefono, fechaNacimiento, curp, sueldo, idEstadoOrigen, idEstatus) values('{nombre}', '{primerApe}', '{segundoApe}', '{correo}', '{telefono}', '{fechaNacimiento.ToString("yyyy-MM-dd")}', '{curp}', {sueldo}, {idEstado}, {idEstatus})";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void Actualizar(Alumno alumno)
        {
            int id = alumno.id;
            string nombre = alumno.nombre;
            string primerApe = alumno.primerApellido;
            string segundoApe = alumno.segundoApellido;
            string correo = alumno.correo;
            string telefono = alumno.telefono;
            DateTime fechaNacimiento = Convert.ToDateTime(alumno.fechaNacimiento);
            string curp = alumno.curp;
            decimal sueldo = alumno.sueldo;
            int idEstado = alumno.idEstado;
            int idEstatus = alumno.idEstatus;
            string query = $"update Alumnos set nombre = '{nombre}', primerApellido = '{primerApe}', segundoApellido = '{segundoApe}', correo = '{correo}', telefono = '{telefono}', fechaNacimiento = '{fechaNacimiento.ToString("yyyy-MM-dd")}', curp = '{curp}', sueldo = '{sueldo}', idEstadoOrigen = '{idEstado}', idEstatus = '{idEstatus}' where id = {id}";
            using(SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void Eliminar(int id)
        {
            string query = $"SP_EliminarAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAlumno", id);
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }

        public static List<ItemTablaISR> ConsultarTablaISR()
        {
            List<ItemTablaISR> listItemIsr = new List<ItemTablaISR>();
            string query = $"select * from TablaISR";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listItemIsr.Add(new ItemTablaISR(
                        Convert.ToDecimal(reader["LimInf"]),
                        Convert.ToDecimal(reader["LimSup"]),
                        Convert.ToDecimal(reader["CuotaFija"]),
                        Convert.ToDecimal(reader["ExedLimInf"]),
                        Convert.ToDecimal(reader["Subsidio"]),
                        Convert.ToDecimal(0.0)));
                }
                con.Close();
            }
            return listItemIsr;
        }
    }
}
