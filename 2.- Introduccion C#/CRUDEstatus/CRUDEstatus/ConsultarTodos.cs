using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class ConsultarTodos
    {
        public static void ConsultarTodo()
        {

            if (ListaDatos._listaEstatus.Count() == 0)
            {
                Console.WriteLine("No existen registros para ver");
            }
            else
            {
                Console.WriteLine("Clave ==> Estatus");
                Console.WriteLine("");
                foreach (var item in ListaDatos._listaEstatus)
                {
                    Console.WriteLine($"{item.clave} ==> {item.nombre}");
                }
            }

            Salir.SalirMenu();
        }
    }
}
