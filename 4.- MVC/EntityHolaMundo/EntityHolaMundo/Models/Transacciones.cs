//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityHolaMundo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transacciones
    {
        public int id { get; set; }
        public Nullable<int> idOrigen { get; set; }
        public Nullable<int> idDestino { get; set; }
        public Nullable<decimal> monto { get; set; }
    
        public virtual Saldos Saldos { get; set; }
        public virtual Saldos Saldos1 { get; set; }
    }
}
