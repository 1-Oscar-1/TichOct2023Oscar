using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_IMSS
{
    internal class CalculadoraIMSS
    {
        public static Aportaciones Calcular(decimal sbc, decimal uma, int tipo)
        {
            decimal enfermedades;
            decimal invalidez;
            decimal retiro;
            decimal cesantia;
            decimal infonavit;

            if(tipo == 1)
            {
                enfermedades = (sbc - (uma * 3)) * 0.011M;
                invalidez = sbc * 0.0175M;
                retiro = sbc * 0.02M;
                cesantia = sbc * 0.03150M;
                infonavit = sbc * 0.05M;
            } else
            {
                enfermedades = (sbc - (uma * 3)) * 0.004M;
                invalidez = sbc * 0.00625M;
                retiro = sbc * 0;
                cesantia = sbc * 0.01125M;
                infonavit = sbc * 0;
            }

            Aportaciones aportaciones = new Aportaciones(enfermedades, invalidez, retiro, cesantia, infonavit);

            return aportaciones;
        }
        public static void Presentacion()
        {
            decimal sbc;
            decimal uma;
            int tipo;

            Aportaciones calculoFinal;

            Console.WriteLine("Ingrese el numero del tipo de usuario que corresponda");
            Console.WriteLine("1.- Patron");
            Console.WriteLine("2.- Trabajador");
            tipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Salario Base de Cotización");
            sbc = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Unidad de Medida de Actualización");
            uma = decimal.Parse(Console.ReadLine());

            calculoFinal = CalculadoraIMSS.Calcular(sbc, uma, tipo);

            Console.WriteLine("------ Calculos ------");
            Console.WriteLine("Enfermedades y Maternidad: " + calculoFinal.EnfermedadMaternidad.ToString("C2"));
            Console.WriteLine("Invalidez y Vida: " + calculoFinal.InvalidezVida.ToString("C2"));
            Console.WriteLine("Retiro: " + calculoFinal.Retiro.ToString("C2"));
            Console.WriteLine("Cesantia: " + calculoFinal.Cesantia.ToString("C2"));
            Console.WriteLine("Credito Infonavit: " + calculoFinal.Infonavit.ToString("C2"));

            Console.ReadKey();
        }
    }
}
