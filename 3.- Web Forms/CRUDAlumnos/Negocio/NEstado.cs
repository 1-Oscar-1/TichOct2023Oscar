using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEstado
    {
        public static List<Estado> Consultar(int id)
        {
            return DEstado.Consultar(id);
        }
    }
}
