using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADOWebForms.Entidades
{
    public class EstatusAlumno
    {
        public EstatusAlumno(int id, string clave, string nombre)
        {
            this.id = id;
            this.clave = clave;
            this.nombre = nombre;
        }

        public int id { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
    }
}