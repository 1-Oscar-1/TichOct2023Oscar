using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Triangulo : IFigura
    {
        public Triangulo(decimal baseTri, decimal ladoIgual)
        {
            this.baseTri = baseTri;
            this.ladoIgual = ladoIgual;
        }

        public decimal baseTri { get; set; }
        public decimal ladoIgual { get; set; }

        public decimal Area()
        {
            // Calcular la altura del triángulo isósceles utilizando el lado igual
            double h = Math.Sqrt(Math.Pow((double)ladoIgual, 2) - Math.Pow((double)baseTri / 2, 2));

            // Calcular el área
            decimal area = (baseTri * (decimal)h) / 2;
            return area;
        }

        public decimal Perimetro()
        {
            decimal perimetro = 2 * ladoIgual + baseTri;
            return perimetro;
        }
    }
}
