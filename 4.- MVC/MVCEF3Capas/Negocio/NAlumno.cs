using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Negocio
{
    public class NAlumno
    {
        EjerciciosTichEntities _DBContext = new EjerciciosTichEntities();
        List<Alumnos> _NAlumnoList;
        public List<Alumnos> Consultar()
        {
            _NAlumnoList = _DBContext.Alumnos.ToList();
            return _NAlumnoList;
        }
        public Alumnos Consultar(int id)
        {
            return _DBContext.Alumnos.Find(id);
        }
        public void Agregar(Alumnos alumno)
        {
            _DBContext.Alumnos.Add(alumno);
            _DBContext.SaveChanges();
        }
        public void Actualizar(Alumnos alumno)
        {
            _DBContext.Entry(alumno).State = EntityState.Modified;
            _DBContext.SaveChanges();
        }
        public void Eliminar(int id)
        {
            Alumnos alumno = _DBContext.Alumnos.Find(id);
            _DBContext.Alumnos.Remove(alumno);
            _DBContext.SaveChanges();
        }

        public ServiceReferenceWCFAlumnos.AportacionesIMSS CalcularIMSS(int id)
        {
            try
            {
                ServiceReferenceWCFAlumnos.WCFAlumnosClient wsAlumnosSoap = new ServiceReferenceWCFAlumnos.WCFAlumnosClient();
                ServiceReferenceWCFAlumnos.AportacionesIMSS aportaciones = wsAlumnosSoap.CalcularIMSS(id);

                return aportaciones;
            }catch (Exception ex)
            {
                return new ServiceReferenceWCFAlumnos.AportacionesIMSS();
            }
        }
        public ServiceReferenceWCFAlumnos.ItemTablaISR CalcularISR(int id)
        {
            try
            {
                ServiceReferenceWCFAlumnos.WCFAlumnosClient wsAlumnosSoap = new ServiceReferenceWCFAlumnos.WCFAlumnosClient();
                ServiceReferenceWCFAlumnos.ItemTablaISR itemISR = wsAlumnosSoap.CalcularISR(id);

                return itemISR;
            }catch(Exception ex)
            {
                return new ServiceReferenceWCFAlumnos.ItemTablaISR();
            }
        }
    }
}
