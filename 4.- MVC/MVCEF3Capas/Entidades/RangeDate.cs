using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
    public class RangeDateAttribute : ValidationAttribute
    {
        public RangeDateAttribute(string fechaMin, string fechaMax)
        {
            this.fechaMin = DateTime.Parse(fechaMin);
            this.fechaMax = DateTime.Parse(fechaMax);
        }
        public DateTime fechaMin { get;}
        public DateTime fechaMax { get;}

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, name, fechaMin.ToString("dd/MM/yyyy"), fechaMax.ToString("dd/MM/yyyy"));
        }
        public override bool IsValid(object value)
        {
            DateTime fechaIngresada = (DateTime)value;
            return fechaIngresada >= fechaMin && fechaIngresada <= fechaMax ? true : false;
        }
    }
}
