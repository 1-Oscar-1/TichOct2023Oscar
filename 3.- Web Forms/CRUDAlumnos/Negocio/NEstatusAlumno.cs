using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEstatusAlumno
    {
        public static List<EstatusAlumno> Consultar(int id)
        {
            return DEstatusAlumno.Consultar(id);
        }
    }
}
