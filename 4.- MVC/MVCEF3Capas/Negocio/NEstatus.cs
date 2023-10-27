using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEstatus
    {
        EjerciciosTichEntities _DBContext = new EjerciciosTichEntities();
        List<EstatusAlumnos> _NEstatusList;
        public List<EstatusAlumnos> Consultar()
        {
            _NEstatusList = _DBContext.EstatusAlumnos.ToList();
            return _NEstatusList;
        }
        public EstatusAlumnos Consultar(int id)
        {
            return _DBContext.EstatusAlumnos.Find(id);
        }
        public void Agregar(EstatusAlumnos estatus)
        {

        }
        public void Actualizar(EstatusAlumnos estatus)
        {

        }
        public void Eliminar(int id)
        {

        }
    }
}
