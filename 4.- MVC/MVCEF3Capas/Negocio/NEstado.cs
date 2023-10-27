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
        EjerciciosTichEntities _DBContext = new EjerciciosTichEntities();
        List<Estados> _NEstadoList;
        public List<Estados> Consultar()
        {
            _NEstadoList = _DBContext.Estados.ToList();
            return _NEstadoList;
        }
        public Estados Consultar(int id)
        {
            return _DBContext.Estados.Find(id);
        }
        public void Agregar(Estados estado)
        {

        }
        public void Actualizar(Estados estado)
        {

        }
        public void Eliminar(int id)
        {

        }
    }
}
