using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFAlumnos
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

        public AportacionesIMSS()
        {
            // Constructor sin argumentos
        }

        public AportacionesIMSS(decimal enfermedadMaternidad, decimal invalidezVida, decimal retiro, decimal censantia, decimal infonavit)
        {
            EnfermedadMaternidad = enfermedadMaternidad;
            InvalidezVida = invalidezVida;
            Retiro = retiro;
            Censantia = censantia;
            Infonavit = infonavit;
        }
    }
}