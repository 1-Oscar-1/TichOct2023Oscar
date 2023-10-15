using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    public class ItemTA : ItemBase
    {
        public ItemTA() { }
        public ItemTA(Articulo articulo, int cantidad, string telefono, string compañia, int comision): base(articulo, cantidad)
        {
            this.telefono = telefono;
            this.compañia = compañia;
            this.comision = comision;
        }

        public virtual string telefono { get; set; }
        public virtual string compañia { get; set; }
        public virtual int comision { get; set; }

        public override decimal Total()
        {

            decimal total = SubTotal() + comision;
            return total;
        }

        public override void Imprimir()
        {
            Console.WriteLine("________________TICH___________________");
            Console.WriteLine($"{id}  {nombre} precio:{precio}  cantidad: {cantidad} subtotal:{SubTotal()} \n Telefono: {telefono} compañia: {compañia} comisión {comision} ");
            Console.WriteLine($"total{Total()}");
        }
    }
}
