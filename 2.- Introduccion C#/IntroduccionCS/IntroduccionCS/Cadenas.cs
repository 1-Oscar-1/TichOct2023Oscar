using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    public class Cadenas
    {
        public static void HolaMundo(string nombre, string primerApe, string segundoApe, string edad)
        {
            //Concatenacion
            Console.WriteLine("Hola " + nombre + " " + primerApe + " " + segundoApe);

            //Formato compuesto
            Console.WriteLine("{0} {1} {2} tiene {3}", nombre, primerApe, segundoApe, edad);

            //Formato de interpolacion
             Console.WriteLine($"Gusto en conocerte {nombre.ToUpper()} {primerApe.ToUpper()} {segundoApe.ToUpper()}!!!");

            //Archivo
            Console.WriteLine(@"C:\Documentos\Diplomado.Net\JorgeValdiviaRosas.docx");
        }
    }
}
