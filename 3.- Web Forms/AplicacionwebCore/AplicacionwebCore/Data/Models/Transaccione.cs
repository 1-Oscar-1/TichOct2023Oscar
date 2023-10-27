using System;
using System.Collections.Generic;

namespace AplicacionwebCore.Data.Models
{
    public partial class Transaccione
    {
        public int Id { get; set; }
        public int? IdOrigen { get; set; }
        public int? IdDestino { get; set; }
        public decimal? Monto { get; set; }

        public virtual Saldo? IdDestinoNavigation { get; set; }
        public virtual Saldo? IdOrigenNavigation { get; set; }
    }
}
