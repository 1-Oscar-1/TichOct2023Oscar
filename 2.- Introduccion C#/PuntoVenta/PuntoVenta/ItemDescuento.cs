using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public class ItemDescuento : ItemBase
    {
        public ItemDescuento()
        {
        }

        public ItemDescuento(Articulo articulo, int cantidad, decimal descuento) : base(articulo, cantidad)
        {
            this.descuento = descuento;
        }

        public virtual decimal descuento { get; set; }
        public virtual decimal impDescuento { get 
            {
                return   SubTotal() * descuento;
            } }


        public override decimal Total()
        {
             
            decimal total =SubTotal()-impDescuento;
            return total;
        }
        public override void Imprimir()
        {
            Console.WriteLine("________________TICH___________________");
            Console.WriteLine($"{id} {nombre} precio:{precio} cantidad: {cantidad} subtotal:{SubTotal()}");
            Console.WriteLine($"Descuento:{impDescuento} ({descuento})");
            Console.WriteLine($"Total{Total()}");
        }
    }
}
