using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class Item : ItemBase
    {
        public Item() { }
        public Item(Articulo articulo, int cantidad) : base (articulo, cantidad)
        {
            
        }
        
        public override void Imprimir()
        {

            Console.WriteLine("________________TICH___________________");
            Console.WriteLine($"{id} {cantidad} {nombre} precio:{precio}");
            Console.WriteLine($" subtotal {SubTotal()}");
            Console.WriteLine($"Total {Total()}");
        }
    }
}
