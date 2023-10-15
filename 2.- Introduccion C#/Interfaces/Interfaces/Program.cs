using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFigura[] arrayFiguras = {new Cuadrado(2), new Triangulo(8,6)};

            foreach (IFigura figura in arrayFiguras)
            {
                Console.WriteLine(figura.ToString());
                Console.WriteLine($"El area de la figura es: {figura.Area()}");
                Console.WriteLine($"El perimetro de la figura es: {figura.Perimetro()}");
                Console.WriteLine("");
            }

            Console.ReadKey();
        }
    }
}
