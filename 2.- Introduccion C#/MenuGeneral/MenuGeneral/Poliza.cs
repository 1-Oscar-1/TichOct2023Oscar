using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Poliza
    {
        public static PolizaResultado Calcular(string fechaInicioEn, string periodoEn, decimal sumaAseguradaEn, string fechaNacimientoEn, string generoEn)
        {
            // Se limpia pantalla
            Console.Clear();

            // Se traen los datos
            DateTime fechaInicio = DateTime.Parse(fechaInicioEn);
            string[] periodoArray = periodoEn.Split(' ');
            string tipoPeriodo = periodoArray[1];
            int cantidadPeriodo = int.Parse(periodoArray[0]);
            decimal sumaAsegurada = sumaAseguradaEn;
            DateTime fechaNacimiento = DateTime.Parse(fechaNacimientoEn);
            string genero = generoEn.ToLower();

            // Arrgelo
            decimal[,] factoresArray = {
                {0.05m, 0.1m, 0.4m, 0.5m, 0.65m, 0.85m}, // Femenino
                {0.05m, 0.1m, 0.4m, 0.55m, 0.7m, 0.9m} // Masculino
            };

            // Se calcula edad actual 
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            // Se confirma el factor a buscar

            int filaGenero;
            int columnaEdad;

            switch (genero)
            {
                case "femenino":
                    filaGenero = 0;
                    break;
                default:
                    filaGenero = 1;
                    break;
            }

            if (edad > 0 && edad <= 20)
            {
                columnaEdad = 0;
            }
            else if (edad <= 30)
            {
                columnaEdad = 1;
            }
            else if (edad <= 40)
            {
                columnaEdad = 2;
            }
            else if (edad <= 50)
            {
                columnaEdad = 3;
            }
            else if (edad <= 60)
            {
                columnaEdad = 4;
            }
            else
            {
                columnaEdad = 5;
            }

            // Factor
            decimal factor = factoresArray[filaGenero, columnaEdad];

            // Se calcula el periodo
            DateTime fechaTermino = fechaInicio;
            switch (tipoPeriodo.ToLower())
            {
                case "años":
                    fechaTermino = fechaTermino.AddYears(cantidadPeriodo);
                    break;
                case "meses":
                    fechaTermino = fechaTermino.AddMonths(cantidadPeriodo);
                    break;
                case "dias":
                    fechaTermino = fechaTermino.AddDays(cantidadPeriodo);
                    break;
                default:
                    Console.WriteLine("Periodo no valido");
                    break;
            }

            // Se hace el calculo de la prima

            decimal prima;

            prima = sumaAsegurada * factor * (fechaTermino - fechaInicio).Days / 360;

            PolizaResultado polizaObjeto = new PolizaResultado(fechaTermino, prima);

            return polizaObjeto;
        }

        public static void Presentacion()
        {
            string fechaInicio;
            string periodo;
            decimal sumaAsegurada;
            string fechaNacimiento;
            string genero;

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Calculo de poliza");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Proporciona la fecha de inicio de Vigencia");
            fechaInicio = Console.ReadLine();
            Console.WriteLine("Proporciona para cuanto tiempo requieres la póliza (ejemplo 2 años)");
            periodo = Console.ReadLine();
            Console.WriteLine("Proporciona la suma asegurada");
            sumaAsegurada = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Proporciona la fecha de nacimiento del asegurado");
            fechaNacimiento = Console.ReadLine();
            Console.WriteLine("Proporciona el género del asegurado");
            genero = Console.ReadLine();

            PolizaResultado resultado = Poliza.Calcular(fechaInicio, periodo, sumaAsegurada, fechaNacimiento, genero);

            Console.WriteLine($"La Poliza vencera el: {resultado.FechaTermino.ToString("dd 'de' MMMM 'de' yyyy", new System.Globalization.CultureInfo("es-ES"))}");
            Console.WriteLine($"La prima a pagar es de: {resultado.Prima.ToString("C2")}");
        }
    }
}
