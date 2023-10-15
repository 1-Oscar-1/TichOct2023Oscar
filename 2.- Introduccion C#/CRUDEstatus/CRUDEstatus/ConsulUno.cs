using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class ConsulUno
    {
        public static void ConsultarUno(string clave)
        {
            bool existeRegistro = false;

            foreach (var item in ListaDatos._listaEstatus)
            {
                if (item.clave.ToUpper() == clave)
                {
                    Console.WriteLine("Clave ==> Estatus");
                    Console.WriteLine("");
                    Console.WriteLine($"{item.clave} ==> {item.nombre}");

                    existeRegistro = true;
                }
            }

            if (existeRegistro == false)
            {
                Console.WriteLine("No existen registros con esa clave");
            }

            Salir.SalirMenu();
        }
    }
}
