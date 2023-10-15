using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Archivotxt
    {
        public static void MostrarTxt(string nombreArchivo)
        {
            // Variables
            string nombreArchi = nombreArchivo.Trim();
            string linea;

            // Leer archivo
            StreamReader archivo = new StreamReader($@"C:\Users\Tichs\Desktop\{nombreArchi.ToString()}");
            linea = archivo.ReadLine();
            Console.WriteLine("Contenido del archivo .TXT");
            Console.WriteLine("---------------------------------");
            while ((linea = archivo.ReadLine()) != null)
            {
                Console.WriteLine(linea);
            }
        }

        public static void Presentacion()
        {
            // Variables
            string nombreAchivoTxt;
            string nombreAchivoCsv;

            Console.WriteLine("Ingresa el nombre del archivo con su extension .TXT");
            nombreAchivoTxt = Console.ReadLine();

            Console.WriteLine("Ingresa el nombre del archivo con su extension .CSV");
            nombreAchivoCsv = Console.ReadLine();

            Console.WriteLine("------------------------------");
            Archivotxt.MostrarTxt(nombreAchivoTxt);
            Console.WriteLine("------------------------------");
            Archivotxt.MostrarCSV(nombreAchivoCsv);
        }

        public static void MostrarCSV(string nombreArchivo)
        {
            // Variables
            string nombreArchi = nombreArchivo.Trim();
            string linea;

            // Leer archivo
            StreamReader archivo = new StreamReader($@"C:\Users\Tichs\Desktop\{nombreArchi.ToString()}");
            linea = archivo.ReadLine();
            Console.WriteLine("Contenido del archivo .CVS");
            Console.WriteLine("---------------------------------");
            while ((linea = archivo.ReadLine()) != null)
            {
                Console.WriteLine(linea);
            }
        }

        public static void EscribirTxt()
        {
            string nombre;
            bool nuevo;
            string codigo;
            StreamWriter archivo;

            string nombreRegistro;
            string primerApellido;
            string segundoApellido;
            string edad;
            string estado;

            Console.WriteLine("Escribir archivo TXT");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Ingrese la ruta y nombre del archivo");
            nombre = Console.ReadLine();
            Console.WriteLine("¿El archivo sera nuevo?");
            if (Console.ReadLine().ToLower() == "si")
            {
                nuevo = true;
            }
            else
            {
                nuevo = false;
            }

            Console.WriteLine("Escriba el codigo que se quiere escribir  (UTF7,UTF8,Unicod,UTF32,ASCII)");
            codigo = Console.ReadLine();
            Encoding encoding;

            switch (codigo.ToLower())
            {
                case "utf7":
                    encoding = Encoding.UTF7;
                    break;
                case "utf8":
                    encoding = Encoding.UTF8;
                    break;
                case "unicode":
                    encoding = Encoding.Unicode;
                    break;
                case "utf32":
                    encoding = Encoding.UTF32;
                    break;
                case "ascii":
                    encoding = Encoding.ASCII;
                    break;
                default:
                    encoding = Encoding.UTF8;
                    break;
            }

            if (nuevo)
            {
                archivo = new StreamWriter($@"C:\Users\Tichs\Desktop\{nombre.ToString()}.txt", false, encoding);
            }
            else
            {
                archivo = new StreamWriter($@"C:\Users\Tichs\Desktop\{nombre.ToString()}.txt", true, encoding);
            }

            archivo.Close();

            do
            {
                Console.Clear();

                Console.WriteLine("Escribir archivo TXT");
                Console.WriteLine("--------------------------------------");

                Console.WriteLine("Ingresa el nombre a registrar");
                nombreRegistro = Console.ReadLine();
                Console.WriteLine("Ingresa el apellido paterno a registrar");
                primerApellido = Console.ReadLine();
                Console.WriteLine("Ingresa el apellido materno a registrar");
                segundoApellido = Console.ReadLine();
                Console.WriteLine("Ingresa la edad a registrar");
                edad = Console.ReadLine();
                Console.WriteLine("Ingresa el estado a registrar");
                estado = Console.ReadLine();

                archivo = new StreamWriter($@"C:\Users\Tichs\Desktop\{nombre.ToString()}.txt", true);
                archivo.WriteLine($"{nombreRegistro}, {primerApellido}, {segundoApellido}, {edad}, {estado}");
                archivo.Close();

                Console.WriteLine("¿Desea ingresar otro registro? (Si/No)");

            } while (Console.ReadLine().ToLower() == "si");

            archivo.Close();

        }
    }
}
