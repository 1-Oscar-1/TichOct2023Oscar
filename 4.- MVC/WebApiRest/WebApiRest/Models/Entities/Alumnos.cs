using System;
using System.Collections.Generic;

namespace WebApiRest.Models.Entities
{
    public partial class Alumnos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Curp { get; set; }
        public decimal? Sueldo { get; set; }
        public int? IdEstadoOrigen { get; set; }
        public short? IdEstatus { get; set; }

        public virtual Estados? IdEstadoOrigenNavigation { get; set; }
    }
}
