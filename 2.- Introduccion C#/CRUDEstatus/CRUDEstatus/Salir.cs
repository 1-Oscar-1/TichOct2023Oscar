using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class Salir
    {
        public static void SalirMenu()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Presiona f para salir y m para ir al menu");
            if (Console.ReadLine().ToLower() == "m")
            {
                Pantallas.Presentacion();
            }
        }
    }
}
