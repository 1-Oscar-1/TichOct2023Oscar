using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEstatusAlumnos
    {
        //private static readonly HttpClient client = new HttpClient();
        //const string urlWebApi = "http://localhost:5118/api/EstatusAlumnos";
        string urlWebApi = ConfigurationManager.AppSettings["urlApi"];
        public List<EstatusAlumnos> Consultar()
        {
            try
            {
                using(HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(urlWebApi).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        List<EstatusAlumnos> listEstatusAlumnos = JsonConvert.DeserializeObject<List<EstatusAlumnos>>(content);
                        return listEstatusAlumnos;
                    }
                    else
                    {
                        return new List<EstatusAlumnos>();
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<EstatusAlumnos>();
                throw new Exception(ex.ToString());
            }
        }
        public EstatusAlumnos Consultar(int id)
        {
            try
            {
                using(HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync($"{urlWebApi}/{id}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        EstatusAlumnos estatusAlumno = JsonConvert.DeserializeObject<EstatusAlumnos>(content);
                        return estatusAlumno;
                    }
                    else
                    {
                        return new EstatusAlumnos();
                    }
                }
            }
            catch (Exception ex)
            {
                return new EstatusAlumnos();
                throw new Exception(ex.ToString());
            }
        }
        public EstatusAlumnos Agregar(EstatusAlumnos estatus)
        {
            EstatusAlumnos estado = new EstatusAlumnos();
            try
            {
                
                //Instancia el objeto HttpClient
                using (var client = new HttpClient())
                {

                    //Creamos un objeto HttpContent instanciando un objeto StringContent, la cual es una clase derivada de HttpContent.
                    //Este contenido se crea con el objeto Estado que se está recibiendo
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(estatus), Encoding.UTF8);

                    //Asignamos a la propiedad ContentType del encabezado de HttpContent
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    //Invoca el método PostAsync del objeto HttpClient, el cual envía una solicitud POST al
                    //URI especificado como parámetro, como una operación asincrónica, asimismo le envía el contenido (objeto estado) dentro del httpContect
                    Task<HttpResponseMessage> postTask = client.PostAsync(urlWebApi, httpContent);

                    // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                    postTask.Wait();

                    //Obtenemos el objeto HttpResponseMessage a través de la propiedad Result del objeto Task<HttpResponseMessage>
                    HttpResponseMessage result = postTask.Result;

                    // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                    // desde la web api, en caso contrario enviamos una excepción
                    if (result.IsSuccessStatusCode)
                    {
                        // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                        // desde la web api, en caso contrario enviamos una excepción
                        var readTask = result.Content.ReadAsStringAsync();
                        // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                        readTask.Wait();
                        //Obtenemos el string en formato json del objeto recibido
                        string json = readTask.Result;
                        //Deserealizamos el objeto recibido, en este caso un estado
                        estado = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else //web api envió error de respuesta
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }
            return estado;
        }
        public void Actualizar(EstatusAlumnos estatus, int id)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(estatus), Encoding.UTF8);

                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    Task<HttpResponseMessage> postTask = client.PutAsync($"{urlWebApi}/{id}", httpContent);

                    postTask.Wait();

                    HttpResponseMessage response = postTask.Result;
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void Eliminar(int id)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    HttpResponseMessage response = client.DeleteAsync($"{urlWebApi}/{id}").Result;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
