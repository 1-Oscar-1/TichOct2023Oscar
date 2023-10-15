using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Arreglos
    {
        public static void Cadenas()
        {
            // Se limpia pantalla
            Console.Clear();

            //Se crea la variable nombre
            string nombreCompleto;

            // Asignamos valor a nombre
            Console.WriteLine("Proporciona tu nombre completo");
            nombreCompleto = Console.ReadLine();

            // El nombre completo se convierte en array de las palabras
            string[] palabras = nombreCompleto.Split(' ');

            // Se recorre e imprime el array de palabras anterior
            Console.WriteLine("Hola");
            foreach (string palabra in palabras)
            {
                Console.WriteLine(palabra);
            }

            // Se invierte el array para obtener el primer apellido
            Array.Reverse(palabras);

            // Se extrae el apellido solicitado
            string apellido = palabras[1];
            char[] letras = apellido.ToCharArray(); // Se crea un array de letras con el apellido

            // Se imprime el array de letras del apellido
            Console.WriteLine("---------------------------------------");
            foreach (char letra in letras)
            {
                Console.WriteLine(letra);
            }
        }

        public static void Enteros()
        {
            // Se limpia pantalla
            Console.Clear();

            // Se crean las variable spara los numeros
            int[] numeros = new int[5];

            // Se piden los numeros
            Console.WriteLine("Ordenar numero enteros");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Ingresa el primer numero");
            numeros[0] = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el segundo numero");
            numeros[1] = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el tercer numero");
            numeros[2] = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el cuarto numero");
            numeros[3] = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el quinto numero");
            numeros[4] = int.Parse(Console.ReadLine());

            // Se ordenan los numeros
            Console.WriteLine($"Numeros ingresados: {numeros[0]}, {numeros[1]}, {numeros[2]}, {numeros[3]}, {numeros[4]}");
            Array.Sort(numeros);
            Console.WriteLine($"Numeros ordenados: {numeros[0]}, {numeros[1]}, {numeros[2]}, {numeros[3]}, {numeros[4]}");

        }

        public static void ConvierteATipoOracion()
        {
            // Se limpia la pantalla
            Console.Clear();

            // Se crea el string para el texto
            string texto;
            string textoNuevo;

            // Se pide la cadena de caracteres
            Console.WriteLine("Ingrese un texto");
            texto = Console.ReadLine();

            // Se convierten en mayusculas
            bool mayus = true;
            char[] carcateres = new char[texto.Length];
            for (int i = 0; i < texto.Length; i++)
            {
                if (mayus == true || texto[i] == ' ')
                {
                    carcateres[i] = char.ToUpper(texto[i]);
                    mayus = false;
                    if (texto[i] == ' ')
                    {
                        mayus = true;
                    }
                } else
                {
                    carcateres[i] = texto[i];
                }
            }

            textoNuevo = new string(carcateres);
            Console.WriteLine(textoNuevo);
        }
    }
}
