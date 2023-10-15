using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.Menu();
        }
        public static void Menu()
        {
            Console.Clear();

            string opcion;

            Console.WriteLine("----------------------------");
            Console.WriteLine("Menú");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Selecciona una opcion de acuerdo al numero");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1.- Saludar");
            Console.WriteLine("2.- Ordenar numeros");
            Console.WriteLine("3.- Convertir mayuscalas primer letra");
            Console.WriteLine("4.- Calcular Poliza");
            Console.WriteLine("5.- Mostrar ArchivoCSV");
            Console.WriteLine("6.- Escribir TXT.");
            Console.WriteLine("7.- Calcular ISR");
            Console.WriteLine("8.- Opción 8");
            Console.WriteLine("F.- Termina");

            opcion = Console.ReadLine();

            if (opcion.ToLower() == "f")
            {

            } else
            {
                Program.Opcion(int.Parse(opcion));
            }
        }
        public static void Opcion(int opcion)
        {
            Console.Clear();

            string menu;

            switch (opcion)
            {
                case 1:
                    Arreglos.Cadenas();
                    break;
                case 2:
                    Arreglos.Enteros();
                    break;
                case 3:
                    Arreglos.ConvierteATipoOracion();
                    break;
                case 4:
                    Poliza.Presentacion();
                    break;
                case 5:
                    Archivotxt.Presentacion();
                    break;
                case 6:
                    Archivotxt.EscribirTxt();
                    break;
                case 7:
                    ISR.Presentacion();
                    break;
                case 8:
                    Console.WriteLine("Usted seleccionó la opción 8");
                    break;
            }

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Presiona F para salir de la aplicacion o M para volver al menu");

            menu = Console.ReadLine().ToLower();

            if (menu == "m")
            {
                Program.Menu();
            } else
            {

            }
        }
    }
}
