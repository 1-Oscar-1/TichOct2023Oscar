using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo
{
    public class Saludo
    {
        //Metodo no estatico
        public string Saludar(string nombre)
        {
            return "Hola " + nombre;
        }

        //Metodo estatico
        public static string SaludarEstatico(string nombre)
        {
            return "Hola " + nombre;
        }
    }
}
