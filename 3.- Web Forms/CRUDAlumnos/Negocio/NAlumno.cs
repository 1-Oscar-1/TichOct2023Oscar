using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Negocio
{
    public class NAlumno
    {
        public static List<Alumno> Consultar()
        {
            return DAlumno.Consultar();
        }
        public static Alumno Consultar(int id)
        {
            return DAlumno.Consultar(id);
        }
        public static void Agregar(Alumno alumno)
        {
            DAlumno.Agregar(alumno);
        }
        public static void Actualizar(Alumno alumno)
        {
            DAlumno.Actualizar(alumno);
        }
        public static void Eliminar(int id)
        {
            DAlumno.Eliminar(id);
        }
        public static ItemTablaISR CalcularISR(int id)
        {
            ItemTablaISR itemTablaISR = new ItemTablaISR();
            try
            {
                refWSAlumnos.WSAlumnosSoapClient wsAlumnosSoap = new refWSAlumnos.WSAlumnosSoapClient();
                refWSAlumnos.ItemTablaISR itemIsr = wsAlumnosSoap.CalcularISR(id);

                string jsonCon = JsonConvert.SerializeObject(itemIsr);

                itemTablaISR = JsonConvert.DeserializeObject<ItemTablaISR>(jsonCon);

                return itemTablaISR;
            } catch(Exception ex)
            {
                decimal sueldo = Consultar(id).sueldo / 2;
                ItemTablaISR itemISR = DAlumno.ConsultarTablaISR().Find(e => sueldo >= e.LimiteInferior && sueldo < e.LimiteSuperior);

                // Calculamos sueldo quincenal - limite inferior
                decimal sueldoLimt = sueldo - itemISR.LimiteInferior;

                // Multiplicamos el resultado anterior por el exedente
                decimal resulExden = (sueldoLimt * itemISR.Excedente) / 100;

                // El resultado anterior se le suma cuota fija menos el subsidio
                decimal isrCalculo = resulExden + itemISR.CuotaFija - itemISR.Subsidio;

                return new ItemTablaISR(itemISR.LimiteInferior, itemISR.LimiteSuperior, itemISR.CuotaFija, itemISR.Excedente, itemISR.Subsidio, isrCalculo);
            }
            
        }
        public static AportacionesIMSS CalcularIMSS(int id)
        {
            AportacionesIMSS aportacion = new AportacionesIMSS();
            try
            {
                refWSAlumnos.WSAlumnosSoapClient wsAlumnosSoap = new refWSAlumnos.WSAlumnosSoapClient();
                refWSAlumnos.AportacionesIMSS aportacionesIMSS = wsAlumnosSoap.CalcularIMSS(id);
                string jscon = JsonConvert.SerializeObject(aportacionesIMSS);

                aportacion = JsonConvert.DeserializeObject<AportacionesIMSS>(jscon);
                return aportacion;
            }
            catch (Exception e)
            {
                decimal sueldo = Consultar(id).sueldo;

                decimal uma = Convert.ToDecimal(ConfigurationManager.AppSettings["uma"]);

                // Variables a guardar
                decimal enfermedades;
                decimal invalidez;
                decimal retiro;
                decimal cesantia;
                decimal infonavit;

                // Calculos
                enfermedades = (sueldo - (uma * 3)) * 0.004M;
                invalidez = sueldo * 0.00625M;
                retiro = sueldo * 0;
                cesantia = sueldo * 0.01125M;
                infonavit = sueldo * 0;

                return new AportacionesIMSS(enfermedades, invalidez, retiro, cesantia, infonavit);
            }

        }
    }
}
