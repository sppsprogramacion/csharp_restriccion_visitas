﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;

using CapaDatos;
using Conexion;
using DAO;
using System.Text;
using Newtonsoft.Json.Linq;
using CommonCache;
using System.Net.Http.Headers;

namespace DAOImplement
{
    public class CiudadanoDaoImpl : ICiudadanoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //CREAR CIUDADANO
        public async Task<HttpResponseMessage> CrearCiudadano(string ciudadano)
        {
            
            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(ciudadano, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/ciudadanos", content);

                
                return httpResponse;
                
            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                throw new Exception($"Error al realizar la solicitud: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON
                throw new Exception($"Error al serializar/deserializar JSON: {jsonException.Message}");
            }
            catch (Exception ex)
            {
                // Capturar cualquier otro tipo de excepción
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                throw new Exception($"Ocurrió un error inesperado: {ex.Message}");
            }

        }
        //FIN CREAR CIUDADANO................................................
        
        //BURCAR CIUDADANO X ID
        async public Task<(DCiudadano, string error)> BuscarCiudadanoXId(int id)
        {
            DCiudadano dCiudadano = new DCiudadano();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/ciudadanos/" + id);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    dCiudadano = JsonConvert.DeserializeObject<DCiudadano>(content);
                    return (dCiudadano, null);
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
        //FIN BUSCAR CIUDADANO X ID...........................................
        

        //RETORNAR TODOS LOS CIUDADANOS
        async  public Task<(List<DCiudadano>, string)> RetornarListaCiudadano()
        {
            List<DCiudadano> listaCiudadanos = new List<DCiudadano>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/ciudadanos/todos");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaCiudadanos = JsonConvert.DeserializeObject<List<DCiudadano>>(content);
                        return (listaCiudadanos, null);
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
        //FIN RETORNAR TODOS LOS CIUDADANOS..............................

        
        //RETORNAR CIUDADANOS X APELLIDO
        async public Task<(List<DCiudadano>, string error)> RetornarListaCiudadanoXApellido(string apellido)
        {
            List<DCiudadano> listaCiudadanos = new List<DCiudadano>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/ciudadanos/buscarlista-xapellido?apellido=" + apellido);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaCiudadanos = JsonConvert.DeserializeObject<List<DCiudadano>>(content);
                        return (listaCiudadanos, null);
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
        //FIN RETORNAR CIUDADANOS X APELLIDO..................................................

        //RETORNAR CIUDADANOS X DNI
        public async Task<(List<DCiudadano>, string error)> RetornarListaCiudadanoXDni(int dni)
        {
            List<DCiudadano> listaCiudadanos = new List<DCiudadano>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/ciudadanos/buscarlista-xdni?dni=" + dni);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaCiudadanos = JsonConvert.DeserializeObject<List<DCiudadano>>(content);
                        return (listaCiudadanos, null);
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
        //FIN RETORNAR CIUDADANOS X DNI...................................................
    }
}
