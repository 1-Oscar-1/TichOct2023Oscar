using System;
using System.Collections.Generic;

namespace AplicacionwebCore.Data.Models
{
    public partial class EstatusAlumno
    {
        public EstatusAlumno()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public short Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
