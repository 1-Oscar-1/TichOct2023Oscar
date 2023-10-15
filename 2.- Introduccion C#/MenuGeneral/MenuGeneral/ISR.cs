using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MenuGeneral
{
    internal class ISR
    {
        public static decimal[,] CargarTabla(string nombreArch)
        {
            string nombreArchivo = nombreArch.Trim();
            string[] datosRegistro;
            string linea;
            decimal[,] tablaIsr = new decimal[21,6];

            // Leer archivo
            StreamReader archivo = new StreamReader($@"C:\Users\Tichs\Desktop\{nombreArchivo.ToString()}");
            
            int contador = 0;
            while ((linea = archivo.ReadLine()) != null)
            {
                datosRegistro = linea.Split(',');
                decimal[] arrayTemp = new decimal[datosRegistro.Length];
                for (int i = 0; i < datosRegistro.Length; i++)
                {
                    tablaIsr[contador,i] = decimal.Parse(datosRegistro[i]);
                }
                contador++;
            }

            return tablaIsr;
        }

        public static decimal Calcular(decimal sueldoMensual, decimal[,] tabla)
        {
            // Variables
            decimal sueldoQuincenal = sueldoMensual / 2;
            decimal[,] tablaIsr = tabla;

            decimal[] columDatos = new decimal[6];

            // Se recorre la matriz
            int filas = tablaIsr.GetLength(0);
            int columnas = tablaIsr.GetLength(1);
            for (int i = 0; i < filas; i++)
            {
                if (sueldoQuincenal >= tablaIsr[i, 1] && sueldoQuincenal < tablaIsr[i, 2])
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        columDatos[j] = tablaIsr[i, j];
                    }
                }
            }

            // Se separan variables para mas orden
            decimal limInferior = columDatos[1];
            decimal cuotaFija = columDatos[3];
            decimal exedente = columDatos[4];
            decimal subsidio = columDatos[5];

            // Calculamos sueldo quincenal - limite inferior
            decimal sueldoLimt = sueldoQuincenal - limInferior;

            // Multiplicamos el resultado anterior por el exedente
            decimal resulExden = (sueldoLimt * exedente) / 100;

            // El resultado anterior se le suma cuota fija menos el subsidio

            decimal isrCalculo = resulExden + cuotaFija - subsidio;

            return isrCalculo;

        }

        public static void Presentacion()
        {
            // Variables
            string nombreArchivo;
            decimal sueldoMensual;
            decimal[,] tablaIsr;
            decimal isr;

            Console.WriteLine("Ingresa el nombre del archivo que contiene la tabla ISR");
            nombreArchivo = Console.ReadLine();
            Console.WriteLine("Ingresa el sueldo mensual");
            sueldoMensual = decimal.Parse(Console.ReadLine());

            tablaIsr = ISR.CargarTabla(nombreArchivo);

            isr = ISR.Calcular(sueldoMensual, tablaIsr);

            Console.WriteLine(" ");
            Console.WriteLine($"El ISR calculado es de: {isr.ToString("C2")}");
        }
    }
}
