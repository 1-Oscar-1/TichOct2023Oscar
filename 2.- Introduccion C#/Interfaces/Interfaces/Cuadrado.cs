using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Cuadrado : IFigura
    {
        public Cuadrado(decimal lado)
        {
            this.lado = lado;
        }

        public decimal lado { get; set; }

        public decimal Area()
        {
            return lado * lado;
        }

        public decimal Perimetro()
        {
            return lado * 4;
        }

    }
}
