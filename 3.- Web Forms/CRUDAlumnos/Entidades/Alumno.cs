using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string primerApellido, string segundoApellido, string correo, string telefono, DateTime fechaNacimiento, string curp, decimal sueldo, int idEstado, int idEstatus)
        {
            this.id = id;
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.correo = correo;
            this.telefono = telefono;
            this.fechaNacimiento = fechaNacimiento;
            this.curp = curp;
            this.sueldo = sueldo;
            this.idEstado = idEstado;
            this.idEstatus = idEstatus;
        }

        public int id {  get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string correo {  get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string curp {  get; set; }
        public decimal sueldo { get; set; }
        public int idEstado { get; set; }
        public int idEstatus { get; set; }
    }
}
