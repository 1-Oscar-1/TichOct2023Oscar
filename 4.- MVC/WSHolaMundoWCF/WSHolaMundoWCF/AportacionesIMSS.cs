using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WSHolaMundoWCF
{
    [DataContract]
    public class AportacionesIMSS
    {
        [DataMember]
        public decimal EnfermedadMaternidad { get; set; }
        [DataMember]
        public decimal InvalidezVida { get; set; }
        [DataMember]
        public decimal Retiro { get; set; }
        [DataMember]
        public decimal Censantia { get; set; }
        [DataMember]
        public decimal Infonavit { get; set; }
    }
}