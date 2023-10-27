using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAlumnos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WCFAlumnos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WCFAlumnos.svc o WCFAlumnos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WCFAlumnos : IWCFAlumnos
    {
        public void DoWork()
        {
        }
        public AportacionesIMSS CalcularIMSS(int id)
        {
            decimal sueldo = NAlumno.Consultar(id).sueldo;

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
        public ItemTablaISR CalcularISR(int id)
        {
            decimal sueldo = NAlumno.Consultar(id).sueldo / 2;
            Entidades.ItemTablaISR itemISR = DAlumno.ConsultarTablaISR().Find(e => sueldo >= e.LimiteInferior && sueldo < e.LimiteSuperior);

            // Calculamos sueldo quincenal - limite inferior
            decimal sueldoLimt = sueldo - itemISR.LimiteInferior;

            // Multiplicamos el resultado anterior por el exedente
            decimal resulExden = (sueldoLimt * itemISR.Excedente) / 100;

            // El resultado anterior se le suma cuota fija menos el subsidio
            decimal isrCalculo = resulExden + itemISR.CuotaFija - itemISR.Subsidio;

            return new ItemTablaISR(itemISR.LimiteInferior, itemISR.LimiteSuperior, itemISR.CuotaFija, itemISR.Excedente, itemISR.Subsidio, isrCalculo);
        }
    }
}
