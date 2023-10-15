using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    public static class ListaDatos
    {
        public static List<Estatus> _listaEstatus = new List<Estatus>();
    }

    public struct Estatus
    {
        public Estatus(string clave, string nombre)
        {
            this.clave = clave;
            this.nombre = nombre;
        }

        public string clave { get; set; }
        public string nombre { get; set; }

    }
}
