using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class Agregar
    {
        public static void AgregarEstatus()
        {
            Console.Clear();

            Console.WriteLine("Agregar estatus");
            Console.WriteLine("----------------------------");
            Console.WriteLine("");

            Console.WriteLine("Ingresa la clave del estatus");
            string clave = Console.ReadLine().ToUpper();
            Console.WriteLine("Ingresa el nombre del estatus");
            string nombreEs = Console.ReadLine();

            ListaDatos._listaEstatus.Add(new Estatus(clave, nombreEs));
            Console.WriteLine("Registro exitoso");

            Salir.SalirMenu();
        }
    }
}
