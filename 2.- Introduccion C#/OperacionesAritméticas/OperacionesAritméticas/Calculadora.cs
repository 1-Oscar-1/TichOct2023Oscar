using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesAritméticas
{
    public class Calculadora
    {
        public static decimal Sumar(decimal num1, decimal num2)
        {
            return num1 + num2;
        }
        public static decimal Restar(decimal num1, decimal num2)
        {
            return num1 - num2;
        }
        public static decimal Multiplicar(decimal num1, decimal num2)
        {
            return (num1 * num2);
        }
        public static decimal Dividir(decimal num1, decimal num2)
        {
            return num1 / num2;
        }
        public static decimal Modulo(decimal num1, decimal num2)
        {
            return num1 % num2;
        }
        public static decimal Operación(OperacionAritmetica OperacionEstruc)
        {
            
            if (OperacionEstruc.tipoOperacion == tipoOperacion.sumar)
            {
                return Calculadora.Sumar(OperacionEstruc.num1, OperacionEstruc.num2);
            }
            else if (OperacionEstruc.tipoOperacion == tipoOperacion.restar)
            {
                return Calculadora.Restar(OperacionEstruc.num1, OperacionEstruc.num2);
            }
            else if (OperacionEstruc.tipoOperacion == tipoOperacion.multiplicar)
            {
                return Calculadora.Multiplicar(OperacionEstruc.num1, OperacionEstruc.num2);
            }
            else if (OperacionEstruc.tipoOperacion == tipoOperacion.dividir)
            {
                return Calculadora.Dividir(OperacionEstruc.num1, OperacionEstruc.num2);
            }
            else
            {
                return Calculadora.Modulo(OperacionEstruc.num1, OperacionEstruc.num2);
            }
        }
        public static Resultado Simultaneas(decimal num1, decimal num2)
        {

            Resultado resultado = new Resultado();

            resultado.suma = Calculadora.Sumar(num1, num2);
            resultado.resta = Calculadora.Restar(num1, num2);
            resultado.multiplicacion = Calculadora.Multiplicar(num1, num2);
            resultado.division = Calculadora.Dividir(num1, num2);
            resultado.modulo = Calculadora.Modulo(num1, num2);

            return resultado;
        }
        public static void Presentacion()
        {
            Console.WriteLine("Operación a Realizar, selecciona una");
            Console.WriteLine("0.- Sumar");
            Console.WriteLine("1.- Restar");
            Console.WriteLine("2.- Multiplicar");
            Console.WriteLine("3.- Dividir");
            Console.WriteLine("4.- Todas");

            byte opcion = byte.Parse(Console.ReadLine());

            Console.WriteLine("Proporciona el primer operador");
            decimal num1 = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Proporciona el segundo operador");
            decimal num2 = decimal.Parse(Console.ReadLine());

            tipoOperacion opcionTipo = (tipoOperacion)opcion;

            OperacionAritmetica operacion = new OperacionAritmetica(num1, num2, opcionTipo);

            Console.WriteLine($"El resultado de la operacion {operacion.tipoOperacion} es {Calculadora.Operación(operacion)}");

            if(opcion == 4)
            {
                Console.WriteLine("------ Resultados-----");
                Console.WriteLine($"La Suma es { Simultaneas(num1, num2).suma}");
                Console.WriteLine($"La Resta es {Simultaneas(num1, num2).resta}");
                Console.WriteLine($"La Multiplicacion es {Simultaneas(num1, num2).multiplicacion}");
                Console.WriteLine($"La Division es {Simultaneas(num1, num2).division}");
                Console.WriteLine($"El Modulo es {Simultaneas(num1, num2).modulo}");
            }

            Console.ReadKey();

        }
    }
}
