using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public  abstract class ItemBase
    {
        public ItemBase() { }
        public ItemBase(Articulo articulo, int cantidad)
        {
            this.id = articulo.id;
            this.nombre = articulo.nombre;
            this.precio = articulo.precio;
            this.cantidad = cantidad;
        }
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }

        public virtual decimal SubTotal()
        {
            decimal subTotal = precio * cantidad;
            return subTotal;
        }
        public virtual decimal Total()
        {
            decimal total = precio * cantidad;
            return total;
        }

        public abstract void Imprimir();


    }

}
