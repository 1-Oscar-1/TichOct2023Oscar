using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class Pantallas
    {
        public static void Presentacion()
        {
            Console.Clear();

            Console.WriteLine("CRUD Estatus");
            Console.WriteLine("------------------------");
            Console.WriteLine("Selecciona una opcion de acuerdo al numero");
            Console.WriteLine("1. Consultar Todos");
            Console.WriteLine("2. Consultar Solo uno");
            Console.WriteLine("3. Agregar");
            Console.WriteLine("4. Actualizar");
            Console.WriteLine("5. Eliminar");
            Console.WriteLine("6. Terminar");

            int opcion = int.Parse(Console.ReadLine());

            Console.Clear();

            switch(opcion)
            {
                case 1:
                    Console.WriteLine("Consultar todos los estatus");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("");
                    ConsultarTodos.ConsultarTodo();
                    break;
                case 2:
                    Console.WriteLine("Consultar estatus");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("");
                    if (ListaDatos._listaEstatus.Count > 0)
                    {
                        Console.WriteLine("Ingresa la clave del estatus a consultar");
                        string clave = Console.ReadLine().ToUpper();
                        ConsulUno.ConsultarUno(clave);
                    }
                    else
                    {
                        Console.WriteLine("No existen registros para consultar");
                        Salir.SalirMenu();
                    }
                    break;
                case 3:
                    Agregar.AgregarEstatus();
                    break;
                case 4:
                    Console.WriteLine("Actualizar estatus");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("");
                    if (ListaDatos._listaEstatus.Count > 0)
                    {
                        Console.WriteLine("Ingresa la clave");
                        string clave = Console.ReadLine().ToUpper();
                        Actualizar.ActualizarEstatus(clave);
                    }
                    else
                    {
                        Console.WriteLine("No existen registros para Actualizar");
                    }
                    Salir.SalirMenu();
                    break;
                case 5:
                    Console.WriteLine("Eliminar estatus");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("");
                    if (ListaDatos._listaEstatus.Count > 0)
                    {
                        Console.WriteLine("Ingresa la clave del estatus a eliminar");
                        string clave = Console.ReadLine().ToUpper();
                        Eliminar.EliminarEstatus(clave);
                    }
                    else
                    {
                        Console.WriteLine("No existen registros para eliminar");
                        Salir.SalirMenu();
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
