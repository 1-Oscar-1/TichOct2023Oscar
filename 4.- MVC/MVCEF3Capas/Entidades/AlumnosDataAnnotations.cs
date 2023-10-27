using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [MetadataType(typeof(AlumnosDataAnnotations))]
    public partial class Alumnos
    {

    }
    public class AlumnosDataAnnotations
    {
        [RegularExpression(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$", ErrorMessage = "El {0} no tiene el formato")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string curp { get; set; }

        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "El {0} no tiene el formato")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string nombre { get; set; }

        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "El {0} no tiene el formato")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string primerApellido { get; set; }

        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "El {0} no tiene el formato")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string segundoApellido { get; set; }

        [RangeDate("01/01/1990", "31/12/2000", ErrorMessage = "La {0} debe estar entre 01/01/1990 y 31/12/2000")]
        public DateTime fechaNacimiento { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string correo { get; set; }

        [Range(10000, 400000, ErrorMessage = "El valor debe estar entre el {1} y el {2}")]
        [DataType(DataType.Currency, ErrorMessage = "No es una moneda")]
        public decimal sueldo { get; set; }
    }
}
