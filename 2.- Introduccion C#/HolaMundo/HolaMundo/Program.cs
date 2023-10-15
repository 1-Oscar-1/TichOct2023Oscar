using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            Console.WriteLine("Cual es tu nombre?");
            nombre = Console.ReadLine();

            //Invocar un metodo estatico
            Saludo.SaludarEstatico(nombre);
            Console.ReadLine();

            //Invocar un metodo no estatico
            //Instancia de una clase
            Saludo saludo = new Saludo();
            string retornoEstatico = saludo.Saludar(nombre);
            Console.ReadLine();
        }
    }
}
