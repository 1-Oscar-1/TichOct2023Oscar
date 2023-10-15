using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class CargarLits
    {
        // Se crean las listas para guardar los articulos e items
        static List<Articulo> _Articulo = new List<Articulo>();
        static List<ItemBase> _ItemBase = new List<ItemBase>();
        public static void  CargarLista()
        {
            string leerjson;
            StreamReader leerltsAlu = new StreamReader(@"C:\Users\Tichs\Desktop\Practicas\Articulos.json");
            leerjson = leerltsAlu.ReadToEnd();
            _Articulo = JsonConvert.DeserializeObject<List<Articulo>>(leerjson);
            var ver = _Articulo.All(x => x.id > 0);
            if (ver == true)
            {
                foreach (Articulo Articulo in _Articulo)
                {
                    Console.WriteLine($" Articulos = {Articulo.id} {Articulo.nombre} {Articulo.precio} {Articulo.tipo}");
                }
            }
        }
        public static List<ItemBase> verTipo(int id, int cantidad)
        {
            Articulo articulo = _Articulo.Find(x => x.id == id);
            if (articulo != null)
            {

                    if (articulo.tipo == 1)
                    {
                        Console.WriteLine("Articulo tipo 1 seleccionado");
                        Item item = new Item(articulo,cantidad);                        
                        _ItemBase.Add(item);
                    } else if(articulo.tipo == 2)
                    {
                        Console.WriteLine("Articulo tipo 2 seleccionado");
                        Console.WriteLine("Proporcione el descuento a aplicar");
                        decimal descuento =Convert.ToDecimal(Console.ReadLine());
                        ItemDescuento itemDescuento = new ItemDescuento(articulo, cantidad, descuento);
                        _ItemBase.Add(itemDescuento);
                    }
                    else if(articulo.tipo == 3)
                    {
                        Console.WriteLine("Articulo tipo 3 seleccionado");
                        Console.WriteLine("proporcione el telefono");
                        string telefono = Console.ReadLine();
                        Console.WriteLine("Proporcione la compañia a la que pertenece el telefono");
                        string compañia = Console.ReadLine();
                        Console.WriteLine("Proporcione la comisión a aplicar");
                        int comision = Convert.ToInt32(Console.ReadLine());
                        ItemTA itemTA = new ItemTA(articulo, cantidad, telefono, compañia, comision);
                        _ItemBase.Add(itemTA);
                    }
                
            }
            else
            {
                Console.WriteLine("Ese articulo no se encuentra");
            }
            return _ItemBase;
        }



    }
}
