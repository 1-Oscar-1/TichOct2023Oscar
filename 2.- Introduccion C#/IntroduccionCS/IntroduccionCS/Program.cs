using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            string primerApe;
            string segundoApe;
            string edad;

            Console.WriteLine("Proporciona tu nombre");
            nombre = Console.ReadLine();
            Console.WriteLine("Proporciona tu primer apellido");
            primerApe = Console.ReadLine();
            Console.WriteLine("Proporciona tu segundo apellido");
            segundoApe = Console.ReadLine();
            Console.WriteLine("Proporciona tu edad");
            edad = Console.ReadLine();

            nombre = nombre.Trim();
            primerApe = primerApe.Trim();
            segundoApe = segundoApe.Trim();
            edad = edad.Trim();

            Cadenas.HolaMundo(nombre, primerApe, segundoApe, edad);
            Console.ReadLine();
        }
    }
}
