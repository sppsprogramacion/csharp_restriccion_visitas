using CapaDatos;
using CommonCache;
using Conexion;
using DAO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class ProhibicinVisitaDaoImpl : IProhibicionVisitaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //CREAR PROHIBICION
        public async Task<(DProhibicionVisita, string error)> CrearProhivisionVisita(string prohibicionVisita)
        {
            DProhibicionVisita dataProhibicion = new DProhibicionVisita();

            try
            {
               
                using (HttpClient httpClient = new HttpClient())
                {
                    // Crear el contenido de la solicitud HTTP
                    StringContent content = new StringContent(prohibicionVisita, Encoding.UTF8, "application/json");

                    // Enviar la solicitud HTTP POST
                    HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/prohibiciones-visita", content);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        dataProhibicion = JsonConvert.DeserializeObject<DProhibicionVisita>(contentRespuesta);
                        
                        // Puedes procesar el token o el resultado adicional aquí.
                        // Establecer el usuario actual
                        return (dataProhibicion, null);
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                        return (null, $"Error en la busqueda: {mensaje}");
                    }
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
        //FIN CREAR PROHIBICION..................................
        
        //EDITAR PROHIBICION
        public async Task<(bool, string error)> EditarProhibicionVisita(int id,string prohibicionVisita)
        {
            

            try
            {
                              
                using (HttpClient httpClient = new HttpClient())
                {
                    // Crear el contenido de la solicitud HTTP
                    StringContent content = new StringContent(prohibicionVisita, Encoding.UTF8, "application/json");

                    // Enviar la solicitud HTTP POST
                    HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/prohibiciones-visita/" + id, content);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();                        
                        
                        var dataRespuesta = JsonConvert.DeserializeObject<DResponseEditar>(contentRespuesta);

                        if(dataRespuesta.Affected > 0)
                        {
                            return (true, null);
                        }
                        else
                        {
                            return (false, "No se pudo editar el registro");
                        }
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                        return (false, $"Error en la edición: {mensaje}");
                    }
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (false, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (false, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN EDITAR PROHIBICION......................................

        //BUSCAR PROHIBICION X ID
        public Task<(DProhibicionVisita, string error)> BuscarProhibicionVisitaXId(int idProhibicionvisita)
        {
            throw new NotImplementedException();
        }
        //FIN BUSCAR PROHIBICION X ID..........................................

        //LEVANTAR UNA PROHIBICION
        public async Task<(bool, string error)> LevantarProhibicionVisita(int id, string dataLevantar)
        {
            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataLevantar, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/prohibiciones-visita/levantar-manual?id_prohibicion=" + id, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();

                    var dataRespuesta = JsonConvert.DeserializeObject<DResponseEditar>(contentRespuesta);

                    if (dataRespuesta.Affected > 0)
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, "No se pudo levantar la prohibicion");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en el levantamiento: {mensaje}");
                }


            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (false, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (false, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN LEVANTAR UNA PROHIBICION..............................................

        //PROHIBIR UNA PROHIBICION
        public async Task<(bool, string error)> ProhibirProhibicionVisita(int id, string dataProhibir)
        {
            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataProhibir, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/prohibiciones-visita/prohibir-manual?id_prohibicion=" + id, content);


                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();

                    var dataRespuesta = JsonConvert.DeserializeObject<DResponseEditar>(contentRespuesta);

                    if (dataRespuesta.Affected > 0)
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, "No se pudo volver a prohibir");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en la prohibición: {mensaje}");
                }

            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (false, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (false, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN PROHIBIR UNA PROHIBICION...................................................

        //ANULAR UNA PROHIBICION
        public async Task<(bool, string error)> AnularProhibicionVisita(int id, string dataAnular)
        {
            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataAnular, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/prohibiciones-visita/anular?id_prohibicion=" + id, content);


                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();

                    var dataRespuesta = JsonConvert.DeserializeObject<DResponseEditar>(contentRespuesta);

                    if (dataRespuesta.Affected > 0)
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, "No se pudo anular la prohibicion");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error al anular: {mensaje}");
                }

            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (false, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (false, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN ANULAR UNA PROHIBICION...................................................

        //RETORNAR LISTA DE PROHIBICIONES X CIUDADANO
        async public Task<(List<DProhibicionVisita>, string error)> RetornarProhibicionesVisitaXCiudadano(int idCiudadano)
        {
            List<DProhibicionVisita> listaProhibiciones = new List<DProhibicionVisita>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/prohibiciones-visita/buscar-xciudadano?id_ciudadano=" + idCiudadano);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaProhibiciones = JsonConvert.DeserializeObject<List<DProhibicionVisita>>(content);
                        return (listaProhibiciones, null);
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                        return (null, $"Error en la busqueda: {mensaje}");
                    }
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
        //FIN RETORNAR LISTA DE PROHIBICIONES X CIUDADANO...................................

        
    }
}
