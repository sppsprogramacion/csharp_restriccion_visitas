using CapaDatos;
using DAO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Conexion;
using CommonCache;
using System.Net.Http.Headers;

namespace DAOImplement
{
    public class ExcepcionIngresoVisitaDaoImpl : IExcepcionIngresoVisitaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();


        //CREAR
        public async Task<(DExcepcionIngresoVisita, string error)> CrearExcepcionIngresoVisita(string excepcionIngresoVisita)
        {
            DExcepcionIngresoVisita dataExcepcion = new DExcepcionIngresoVisita();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(excepcionIngresoVisita, Encoding.UTF8, "application/json");

                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/prohibiciones-visita", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataExcepcion = JsonConvert.DeserializeObject<DExcepcionIngresoVisita>(contentRespuesta);

                    // Puedes procesar el token o el resultado adicional aquí.
                    // Establecer el usuario actual
                    return (dataExcepcion, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error al crear: {mensaje}");
                }

            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (null, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (null, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN CREAR...........................................................

        //BUSCAR XID
        public Task<(DExcepcionIngresoVisita, string error)> BuscarExcepcionIngresoVisitaXId(int idExcepcionIngresoVisita)
        {
            throw new NotImplementedException();
        }
        //FIN BUSCAR XID...........................................................

        //LISTA DE EXCEPCIONES POR CIUDADANO
        public async Task<(List<DExcepcionIngresoVisita>, string error)> RetornarExcepcionesIngresoXCiudadano(int idCiudadano)
        {
            List<DExcepcionIngresoVisita> listaExcepcionesIngreso = new List<DExcepcionIngresoVisita>();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/excepciones-ingreso-visita/lista-xciudadano?id_ciudadano=" + idCiudadano);

                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaExcepcionesIngreso = JsonConvert.DeserializeObject<List<DExcepcionIngresoVisita>>(content);
                    return (listaExcepcionesIngreso, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error en la busqueda: {mensaje}");
                }

            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (null, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (null, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }

        }
        //FIN LISTA DE EXCEPCIONES POR CIUDADANO...................................................
    }
}
