using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class Eliminar
    {
        public static void EliminarEstatus(string clave)
        {

            bool existeRegistro = false;

            for (int i = 0; i < ListaDatos._listaEstatus.Count(); i++)
            {
                if (ListaDatos._listaEstatus[i].clave.ToUpper() == clave)
                {
                    ListaDatos._listaEstatus.RemoveAt(i);

                    existeRegistro = true;
                }
            }

            if (existeRegistro)
            {
                Console.WriteLine("El estatus se elimino con exito");
            }
            else
            {
                Console.WriteLine("La clave no coincide con nigun estatus");
            }

            Salir.SalirMenu();
        }
    }
}
