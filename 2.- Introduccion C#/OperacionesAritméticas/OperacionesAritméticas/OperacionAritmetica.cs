using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesAritméticas
{
    public struct OperacionAritmetica
    {
        public OperacionAritmetica(decimal num1, decimal num2, tipoOperacion tipoOperacion)
        {
            this.num1 = num1;
            this.num2 = num2;
            this.tipoOperacion = tipoOperacion;
        }

        public decimal num1 { get; set; }
        public decimal num2 { get; set; }
        public tipoOperacion tipoOperacion { get; set; }
    }
    
  
}
