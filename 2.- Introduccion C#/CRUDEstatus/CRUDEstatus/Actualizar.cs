using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class Actualizar
    {
        public static void ActualizarEstatus(string clave)
        {
            bool existeRegistro = false;

            for (int i = 0; i < ListaDatos._listaEstatus.Count(); i++)
            {
                if (ListaDatos._listaEstatus[i].clave.ToUpper() == clave)
                {
                    Console.WriteLine("Ingresa la nueva clave o la misma");
                    string claveNueva = Console.ReadLine().ToUpper();
                    Console.WriteLine("Ingresa el nuevo estatus");
                    string nombreNuevo = Console.ReadLine();

                    ListaDatos._listaEstatus[i] = new Estatus(claveNueva, nombreNuevo);

                    existeRegistro = true;
                }
            }

            if (existeRegistro)
            {
                Console.WriteLine("El estatus se actualizo con exito");
            }
            else
            {
                Console.WriteLine("La clave no coincide con ningun estatus");
            }
        }
    }
}
