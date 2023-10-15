using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LINKQ
{
    public class OperacionesLINQ
    {
        public List<Alumno> _listAlumnos = new List<Alumno>();
        public List<Estado> _listEstados = new List<Estado>();
        public List<Estatus> _listEstatus = new List<Estatus>();
        public List<ItemISR> _listItemISR = new List<ItemISR>();
        public void CargarLists()
        {
            // Se lee el archivo JSON
            StreamReader archivoAlumnos = new StreamReader(@"C:\Users\Tichs\Desktop\Practicas\Alumnos.json");
            StreamReader archivoEstado = new StreamReader(@"C:\Users\Tichs\Desktop\Practicas\Estados.json");
            StreamReader archivoEstatus = new StreamReader(@"C:\Users\Tichs\Desktop\Practicas\Estatus.json");
            // Se lee el archivo csv
            StreamReader archivoIsr = new StreamReader(@"C:\Users\Tichs\Desktop\isr.csv");

            // Se cargan las listas
            _listAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(archivoAlumnos.ReadLine());
            _listEstados = JsonConvert.DeserializeObject<List<Estado>>(archivoEstado.ReadLine());
            _listEstatus = JsonConvert.DeserializeObject<List<Estatus>>(archivoEstatus.ReadLine());

            int contador = 0;
            string linea;
            while ((linea = archivoIsr.ReadLine()) != null)
            {
                string[] datosRegistro = linea.Split(',');

                ItemISR item = new ItemISR();

                item.limInf = decimal.Parse(datosRegistro[1]);
                item.limSup = decimal.Parse(datosRegistro[2]);
                item.cuotaFija = decimal.Parse(datosRegistro[3]);
                item.porExced = decimal.Parse(datosRegistro[4]);
                item.subsidio = decimal.Parse(datosRegistro[5]);

                _listItemISR.Add(item);
            }
        }

        public static void Consultas()
        {
            // Se instancia la clase
            OperacionesLINQ clasOperaciones = new OperacionesLINQ();

            // Cargamos los archivos
            clasOperaciones.CargarLists();

            Estado edo = clasOperaciones._listEstados.First(e => e.id == 5);
            Console.WriteLine($"El estado con el id 5 es {edo.nombre}");

            Console.WriteLine("");

            var alumnos =
                from alumno in clasOperaciones._listAlumnos
                where alumno.idEstado == 29 || alumno.idEstado == 13
                orderby alumno.nombre
                select alumno;

            foreach (var alumno in alumnos)
            {
                Console.WriteLine($"id = {alumno.idEstado}, nombre = {alumno.nombre}");
            }

            Console.WriteLine("");

            var alumnos2 =
                from alumno in clasOperaciones._listAlumnos
                where alumno.idEstado == 19 || alumno.idEstado == 20 && alumno.idEstatus == 4 || alumno.idEstatus == 5
                orderby alumno.nombre
                select alumno;

            foreach (var alumno in alumnos2)
            {
                Console.WriteLine($"id = {alumno.idEstado}, nombre = {alumno.nombre}, idEstatus = {alumno.idEstatus}");
            }

            Console.WriteLine("");

            foreach (var calificacion in clasOperaciones._listAlumnos)
            {
                Console.WriteLine(calificacion.calificacion);
            }

            bool todosEnRango67 = clasOperaciones._listAlumnos.All(alumno => alumno.calificacion >= 6 && alumno.calificacion <= 7);

            if (!todosEnRango67)
            {
                // Si no todos los alumnos están en el rango 6-7, sumar 1 punto a la calificación de todos
                foreach (var alumno in clasOperaciones._listAlumnos)
                {
                    alumno.calificacion += 1;
                }
            }
            else
            {
                bool contieneCalificacion10 = alumnos.Any(alumno => alumno.calificacion == 10);
                if (contieneCalificacion10 == false)
                {
                    foreach (var alumno in clasOperaciones._listAlumnos)
                    {
                        alumno.calificacion += 1;
                    }
                }

            }
            Console.WriteLine("----------------");
            foreach (var calificacion in clasOperaciones._listAlumnos)
            {
                Console.WriteLine(calificacion.calificacion);
            }

            Console.WriteLine("");

            var alumnos3 =
                from alumno in clasOperaciones._listAlumnos
                where alumno.calificacion >= 6
                orderby alumno.calificacion descending
                select alumno;

            foreach (var alumno in alumnos3)
            {
                Console.WriteLine($"calificacion = {alumno.calificacion}, nombre = {alumno.nombre}");
            }

            Console.WriteLine("");

            var calificaciones =
                from alumno in clasOperaciones._listAlumnos
                select alumno.calificacion;
            decimal promedio = 0;

            foreach (var calificacion in calificaciones)
            {
                promedio = promedio + calificacion;
            }

            promedio = promedio / calificaciones.Count();
            Console.WriteLine($"El promedio de calificaciones es: {promedio}");

            Console.WriteLine("");

            var alumnos4 =
                from alumno in clasOperaciones._listAlumnos
                join estado in clasOperaciones._listEstados on alumno.idEstado equals estado.id
                where alumno.idEstatus == 3
                select new {idAlumno = alumno.id, nombreAlumno = alumno.nombre, nombreEstado = estado.nombre};

            foreach (var alumno in alumnos4)
            {
                Console.WriteLine($"id = {alumno.idAlumno}, nombre = {alumno.nombreAlumno}, estado = {alumno.nombreEstado}");
            }

            Console.WriteLine("");

            var alumnos5 =
                from alumno in clasOperaciones._listAlumnos
                join estatus in clasOperaciones._listEstatus on alumno.idEstatus equals estatus.id
                where alumno.idEstatus == 5
                select new {idAlumno = alumno.id, nombreAlumno = alumno.nombre, nombreEstatus = estatus.nombre};

            foreach (var alumno in alumnos5)
            {
                Console.WriteLine($"id = {alumno.idAlumno}, nombre = {alumno.nombreAlumno}, estatus = {alumno.nombreEstatus}");
            }

            Console.WriteLine("");

            var alumnos6 =
                from alumno in clasOperaciones._listAlumnos
                join estado in clasOperaciones._listEstados on alumno.idEstado equals estado.id
                join estatus in clasOperaciones._listEstatus on alumno.idEstatus equals estatus.id
                where alumno.idEstatus > 2
                orderby alumno.nombre
                select new {idAlumno = alumno.id, nombreAlumno = alumno.nombre, nombreEstado = estado.nombre, nombreEstatus = estatus.nombre};

            foreach (var alumno in alumnos6)
            {
                Console.WriteLine($"{alumno.idAlumno} | {alumno.nombreAlumno} | {alumno.nombreEstado} | {alumno.nombreEstatus}");
            }

            Console.WriteLine("");

            ItemISR isrObj = clasOperaciones._listItemISR.First(e => 22000 >= e.limInf && 22000 < e.limSup);

            // Calculamos sueldo quincenal - limite inferior
            decimal sueldoLimt = (22000 / 2) - isrObj.limInf;

            // Multiplicamos el resultado anterior por el exedente
            decimal resulExden = (sueldoLimt * isrObj.porExced) / 100;

            // El resultado anterior se le suma cuota fija menos el subsidio

            decimal isrCalculo = resulExden + isrObj.cuotaFija - isrObj.subsidio;

            Console.WriteLine($"El isr es de: {isrCalculo.ToString("C2")}");

            Console.ReadKey();

        }
    }
}
