using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.Presentacion();
        }
        public static void Presentacion()
        {
            Console.Clear();

            Console.WriteLine("Seleccione una opcion de acuerdo al numero");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("1. Consultar Todos");
            Console.WriteLine("2. Consultar Solo uno");
            Console.WriteLine("3. Agregar");
            Console.WriteLine("4. Actualizar");
            Console.WriteLine("5. Eliminar");
            Console.WriteLine("6. Terminar");

            int opcion = int.Parse(Console.ReadLine());

            Console.Clear();
            switch (opcion)
            {
                case 1:
                    Program.ConsultarTodos();
                    break;
                case 2:
                    Program.ConsultarUno();
                    break;
                case 3:
                    Program.Agregar();
                    break;
                case 4:
                    Program.Actualizar();
                    break;
                case 5:
                    Program.Eliminar();
                    break;
                default:
                    break;
            }

        }

        public static void ConsultarTodos()
        {
            Console.WriteLine("Consultar todos los registros");
            Console.WriteLine("----------------------------------------");

            if (DBEstados._dbestados.Count == 0)
            {
                Console.WriteLine("Aun no existen registros");
            }
            else
            {
                Console.WriteLine("id del estado  =>   Estado");
            }

            Console.WriteLine("");
            
            foreach (var kvp in DBEstados._dbestados)
            {
                Console.WriteLine($"{kvp.Key}  =>  {kvp.Value}");
            }

            Program.SalirOpcion();
        }

        public static void ConsultarUno()
        {

            Console.WriteLine("Consultar un registro");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Ingresa el id o numero de estado");
            int idEstado = int.Parse(Console.ReadLine());

            if (DBEstados._dbestados.ContainsKey(idEstado))
            {
                Console.WriteLine($"El estado de {DBEstados._dbestados[idEstado]} coincide con el id = {idEstado} ingresado");
            }

            Program.SalirOpcion();
        }

        public static void Agregar()
        {

            int key;
            string nombreEstado;

            do
            {
                bool registro = false;
                string mensaje = "";
                do
                {
                    Console.Clear();
                    Console.WriteLine("Agregar un registro");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine(mensaje);

                    Console.WriteLine("Ingresa el nombre del estado");
                    nombreEstado = Console.ReadLine();
                    Console.WriteLine("Ingresa su id o numero");
                    key = int.Parse(Console.ReadLine());

                    if (DBEstados._dbestados.ContainsKey(key))
                    {
                        mensaje = "Ese id ya esta asignado a un estado, ingrese otro id";
                    }
                    else
                    {
                        DBEstados._dbestados.Add(key, nombreEstado);
                        Console.WriteLine("Registro exitoso");
                        registro = true;
                    }
                } while (registro == false);

                Console.WriteLine("Quiere registrar otro estado?");

            } while (Console.ReadLine().ToLower() == "si");

            Program.SalirOpcion();
        }

        public static void Actualizar()
        {
            string nuevoNombre;
            int key;

            if (DBEstados._dbestados.Count() == 0)
            {
                Console.WriteLine("No existen registros para poder editar");
            }
            else
            {
                do
                {
                    bool registro = false;
                    string mensaje = "";
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Editar un registro");
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine(mensaje);

                        Console.WriteLine("Ingresa el id o numero de estado para editar");
                        key = int.Parse(Console.ReadLine());

                        if (DBEstados._dbestados.ContainsKey(key))
                        {
                            Console.WriteLine("Ingresa el nuevo nombre");
                            nuevoNombre = Console.ReadLine();

                            DBEstados._dbestados[key] = nuevoNombre.Trim();
                            Console.WriteLine("Actualizacion exitosa");
                            registro = true;
                        }
                        else
                        {
                            mensaje = "Ese id no existe, ingrese otro id";
                        }
                    } while (registro == false);

                    Console.WriteLine("Quiere actualizar otro estado?");

                } while (Console.ReadLine().ToLower() == "si");
            }

            Program.SalirOpcion();
        }

        public static void Eliminar()
        {
            int key;

            if (DBEstados._dbestados.Count() == 0)
            {
                Console.WriteLine("No existen registros para poder eliminar");
            }
            else
            {
                bool salir = false;
                do
                {
                    bool registro = false;
                    string mensaje = "";
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Eliminar un registro");
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine(mensaje);

                        Console.WriteLine("Ingresa el id o numero de estado para eliminar");
                        key = int.Parse(Console.ReadLine());

                        if (DBEstados._dbestados.ContainsKey(key))
                        {
                            DBEstados._dbestados.Remove(key);
                            Console.WriteLine("Eliminacion exitosa");
                            registro = true;
                        }
                        else
                        {
                            mensaje = "Ese id no existe, ingrese otro id";
                        }
                    } while (registro == false);

                    if (DBEstados._dbestados.Count() == 0)
                    {
                        salir = true;
                    } 
                    else
                    {
                        Console.WriteLine("Quiere eliminar otro estado?");
                        if (Console.ReadLine().ToLower() == "si")
                        {
                            salir = false;
                        }
                        else
                        {
                            salir = true;
                        }
                    }

                } while (salir == false);
            }

            Program.SalirOpcion();
        }

        public static void Terminar()
        {

        }

        public static void SalirOpcion()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Presiona f para salir y m para ir al menu");
            if (Console.ReadLine().ToLower() == "m")
            {
                Program.Presentacion();
            }
        }
    }
}
