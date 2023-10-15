using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string opcion = null;
            string opcion2 = null;
            List<ItemBase> ticket = new List<ItemBase>();
            do
            {
                Console.WriteLine("Iniciar una venta (V) terminar(T)");
                opcion = Console.ReadLine();
                CargarLits.CargarLista();
                do
                {

                    Console.WriteLine("Ingrese el id del articulo");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("ingrese la cantidad del articulo");
                    int cantidad = Convert.ToInt32(Console.ReadLine());                   
                    ticket=  CargarLits.verTipo(id, cantidad);
                    Console.WriteLine("Desea agregar otro articulo SI / NO");
                    opcion2 = Console.ReadLine();

                }
                while (opcion2 == "SI");
                
                foreach (ItemBase itemBase in ticket)
                {
                    itemBase.Imprimir();
                    
                }
                Console.WriteLine($"TOTAl A PAGAR {ticket.Sum(x => x.Total())} ");


            }
            while (opcion == "T");

            Console.ReadKey();
        }
    }
}
